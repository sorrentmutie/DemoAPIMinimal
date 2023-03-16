using Microsoft.EntityFrameworkCore;
namespace DemoAPI.Models
{
    public class ToDoDbContext: DbContext
    {
        public ToDoDbContext(DbContextOptions<ToDoDbContext> opzioni) : base(opzioni)
        {
           
        }

        public DbSet<ToDo> Todos => Set<ToDo>();
        public DbSet<Category> Categories => Set<Category>();
    }
}
