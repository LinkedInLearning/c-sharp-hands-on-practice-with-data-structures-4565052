namespace TodoListApp.Models
{
  public class TodoItem
  {
    public int Id { get; set; }
    public string Description { get; set; }

    public TodoItem(string description)
    {
      Description = description ?? throw new ArgumentNullException(nameof(description));
    }
  }
}
