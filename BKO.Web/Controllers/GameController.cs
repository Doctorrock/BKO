using System;
using Microsoft.AspNetCore.Mvc;

namespace BKO.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Game")]
    public class GameController : Controller
    {
        [HttpPut]
        public bool SitPlayer()
        {
            throw new NotImplementedException();
        }


    }
}