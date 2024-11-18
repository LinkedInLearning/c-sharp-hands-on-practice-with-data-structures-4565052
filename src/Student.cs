using System;
using System.Collections.Generic;

class Student
{
  public string Name { get; set; }

  public Student(string name)
  {
    Name = name;
  }

  public void AddGrade(int grade)
  {

  }

  public void RemoveFailingGrades()
  {

  }

  public double CalculateAverage()
  {

  }


  public bool HasFailingGrade()
  {

  }

  public bool HasPassed()
  {
    return CalculateAverage() >= 60;
  }

  public void DisplayGrades()
  {
    Console.WriteLine($"{Name}'s grades: {string.Join(", ", grades)}");
    Console.WriteLine($"Average grade: {CalculateAverage():F2}");
    Console.WriteLine(HasPassed() ? "Status: Passed" : "Status: Failed");
    Console.WriteLine($"Has Failing Grade? {HasFailingGrade():F2}");
  }
}