using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TestApi.Controllers
{
    public class ProductsController : ApiController
    {
        [Route("api/Products/GetAll")]
        [HttpPost]
        public Models.Result GetAll()
        {
            return new Models.Result()
            {
                Details = "Prueba Ok",
                Status = Models.Result.Estatus.Ok,
            };
        }
    }
}
