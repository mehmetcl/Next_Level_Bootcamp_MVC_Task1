using MehmetCIL_Odev1.Models;
using Microsoft.EntityFrameworkCore;

namespace MehmetCIL_Odev1.Context
{
    public class NorthwindDbContext : DbContext
    {

        public   DbSet<Employee> Employees { get; set; }

       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = Northwind");
                base.OnConfiguring(optionsBuilder);
            }
         
        }
        public NorthwindDbContext(DbContextOptions<NorthwindDbContext> options) : base(options)
        {
            
        }


    }





}
