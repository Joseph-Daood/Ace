using Microsoft.AspNetCore.Mvc;

namespace Ace.Shared.Helpers
{
    public static class ResourceUri
    {
        public static string? CreateResourceUri(IUrlHelper url,
       ResourceParameters.ResourceParameters resourceParameters,
       ResourceUriType type, string targethttpRequestName)
        {
            switch (type)
            {
                case ResourceUriType.PreviousPage:
                    return url.Link(targethttpRequestName,
                        new
                        {
                            pageNumber = resourceParameters.PageNumber - 1,
                            pageSize = resourceParameters.PageSize,
                            mainCategory = resourceParameters.MainCategory,
                            searchQuery = resourceParameters.SearchQuery
                        });
                case ResourceUriType.NextPage:
                    return url.Link(targethttpRequestName,
                        new
                        {
                            pageNumber = resourceParameters.PageNumber + 1,
                            pageSize = resourceParameters.PageSize,
                            mainCategory = resourceParameters.MainCategory,
                            searchQuery = resourceParameters.SearchQuery
                        });
                default:
                    return url.Link(targethttpRequestName,
                        new
                        {
                            pageNumber = resourceParameters.PageNumber,
                            pageSize = resourceParameters.PageSize,
                            mainCategory = resourceParameters.MainCategory,
                            searchQuery = resourceParameters.SearchQuery
                        });
            }
        }
    }
}
