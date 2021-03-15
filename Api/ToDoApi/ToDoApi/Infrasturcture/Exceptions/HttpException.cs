using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApi.Infrasturcture.Exceptions
{
    public class HttpException : Exception
    {
        public int StatusCode { get; set; }
        public object ResponseObj { get; set; }

        public HttpException(int statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
            ResponseObj = new
            {
                message
            };
        }
    }
}
