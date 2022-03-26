using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogic.Commands.UserCommands.CreateUser;
using Store.BusinessLogic.Common.Interfaces;
using Store.BusinessLogic.Common.UserModels;
using Store.DAL.Entities;
using Store.DAL.Interfaces;

namespace Store.WebAPI.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IStoreDbContext _context;
        private readonly IJWTService _jwtService;
        private readonly IMediator _mediator;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly UserManager<User> _userManager;

        public UserController(UserManager<User> userManager, IJWTService jwtService, IStoreDbContext context, IMediator mediator,IPasswordHasher<User> passwordHasher)
        {
            _userManager = userManager;
            _jwtService = jwtService;
            _context = context;
            _mediator = mediator;
            _passwordHasher = passwordHasher;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Login(UserLogin userLogin)
        {
            var user = await _userManager.FindByEmailAsync(userLogin.Email);

            if (user is null)
                return BadRequest(new {message = "Username or password is incorrect"});
            var result =
                _userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, userLogin.Password);
            if (result == PasswordVerificationResult.Success)
            {
                await _context.Entry(user).Reference(c => c.Country).LoadAsync();
                return Ok(_jwtService.GenerateJwtToken(user));
            }

            return BadRequest(new {message = "Username or password is incorrect"});
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Create(CommandCreateUser command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}