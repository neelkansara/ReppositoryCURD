using CURD.Business.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CURD.Business.Models
{
    public class ResponseDetail
    {
        public string Message { get; set; }

        public bool Success { get; set; }

        public object Data { get; set; }

        public MessageType MessageType { get; set; }
    }
}
