namespace TextEditorApp.Services
{
  public class TextEditorService
  {
    private string _currentText = string.Empty;
    private Stack<string> _undoStack = new Stack<string>();

    public string GetText() => _currentText;

    public void SaveText(string newText)
    {
      _undoStack.Push(_currentText);
      _currentText += newText;

    }

    public void ClearText()
    {
      _undoStack.Push(_currentText);
      _currentText = string.Empty;
    }

    public bool Undo()
    {
      if (_undoStack.Count != 0)
      {
        _currentText = _undoStack.Pop();
        return true;
      }
      return false;
    }

    public bool Redo()
    {
      return true;
    }
  }
}
