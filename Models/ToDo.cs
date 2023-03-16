namespace DemoAPI.Models;

public class ToDo
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool? IsCompleted { get; set; }
    public int CategoryId { get; set; }
   // public Category? Category { get; set; }
}

public class Category
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public List<ToDo>? ToDoList { get; set; }
}