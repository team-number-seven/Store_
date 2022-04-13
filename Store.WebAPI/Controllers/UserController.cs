using System;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Store.BusinessLogic.Commands.UserCommands.AddItemToBagItems;
using Store.BusinessLogic.Commands.UserCommands.AddItemToFavorite;
using Store.BusinessLogic.Commands.UserCommands.CreateUser;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects.BagItem;
using Store.BusinessLogic.Queries.UserQueries.GetBagItems;
using Store.BusinessLogic.Queries.UserQueries.GetFavoriteItems;
using Store.BusinessLogic.Queries.UserQueries.LoginUserQuery;
using Store.BusinessLogic.Queries.UserQueries.RefreshTokens;
using Store.BusinessLogic.Queries.UserQueries.SendConfirmationByEmail;
using Store.DAL.Entities;

namespace Store.WebAPI.Controllers
{
    [Authorize(Policy = nameof(PolicyRoles.User))]
    [Route("Store/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IMediator _mediator;
        private readonly UserManager<User> _userManager;

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

        [AllowAnonymous]
        [HttpPost]
        [Route("SignIn")]
        public async Task<IActionResult> Login([FromHeader] LoginUserQuery request)
        {
            var response = await _mediator.Send(request);
            _logger.LogInformation($"{LoggerMessages.DoneMessage(nameof(Login))}");

            return StatusCode((int) response.StatusCode, response);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("SignUp")]
        public async Task<IActionResult> CreateUser([FromHeader] CreateUserCommand request)
        {
            var response = await _mediator.Send(request);
            if (response.StatusCode is HttpStatusCode.Created)
            {
                var userId = ((CreateUserResponse) response).Id;
                await _mediator.Send(new QuerySendConfirmationByEmail(userId, Url));
            }

            _logger.LogInformation($"{LoggerMessages.DoneMessage(nameof(CreateUser))}");

            return StatusCode((int) response.StatusCode, response);
        }

        [HttpPost]
        [Route("RefreshToken")]
        public async Task<IActionResult> RefreshToken([FromBody] QueryRefreshTokens request)
        {
            var response = await _mediator.Send(request);
            _logger.LogInformation($"{LoggerMessages.DoneMessage(nameof(RefreshToken))}");

            return StatusCode((int) response.StatusCode, response);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> ConfirmEmail([FromQuery] string userId, [FromQuery] string tokenConfirmation)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return BadRequest();
            if (user.EmailConfirmed) return Redirect("http://localhost:3000");

            var result = await _userManager.ConfirmEmailAsync(user, tokenConfirmation);
            if (result.Succeeded)
                return Redirect("http://localhost:3000/email/confirm/success");
            return BadRequest();
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("[action]")]
        public async Task<IActionResult> DeclineEmail([FromQuery] string userId, [FromQuery] string tokenConfirmation)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return BadRequest(); //the link is not valid
            var isVerifyUserToken = await _userManager.VerifyUserTokenAsync(user,
                _userManager.Options.Tokens.EmailConfirmationTokenProvider, "EmailConfirmation",
                tokenConfirmation);
            if (isVerifyUserToken)
            {
                var result = await _userManager.DeleteAsync(user); //email deleted 
                return Ok();
            }

            return BadRequest("Gavno"); //the link is not valid
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddItemToBagItems([FromBody] AddItemToBagItemCommand request)
        {
            //Guid.TryParse(User!.FindFirstValue("Id"), out var id);
            request.BagItem.UserId = User!.FindFirstValue("Id");
            var response = await _mediator.Send(request);
            _logger.LogInformation($"{LoggerMessages.DoneMessage(nameof(AddItemToBagItems))}");

            return StatusCode((int)response.StatusCode, response);
        }



        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetBagItems([FromQuery]uint count = 10)
        {
            var request = new GetBagItemsQuery(User!.FindFirstValue("id"), count);
            var response = await _mediator.Send(request);
            _logger.LogInformation($"{LoggerMessages.DoneMessage(nameof(GetBagItems))}");

            return StatusCode((int)response.StatusCode, response);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddItemToFavoriteItem([FromBody] AddItemToFavoriteCommand request)
        {
            request.FavoriteItem.UserId = User!.FindFirstValue("Id");
            var response = await _mediator.Send(request);
            _logger.LogInformation($"{LoggerMessages.DoneMessage(nameof(AddItemToFavoriteItem))}");

            return StatusCode((int)response.StatusCode, response);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetFavoriteItems([FromQuery] uint count = 10)
        {
            var request = new GetFavoriteItemsQuery(User!.FindFirstValue("id"), count);
            var response = await _mediator.Send(request);
            _logger.LogInformation($"{LoggerMessages.DoneMessage(nameof(GetFavoriteItems))}");

            return StatusCode((int)response.StatusCode, response);
        }
    }
}