using CoffeeRoastManagement.Shared;
using CoffeeRoastManagement.Server.Entities;
using CoffeeRoastManagement.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CoffeeRoastManagement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoastController : ControllerBase
    { 
        private readonly RoastDbContext _context;
        private readonly ILogger _logger;

        public RoastController(RoastDbContext context, ILogger<RoastController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Roast> Get()
        {
            var roasts = _context.Roasts.Include(x => x.CuppingInfo)
                                        .Include(x => x.Beans)
                                            .ThenInclude(y => y.StockItem).ThenInclude(z => z.GreenBeanInfo)
                                        .Include(x => x.Beans).ThenInclude(y => y.StockItem).ThenInclude(z => z.SellerContact); //.ThenInclude(z => z.GreenBeanInfo).Include(x => x.CuppingInfo).Include(x => x.Beans).ThenInclude(x => x.First().StockItem).ThenInclude(z => z.SellerContact);
            return roasts;
        }

        [HttpGet("{id}")]
        public Roast Get(int id)
        {
            var roast = _context.Roasts.Include(x => x.CuppingInfo)
                                        .Include(x => x.Beans)
                                            .ThenInclude(y => y.StockItem).ThenInclude(z => z.GreenBeanInfo)
                                        .Include(x => x.Beans).ThenInclude(y => y.StockItem).ThenInclude(z => z.SellerContact).FirstOrDefault(x => x.Id == id);
            return roast;
        }

        [HttpPut]
        public void Put(Roast roast)
        {
            _logger.LogInformation("Update roast information: {roast}");
            // get roast from database
            var dbRoasts = _context.Roasts.Include(x => x.Beans).ThenInclude(x => x.StockItem); 
            var dbRoast = dbRoasts.FirstOrDefault(x => x.Id == roast.Id);
            //List<GreenBlend> blendsToRemove = new List<GreenBlend>();
            // remove items, which are not yet needed anymore
            foreach (var bl in dbRoast.Beans)
            {
                if (!roast.Beans.Select(x => x.Id).Contains(bl.Id))
                {
                    //blendsToRemove.Add(bl);
                    var sbl = _context.GreenBlends.FirstOrDefault(x => x.Id == bl.Id);
                    _context.GreenBlends.Remove(sbl);
                }
            }
            _context.SaveChanges();

            List<GreenBlend> blend = new List<GreenBlend>();
            // add new items
            foreach (var bl in roast.Beans)
            {
                var b = _context.GreenBlends.FirstOrDefault(x => x.Id == bl.Id);
                blend.Add(b);
            }
            dbRoast.Beans = blend;
            _context.Entry(dbRoast).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

        }

        [HttpPost]
        public int Post(Roast roast)
        {
            if (roast.CuppingInfo != null)
            {
                roast.CuppingInfo = _context.Cuppings.FirstOrDefault(x => x.Id == roast.CuppingInfo.Id);
            }
            List<GreenBlend> blend = new List<GreenBlend>();
            roast.Beans.ForEach(x => blend.Add(_context.GreenBlends.FirstOrDefault(k => k.Id == x.Id)));
            roast.Beans.Clear();
            roast.Beans.AddRange(blend);
            _context.Add<Roast>(roast);
            _context.SaveChanges();
            return roast.Id;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var roast = _context.Roasts.Include(x => x.Beans).Include(x => x.CuppingInfo).FirstOrDefault(x => x.Id == id);
            if (roast.Beans != null) roast.Beans.ForEach(x => _context.GreenBlends.Remove(x));
            if (roast.CuppingInfo != null) _context.Remove(roast.CuppingInfo);
            _context.Remove(roast);
            _context.SaveChanges();
        }

    }
}
