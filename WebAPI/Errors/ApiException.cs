using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Errors
{
    public class ApiException : ApiResponse
    {
        public ApiException(int statusCode,string message = null,string detalis=null)
            :base(statusCode,message)
        {
            this.Details = detalis;
        }
        public string Details { get; set; }
    }
}
