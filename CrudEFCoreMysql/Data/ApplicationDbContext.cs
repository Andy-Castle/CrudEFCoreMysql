using CrudEFCoreMysql.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudEFCoreMysql.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
                
        }


        public DbSet<Producto> Producto { get; set; }
    }
}
