using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
  public string Name { get; set; }
  private List<int> grades;

  public Student(string name)
  {
    Name = name;
    grades = new List<int>();
  }

  public void AddGrade(int grade)
  {
    grades.Add(grade);
    // grades.Insert(0, 90);
    // grades.AddRange(new List<int> {75, 88 });
  }

  public void RemoveFailingGrades()
  {
    grades.RemoveAll(grade => grade < 60);
    // Remove()
    // RemoveAt()
    // Clear()
  }

  public double CalculateAverage()
  {
    return grades.Count > 0 ? grades.Average() : 0;
  }


  public bool HasFailingGrade()
  {
    // grades.Contains(60);
    return grades.Any(grade => grade < 60);
    // for(int i = 0; i < grades.Count; i++) {
    //   if(grades[i] < 60) {
    //     return true;
    //   }
    // }
    // return false;
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