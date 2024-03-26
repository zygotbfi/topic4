using System;

class Student
{
    public string Name;
    public double ScienceGrade;
    public double MathGrade;
    public double EnglishGrade;
    public double AverageGrade
    {
        get
        {
            return (ScienceGrade + MathGrade + EnglishGrade) / 3;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter total students:");
        int totalStudents = int.Parse(Console.ReadLine());
        Student[] students = new Student[totalStudents];

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\nWelcome to the Student Grades System!");
            Console.WriteLine("[1] Enroll Students");
            Console.WriteLine("[2] Enter Student Grades");
            Console.WriteLine("[3] Show Student Grades");
            Console.WriteLine("[4] Show Top Student");
            Console.WriteLine("[5] Exit");
            Console.Write("Enter Choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    EnrollStudents(students);
                    break;
                case 2:
                    EnterStudentGrades(students);
                    break;
                case 3:
                    ShowStudentGrades(students);
                    break;
                case 4:
                    ShowTopStudent(students);
                    break;
                case 5:
                    Console.WriteLine("\nBye!");
                    exit = true;
                    break;
                default:
                    Console.WriteLine("\nError: Invalid choice. Please enter a number between 1 and 5.");
                    break;
            }
        }
    }

    static void EnrollStudents(Student[] students)
    {
        for (int i = 0; i < students.Length; i++)
        {
            Console.Write("Enter student name: ");
            string name = Console.ReadLine();
            students[i] = new Student { Name = name };
            if (i < students.Length - 1)
            {
                Console.Write("Enter Again[Y/N]: ");
                char again = char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine();
                if (again != 'Y')
                    break;
            }
        }
    }

    static void EnterStudentGrades(Student[] students)
    {
        foreach (var student in students)
        {
            Console.WriteLine($"\nStudent: {student.Name}");
            Console.Write("Enter grade for Science: ");
            student.ScienceGrade = double.Parse(Console.ReadLine());
            Console.Write("Enter grade for Math: ");
            student.MathGrade = double.Parse(Console.ReadLine());
            Console.Write("Enter grade for English: ");
            student.EnglishGrade = double.Parse(Console.ReadLine());

            Console.Write("Enter Again[Y/N]: ");
            char again = char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();
            if (again != 'Y')
                break;
        }
    }

    static void ShowStudentGrades(Student[] students)
    {
        Console.WriteLine("\nStudent Grades");
        Console.WriteLine("Name\t\tScience\tMath\tEnglish\tAve.");
        foreach (var student in students)
        {
            Console.WriteLine($"{student.Name}\t\t{student.ScienceGrade}\t{student.MathGrade}\t{student.EnglishGrade}\t{student.AverageGrade}");
        }
    }

    static void ShowTopStudent(Student[] students)
    {
        double maxAverage = double.MinValue;
        Student topStudent = null;
        foreach (var student in students)
        {
            if (student.AverageGrade > maxAverage)
            {
                maxAverage = student.AverageGrade;
                topStudent = student;
            }
        }
        Console.WriteLine($"\nTop Student: {topStudent.Name}");
    }
}
