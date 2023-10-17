using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using Schm.Core.DTO.Request;
using Schm.Core.DTO.Request.Category;
using Schm.Core.DTO.Request.SubCategory;
using Schm.Core.SearchContext;
using Schm.Domain.Model;
using Schm.UI.Infrastructure.Common;
using Schm.UI.Infrastructure.Contracts;

namespace Schm.UI.Infrastructure.Services
{
    public class ItemCategoryService : IItemCategoryService
    {
        public IOptions<Config.Config> Options { get; }

        public ItemCategoryService(IOptions<Config.Config> options)
        {
            Options = options;
        }

        public async Task<ResponseBody<List<ItemCatagory>>> GetList()
        {
            var result = SendRequest<ResponseBody<List<ItemCatagory>>>.Send(Options.Value.ApiSchmUrl + "/api/Category/List", Method.GET, "", false);
            return new ResponseBody<List<ItemCatagory>>()
            {
                TotalCount = result.Result.TotalCount,
                Result = result.Result.Result,
                ErrorList = result.Result.ErrorList,
                IsSuccess = result.Result.IsSuccess
            };
        }

        public async Task<ResponseBody<List<ItemCatagory>>> Search(SearchItemCategoryCntx SearchCntx)
        {
            var result = SendRequest<ResponseBody<List<ItemCatagory>>>.Send(Options.Value.ApiSchmUrl + "/api/Category/Search", Method.POST, JsonConvert.SerializeObject(SearchCntx));
            return new ResponseBody<List<ItemCatagory>>()
            {
                TotalCount = result.Result.TotalCount,
                Result = result.Result.Result,
                ErrorList = result.Result.ErrorList,
                IsSuccess = result.Result.IsSuccess
            };
        }

        public async Task<ResponseBody<ItemCatagory>> Get(int id)
        {
            var result = SendRequest<ResponseBody<ItemCatagory>>.Send(Options.Value.ApiSchmUrl + "/api/Category/" + id, Method.GET, "", false);
            if (result != null)
            {
                result.Result.Result.ImageUrl = Options.Value.ApiSchmUrl + result.Result.Result.ImageUrl;
            }
            return result.Result;
        }

        public async Task<ResponseBody<ItemCatagory>> Insert(InsertCategoryDto category, IFormFile image)
        {
            var client = new RestClient(Options.Value.ApiSchmUrl + "/api/Category/Insert");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("Title", category.Title);
            byte[] imageBytes = null;
            if (image != null)
            {
                using (var ms = new MemoryStream())
                {
                    image.CopyTo(ms);
                    imageBytes = ms.ToArray();
                }
                request.AddFile("Image", imageBytes, image.FileName, image.ContentType);
                request.AddHeader("Content-Type", "multipart/form-data");
            }

            IRestResponse response = client.Execute(request);
            return JsonConvert.DeserializeObject<ResponseBody<ItemCatagory>>(response.Content);
        }

        public async Task<ResponseBody<bool>> Update(UpdateCategoryDto category, IFormFile image)
        {
            var client = new RestClient(Options.Value.ApiSchmUrl + "/api/Category/Update");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddParameter("Id", category.Id);
            request.AddParameter("Title", category.Title);
            byte[] imageBytes = new byte[1];
            if (image != null)
            {
                using (var ms = new MemoryStream())
                {
                    image.CopyTo(ms);
                    imageBytes = ms.ToArray();
                }
                request.AddFile("Image", imageBytes, image.FileName, image.ContentType);
            }
            else
            {
                request.AddFile("Image", imageBytes, "", "jpg");
            }
            request.AddHeader("Content-Type", "multipart/form-data");
            IRestResponse response = client.Execute(request);
            return JsonConvert.DeserializeObject<ResponseBody<bool>>(response.Content);
        }

        public async Task<ResponseBody<bool>> Delete(int id)
        {
            var result = SendRequest<ResponseBody<bool>>.Send(Options.Value.ApiSchmUrl + "/api/Category/" + id, Method.POST, "", false);
            return result.Result;
        }

    }
}
