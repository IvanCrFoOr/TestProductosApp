using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Domain;

namespace Api.Controllers
{
    public class ProductsController : ApiController
    {
        [HttpGet]
        [Route("api/Products/GetAll")]
        public Models.Result GetAll()
        {
            var result = new Models.Result();
            try
            {
                using (var db = new Domain.Entities.TESTPRODUCTSEntities())
                {

                    result.ObjectResult = db.PRODUCTS.ToList();
                    result.Details = "GetAll Suuccessful";
                    result.Status = Models.Result.Estatus.Ok;
                }
            }
            catch(Exception e)
            {
                result.Status = Models.Result.Estatus.Error;
                result.Details = e.Message;
            }
            return result;
        }

        [HttpPost]
        [Route("api/Products/AddProduct")]
        public Models.Result AddProduct(Domain.Entities.PRODUCTS entity)
        {
            var result = new Models.Result();
            try
            {
                using (var db = new Domain.Entities.TESTPRODUCTSEntities())
                {
                    entity.CreateDate = DateTime.Now;
                    db.PRODUCTS.Add(entity);
                    db.SaveChanges();
                    result.Details = "Add Suuccessful";
                    result.Status = Models.Result.Estatus.Ok;
                }
            }
            catch (Exception e)
            {
                result.Status = Models.Result.Estatus.Error;
                result.Details = e.Message;
            }
            return result;
        }

        [HttpDelete]
        [Route("api/Products/DeleteProduct")]
        public Models.Result DeleteProduct(int id)
        {
            var result = new Models.Result();
            try
            {
                using (var db = new Domain.Entities.TESTPRODUCTSEntities())
                {
                    var product = db.PRODUCTS.FirstOrDefault(x => x.IdProduct == id);
                    db.Entry(product).State = System.Data.Entity.EntityState.Deleted;
                    db.SaveChanges();
                    result.Details = "Delete Suuccessful";
                    result.Status = Models.Result.Estatus.Ok;
                }
            }
            catch (Exception e)
            {
                result.Status = Models.Result.Estatus.Error;
                result.Details = e.Message;
            }
            return result;
        }
    }
}
