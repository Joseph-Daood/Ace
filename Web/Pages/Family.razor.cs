using Microsoft.AspNetCore.Components;
using Web.Services;
using Telerik.DataSource.Extensions;
using Telerik.Blazor.Components;
using Telerik.SvgIcons;
using System.Data;
using Telerik.DataSource.Extensions;
using Telerik.DataSource;
using System.ComponentModel.DataAnnotations;
using Ace.Models;

namespace Web.Pages
{

    public partial class Family
    {
        [Inject]
        public IFamilyDataService FamilyDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public IEnumerable<FamilyReadDto> FamilyList { get; set; }

        public DataTable DataTable { get; set; }



        protected override async Task OnInitializedAsync()
        {
            FamilyList = await FamilyDataService.GetFamiliesAsync();
            DataTable = GetData();
        }

        protected async Task AddNewFamilyAsync()
        {
            NavigationManager.NavigateTo("/FamilyEdit");

        }

        public DataTable GetData()
        {
            DataTable table = new DataTable();

            table.Columns.Add("FamilyId", typeof(int));
            table.Columns.Add("Identity", typeof(string));
            table.Columns.Add("Name", typeof(string));

            foreach(var family in FamilyList)
            {
                table.Rows.Add(family.FamilyId, family.Identity,family.Name);
            }

            return table;
        }


        protected void ReadItems(GridReadEventArgs args)
        {
            // this provides sorting, filtering, paging - the advanced data source operations
            var datasourceResult = DataTable.ToDataSourceResult(args.Request);

            // this is how you can shape the data from the DataTable so it is usable by the grid
            // and so that there are no invalid DBNull values which can break it
            args.Data = (datasourceResult.Data as IEnumerable<Dictionary<string, object>>)
                .Select(x => x.ToDictionary(
                    x => x.Key,
                    x =>
                    {
                        // This is mandatory if you are having some data with empty values (nulls)
                        // DBNull is not parsable to other primitive types and we should convert it manually
                        if (x.Value == DBNull.Value)
                        {
                            return null;
                        }

                        return x.Value;
                    }))
                .ToList();

            args.Total = datasourceResult.Total;

        }

        public async Task UpdateHandler(GridCommandEventArgs args)
        {
            //var product = (ProductDto)args.Item;
            //product.CategoryName = Categories.FirstOrDefault(c => c.CategoryId == product.CategoryId)?.CategoryName;
            ////ProductService.UpdateProduct(product);
            //Products.Add(product);
            //LoadData();
        }

        public async Task DeleteHandler(GridCommandEventArgs args)
        {
            //Products.Remove((ProductDto)args.Item);
            //LoadData();
        }

        //public async Task CreateHandler(GridCommandEventArgs args)
        //{
        //    try
        //    {
        //        var family = (FamilyCreateDto)args.Item;
        //        await FamilyDataService.AddFamilyAsync(family);
        //    }
        //    catch (Exception ex) 
        //    {
        //        var message = ex.Message;
        //        var bla = "";
        //    }
        //}
        public async Task CreateHandler(GridCommandEventArgs args)
        {
            try
            {
                var itemDictionary = (Dictionary<string, object>)args.Item;

                var family = new FamilyCreateDto
                {
                    Name = itemDictionary["Name"].ToString(),
                    Identity = itemDictionary["Identity"].ToString(),
                    // Set other properties accordingly
                };

                await FamilyDataService.AddFamilyAsync(family);
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                // Handle the exception as needed
            }
        }

        public List<int?> GetFilterValues(CompositeFilterDescriptor filterDescriptor)
        {
            return filterDescriptor.FilterDescriptors.Select(f => (int?)(f as FilterDescriptor).Value).ToList();
        }

        //public void ColumnValueChanged(bool value, int categoryId, CompositeFilterDescriptor filterDescriptor)
        //{
        //    var filter = filterDescriptor.FilterDescriptors.FirstOrDefault(f => categoryId.Equals((f as FilterDescriptor).Value));

        //    filterDescriptor.LogicalOperator = FilterCompositionLogicalOperator.Or;

        //    if (value && filter == null)
        //    {
        //        filterDescriptor.FilterDescriptors.Add(new FilterDescriptor(nameof(ProductDto.CategoryId), FilterOperator.IsEqualTo, categoryId));
        //    }
        //    else if (!value && filter != null)
        //    {
        //        filterDescriptor.FilterDescriptors.Remove(filter);
        //    }
        //}
    }

}
