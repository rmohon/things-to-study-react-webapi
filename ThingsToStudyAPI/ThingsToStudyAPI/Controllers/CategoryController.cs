using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ThingsToStudyAPI.Models;
using System.Data.SqlClient;
using System.Configuration;

namespace ThingsToStudyAPI.Controllers
{
    public class CategoryController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable table = new DataTable();

            string query = @"
                        select CategoryID, CategoryName 
                        from dbo.Category
                        ";
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["TechToStudyAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        public string Post(Category cat)
        {
            try
            {
                DataTable table = new DataTable();

                string query = @"
                            insert into dbo.Category values ('" + cat.CatName + @"') 
                            ";

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["TechToStudyAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Added Successfully";
            }
            catch (Exception)
            {
                return "Failed to Add";
            }
        }

        public string Put(Category cat)
        {
            try
            {
                DataTable table = new DataTable();

                string query = @"
                            update dbo.Category set CategoryName = '" + cat.CatName + @"'
                            where CategoryID = '" + cat.CatID + @"'
                            ";

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["TechToStudyAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Updated Successfully";
            }
            catch (Exception)
            {
                return "Failed to Update";
            }
        }

        public string Delete(int id)
        {
            try
            {
                DataTable table = new DataTable();

                string query = @"
                            delete from dbo.Category
                            where CategoryID = " + id;

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["TechToStudyAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Deleted Successfully";
            }
            catch (Exception)
            {
                return "Failed to Delete";
            }
        }
    }
}
