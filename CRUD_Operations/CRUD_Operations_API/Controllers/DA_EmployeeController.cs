using CRUD_Operations_API.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CRUD_Operations_API.Controllers
{
    public class DA_EmployeeController : ApiController
    {
        public static SaveResponses SaveEmployeeDetailsToDB()//save docs and blobs details to DB
        {
            var httpRequest = System.Web.HttpContext.Current.Request;
            string employeeName = httpRequest.Params["employeeName"];
            SaveResponses saveResponse = new SaveResponses();
            string str = "server=Your Server Name; Initial Catalog=Your Database Name; User ID=User Id; Password=Your Password";//DESKTOP-0E8DCT4\SQLEXPRESS
            SqlConnection cn = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("SpMyProcedure",cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@docName",employeeName);
            cn.Open();
            int i = cmd.ExecuteNonQuery();
            cn.Close();
            if(i >= 1)
            {
                saveResponse.saveStatus = "true";
            }
            else
            {
                saveResponse.saveStatus = "false";
            }
            return (saveResponse);


        }
        //public static List<Blob_Save_Details> GetBlobDetails(Blob_Save_Details BlobList)
        //{
        //    List<Blob_Save_Details> Blob_Details = new List<Blob_Save_Details>();
        //    try
        //    {
        //        string getBlobsQuery = "EXEC [docs].[Get_Blob_Details] '" + BlobList.Blob_Container_Name + "', '" + BlobList.Employee_Name + "'";
        //        DataTable blobData = ClassDB.selectRecords(getBlobsQuery);
        //        foreach(DataRow item in blobData.Rows)
        //        {
        //            Blob_Save_Details blobCollection = new Blob_Save_Details();
        //            blobCollection.Doc_Name = item["Doc_Name"].ToString();
        //            blobCollection.Barcode_No = item["Barcode_No"].ToString();
        //            blobCollection.Rack_No = item["Rack_No"].ToString();
        //            blobCollection.Doc_Code = item["Doc_Code"].ToString();
        //            Blob_Details.Add(blobCollection);
        //        }
        //    }
        //    catch { }
        //    return Blob_Details;
        //}//View Docs details in upload page
    }
}
