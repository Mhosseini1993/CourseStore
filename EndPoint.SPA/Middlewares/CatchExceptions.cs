using CourseStore.Application.Shared.Exceptions;
using CourseStore.Domain.Shared.Exceptions;

namespace EndPoint.SPA.Middlewares
{
    public class CatchExceptions
    {
        private readonly RequestDelegate request;

        public CatchExceptions(RequestDelegate request)
        {
            this.request=request;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {

                await request.Invoke(context);
            }
            catch (BaseCommandException ex1)
            {

            }
            catch (NullOrEmptyDomainDataException ex1)
            {

            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
    }
    public static class CatchExceptionExtention
    {
        public static IApplicationBuilder UseCatchException(this IApplicationBuilder app) 
        {
            return app.UseMiddleware<CatchExceptions>();
        }
    }
}
