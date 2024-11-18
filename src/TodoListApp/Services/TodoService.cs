using TodoListApp.Models;

namespace TodoListApp.Services
{
  public class TodoService
  {
    private TodoItem[] _tasks = new TodoItem[10];
    private int _count = 0;

    public IEnumerable<TodoItem> GetAll()
    {
      return _tasks.Take(_count);
    }

    public void Add(TodoItem todoItem)
    {
      if (_count == _tasks.Length)
      {
        ResizeArray();
      }
      todoItem.Id = _count;
      _tasks[_count] = todoItem;
      _count++;
    }

    public void Delete(int id)
    {
      for (int i = 0; i < _count; i++)
      {
        if (_tasks[i].Id == id)
        {
          for (int j = i; j < _count - 1; j++)
          {
            _tasks[j] = _tasks[j + 1];
          }
          _tasks[_count - 1] = null;
          _count--;
          break;
        }
      }
    }

    private void ResizeArray() {
      var newArray = new TodoItem[_tasks.Length * 2];
      Array.Copy(_tasks, newArray, _tasks.Length);
      _tasks = newArray;
    }
  }
}