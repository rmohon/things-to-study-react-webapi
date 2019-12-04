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
using System.Threading.Tasks;
using ThingsToStudyAPI.Data;

namespace ThingsToStudyAPI.Controllers
{
    public class TechnologyController : ApiController
    {
        private readonly ITechnologyRepository _repository;

        public TechnologyController(ITechnologyRepository repository)
        {
            _repository = repository;
        }

        public IHttpActionResult Get()
        {
            /*DataTable table = new DataTable();

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
            }*/
            try
            {
                var result = _repository.GetTechnologies();

                return Ok(result);
            }
            catch (Exception ex)
            {
                // TODO Add Logging
                return InternalServerError(ex);
            }
        }

        public IHttpActionResult Post(TechnologyModel tech)
        {
            try
            {
                /*
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
                }*/
                _repository.AddTechnology(tech);

                return Ok("Added Successfully");
            }
            catch (Exception ex)
            {
                //TODO Add logging
                return InternalServerError(ex);
            }
        }

        public IHttpActionResult Put(TechnologyModel tech)
        {
            try
            {
                /*
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
                }*/

                _repository.UpdateTechnology(tech);

                return Ok("Updated Successfully");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        public IHttpActionResult Delete(int id)
        {
            try
            {
                /*
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
                }*/

                _repository.DeleteTechnology(id);

                return Ok("Deleted Successfully");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
