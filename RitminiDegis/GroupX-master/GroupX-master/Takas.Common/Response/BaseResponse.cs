using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Takas.Common.Response
{
    public class BaseResponse
    {
        public int Code { get; set; }
        public string Message { get; set; }


        public void setError(SystemConstants.SystemConstannts.ERROR_CODES errorCode)
        {
            this.Code = (int)errorCode;
            this.Message = SystemConstants.SystemConstannts.ERROR_MESSAGE.FirstOrDefault(t => t.Key == (int)errorCode).Value;
        }
    }
}
