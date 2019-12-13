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
using System.Threading.Tasks;
using ThingsToStudyAPI.Data;

namespace ThingsToStudyAPI.Controllers
{
    public class CategoryController : ApiController
    {
        private readonly ICategoryRepository _repository;

        public CategoryController(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public IHttpActionResult Get()
        {
            try
            {
                var result = _repository.GetCategories();

                return Ok(result);
            }
            catch (Exception ex)
            {
                // TODO Add Logging
                return InternalServerError(ex);
            }
        }

        public IHttpActionResult Post(CategoryModel cat)
        {
            try
            {
                _repository.AddCategory(cat);

                return Ok();
            }
            catch (Exception ex)
            {
                //TODO Add Logging
                return InternalServerError(ex);
            }
        }

        public IHttpActionResult Put(CategoryModel cat)
        {
            try
            {
                _repository.UpdateCategory(cat);

                return Ok("Updated Successfully");
            }
            catch (Exception ex)
            {
                //TODO Add Logging
                return InternalServerError(ex);
            }
        }

        public IHttpActionResult Delete(int id)
        {
            try
            {
                _repository.DeleteCategory(id);

                return Ok("Deleted Successfully");
            }
            catch (Exception ex)
            {
                //TODO Add Logging
                return InternalServerError(ex);
            }
        }
    }
}
