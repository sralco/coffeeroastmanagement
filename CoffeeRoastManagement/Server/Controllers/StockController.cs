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
    public class StockController : ControllerBase
    {
        private readonly RoastDbContext _context;
        private readonly ILogger _logger;

        public StockController(RoastDbContext context, ILogger<StockController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Stock> Get()
        {
            var stocks = _context.Stocks.Include(stock => stock.SellerContact).Include(stock => stock.GreenBeanInfo).ToList();
            return stocks.ToArray();
        }

        [HttpGet("{id}")]
        public Stock Get(int id)
        {
            var stock = _context.Stocks.Include(stock => stock.SellerContact).Include(stock => stock.GreenBeanInfo).FirstOrDefault(x => x.Id == id);
            return stock;
        }

        [HttpPut]
        public void Put(Stock stock)
        {
            _logger.LogInformation("Update stock information: {stock}");
            stock.GreenBeanInfo = _context.GreenBeanInfos.FirstOrDefault(x => x.Id == stock.GreenBeanInfo.Id);
            stock.SellerContact = _context.Contacts.FirstOrDefault(x => x.Id == stock.SellerContact.Id);
            _context.Entry(stock).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

        }

        [HttpPost]
        public int Post(Stock stock)
        {
            stock.GreenBeanInfo = _context.GreenBeanInfos.FirstOrDefault(x => x.Id == stock.GreenBeanInfo.Id);
            stock.SellerContact = _context.Contacts.FirstOrDefault(x => x.Id == stock.SellerContact.Id);
            _context.Add<Stock>(stock);
            _context.SaveChanges();
            return stock.Id;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var stock = new Stock { Id = id };
            _context.Remove(stock);
            _context.SaveChanges();
        }
    }
}
