using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Store.WebAPI.Controllers
{
    [Route("[controller]")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;

        public RoleController(RoleManager<IdentityRole<Guid>> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Create(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                var result = await _roleManager.CreateAsync(new IdentityRole<Guid>(name));
                if (result.Succeeded) return Ok(name);
            }

            return BadRequest();
        }
    }
}