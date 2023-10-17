using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using Schm.Core.DTO.Request.Document;
using Schm.Core.DTO.SearchContext;
using Schm.Domain.Model;
using Schm.UI.Infrastructure.Common;
using Schm.UI.Infrastructure.Contracts;

namespace Schm.UI.Infrastructure.Services
{
    public class DocumentService: IDocumentService
    {

        public IOptions<Config.Config> Options { get; }

        public DocumentService(IOptions<Config.Config> options)
        {
            Options = options;
        }

        public async Task<ResponseBody<List<Document>>> GetList(int supplierId)
        {
            var result = SendRequest<ResponseBody<List<Document>>>.Send(Options.Value.ApiSchmUrl + "/api/Document/List?supplierId="+supplierId, Method.GET, "", false);
            return new ResponseBody<List<Document>>()
            {
                TotalCount = result.Result.TotalCount,
                Result = result.Result.Result,
                ErrorList = result.Result.ErrorList,
                IsSuccess = result.Result.IsSuccess
            };
        }

        public async Task<ResponseBody<List<Document>>> Search(SearchDocumentCntxDto SearchCntx)
        {
            var result = SendRequest<ResponseBody<List<Document>>>.Send(Options.Value.ApiSchmUrl + "/api/Document/Search", Method.POST, JsonConvert.SerializeObject(SearchCntx));
            return new ResponseBody<List<Document>>()
            {
                TotalCount = result.Result.TotalCount,
                Result = result.Result.Result,
                ErrorList = result.Result.ErrorList,
                IsSuccess = result.Result.IsSuccess
            };
        }

        public async Task<ResponseBody<Document>> Get(int id)
        {
            var result = SendRequest<ResponseBody<Document>>.Send(Options.Value.ApiSchmUrl + "/api/Document/" + id, Method.GET, "", false);
            return result.Result;
        }

        public async Task<ResponseBody<Document>> Insert(InsertDocumentDto option)
        {
            var result = SendRequest<ResponseBody<Document>>.Send(Options.Value.ApiSchmUrl + "/api/Document/Insert", Method.POST, JsonConvert.SerializeObject(option));
            return result.Result;
        }

        public async Task<ResponseBody<bool>> Update(UpdateDocumentDto option)
        {
            var result = SendRequest<ResponseBody<bool>>.Send(Options.Value.ApiSchmUrl + "/api/Document/Update", Method.POST, JsonConvert.SerializeObject(option));
            return result.Result;
        }

        public async Task<ResponseBody<bool>> Delete(int id)
        {
            var result = SendRequest<ResponseBody<bool>>.Send(Options.Value.ApiSchmUrl + "/api/Document/" + id, Method.POST, "", false);
            return result.Result;
        }

        public async Task<ResponseBody<bool>> Final(int id)
        {
            var result = SendRequest<ResponseBody<bool>>.Send(Options.Value.ApiSchmUrl + "/api/Document/Final/" + id, Method.POST, "", false);
            return result.Result;
        }
    }
}
