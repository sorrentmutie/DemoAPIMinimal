using Microsoft.EntityFrameworkCore;

namespace DemoAPI.Models
{
    public class DataService : IDataService
    {
        private readonly ToDoDbContext database;

        public DataService(ToDoDbContext database)
        {
            this.database = database;
        }

        public async Task<ToDo> CreateAsync(ToDo toDo)
        {
            database.Add(toDo);
            await database.SaveChangesAsync();
            return toDo;
        }

        public async Task<Category> CreateCategoryAsync(Category category)
        {
            database.Categories.Add(category);
            await database.SaveChangesAsync();
            return category;
            //database.Add(category),
        }

        public async Task<IEnumerable<ToDo>> GetAllAsync()
        {
            return await database.Todos.ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await database.Categories.ToListAsync();
        }

        public async Task<ToDo?> GetByIdAsync(int id)
        {
            return await database.Todos.FindAsync(id);
        }

        public async Task UpdateAsync(int id, ToDo toDo)
        {
            var toDoDatabase = await database.Todos.FindAsync(id);
            if(toDoDatabase != null)
            {
                toDoDatabase.Name = toDo.Name;
                toDoDatabase.IsCompleted = toDo.IsCompleted;
                await database.SaveChangesAsync();
            }
        }
    }
}
