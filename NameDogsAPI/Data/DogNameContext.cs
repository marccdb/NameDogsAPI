using DataLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace NameDogsAPI.Data
{
    public class DogNameContext : DbContext
    {
        public DogNameContext(DbContextOptions<DogNameContext> options) : base(options)
        {

        }

        public DbSet<Dog> Dogs { get; set; }



    }
}
