using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BKO.Domain.Interfaces;
using BKO.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BKO.Controllers
{
    public class HomeController : Controller
    {
        private Board _board;

        public HomeController(Board board)
        {
            _board = board;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;

            return View();
        }
    }
}
