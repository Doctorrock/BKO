using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BKO.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BKO.WebA.Controllers
{
    [Produces("application/json")]
    [Route("api/Hand")]
    public class HandController : Controller
    {
        [HttpGet]
        public IEnumerable<Card> GetCards()
        {
            throw new NotImplementedException();
        }
    }
}