using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class ProductsResponse
    {
        public int status { get; set; }
        public List<ObjectResult> objectResult { get; set; }
        public string Details { get; set; }
        public class ObjectResult
        {
            public int IdProduct { get; set; }
            public string Name { get; set; }
            public decimal Cost { get; set; }
            public int Unit { get; set; }
            public string Description { get; set; }
            public string IdCategory { get; set; }
            public DateTime CreateDate { get; set; }
            public bool Active { get; set; }
        }
    }
}