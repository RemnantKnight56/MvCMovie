using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvCMovie.Models;

namespace MvCMovie.Data
{
    public class MvCMovieContext : DbContext
    {
        public MvCMovieContext (DbContextOptions<MvCMovieContext> options)
            : base(options)
        {
        }

        public DbSet<MvCMovie.Models.Movie> Movie { get; set; } = default!;
    }
}
