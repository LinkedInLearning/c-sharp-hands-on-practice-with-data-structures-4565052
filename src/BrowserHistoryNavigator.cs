using System.Collections.Generic;

class BrowserHistoryNavigator
{
  private Stack<string> browserHistory = new Stack<string>();

  public void visitWebsite(website)
  {
    browserHistory.Push(website);
  }

  public void backToPreviousWebsite()
  {
    if (browserHistory.Count > 0)
    {
      browserHistory.Pop();
    }
  }

  public string getCurrentWebsite()
  {
    if (browserHistory.Count > 0)
    {
      return browserHistory.Peek();
    }
  }
}