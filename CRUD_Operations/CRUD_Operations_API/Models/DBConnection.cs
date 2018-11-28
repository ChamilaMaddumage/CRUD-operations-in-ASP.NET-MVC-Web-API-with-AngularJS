using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_Operations_API.Models
{
    public class DBConnection
    {
        public static string Connection()
        {
            return "Data Source=.;Initial Catalog=Employee_DB;Integrated Security=True;MultipleActiveResultSets=True";
        }
    }
}