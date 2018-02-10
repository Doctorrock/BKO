using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BKO.Web.Models;
using BKO.Web.Repositories;
using BKO.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Rest;

namespace BKO.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Account")]
    public class AccountController : Controller
    {
        private readonly IDocumentDbRepository<AppUser> _useRepository;
        private readonly UserManager<AppUser> _userManager;
        public AccountController(IDocumentDbRepository<AppUser> dbRepository, UserManager<AppUser> userManager)
        {
            _useRepository = dbRepository;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]RegistrationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                throw new ValidationException();
            }

            var userIdentity =  new AppUser()
            {
                UserName = model.Login,
                Email = model.Email,
            };

            IdentityResult result;
            try
            {
                 result = await _userManager.CreateAsync(userIdentity, model.Password);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            

            if (!result.Succeeded)
            {
                return  new BadRequestResult();
            }
            //await _useRepository.CreateItemAsync(userIdentity);

            return new OkObjectResult("Account created");
        }
    }
}