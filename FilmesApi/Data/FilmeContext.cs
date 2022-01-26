using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Data
{
    public class FilmeContext : DbContext
    {
        public FilmeContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Filme> Filmes { get; set; }
    }
}