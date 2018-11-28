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
        public static SaveResponses SaveEmployeeDetailsToDB()//Save employee details to DB
        {
            try{
                var httpRequest = System.Web.HttpContext.Current.Request;
                string employeeName = httpRequest.Params["employeeName"];
                string employeeAge = httpRequest.Params["employeeAge"];
                string employeeAddress = httpRequest.Params["employeeAddress"];
                SaveResponses saveResponse = new SaveResponses();
                string connetionString = DBConnection.Connection();
                string saveUserDetails = "EXEC [dbo].[Save_Employee_Details] '" + employeeName + "','" + employeeAge + "','" + employeeAddress + "'";
                using(SqlConnection conn = new SqlConnection(connetionString))
                {
                    using(SqlCommand cmd = new SqlCommand(saveUserDetails,conn))
                    {
                        conn.Open();
                        cmd.CommandTimeout = 0;
                        int result = cmd.ExecuteNonQuery();
                        conn.Close();
                        if(result >= 1)
                        {
                            saveResponse.saveStatus = "true";
                        }
                        else
                        {
                            saveResponse.saveStatus = "false";
                        }
                        return (saveResponse);
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }



        public static List<EmployeeDetails> GetEmployeeDetails()
        {
            List<EmployeeDetails> teamDetails = new List<EmployeeDetails>();
            try
            {
                string connetionString = DBConnection.Connection();
                using(SqlConnection conn = new SqlConnection(connetionString))
                {
                    string getTeamDetailsQuery = "select * from Employee_Details";
                    conn.Open();
                    using(SqlCommand cmd = new SqlCommand(getTeamDetailsQuery,conn))
                    {
                        SqlDataReader rdr = cmd.ExecuteReader();
                        while(rdr.HasRows && rdr.Read())
                        {
                            teamDetails.Add(new EmployeeDetails
                            {
                                //EmployeeID = rdr.GetString(rdr.GetOrdinal("EmployeeID")),
                                EmployeeName = rdr.GetString(rdr.GetOrdinal("EmployeeName")),
                                //Age = rdr.GetString(rdr.GetOrdinal("EmployeeName")),
                                EMployeeAddress = rdr.GetString(rdr.GetOrdinal("EMployeeAddress")),

                            });
                        }
                        return teamDetails;
                        
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }//View Team Details






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
