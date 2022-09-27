using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieManager.Models;

namespace MovieManager.Data
{
    public class MovieManagerContext : DbContext
    {
        public MovieManagerContext (DbContextOptions<MovieManagerContext> options)
            : base(options)
        {
        }

        public DbSet<MovieManager.Models.Movie> Movie { get; set; } = default!;
    }
}
