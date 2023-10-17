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
    public class OptionGroupTypeService : IOptionGroupTypeService
    {
        public IOptions<Config.Config> Options { get; }

        public OptionGroupTypeService(IOptions<Config.Config> options)
        {
            Options = options;
        }

        public async Task<ResponseBody<bool>> Delete(int id)
        {
            var result = SendRequest<ResponseBody<bool>>.Send(Options.Value.ApiSchmUrl + "/api/OptionGroup/" + id, Method.POST, "", false);
            return result.Result;
        }

        public async Task<ResponseBody<OptionGroupType>> Get(int id)
        {
            var result = SendRequest<ResponseBody<OptionGroupType>>.Send(Options.Value.ApiSchmUrl + "/api/OptionGroup/" + id, Method.GET, "", false);
            return result.Result;
        }

        public async Task<ResponseBody<List<OptionGroupType>>> GetList()
        {
            var result = SendRequest<ResponseBody<List<OptionGroupType>>>.Send(Options.Value.ApiSchmUrl + "/api/OptionGroup/List", Method.GET, "", false);
            return new ResponseBody<List<OptionGroupType>>()
            {
                TotalCount = result.Result.TotalCount,
                Result = result.Result.Result,
                ErrorList = result.Result.ErrorList,
                IsSuccess = result.Result.IsSuccess
            };
        }

        public async Task<ResponseBody<OptionGroupType>> Insert(InsertOptionTypeDto option)
        {
            var result = SendRequest<ResponseBody<OptionGroupType>>.Send(Options.Value.ApiSchmUrl + "/api/OptionGroup/Insert", Method.POST, JsonConvert.SerializeObject(option));
            return result.Result;
        }

        public async Task<ResponseBody<List<OptionGroupType>>> Search(SearchOptionTypeCntxDto SearchCntx)
        {
            var result = SendRequest<ResponseBody<List<OptionGroupType>>>.Send(Options.Value.ApiSchmUrl + "/api/OptionGroup/Search", Method.POST, JsonConvert.SerializeObject(SearchCntx));
            return new ResponseBody<List<OptionGroupType>>()
            {
                TotalCount = result.Result.TotalCount,
                Result = result.Result.Result,
                ErrorList = result.Result.ErrorList,
                IsSuccess = result.Result.IsSuccess
            };
        }

    }
}
