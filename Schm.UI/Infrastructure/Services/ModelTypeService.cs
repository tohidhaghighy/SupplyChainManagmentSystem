using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using Schm.Core.DTO.Request.Model;
using Schm.Core.DTO.SearchContext;
using Schm.Domain.Model;
using Schm.UI.Infrastructure.Common;
using Schm.UI.Infrastructure.Contracts;

namespace Schm.UI.Infrastructure.Services
{
    public class ModelTypeService: IModelTypeService
    {
        public IOptions<Config.Config> Options { get; }

        public ModelTypeService(IOptions<Config.Config> options)
        {
            Options = options;
        }

        public async Task<ResponseBody<List<ModelType>>> GetList()
        {
            var result = SendRequest<ResponseBody<List<ModelType>>>.Send(Options.Value.ApiSchmUrl + "/api/Model/List", Method.GET, "", false);
            return new ResponseBody<List<ModelType>>()
            {
                TotalCount = result.Result.TotalCount,
                Result = result.Result.Result,
                ErrorList = result.Result.ErrorList,
                IsSuccess = result.Result.IsSuccess
            };
        }

        public async Task<ResponseBody<List<ModelType>>> Search(SearchModelTypeCntxDto SearchCntx)
        {
            var result = SendRequest<ResponseBody<List<ModelType>>>.Send(Options.Value.ApiSchmUrl + "/api/Model/Search", Method.POST, JsonConvert.SerializeObject(SearchCntx));
            return new ResponseBody<List<ModelType>>()
            {
                TotalCount = result.Result.TotalCount,
                Result = result.Result.Result,
                ErrorList = result.Result.ErrorList,
                IsSuccess = result.Result.IsSuccess
            };
        }

        public async Task<ResponseBody<ModelType>> Get(int id)
        {
            var result = SendRequest<ResponseBody<ModelType>>.Send(Options.Value.ApiSchmUrl + "/api/Model/" + id, Method.GET, "", false);
            return result.Result;
        }

        public async Task<ResponseBody<ModelType>> Insert(InsertModelTypeDto category)
        {
            var result = SendRequest<ResponseBody<ModelType>>.Send(Options.Value.ApiSchmUrl + "/api/Model/Insert", Method.POST, JsonConvert.SerializeObject(category));
            return result.Result;
        }

        public async Task<ResponseBody<bool>> Update(UpdateModelTypeDto category)
        {
            var result = SendRequest<ResponseBody<bool>>.Send(Options.Value.ApiSchmUrl + "/api/Model/Update", Method.POST, JsonConvert.SerializeObject(category));
            return result.Result;
        }

        public async Task<ResponseBody<bool>> Delete(int id)
        {
            var result = SendRequest<ResponseBody<bool>>.Send(Options.Value.ApiSchmUrl + "/api/Model/" + id, Method.POST, "", false);
            return result.Result;
        }

    }
}
