using EcommerceCenima.Data;
using EcommerceCenima.Data.Services;
using EcommerceCenima.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace EcommerceCenima.Controllers
{
    public class ActorController : Controller
    {
        private readonly IActorService actorService;

        public ActorController(IActorService actorService)
        {
            this.actorService = actorService;
        }

        public  async Task<IActionResult> Index()
        {
            var data=await actorService.GetAllAsync();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
		public async Task<IActionResult> Create([Bind("FullName,Bio,PicUrl")]Actor actor)
		{
            if(!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                return View();
            }
             await actorService.AddAsync(actor);
            return RedirectToAction("Index");
			
		}
        public async Task<ActionResult> Details(int id)
        {
            var actor=await actorService.DetailsAsync(id);
            if(actor == null)
            {
                return View("NotFound");
            }
            return View(actor);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var actor = await actorService.DetailsAsync(id);
            if (actor == null)
            {
                return View("NotFound");
            }
            return View(actor);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id,Actor actor)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                return View();
            }
            await actorService.EditAsync(id,actor);
            return RedirectToAction("Index");

        }
		public async Task<IActionResult> Delete(int id)
		{
			var actor = await actorService.DetailsAsync(id);
			if (actor == null)
			{
				return View("NotFound");
			}
			return View(actor);
		}
		[HttpPost]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var actor = await actorService.DetailsAsync(id);
			if (actor == null)
			{
				return View("NotFound");
			}
            await actorService.DeleteAsync(id);
			return RedirectToAction("Index");

		}
	}
}
