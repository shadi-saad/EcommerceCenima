using EcommerceCenima.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceCenima.Controllers
{
	public class MoviesController : Controller
	{
		private readonly AppDbContext context;

		public MoviesController(AppDbContext context)
		{
			this.context = context;
		}
		public async Task<IActionResult> Index()
		{
			var movies = await context.Movies.Include(c=>c.Cinema).ToListAsync();
			return View(movies);
		}
	}
}
