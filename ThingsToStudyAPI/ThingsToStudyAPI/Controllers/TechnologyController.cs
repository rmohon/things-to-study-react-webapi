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
