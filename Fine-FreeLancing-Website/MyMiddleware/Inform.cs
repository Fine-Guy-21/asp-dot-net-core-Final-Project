using Fine_FreeLancing_Website.Models;
using System.Globalization;

namespace Fine_FreeLancing_Website.MyMiddleware
{
    public class Inform
    {
        private readonly RequestDelegate next;
        public Inform(RequestDelegate requestDelegate)
        {
            next = requestDelegate;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path == "/Account/AccessDenied" && context.Request.Query.TryGetValue("ReturnUrl", out var returnUrl))
            {
                string returnUrlValue = returnUrl.FirstOrDefault();

                string url = "~/Imgs/unauthorized.jpg";
                context.Response.ContentType = "text/html";

                string htmlContent = await File.ReadAllTextAsync("wwwroot/unauthorized.html");

                await context.Response.WriteAsync(htmlContent);
                return; 

            }
            await next(context); 
        }           


    }
}
