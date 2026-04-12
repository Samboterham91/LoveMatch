using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LoveMatch.Models;

namespace LoveMatch.Data
{
    class AppDbContext : DbContext
    {
          public DbSet<Profile> Profiles { get; set; }
           
          public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
          {

          }
    }
}
