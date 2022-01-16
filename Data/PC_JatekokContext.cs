using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PC_Jatekok.Models;

namespace PC_Jatekok.Data
{
    public class PC_JatekokContext : DbContext
    {
        public PC_JatekokContext (DbContextOptions<PC_JatekokContext> options)
            : base(options)
        {
        }

        public DbSet<PC_Jatekok.Models.Jatek> Jatek { get; set; }
    }
}
