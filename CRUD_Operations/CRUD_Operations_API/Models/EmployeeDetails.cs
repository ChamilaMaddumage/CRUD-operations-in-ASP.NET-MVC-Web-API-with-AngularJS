using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_Operations_API.Models
{
    public class EmployeeDetails
    {
        public int EmployeeID
        {
            get; set;
        }
        public string EmployeeName
        {
            get; set;
        }
        public int Age
        {
            get; set;
        }
        public string EMployeeAddress
        {
            get; set;
        }
    }
}