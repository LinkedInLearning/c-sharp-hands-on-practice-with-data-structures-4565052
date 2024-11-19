class Program
{
  static void Main()
  {
    string rootDirectory = @"C:\Your\Directory\Path";
    SystemNavigator navigator = new SystemNavigator(rootDirectory);

    navigator.TraverseDirectory();
  }
}