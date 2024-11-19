class Program
{
  static void Main()
  {
    PrintJobProcessor processor = new PrintJobProcessor();

    processor.AddJob("Document1.pdf");
    processor.AddJob("Document2.pdf");
    processor.AddJob("Document3.pdf");

    processor.ProcessPrintJobs();

    processor.AddJob("Document4.pdf");
    processor.AddJob("Document5.pdf");

    Console.WriteLine($"Printing document: {processor.GetNextPrintJob()}");

    processor.ClearJobs();

    processor.AddJob("Document6.pdf");

    processor.ProcessPrintJobs();
  }
}
