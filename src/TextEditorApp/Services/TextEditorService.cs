namespace TextEditorApp.Services
{
  public class TextEditorService
  {
    private string _currentText = string.Empty;
    private Stack<string> _undoStack = new Stack<string>();
    private Stack<string> _redoStack = new Stack<string>();

    public string GetText() => _currentText;

    public void SaveText(string newText)
    {
      _undoStack.Push(_currentText);
      _currentText += newText;
      _redoStack.Clear();
    }

    public void ClearText()
    {
      _undoStack.Push(_currentText);
      _currentText = string.Empty;
      _redoStack.Clear();
    }

    public bool Undo()
    {
      if (_undoStack.Count != 0)
      {
        _redoStack.Push(_currentText);
        _currentText = _undoStack.Pop();
        return true;
      }
      return false;
    }

    public bool Redo()
    {
      if (_redoStack.Count > 0)
      {
        _undoStack.Push(_currentText);
        _currentText = _redoStack.Pop();
        return true;
      }
      return false;
    }
  }
}
