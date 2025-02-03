using CourseStore.Query.Users.GetByPhoneNumber;
using EndPoint.Api.ViewModels.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace EndPoint.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private const string privateKey = "289ED825-904E-41BD-9C59-7121D6F63860";
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            this._mediator=mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Get([FromBody] FetchTokenViewModel command)
        {
            var user = await _mediator.Send(new GetUserByPhoneNumberQuery(command.PhoneNumber));
           
            if(user != null)
            {
                List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,user.PhoneNumber),
                new Claim(ClaimTypes.MobilePhone,command.PhoneNumber)
            };

                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(privateKey);
                SecurityKey securityKey = new SymmetricSecurityKey(bytes);
                SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                SecurityToken token = new JwtSecurityToken(
                    issuer: "Blazor",
                    audience: "Blazor",
                    notBefore: DateTime.Now,
                    expires: DateTime.Now.AddMinutes(5),
                    claims: claims,
                    signingCredentials: credentials);

                var finalToken = new JwtSecurityTokenHandler().WriteToken(token);
                return Ok(finalToken);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
