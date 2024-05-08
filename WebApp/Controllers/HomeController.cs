using Business.Abstract;
using DataAccessLayer.Concrete;
using Entity.Concrete;
using Entity.Concrete.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using WebApp.Models;
using X.PagedList;

namespace WebApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        IMovieService _movieService;
        public HomeController(IMovieService movieService)
        {
            _movieService = movieService;
        }


        public async Task<IActionResult> Index(int page = 1)
        {
            var movies = _movieService.GetMoviesWithCategory().ToPagedList(page,2);
            return View(movies);
        }


    }
}