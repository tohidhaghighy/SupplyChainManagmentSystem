using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using Schm.Core.DTO.Request.SubDocument;
using Schm.Core.DTO.SearchContext;
using Schm.Domain.Model;
using Schm.UI.Infrastructure.Common;
using Schm.UI.Infrastructure.Contracts;
using Schm.UI.Infrastructure.ViewModels;

namespace Schm.UI.Infrastructure.Services
{
    public class SubDocumentService: ISubDocumentService
    {
        public IOptions<Config.Config> Options { get; }

        public SubDocumentService(IOptions<Config.Config> options)
        {
            Options = options;
        }

        public async Task<ResponseBody<List<SubDocumentViewModel>>> GetList(int documentId)
        {
            var result = SendRequest<ResponseBody<List<SubDocumentViewModel>>>.Send(Options.Value.ApiSchmUrl + "/api/SubDocument/List?documentId=" + documentId, Method.GET, "", false);
            return new ResponseBody<List<SubDocumentViewModel>>()
            {
                TotalCount = result.Result.TotalCount,
                Result = result.Result.Result,
                ErrorList = result.Result.ErrorList,
                IsSuccess = result.Result.IsSuccess
            };
        }

        public async Task<ResponseBody<List<SubDocumentViewModel>>> Search(SearchSubDocumentCntxDto SearchCntx)
        {
            var result = SendRequest<ResponseBody<List<SubDocumentViewModel>>>.Send(Options.Value.ApiSchmUrl + "/api/SubDocument/Search", Method.POST, JsonConvert.SerializeObject(SearchCntx));
            return new ResponseBody<List<SubDocumentViewModel>>()
            {
                TotalCount = result.Result.TotalCount,
                Result = result.Result.Result,
                ErrorList = result.Result.ErrorList,
                IsSuccess = result.Result.IsSuccess
            };
        }

        public async Task<ResponseBody<SubDocument>> Get(int id)
        {
            var result = SendRequest<ResponseBody<SubDocument>>.Send(Options.Value.ApiSchmUrl + "/api/SubDocument/" + id, Method.GET, "", false);
            return result.Result;
        }

        public async Task<ResponseBody<SubDocument>> Insert(InsertSubDocumentDto option)
        {
            var result = SendRequest<ResponseBody<SubDocument>>.Send(Options.Value.ApiSchmUrl + "/api/SubDocument/Insert", Method.POST, JsonConvert.SerializeObject(option));
            return result.Result;
        }

        public async Task<ResponseBody<bool>> Update(UpdateSubDocumentDto option)
        {
            var result = SendRequest<ResponseBody<bool>>.Send(Options.Value.ApiSchmUrl + "/api/SubDocument/Update", Method.POST, JsonConvert.SerializeObject(option));
            return result.Result;
        }

        public async Task<ResponseBody<bool>> Delete(int id)
        {
            var result = SendRequest<ResponseBody<bool>>.Send(Options.Value.ApiSchmUrl + "/api/SubDocument/" + id, Method.POST, "", false);
            return result.Result;
        }

    }
}
