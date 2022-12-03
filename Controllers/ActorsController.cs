using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETickets.Data;
using ETickets.Data.Service;
using ETickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ETickets.Controllers
{
    public class ActorsController : Controller
    {
        private readonly AppDbContext dbContext;
        private readonly IActorService actorService;

        public ActorsController(AppDbContext dbContext,IActorService actorService)
        {
            this.dbContext = dbContext;
            this.actorService = actorService;
        }

        // GET: /<controller>/



        public async Task<IActionResult> Index()
        {
            var data = await actorService.GetAllAsync();


            return View(data);
        }


        [HttpGet]
        [Route("api/actors")]
        public async Task<IActionResult> Get()
        {

            var data = await actorService.GetAllAsync();
            return Ok(data);
        }

        // [BindProperty] 
        // public Actor AddRequest {get;set;}



        public  IActionResult Create()
        {
      


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL,FullName,Bio")] Actor actor){

            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await actorService.AddAsync(actor);
            return RedirectToAction(nameof(Index));


        }

        [HttpPost]
        [Route("api/actors")]
        public async Task<IActionResult> AddActor([FromBody] Actor actor)
        {
          


            var saveactor = new Actor()
            {

                ProfilePictureURL = actor.ProfilePictureURL,
                FullName = actor.FullName,
  
                Bio = actor.Bio

            

            };

            await actorService.AddAsync(saveactor);

            return Ok(saveactor);
        }



        public async Task<IActionResult> Details(int id)
        {


            var actor = await actorService.GetByIdAsync(id);

            if (actor == null) return View("NotFound");

            return View(actor);

        }



        public async Task<IActionResult> Edit(int id)
        {


            var actor = await actorService.GetByIdAsync(id);

            if (actor == null) return View("NotFound");

            return View(actor);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([Bind("Id,ProfilePictureURL,FullName,Bio")] int id,Actor actor)
        {

            if (ModelState.IsValid)
            {

                await actorService.UpdateAsync(id,actor);
                return RedirectToAction(nameof(Index));



                Console.Write("ACTORSSS");

            }
            else
            {
                return View(actor);


            }


        }



        public async Task<IActionResult> Delete(int id)
        {


            var actor = await actorService.GetByIdAsync(id);

            if (actor == null) return View("NotFound");

            return View(actor);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed( int id)
        {

            var actor = await actorService.GetByIdAsync(id);

            if (actor == null) return View("NotFound");

            await actorService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));


        }




    }



}

