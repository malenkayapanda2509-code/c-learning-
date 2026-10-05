using System;
using System.Collections.Generic;
using System.Linq;

public static class StatisticsService
{
    public static double GetAverage(Student student)
    {
        var grades = student.GetAllGrades();

        if (grades.Count == 0)
        {
            return 0;
        }

        return grades.Average();
    }

    public static double GetFivePercentage(Student student)
    {
        var grades = student.GetAllGrades();

        if (grades.Count == 0)
        {
            return 0;
        }

        var fives = grades.Count(grade => grade == 5);

        return fives * 100.0 / grades.Count;
    }

    public static double GetFourPercentage(Student student)
    {
        var grades = student.GetAllGrades();

        if (grades.Count == 0)
        {
            return 0;
        }

        var fours = grades.Count(grade => grade == 4);

        return fours * 100.0 / grades.Count;
    }

    public static Subject GetBestSubject(Student student)
    {
        if (student.Subjects.Count == 0)
        {
            return null;
        }

        return student.Subjects
            .OrderByDescending(
                subject => subject.GetAverage())
            .First();
    }

    public static Subject GetWeakestSubject(Student student)
    {
        if (student.Subjects.Count == 0)
        {
            return null;
        }

        return student.Subjects
            .OrderBy(
                subject => subject.GetAverage())
            .First();
    }

    public static void ShowChart(Student student)
    {
        Console.WriteLine("📊 УСПЕВАЕМОСТЬ");
        Console.WriteLine();

        foreach (var subject in student.Subjects)
        {
            var average = subject.GetAverage();

            var blocks = (int)Math.Round(average * 2);

            var filled = new string('█', blocks);
            var empty = new string('░', 10 - blocks);

            Console.WriteLine(
                $"{subject.Name,-20} " +
                $"{filled}{empty} " +
                $"{average:F2}");
        }
    }
}
