using System;

class Program
{
  static void Main(string[] args)
  {
    Student student = new Student("Alice");

    student.AddGrade(50);
    student.AddGrade(85);
    student.AddGrade(95);

    student.RemoveFailingGrades();

    student.DisplayGrades();
  }
}
