using Microsoft.EntityFrameworkCore;

namespace Movies.Client.Data
{
    public class MoviesClientContext : DbContext
    {
        public MoviesClientContext (DbContextOptions<MoviesClientContext> options)
            : base(options)
        {
        }

        public DbSet<Movies.Client.Models.Movie> Movie { get; set; }
    }
}
