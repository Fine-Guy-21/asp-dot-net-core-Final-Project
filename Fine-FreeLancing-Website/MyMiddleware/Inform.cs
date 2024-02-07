using Fine_FreeLancing_Website.Models;

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

                context.Response.ContentType = "text/html";

                string htmlContent = "<html>" +
                    "<head> " +
                    "<style>" +
                    "h1{ color:white; text-align:center;}" +
                    "h3{ color:white; text-align:center;}" +
                    "body{ background-color:grey; }" +
                    "</style>" +
                    "</head>" +
                    "<body>" +
                    "<h1> Sorry, You're Not allowed to Visit This Page </h1> " +
                    "<br>" +
                    " <h3>" + returnUrlValue +"</h3>" +
                    "</body>" +
                    "</html>";

                await context.Response.WriteAsync(htmlContent);
                return; 

            }
            await next(context); 
        }           


    }
}
