using Microsoft.AspNetCore.Mvc;
using Moveis.Data.Repositories.Interface;
using Moveis.Models;
using Moveis.Service.Interface;
using Moveis.ViewModel.Film;
using System.Diagnostics;

namespace Moveis.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFilmService _filmService;
        public HomeController(IFilmService filmService)
        {
            _filmService = filmService;
        }
    
        public IActionResult Index(FilmDropDown model)
        {
            var films = _filmService.GetByFilter(model);
            return View();
        }

        public IActionResult UserList()
        {

            return View();
        }
        [HttpGet]
        public IActionResult FilmFilter()
        {
            ViewBag.film = _filmService.GetDropDownList();
            return View();
        }
        [HttpPost]  
        public IActionResult FilmFilter(FilmDropDown model)
        {
             ViewBag.film = _filmService.GetByFilter(model);
            return View();
        }
    }
}