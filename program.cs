using System.Collections.Generic;
using System.Linq;

public class Student
{
    public string Name { get; set; }
    public double TargetAverage { get; set; }
    public List<Subject> Subjects { get; set; }
    public List<int> GradeHistory { get; set; }
    public List<ScheduleItem> Schedule { get; set; }
    public int XP { get; set; }

    public Student()
    {
        Name = "";
        TargetAverage = 4.5;
        Subjects = new List<Subject>();
        GradeHistory = new List<int>();
        Schedule = new List<ScheduleItem>();
        XP = 0;
    }

    public Student(string name)
    {
        Name = name;
        TargetAverage = 4.5;
        Subjects = new List<Subject>();
        GradeHistory = new List<int>();
        Schedule = new List<ScheduleItem>();
        XP = 0;
    }

    public List<int> GetAllGrades()
    {
        var grades = new List<int>();

        foreach (var subject in Subjects)
            grades.AddRange(subject.Grades);

        return grades;
    }

    public double GetAverage()
    {
        var grades = GetAllGrades();

        if (grades.Count == 0)
            return 0;

        return grades.Average();
    }

    public int GetTotalGrades()
    {
        return GetAllGrades().Count;
    }

    public int GetExcellentGrades()
    {
        return GetAllGrades().Count(x => x == 5);
    }

    public int GetGoodGrades()
    {
        return GetAllGrades().Count(x => x == 4);
    }

    public int GetAverageGrades()
    {
        return GetAllGrades().Count(x => x == 3);
    }

    public int GetBadGrades()
    {
        return GetAllGrades().Count(x => x <= 2);
    }

    public Subject GetBestSubject()
    {
        if (Subjects.Count == 0)
            return null;

        return Subjects
            .Where(x => x.Grades.Count > 0)
            .OrderByDescending(x => x.GetAverage())
            .FirstOrDefault();
    }

    public Subject GetWeakestSubject()
    {
        if (Subjects.Count == 0)
            return null;

        return Subjects
            .Where(x => x.Grades.Count > 0)
            .OrderBy(x => x.GetAverage())
            .FirstOrDefault();
    }

    public bool HasReachedTarget()
    {
        return GetAverage() >= TargetAverage;
    }

    public int GetTotalTasks()
    {
        return Subjects.Sum(x => x.GetTotalTasks());
    }

    public int GetCompletedTasks()
    {
        return Subjects.Sum(x => x.GetCompletedTasks());
    }

    public void AddXP(int amount)
    {
        XP += amount;
    }

    public int GetLevel()
    {
        return XP / 100 + 1;
    }

    public int GetLevelProgress()
    {
        return XP % 100;
    }
}
