class Program
{
  static void Main()
  {
    BrowserHistoryNavigator navigator = new BrowserHistoryNavigator();
    navigator.visitWebsite("https://stackoverflow.com");
    navigator.visitWebsite("https://linkedin.com");
    navigator.visitWebsite("https://google.com");

    Console.WriteLine(navigator.getCurrentWebsite());

    navigator.backToPreviousWebsite();

    Console.WriteLine(navigator.getCurrentWebsite());

    navigator.backToPreviousWebsite();
    navigator.backToPreviousWebsite();
    navigator.backToPreviousWebsite();

    Console.WriteLine(navigator.getCurrentWebsite());
  }
}