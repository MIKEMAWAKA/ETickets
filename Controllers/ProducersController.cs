using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ETickets.Data
{
    public class ProducersController : Controller
    {
        private readonly AppDbContext dbContext;

        public ProducersController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var data = await dbContext.Producers.ToListAsync();
            return View(data);
        }

        [HttpGet]
        [Route("api/producers")]
        public async Task<IActionResult> Get()
        {


            var data = await dbContext.Producers.ToListAsync();
            return Ok(data);
        }
    }
}

