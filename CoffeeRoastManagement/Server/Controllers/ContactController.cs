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
    public class ContactController : ControllerBase
    {
        private readonly RoastDbContext _context;
        private readonly ILogger _logger;

        public ContactController(RoastDbContext context, ILogger<ContactController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Contact> Get()
        {
            var contacts = _context.Contacts.ToList();
            return contacts.ToArray();
        }

        [HttpGet("{id}")]
        public Contact Get(int id)
        {
            var contact = _context.Contacts.FirstOrDefault(x => x.Id == id);
            return contact;
        }

        [HttpPut]
        public void Put(Contact contact)
        {
            _logger.LogInformation("Update contact: {contact}");
            _context.Entry(contact).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

        }

        [HttpPost]
        public Int64 Post(Contact contact)
        {
            _context.Add<Contact>(contact);
            _context.SaveChanges();
            return contact.Id;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var contact = new Contact { Id = id };
            _context.Remove(contact);
            _context.SaveChanges();
        }
    }
}
