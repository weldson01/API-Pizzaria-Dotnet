
using Microsoft.EntityFrameworkCore;
using PizzariaAPI.model;

namespace PizzariaAPI.context
{
    public class PizzariaContext: DbContext
    {
        public PizzariaContext(DbContextOptions<PizzariaContext> options):base(options)
        {
        }

        public DbSet<Pizza> pizzas{ get; set; }
    }
}