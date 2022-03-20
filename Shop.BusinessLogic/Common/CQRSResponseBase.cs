using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Store.BusinessLogic.Common
{
    public record CQRSResponseBase
    {
        public CQRSResponseBase(){}
        public CQRSResponseBase(string errorMessage,HttpStatusCode statusCode)
        {
            ErrorMessage = errorMessage;
            StatusCode = statusCode;
        }
        public HttpStatusCode StatusCode { get; init; } = HttpStatusCode.OK;
        public string ErrorMessage { get; init; }
    }
}
