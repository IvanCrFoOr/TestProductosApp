using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Models
{
    public class Result
    {
        public enum Estatus { Ok, Error }
        public dynamic ObjectResult { get; set; }
        public string Details { get; set; }
        public Estatus Status { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public Result()
        {
            Details = string.Empty;
            ObjectResult = null;
            Status = Estatus.Error;
        }

        /// <summary>
        /// Destructor
        /// </summary>
        ~Result()
        {
            GC.Collect();
        }
    }
}