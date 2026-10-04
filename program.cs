using System;

public class ScheduleItem
{
    public string Day { get; set; }

    public string Time { get; set; }

    public string Subject { get; set; }

    public string Teacher { get; set; }

    public string Room { get; set; }

    public ScheduleItem(
        string day,
        string time,
        string subject,
        string teacher,
        string room)
    {
        Day = day;
        Time = time;
        Subject = subject;
        Teacher = teacher;
        Room = room;
    }

    public string GetInfo()
    {
        return $"{Time} — {Subject} — {Room}";
    }
}
