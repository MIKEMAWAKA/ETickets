﻿using System;
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
            var data = await actorService.GetActors();


            return View(data);
        }

        // [BindProperty] 
        // public Actor AddRequest {get;set;}
      


        public  IActionResult Create()
        {
      


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL,FullName,Bio")] Actor actor){

            if(ModelState.IsValid)
            {
               
              await  actorService.AddActor(actor);
                return RedirectToAction(nameof(Index));
            
        
              
                Console.Write("ACTORSSS");

            }
            else
            {
                return View(actor);


            }
        

        }


        public async Task<IActionResult> Details(int id)
        {


            var actor = await actorService.GetActor(id);

            if (actor == null) return View("NotFound");

            return View(actor);

        }



        public async Task<IActionResult> Edit(int id)
        {


            var actor = await actorService.GetActor(id);

            if (actor == null) return View("NotFound");

            return View(actor);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([Bind("Id,ProfilePictureURL,FullName,Bio")] int id,Actor actor)
        {

            if (ModelState.IsValid)
            {

                await actorService.UpdateActor(id,actor);
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


            var actor = await actorService.GetActor(id);

            if (actor == null) return View("NotFound");

            return View(actor);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed( int id)
        {

            var actor = await actorService.GetActor(id);

            if (actor == null) return View("NotFound");

            await actorService.DeleteActor(id);
            return RedirectToAction(nameof(Index));


        }




    }



}

