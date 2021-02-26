namespace MSmile.Api.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using MSmile.Api.Authentication;

    /// <summary>
    /// Authentication controller.
    /// </summary>
    [Route("api/[controller]")]
    public class AuthenticateController : Controller
    {
        /// <summary>
        /// Authenticates a user.
        /// </summary>
        /// <param name="service">Service.</param>
        /// <param name="model">Model.</param>
        /// <returns>User model.</returns>
        [HttpPost]
        public Task<UserModel> Authenticate([FromServices] AuthenticationService service, [FromBody] AuthenticationModel model)
        {
            return service.Authenticate(model.Login, model.PasswordHash);
        }
    }
}
