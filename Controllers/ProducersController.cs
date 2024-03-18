using EcommerceCenima.Data;
using EcommerceCenima.Data.Services;
using EcommerceCenima.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceCenima.Controllers
{
	public class ProducersController : Controller
	{
        private readonly IproducerServices producerServices;

        public ProducersController(IproducerServices producerServices)
        {
            this.producerServices = producerServices;
        }

        public async Task<IActionResult> Index()
        {
            var data = await producerServices.GetAllAsync();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,Bio,PicUrl")] Producer producer)
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
            await producerServices.AddAsync(producer);
            return RedirectToAction("Index");

        }
        public async Task<ActionResult> Details(int id)
        {
            var producer = await producerServices.DetailsAsync(id);
            if (producer == null)
            {
                return View("NotFound");
            }
            return View(producer);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var producer = await producerServices.DetailsAsync(id);
            if (producer == null)
            {
                return View("NotFound");
            }
            return View(producer);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Producer producer)
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
            await producerServices.EditAsync(id, producer);
            return RedirectToAction("Index");

        }
        public async Task<IActionResult> Delete(int id)
        {
            var producer = await producerServices.DetailsAsync(id);
            if (producer == null)
            {
                return View("NotFound");
            }
            return View(producer);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actor = await producerServices.DetailsAsync(id);
            if (actor == null)
            {
                return View("NotFound");
            }
            await producerServices.DeleteAsync(id);
            return RedirectToAction("Index");

        }
    }
}
