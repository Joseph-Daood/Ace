using Ace.Api.DataBase;
using Ace.Api.DataBase.Repositories.Interfaces;
using Ace.Api.Entities;
using Ace.Api.Models;
using Ace.Api.Services;
using Ace.Shared.Helpers;
using Ace.Shared.ResourceParameters;
using Ace.Shared.Rest;
using AutoMapper;
using Isg.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json;


namespace Ace.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamiliesController : ControllerBase
    {
        private readonly IFamilyRepository _familyRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPropertyMappingService _propertyMappingService;


        public FamiliesController(IFamilyRepository familyRepository, IMapper mapper, IUnitOfWork unitOfWork, IPropertyMappingService propertyMappingService = null)
        {
            _familyRepository = familyRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _propertyMappingService = propertyMappingService;
        }


        [HttpGet(Name = "GetFamilies")]
        public async Task<IActionResult> GetAll([FromQuery] ResourceParameters resourceParameters)
        {
            // get property mapping dictionary
            var familyPropertyMappingDictionary = _propertyMappingService
                .GetPropertyMapping<FamilyReadDto, Family>();
            var families = await _familyRepository.GetAllAsync(resourceParameters, familyPropertyMappingDictionary);
            if (families.IsNullOrEmpty())
            {
                return NotFound();
            }

            //CreateResourceUri
            var previousPageLink = families.HasPrevious
            ? ResourceUri.CreateResourceUri(Url,
                resourceParameters,
                ResourceUriType.PreviousPage, "GetFamilies") : null;

            var nextPageLink = families.HasNext
                ? ResourceUri.CreateResourceUri(Url,
                    resourceParameters,
                    ResourceUriType.NextPage, "GetFamilies") : null;



            var paginationMetadata = new
            {
                totalCount = families.TotalCount,
                pageSize = families.PageSize,
                currentPage = families.CurrentPage,
                totalPages = families.TotalPages,
                previousPageLink = previousPageLink,
                nextPageLink = nextPageLink
            };

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

            return Ok(families);
        }

        [HttpGet("{familyId}", Name = "GetFamily")]
        public async Task<IActionResult> Get(int familyId)
        {
            var family = await _familyRepository.GetByIdAsync(familyId);
            if (family == null)
            {
                return NotFound();
            }
            return Ok(family);
        }


        [HttpPost(Name = "CreateNewFamily")]
        public async Task<ActionResult> AddFamily([FromBody] FamilyCreateDto familyCreateDto)
        {
            var family = _mapper.Map<Family>(familyCreateDto);

            await _familyRepository.InsertAsync(family);
            await _unitOfWork.CommitAsync();

            return CreatedAtRoute("GetFamily", new { familyId = family.FamilyId }, family);

            //var familyToReturn = _mapper.Map<FamilyReadDto>(family);
            //// create links
            //var links = CreateLinks(familyToReturn.FamilyId, null);

            //// add
            //var linkedResourceToReturn = familyToReturn.ShapeData(null) as IDictionary<string, object?>;
            //linkedResourceToReturn.Add("links", links);

            //return CreatedAtRoute("GetFamily", new { familyId = linkedResourceToReturn["FamilyId"] }, linkedResourceToReturn);
        }

        [HttpPut()]
        public async Task<ActionResult> UpdateFamily([FromBody] FamilyReadDto value)
        {
            var family = _mapper.Map<Family>(value);
            if (family.FamilyId == 0)
            {
                return BadRequest();
            }

            var familyExists = await _familyRepository.ExistsAsync(f => f.FamilyId == family.FamilyId);
            if (!familyExists)
            {
                return NotFound($"Family with FamilyId:{family.FamilyId} not found!");
            }

            _familyRepository.Update(family);
            await _unitOfWork.CommitAsync();

            return CreatedAtRoute("GetFamily", new { familyId = family.FamilyId }, family);
            //var familyToReturn = _mapper.Map<FamilyReadDto>(family);
            //// create links
            //var links = CreateLinks(familyToReturn.FamilyId, null);
            //// add
            //var linkedResourceToReturn = familyToReturn.ShapeData(null) as IDictionary<string, object?>;
            //linkedResourceToReturn.Add("links", links);
            //return CreatedAtRoute("GetFamily", new { familyId = linkedResourceToReturn["FamilyId"] }, linkedResourceToReturn);
        }

        [HttpDelete("{familyId}")]
        public async Task<ActionResult> DeleteAsync(int familyId)
        {
            if (familyId == 0)
            {
                return BadRequest();
            }

            var familyExists = await _familyRepository.ExistsAsync(f => f.FamilyId == familyId);
            if (!familyExists)
            {
                return NotFound($"Family with FamilyId:{familyId} not found!");
            }

            _familyRepository.Delete(familyId);

            return NoContent();

        }

        //private IEnumerable<LinkDto> CreateLinks(int objectId,
        //string? fields)
        //{
        //    var links = new List<LinkDto>();

        //    if (string.IsNullOrWhiteSpace(fields))
        //    {
        //        links.Add(
        //          new(Url.Link("GetFamily", new { objectId }),
        //          "self",
        //          "GET"));
        //    }
        //    else
        //    {
        //        links.Add(
        //          new(Url.Link("GetFamily", new { objectId, fields }),
        //          "self",
        //          "GET"));
        //    }

        //    return links;
        //}
    }
}
