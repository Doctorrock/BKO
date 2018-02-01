using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BKO.Web.Models;
using BKO.Web.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BKO.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Auth")]
    public class AuthController : Controller
    {
        private IDocumentDbRepository<AppUser> _useRepository;
        public AuthController(IDocumentDbRepository<AppUser> dbRepository)
        {
            _useRepository = dbRepository;
        }

        [HttpGet]
        public IEnumerable<AppUser> GetUsers()
        {
            var users = _useRepository.GetItemsAsync(x => x == x).Result;
            return users;
        }


    }
}