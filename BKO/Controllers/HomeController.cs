using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BKO.Interfaces;
using BKO.Models;
using Microsoft.AspNetCore.Mvc;

namespace BKO.Controllers
{
    public class HomeController : Controller
    {
        private IBoard _board;

        public HomeController(IBoard board)
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

            _board.CreateHands();
            return View();
        }
    }
}
