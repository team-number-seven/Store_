using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Store.BusinessLogic.Commands.UserCommands.CreateUser;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Queries.UserQueries.LoginUser;
using Store.BusinessLogic.Queries.UserQueries.RefreshTokens;
using Store.BusinessLogic.Queries.UserQueries.SendConfirmationByEmail;
using Store.DAL.Entities;

namespace Store.WebAPI.Controllers
{
    [AllowAnonymous]
    [Route("Store/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly UserManager<User> _userManager;
        private readonly IMediator _mediator;

        public UserController(
            IMediator mediator, 
            ILogger<UserController> logger,
            UserManager<User> userManager
            )
        {
            _mediator = mediator;
            _logger = logger;
            _userManager = userManager;
        }


        [HttpPost]
        [Route("SignIn")]
        public async Task<IActionResult> Login([FromHeader] QueryLoginUser request)
        {
            var response = await _mediator.Send(request);
            _logger.LogInformation($"{LoggerMessages.DoneMessage("Login")}");

            return StatusCode((int) response.StatusCode, response);
        }

        [HttpPost]
        [Route("SignUp")]
        public async Task<IActionResult> CreateUser([FromHeader] CommandCreateUser request)
        {
            var response = await _mediator.Send(request);
            if (response.StatusCode is HttpStatusCode.Created)
            {
                var userId = ((ResponseCreateUser) response).Id;
                await _mediator.Send(new QuerySendConfirmationByEmail(userId, Url));
            }
            _logger.LogInformation($"{LoggerMessages.DoneMessage("CreateUser")}");

            return StatusCode((int) response.StatusCode, response);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("RefreshToken")]
        public async Task<IActionResult> RefreshToken([FromBody] QueryRefreshTokens request)
        {
            var response = await _mediator.Send(request);
            _logger.LogInformation($"{LoggerMessages.DoneMessage("RefreshToken")}");

            return StatusCode((int) response.StatusCode, response);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("[action]")]
        public async Task<IActionResult> ConfirmEmail([FromQuery]string userId, [FromQuery]string tokenConfirmation)
        {
            
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return BadRequest();//the link is not valid
            if (user.EmailConfirmed)//already exists
            {
                return Redirect("http://localhost:3000");;
            }
            var result = await _userManager.ConfirmEmailAsync(user, tokenConfirmation);
            if (result.Succeeded)//successful
            {
                return Redirect("http://localhost:3000/email/confirm/success");
            }
            return BadRequest();//the link is not valid
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("[action]")]
        public async Task<IActionResult> DeclineEmail([FromQuery] string userId, [FromQuery] string tokenConfirmation)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return BadRequest();//the link is not valid
            var isVerifyUserToken = await _userManager.VerifyUserTokenAsync(user,
                _userManager.Options.Tokens.EmailConfirmationTokenProvider.ToString(), "EmailConfirmation",
                tokenConfirmation);
            if (isVerifyUserToken)
            {
                var result = await _userManager.DeleteAsync(user);//email deleted 
                return Ok();
            }
            return BadRequest("Gavno");//the link is not valid
        }
    }
}