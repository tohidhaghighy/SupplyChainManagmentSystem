using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using Schm.Core.DTO.Request.ItemImage;
using Schm.Domain.Model;
using Schm.UI.Infrastructure.Common;
using Schm.UI.Infrastructure.Contracts;

namespace Schm.UI.Infrastructure.Services
{
    public class ItemImageService: IItemImageService
    {
        public IOptions<Config.Config> Options { get; }

        public ItemImageService(IOptions<Config.Config> options)
        {
            Options = options;
        }

        public async Task<ResponseBody<List<ItemImage>>> GetList(int itemId)
        {
            var result = SendRequest<ResponseBody<List<ItemImage>>>.Send(Options.Value.ApiSchmUrl + "/api/ItemImage/List?itemId="+itemId , Method.GET, "", false);
            foreach (var item in result.Result.Result)
            {
                item.ImageUrl = Options.Value.ApiSchmUrl + item.ImageUrl;
            }
            return new ResponseBody<List<ItemImage>>()
            {
                TotalCount = result.Result.TotalCount,
                Result = result.Result.Result,
                ErrorList = result.Result.ErrorList,
                IsSuccess = result.Result.IsSuccess
            };
        }

        public async Task<ResponseBody<ItemImage>> Get(int id)
        {
            var result = SendRequest<ResponseBody<ItemImage>>.Send(Options.Value.ApiSchmUrl + "/api/ItemImage/" + id, Method.GET, "", false);
            if (result != null)
            {
                result.Result.Result.ImageUrl = Options.Value.ApiSchmUrl + result.Result.Result.ImageUrl;
            }
            return result.Result;
        }

        public async Task<ResponseBody<ItemImage>> Insert(InsertItemImageDto itemImage, IFormFile image)
        {
            var client = new RestClient(Options.Value.ApiSchmUrl + "/api/ItemImage/Insert");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("ItemId", itemImage.ItemId);
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
            return JsonConvert.DeserializeObject<ResponseBody<ItemImage>>(response.Content);
        }

        public async Task<ResponseBody<bool>> Delete(int id)
        {
            var result = SendRequest<ResponseBody<bool>>.Send(Options.Value.ApiSchmUrl + "/api/ItemImage/" + id, Method.POST, "", false);
            return result.Result;
        }

    }
}
