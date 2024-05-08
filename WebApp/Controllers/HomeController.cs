using Business.Abstract;
using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using DocumentFormat.OpenXml.Vml;
using Entity.Concrete;
using Entity.Concrete.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Versioning;
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

        public IActionResult Excel()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Filmler ve Kategorileri");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "FilmAdı";
                worksheet.Cell(currentRow, 2).Value = "Yönetmen";
                worksheet.Cell(currentRow, 3).Value = "Kategori";
                worksheet.Cell(currentRow, 4).Value = "ImdbPuan";

                var values = _movieService.GetMoviesWithCategory();
                foreach (var item in values)
                {
                    currentRow++;
                    worksheet.Cell(currentRow,1).Value= item.Name;
                    worksheet.Cell(currentRow,2).Value= item.Director;
                    worksheet.Cell(currentRow,3).Value= item.CategoryName;
                    worksheet.Cell(currentRow,4).Value= item.ImdbRate;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreedsheetml.sheet", "Filmler.xlsx");
                }
            }
        }

    }
}