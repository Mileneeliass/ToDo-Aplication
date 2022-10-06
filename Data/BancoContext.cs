using Microsoft.EntityFrameworkCore;
using ToDo_Aplication.Models;

namespace ToDo_Aplication.Data
{
 
    public class BancoContext : DbContext 
    {
        public DbSet<ToDoModel> ToDo { get; set; }      
        public BancoContext(DbContextOptions<BancoContext> options) : base(options){ }
   

    }
}
