using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace EndPoint.Api.ViewModels.User
{
    public class FetchTokenViewModel
    {
        public string PhoneNumber { get; set; }
    }

    public interface ICustomTokenValidator
    {
        Task Execute(TokenValidatedContext context);
    }
    public class CustomTokenValidator : ICustomTokenValidator
    {
        public Task Execute(TokenValidatedContext context)
        {
            return Task.CompletedTask;  
        }
    }
}
