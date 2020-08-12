using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class ProductsController : Controller
    {
        private Operations.ConsumeApi service = new Operations.ConsumeApi();
        // GET: Products
        public ActionResult Index()
        {
            
            var req = (Models.ProductsResponse)service.ConsumeApiService(typeof(Models.ProductsResponse), "https://localhost:44352/api/Products/GetAll", "", RestSharp.Method.GET);
            var model = new List<Models.ProductsResponse.ObjectResult>();
            foreach(var item in req.objectResult)
            {
                model.Add(new Models.ProductsResponse.ObjectResult { Active = item.Active, Cost = item.Cost, Description = item.Description, IdProduct = item.IdProduct,
                IdCategory = item.IdCategory, Name = item.Name, Unit = item.Unit, CreateDate = item.CreateDate 
                });
            }
            return View(model);
        }

        public ActionResult Crud(int id=0)
        {
            var req = (Models.ProductsResponse)service.ConsumeApiService(typeof(Models.ProductsResponse), "https://localhost:44352/api/Products/GetId?id=" + id, "", RestSharp.Method.GET);
            //var model = new Models.ProductsResponse.ObjectResult() { IdProduct= req.objectResult };
            
            
            
            
            return View(req.objectResult[0]);
        }

        [HttpPost]
        public ActionResult Crud(Models.ProductsResponse.ObjectResult entity)
        {
            entity.Active = true;
            var request = JsonConvert.SerializeObject(entity);
            if (entity.IdProduct == 0)
            {
                var req = (Models.ProductsResponse)service.ConsumeApiService(typeof(Models.ProductsResponse), "https://localhost:44352/api/Products/AddProduct", request, RestSharp.Method.POST);
            }
            else
            {
                var req = (Models.ProductsResponse)service.ConsumeApiService(typeof(Models.ProductsResponse), "https://localhost:44352/api/Products/UpdateProduct", request, RestSharp.Method.PATCH);
            }
            return RedirectToAction("Index", "Products");
        }

       
        public ActionResult Delete(int id)
        {
            var req = (Models.ProductsResponse)service.ConsumeApiService(typeof(Models.ProductsResponse), "https://localhost:44352/api/Products/DeleteProduct?id=" + id, "", RestSharp.Method.DELETE);

            return RedirectToAction("Index", "Products");
        }
    }
}