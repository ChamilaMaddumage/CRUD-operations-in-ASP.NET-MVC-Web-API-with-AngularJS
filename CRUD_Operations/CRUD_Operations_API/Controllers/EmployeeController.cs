using CRUD_Operations_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CRUD_Operations_API.Controllers
{
    public class EmployeeController : ApiController
    {
        [HttpPost]
        public IHttpActionResult SaveEmployeeDetails()
        {
            return Ok(DA_EmployeeController.SaveEmployeeDetailsToDB());
        }
        [HttpPost]
        public IHttpActionResult GetEmployeeDetails()
        {
            return Ok(DA_EmployeeController.GetEmployeeDetails());
        }
    }
}
