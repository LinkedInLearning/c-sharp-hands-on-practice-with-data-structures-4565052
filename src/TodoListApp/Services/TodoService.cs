using TodoListApp.Models;

namespace TodoListApp.Services
{
  public class TodoService
  {
    private List<TodoItem> _tasks = new List<TodoItem>();

    public IEnumerable<TodoItem> GetAll()
    {
      return _tasks;
    }

    public void Add(TodoItem todoItem)
    {
      todoItem.Id = _tasks.Count;
      _tasks.Add(todoItem);
    }

    public void Delete(int id)
    {
      var item = _tasks.FirstOrDefault(t => t.Id == id);
      if (item != null) {
        _tasks.Remove(item);
      }
    }
  }
}