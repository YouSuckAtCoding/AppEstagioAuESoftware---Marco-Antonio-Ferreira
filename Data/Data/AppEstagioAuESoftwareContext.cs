using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace Data.Data
{
    public class AppEstagioAuESoftwareContext : DbContext
    {
        public AppEstagioAuESoftwareContext (DbContextOptions<AppEstagioAuESoftwareContext> options)
            : base(options)
        {
        }

        public DbSet<Domain.Models.Usuario> Usuario { get; set; }
    }
}
