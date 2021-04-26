using CoffeeRoastManagement.Shared.Entities;
using CoffeeRoastManagement.Server.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeRoastManagement.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CuppingController : ControllerBase
    {
        private readonly RoastDbContext _context;
        private readonly ILogger _logger;

        public CuppingController(RoastDbContext context, ILogger<CuppingController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Cupping> Get()
        {
            var cuppings = _context.Cuppings.ToList();
            return cuppings.ToArray();
        }

        [HttpGet("{id}")]
        public Cupping Get(int id)
        {
            var cupping = _context.Cuppings.FirstOrDefault(x => x.Id == id);
            return cupping;
        }

        [HttpPut]
        public void Put(Cupping cupping)
        {
            _logger.LogInformation("Update cupping: {cupping}");
            _context.Entry(cupping).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

        }

        [HttpPost]
        public int Post(Cupping cupping)
        {
            _context.Add<Cupping>(cupping);
            _context.SaveChanges();
            return cupping.Id;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var cupping = new Cupping { Id = id };
            _context.Remove(cupping);
            _context.SaveChanges();
        }
    }
}
