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
    public class GreenBeanInfoController : ControllerBase
    {
        private readonly RoastDbContext _context;
        private readonly ILogger _logger;

        public GreenBeanInfoController(RoastDbContext context, ILogger<GreenBeanInfoController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<GreenBeanInfo> Get()
        {
            var greenBeanInfos = _context.GreenBeanInfos.ToList();
            return greenBeanInfos.ToArray();
        }

        [HttpGet("{id}")]
        public GreenBeanInfo Get(int id)
        {
            var greenBeanInfo = _context.GreenBeanInfos.FirstOrDefault(x => x.Id == id);
            return greenBeanInfo;
        }

        [HttpPut]
        public void Put(GreenBeanInfo greenBeanInfo)
        {
            _logger.LogInformation("Update GreenBeanInfo: {greenBeanInfo}");
            _context.Entry(greenBeanInfo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

        }

        [HttpPost]
        public int Post(GreenBeanInfo greenBeanInfo)
        {
            _context.Add<GreenBeanInfo>(greenBeanInfo);
            _context.SaveChanges();
            return greenBeanInfo.Id;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var greenBeanInfo = new GreenBeanInfo { Id = id };
            _context.Remove(greenBeanInfo);
            _context.SaveChanges();
        }
    }
}
