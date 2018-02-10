﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BKO.WebA.Controllers
{
    [Authorize(Policy = "ApiUser")]
    [Produces("application/json")]
    [Route("api/Table")]
    public class TableController : Controller
    {

    }
}