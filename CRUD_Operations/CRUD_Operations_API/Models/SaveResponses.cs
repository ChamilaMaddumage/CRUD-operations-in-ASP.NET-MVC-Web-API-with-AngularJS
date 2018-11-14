using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_Operations_API.Models
{
    public class SaveResponses
    {
        public string saveStatus
        {
            get; set;
        }
        public string messageType
        {
            get; set;
        }
        public string message
        {
            get; set;
        }
        public string Doc_No
        {
            get; set;
        }
        public string Doc_Name
        {
            get; set;
        }//should be changed to Doc_N0
    }
}