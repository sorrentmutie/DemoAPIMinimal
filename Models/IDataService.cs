namespace DemoAPI.Models;

public interface IDataService
{
    Task<IEnumerable<ToDo>> GetAllAsync();
    Task<ToDo> CreateAsync(ToDo toDo);
    Task<Category> CreateCategoryAsync(Category category);
    Task<IEnumerable<Category>> GetAllCategoriesAsync();
    Task UpdateAsync(int id, ToDo toDo);
    Task<ToDo?> GetByIdAsync(int id);
}
