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
using Microsoft.Azure.Documents;
using Microsoft.Rest;

namespace BKO.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Account")]
    public class AccountController : Controller
    {
        private readonly IDocumentDbRepository<Player> _useRepository;
        private readonly UserManager<AppUser> _userManager;
        public AccountController(IDocumentDbRepository<Player> dbRepository, UserManager<AppUser> userManager)
        {
            _useRepository = dbRepository;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegistrationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                throw new ValidationException();
            }

            var userIdentity = new AppUser()
            {
                UserName = model.Login,
                Email = model.Email,
            };


            IdentityResult result = await _userManager.CreateAsync(userIdentity, model.Password);

            if (!result.Succeeded)
            {
                return new BadRequestResult();
            }

            await _useRepository.CreateItemAsync(new Player{IdentityId = userIdentity.Id});

            return new OkObjectResult("Account created");
        }
    }
}