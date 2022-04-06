using System;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using MailKit.Net.Smtp;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MimeKit;
using Store.BusinessLogic.Commands.ItemCommands.ItemCreate;
using Store.BusinessLogic.Commands.UserCommands.CreateUser;
using Store.BusinessLogic.Common.DataTransferObjects;
using Store.BusinessLogic.Common.Extensions;
using Store.BusinessLogic.Queries.CountryQueries.GetAllCountries;
using Store.BusinessLogic.Queries.UserQueries.SendConfirmationByEmail;
using Store.BusinessLogic.Services.EmailService;
using Store.DAL.Entities;
using System.IO;

namespace Store.WebAPI.Controllers
{
    /// <summary>
    ///     TEST CONTROLLER
    /// </summary>
    [ApiController]
    [Route("Store/[controller]")]
    [AllowAnonymous]
    public class HomeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IEmailService _emailService;
        private readonly UserManager<User> _userManager;

        public HomeController(IMediator mediator,IEmailService emailService,UserManager<User> userManager)
        {
            _mediator = mediator;
            _emailService = emailService;
            _userManager = userManager;
            return;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Create(CommandCreateUser request)
        {
            return Ok(await _mediator.Send(request));
        }


        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllCountries(QueryGetAllCountries request)
        {
            var response = await _mediator.Send(request);
            return response is null ? NotFound() : Ok(response);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> google()
        {
            var userId = "6142dea4-91e4-4c34-b873-d37ab8b75be3";
            var tokenConfirmation = await _userManager.GenerateEmailConfirmationTokenAsync(userId);

            var response = await _mediator.Send(new QuerySendConfirmationByEmail(Guid.Parse(userId),tokenConfirmation));

            return Ok();
        }

        [HttpGet]
        [Route("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> VerifyEmail(string userId, string tokenConfirmation)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null) return BadRequest();

            var result = await _userManager.ConfirmEmailAsync(user, tokenConfirmation);

            if (result.Succeeded)
            {
                return Ok("Succeeded");
            }

            return BadRequest();
        }
    }
}