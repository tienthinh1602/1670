using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using test01MVC.Models;

namespace test01MVC.Data
{
    public class test01MVCContext : DbContext
    {
        public test01MVCContext (DbContextOptions<test01MVCContext> options)
            : base(options)
        {
        }

        public DbSet<test01MVC.Models.Ticket> Ticket { get; set; } = default!;
    }
}
