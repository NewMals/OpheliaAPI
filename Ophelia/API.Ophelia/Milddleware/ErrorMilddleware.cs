using Global.Ophelia.Excepciones;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Ophelia.Milddleware
{
    public class ErrorMilddleware
    {
        private readonly RequestDelegate next;
        public ErrorMilddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (CustomException ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, CustomException ex)
        {
            string result = JsonConvert.SerializeObject(ex.GetException());
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = ex.StatusCode;
            return context.Response.WriteAsync(result);
        }

    }
}
