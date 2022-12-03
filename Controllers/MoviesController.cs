using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ETickets.Data;
using ETickets.Data.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ETickets.Controllers
{
    public class MoviesController : Controller
    {
        private readonly AppDbContext dbContext;

        public MoviesController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {

            var movies = await dbContext.Movies.Include(n=>n.Cinema).OrderBy(b => b.Name).ToListAsync();
            return View(movies);
        }


        [HttpGet]
        [Route("api/movies")]
        public async Task<IActionResult> Get()
        {
            var options = new JsonSerializerOptions()
            {
                MaxDepth = 0,
                IgnoreNullValues = true,
                IgnoreReadOnlyProperties = true
            };

           

            var movies = await dbContext.Movies.Include(n => n.Cinema).OrderBy(b => b.Name).ToListAsync();

            //var objstr = JsonSerializer.Serialize(movies, options);
            return Ok(movies);
        }
    }
}

