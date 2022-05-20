using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jenshin.Impack.API.Output
{
    public class OutputBaseWithMessage
    {
        public OutputBaseWithMessage(int code, Exception ex)
        {
            this.ResultCode = code;
            this.ErrorMessage = ex.Message;
        }
        public int ResultCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}
