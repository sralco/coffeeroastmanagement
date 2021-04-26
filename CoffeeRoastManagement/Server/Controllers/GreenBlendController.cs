using CoffeeRoastManagement.Shared.Entities;
using CoffeeRoastManagement.Server.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CoffeeRoastManagement.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GreenBlendController : ControllerBase
    {
        private readonly RoastDbContext _context;
        private readonly ILogger _logger;

        public GreenBlendController(RoastDbContext context, ILogger<GreenBlendController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<GreenBlend> Get()
        {
            var greenBlend = _context.GreenBlends.Include(x => x.StockItem).ThenInclude(x => x.GreenBeanInfo).Include(x => x.StockItem.SellerContact).ToList();
            return greenBlend.ToArray();
        }

        [HttpGet("{id}")]
        public GreenBlend Get(int id)
        {
            var greenBlend = _context.GreenBlends.Include(x => x.StockItem).FirstOrDefault(x => x.Id == id);
            return greenBlend;
        }

        [HttpPut]
        public void Put(GreenBlend greenBlend)
        {
            _logger.LogInformation("Update GreenBeanInfo: {greenBeanInfo}");
            _context.Entry(greenBlend).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

        }

        [HttpPost]
        public int Post(GreenBlend greenBlend)
        {
            greenBlend.StockItem = _context.Stocks.FirstOrDefault(x => x.Id == greenBlend.StockItem.Id);
            _context.Add<GreenBlend>(greenBlend);
            _context.SaveChanges();
            return greenBlend.Id;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var greenBlend = new GreenBlend { Id = id };
            _context.Remove(greenBlend);
            _context.SaveChanges();
        }
    }
}
