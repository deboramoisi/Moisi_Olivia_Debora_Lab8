using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moisi_Olivia_Debora_Lab8.Models;

namespace Moisi_Olivia_Debora_Lab8.Data
{
    public class Moisi_Olivia_Debora_Lab8Context : DbContext
    {
        public Moisi_Olivia_Debora_Lab8Context (DbContextOptions<Moisi_Olivia_Debora_Lab8Context> options)
            : base(options)
        {
        }

        public DbSet<Moisi_Olivia_Debora_Lab8.Models.Book> Book { get; set; }

        public DbSet<Moisi_Olivia_Debora_Lab8.Models.Publisher> Publisher { get; set; }

        public DbSet<Moisi_Olivia_Debora_Lab8.Models.Category> Category { get; set; }
    }
}
