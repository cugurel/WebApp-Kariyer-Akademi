﻿using Business.Abstract;
using DataAccessLayer.Concrete;
using Entity.Concrete;
using Entity.Concrete.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using WebApp.Models;

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


        public async Task<IActionResult> Index()
        {
            var movies = _movieService.GetMoviesWithCategory();
            return View(movies);
        }


    }
}