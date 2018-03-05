using System;
using System.Collections.Generic;
using BKO.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BKO.Web.Controllers
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