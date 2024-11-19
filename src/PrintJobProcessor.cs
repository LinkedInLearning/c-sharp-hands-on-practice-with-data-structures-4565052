using System;
using System.Collections.Generic;

class PrintJobProcessor
{

  private Queue<string> printQueue = new Queue<string>();

  public void AddJob(string documentName)
  {
    printQueue.Enqueue(documentName);
  }

  public void ProcessPrintJobs()
  {
    // TryDequeue(out result)
    while(printQueue.Count > 0) {
      string documentName = printQueue.Dequeue();
      Console.WriteLine($"Printing document: {documentName}");
    }
  }

  public string GetNextPrintJob()
  {
    // return printQueue.Count > 0 ? printQueue.Peek() : null;
    return printQueue.TryPeek(out string document) ? document : null;
  }

  public void ClearJobs()
  {
    printQueue.Clear();
  }
}
