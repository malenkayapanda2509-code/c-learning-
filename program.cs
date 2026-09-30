using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    public string Name { get; set; }

    public double TargetAverage { get; set; }

    public List<Subject> Subjects { get; set; }

    public Student(string name)
    {
        Name = name;
        TargetAverage = 4.5;
        Subjects = new List<Subject>();
    }

    public double GetAverage()
    {
        var allGrades = GetAllGrades();

        if (allGrades.Count == 0)
        {
            return 0;
        }

        return allGrades.Average();
    }

    public List<int> GetAllGrades()
    {
        var grades = new List<int>();

        foreach (var subject in Subjects)
        {
            grades.AddRange(subject.Grades);
        }

        return grades;
    }

    public int GetTotalGrades()
    {
        return GetAllGrades().Count;
    }

    public Subject GetBestSubject()
    {
        if (Subjects.Count == 0)
        {
            return null;
        }

        return Subjects
            .OrderByDescending(subject => subject.GetAverage())
            .First();
    }

    public Subject GetWeakestSubject()
    {
        if (Subjects.Count == 0)
        {
            return null;
        }

        return Subjects
            .OrderBy(subject => subject.GetAverage())
            .First();
    }

    public int GetExcellentGrades()
    {
        return GetAllGrades().Count(grade => grade == 5);
    }

    public int GetGoodGrades()
    {
        return GetAllGrades().Count(grade => grade == 4);
    }

    public int GetAverageGrades()
    {
        return GetAllGrades().Count(grade => grade == 3);
    }

    public int GetBadGrades()
    {
        return GetAllGrades().Count(grade => grade <= 2);
    }

    public string GetLevel()
    {
        var average = GetAverage();

        if (average >= 4.8)
        {
            return "🏆 Отличник";
        }

        if (average >= 4.5)
        {
            return "🌟 Сильный студент";
        }

        if (average >= 4.0)
        {
            return "📚 Хороший студент";
        }

        if (average >= 3.5)
        {
            return "📖 Стабильный студент";
        }

        if (average >= 3.0)
        {
            return "🌱 Есть куда расти";
        }

        return "💪 Нужен дополнительный фокус";
    }

    public bool HasReachedTarget()
    {
        return GetAverage() >= TargetAverage;
    }
}
