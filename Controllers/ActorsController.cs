using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETickets.Data;
using ETickets.Data.Service;
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


        public  IActionResult Create()
        {
      


            return View();
        }



    }
}

