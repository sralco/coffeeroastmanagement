using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeRoastManagement.Shared.Entities;

namespace CoffeeRoastManagement.Server.Entities
{
    public class RoastDbContext : DbContext
    {
        public RoastDbContext(DbContextOptions<RoastDbContext> options) : base(options) {

        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<GreenBeanInfo> GreenBeanInfos { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<GreenBlend> GreenBlends { get; set; }
        public DbSet<Roast> Roasts { get; set; }
        public DbSet<Cupping> Cuppings { get; set; }

    }
}
