using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AT_Guilherme_Duques.Models;

namespace AT_Guilherme_Duques.Data
{
    public class AT_Guilherme_DuquesContext : DbContext
    {
        public AT_Guilherme_DuquesContext (DbContextOptions<AT_Guilherme_DuquesContext> options)
            : base(options)
        {
        }

        public DbSet<AT_Guilherme_Duques.Models.Pessoa> Pessoa { get; set; }
    }
}
