using System.Net;

namespace MiddlewareHomework.Middlewares
{
    public class StudentHeadersMiddleware
    {
        private readonly RequestDelegate _next;

        private const string StudentName = "Esman Dmitriy Olegovich";
        private const string StudentGroup = "RI-240944";

        public StudentHeadersMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.Response.OnStarting(() =>
            {
                context.Response.Headers["X-Student-Name"] =
                    WebUtility.UrlEncode(StudentName);

                context.Response.Headers["X-Student-Group"] =
                    WebUtility.UrlEncode(StudentGroup);

                return Task.CompletedTask;
            });

            await _next(context);
        }
    }
}