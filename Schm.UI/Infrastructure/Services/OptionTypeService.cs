using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using Schm.Core.DTO.Request.Option;
using Schm.Core.DTO.SearchContext;
using Schm.Domain.Model;
using Schm.UI.Infrastructure.Common;
using Schm.UI.Infrastructure.Contracts;

namespace Schm.UI.Infrastructure.Services
{
    public class OptionTypeService: IOptionTypeService
    {
        public IOptions<Config.Config> Options { get; }

        public OptionTypeService(IOptions<Config.Config> options)
        {
            Options = options;
        }

        public async Task<ResponseBody<List<OptionType>>> GetList()
        {
            var result = SendRequest<ResponseBody<List<OptionType>>>.Send(Options.Value.ApiSchmUrl + "/api/Option/List", Method.GET, "", false);
            return new ResponseBody<List<OptionType>>()
            {
                TotalCount = result.Result.TotalCount,
                Result = result.Result.Result,
                ErrorList = result.Result.ErrorList,
                IsSuccess = result.Result.IsSuccess
            };
        }

        public async Task<ResponseBody<List<OptionType>>> Search(SearchOptionTypeCntxDto SearchCntx)
        {
            var result = SendRequest<ResponseBody<List<OptionType>>>.Send(Options.Value.ApiSchmUrl + "/api/Option/Search", Method.POST, JsonConvert.SerializeObject(SearchCntx));
            return new ResponseBody<List<OptionType>>()
            {
                TotalCount = result.Result.TotalCount,
                Result = result.Result.Result,
                ErrorList = result.Result.ErrorList,
                IsSuccess = result.Result.IsSuccess
            };
        }

        public async Task<ResponseBody<OptionType>> Get(int id)
        {
            var result = SendRequest<ResponseBody<OptionType>>.Send(Options.Value.ApiSchmUrl + "/api/Option/" + id, Method.GET, "", false);
            return result.Result;
        }

        public async Task<ResponseBody<OptionType>> Insert(InsertOptionTypeDto option)
        {
            var result = SendRequest<ResponseBody<OptionType>>.Send(Options.Value.ApiSchmUrl + "/api/Option/Insert", Method.POST, JsonConvert.SerializeObject(option));
            return result.Result;
        }

        public async Task<ResponseBody<bool>> Update(UpdateOptionItemTypeDto option)
        {
            var result = SendRequest<ResponseBody<bool>>.Send(Options.Value.ApiSchmUrl + "/api/Option/Update", Method.POST, JsonConvert.SerializeObject(option));
            return result.Result;
        }

        public async Task<ResponseBody<bool>> Delete(int id)
        {
            var result = SendRequest<ResponseBody<bool>>.Send(Options.Value.ApiSchmUrl + "/api/Option/" + id, Method.POST, "", false);
            return result.Result;
        }
    }
}
