using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ThingsToStudyAPI.Models;

namespace ThingsToStudyAPI.Controllers
{
    public class TechnologyController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable table = new DataTable();

            string query = @"
                          select TechID, TechName, Category, TechDescription, TechURL 
                          from dbo.Technologies
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

        public string Post(Technology tech)
        {
            try
            {
                DataTable table = new DataTable();

                string query = @"
                            insert into dbo.Technologies (TechName, Category, TechDescription, TechURL) 
                            Values 
                            (
                            '" + tech.TechName + @"' 
                            ,'" + tech.CatName + @"'
                            ,'" + tech.TechDes + @"'          
                            ,'" + tech.TechURL + @"'
                            )";

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

        public string Put(Technology tech)
        {
            try
            {
                DataTable table = new DataTable();

                string query = @"
                            update dbo.Technologies set
                            TechName = '" + tech.TechName + @"'
                            ,Category = '" + tech.CatName + @"'
                            ,TechDescription = '" + tech.TechDes + @"'
                            ,TechURL = '" + tech.TechURL + @"'
                            where TechID = '" + tech.TechID + @"'
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
                            delete from dbo.Technologies
                            where TechID = " + id;

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
