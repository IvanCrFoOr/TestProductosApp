using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Domain;

namespace TestApi.Controllers
{
    public class CategoryController : ApiController
    {
        [HttpGet]
        [Route("api/Category/GetAll")]
        public Models.Result GetAll()
        {
            var result = new Models.Result();
            try
            {
                using (var db = new Domain.Entities.TESTPRODUCTSEntities())
                {
                    result.ObjectResult = db.CATEGORY.ToList();
                    result.Status = Models.Result.Estatus.Ok;
                    result.Details = "GetAll Successful";
                }
            }
            catch (Exception e)
            {
                result.Details = e.Message;
                result.Status = Models.Result.Estatus.Error;
            }

            return result;
        }

        [HttpPost]
        [Route("api/AddCategory")]
        public Models.Result AddCategory(Domain.Entities.CATEGORY entity)
        {
            var result = new Models.Result();
            try
            {
                using (var db = new Domain.Entities.TESTPRODUCTSEntities())
                {
                    db.CATEGORY.Add(entity);
                    db.SaveChanges();
                    result.Details = "Add Category Successful";
                    result.ObjectResult = entity;
                }
            }
            catch (Exception e)
            {
                result.Details = e.Message;
                result.Status = Models.Result.Estatus.Error;
            }

            return result;
        }
    }
}
