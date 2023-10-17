using LTMS.Core.GenericDataResponse;

namespace Schm.UI.Infrastructure.Common
{
    public class ResponseBody<T>
    {
        public bool IsSuccess { get; set; }
        public List<ResponseError> ErrorList { get; set; }
        public int TotalCount { get; set; }
        public T Result { get; set; }
    }
}
