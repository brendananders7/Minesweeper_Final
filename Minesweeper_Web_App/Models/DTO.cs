using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Minesweeper_Web_App.Models
{
    [DataContract]
    public class DTO
    {
        public DTO(int errorCode, string errorMsg, string data)
        {
            this.errorCode = errorCode;
            this.errorMsg = errorMsg;
            this.data = data;
        }

        [DataMember]
        public int errorCode{ get; set; }
        [DataMember]
        public string errorMsg{ get; set; }
        [DataMember]
        public string data{ get; set; }
    }
}