using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TakeAway.IdentityServer.Dtos;
using TakeAway.IdentityServer.Models;

namespace TakeAway.IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RegistersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task <IActionResult> UserRegister(CreateUserRegisterDto createUserRegisterDto)
        {
            var values = new ApplicationUser()
            {
                UserName = createUserRegisterDto.Username,
                Email = createUserRegisterDto.Email,
                Name = createUserRegisterDto.Name,
                Surname = createUserRegisterDto.Surname,
            };

            {
                var result = await _userManager.CreateAsync(values, createUserRegisterDto.Password);
                if (result.Succeeded)
                {
                    return Ok("Başarıyla eklendi");
                }

                return Ok("Bir hata oluştu");
            }
            
        }
    }
}
