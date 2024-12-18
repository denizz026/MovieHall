using Microsoft.AspNetCore.Mvc;
using MovieHall.Data;
using MovieHall.Models;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace MovieHall.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        // Constructor: ILogger ve AppDbContext dependency injection ile al�n�yor
        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // Index Action: Vizyondaki filmler ve vizyona girecek filmleri veritaban�ndan al�r ve ViewData'ya ekler
        public IActionResult Index()
        {
            var vizyondakiler = _context.Movies.ToList(); // Movies tablosundan verileri al�yoruz
            var vizyonaGirecekler = _context.UpcomingMovies.ToList(); // UpcomingMovies tablosundan verileri al�yoruz

            // Verileri ViewData'ya ekliyoruz
            ViewData["Vizyondakiler"] = vizyondakiler;
            ViewData["VizyonaGirecekler"] = vizyonaGirecekler;

            return View();
        }

        // Privacy Action
        public IActionResult Privacy()
        {
            return View();
        }

        // Error Action: Hata sayfas�n� d�nd�r�r
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
