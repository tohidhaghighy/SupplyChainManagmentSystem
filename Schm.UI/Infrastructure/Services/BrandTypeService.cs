using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using Schm.Core.DTO.Request;
using Schm.Core.SearchContext;
using Schm.Domain.Model;
using Schm.UI.Infrastructure.Common;
using Schm.UI.Infrastructure.Contracts;

namespace Schm.UI.Infrastructure.Services
{
    public class BrandTypeService: IBrandTypeService
    {
        public IOptions<Config.Config> Options { get; }

        public BrandTypeService(IOptions<Config.Config> options)
        {
            Options = options;
        }

        public async Task<ResponseBody<List<BrandType>>> GetList()
        {
            var result = SendRequest<ResponseBody<List<BrandType>>>.Send(Options.Value.ApiSchmUrl + "/api/Brand/List", Method.GET ,"" ,false);
            return new ResponseBody<List<BrandType>>()
            {
                TotalCount = result.Result.TotalCount,
                Result = result.Result.Result,
                ErrorList = result.Result.ErrorList,
                IsSuccess = result.Result.IsSuccess
            };
        }

        public async Task<ResponseBody<List<BrandType>>> Search(SearchBrandCntx SearchCntx)
        {
            var result = SendRequest<ResponseBody<List<BrandType>>>.Send(Options.Value.ApiSchmUrl + "/api/Brand/Search", Method.POST, JsonConvert.SerializeObject(SearchCntx));
            return new ResponseBody<List<BrandType>>()
            {
                TotalCount = result.Result.TotalCount,
                Result = result.Result.Result,
                ErrorList = result.Result.ErrorList,
                IsSuccess = result.Result.IsSuccess
            };
        }

        public async Task<ResponseBody<BrandType>> Get(int id)
        {
            var result = SendRequest<ResponseBody<BrandType>>.Send(Options.Value.ApiSchmUrl + "/api/Brand/"+id, Method.GET, "", false);
            if (result!=null)
            {
                result.Result.Result.ImageUrl = Options.Value.ApiSchmUrl + result.Result.Result.ImageUrl;
            }
            return result.Result;
        }

        public async Task<ResponseBody<BrandType>> Insert(InsertBrandTypeDto brand,IFormFile image)
        {
            var client = new RestClient(Options.Value.ApiSchmUrl + "/api/Brand/Insert");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("Title", brand.Title);
            request.AddParameter("Description", brand.Description);
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
            return JsonConvert.DeserializeObject<ResponseBody<BrandType>>(response.Content);
        }

        public async Task<ResponseBody<bool>> Update(UpdateBrandTypeDto brand,IFormFile image)
        {
            var client = new RestClient(Options.Value.ApiSchmUrl + "/api/Brand/Update");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddParameter("Id", brand.Id);
            request.AddParameter("Title", brand.Title);
            request.AddParameter("Description", brand.Description);
            request.AddParameter("IsActive", brand.IsActive);
            byte[] imageBytes=new byte[1];
            if (image!=null)
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
                request.AddFile("Image", imageBytes, "" , "jpg");
            }
            request.AddHeader("Content-Type", "multipart/form-data");
            IRestResponse response = client.Execute(request);
            return JsonConvert.DeserializeObject<ResponseBody<bool>>(response.Content);
        }

        public async Task<ResponseBody<bool>> Delete(int id)
        {
            var result = SendRequest<ResponseBody<bool>>.Send(Options.Value.ApiSchmUrl + "/api/Brand/" + id, Method.POST, "", false);
            return result.Result;
        }
    }
}
