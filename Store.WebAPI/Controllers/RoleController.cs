using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Store.DAL.Entities;
using System;
using System.Threading.Tasks;

namespace Store.WebAPI.Controllers
{
    [Route("[controller]")]
    public class RoleController:Controller
    {
        RoleManager<IdentityRole<Guid>> _roleManager;
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
                IdentityResult result = await _roleManager.CreateAsync(new IdentityRole<Guid>(name));
                if (result.Succeeded)
                {
                    return Ok(name);
                }
            }
            return BadRequest();


        }
    }
}
