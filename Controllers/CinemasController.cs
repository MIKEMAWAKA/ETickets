using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ETickets.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ETickets.Controllers
{
    public class CinemasController : Controller
    {
        private readonly AppDbContext dbContext;

        public CinemasController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var cinemas = await dbContext.Cinemas.ToListAsync();
            return View(cinemas);
        }

        [HttpGet]
        [Route("api/cinemas")]
        public async Task<IActionResult> Get()
        {


            var cinemas = await dbContext.Cinemas.ToListAsync();
            return Ok(cinemas);
        }
    }
}

