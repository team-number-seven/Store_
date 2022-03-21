using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogic.Common.Interfaces;
using Store.BusinessLogic.Common.UserModels;
using Store.DAL.Entities;
using Store.BusinessLogic.Commands.UserCommands.create;
using Store.DAL.Interfaces;
using MediatR;
namespace Store.WebAPI.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IJWTService _jwtService;
        private readonly SignInManager<User> _userSignInManager;
        private readonly IStoreDbContext _context;
        private readonly IMediator _mediator;

        public UserController(UserManager<User> userManager, IJWTService jwtService, 
            SignInManager<User> userSignInManager,IStoreDbContext context,IMediator mediator)
        {
            _userManager = userManager;
            _jwtService = jwtService;
            _userSignInManager = userSignInManager;
            _context = context;
            _mediator = mediator;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Login(UserLogin userLogin)
        {

            var user = await _userManager.FindByEmailAsync(userLogin.Email);

            if (user is null)
                return BadRequest(new {message = "Username or password is incorrect"});

            var passwordHash = _userManager.PasswordHasher.HashPassword(user,userLogin.Password);

           var result = await _userSignInManager.PasswordSignInAsync(user, userLogin.Password, true, false);
           if (result.Succeeded)
           {
               await _context.Entry(user).Reference(c => c.Country).LoadAsync();
               return Ok(_jwtService.GenerateJwtToken(user));

            }
           return BadRequest(new { message = "Username or password is incorrect" });
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Create(CreateUser.Command command)
            => Ok(await _mediator.Send(command));
    }
}