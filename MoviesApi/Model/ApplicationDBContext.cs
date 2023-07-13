using Microsoft.EntityFrameworkCore;

namespace MoviesApi.Model
{
    public class ApplicationDBContext :DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
                
        }
        public DbSet<Genera> Generas { get; set; }

    }
}
