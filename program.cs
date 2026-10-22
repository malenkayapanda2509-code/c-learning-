using System;

public class TaskItem
{
    public string Title { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime Deadline { get; set; }
    public int Priority { get; set; }

    public TaskItem()
    {
        Title = "";
        IsCompleted = false;
        Deadline = DateTime.Today;
        Priority = 2;
    }

    public TaskItem(string title, DateTime deadline, int priority)
    {
        Title = title;
        Deadline = deadline;
        Priority = priority;
        IsCompleted = false;
    }

    public string GetPriorityName()
    {
        if (Priority == 1)
            return "🔴 Высокий";

        if (Priority == 2)
            return "🟡 Средний";

        return "🟢 Низкий";
    }

    public string GetStatus()
    {
        if (IsCompleted)
            return "✅ Выполнено";

        var daysLeft =
            (Deadline.Date - DateTime.Today).Days;

        if (daysLeft < 0)
            return $"🔴 Просрочено на {Math.Abs(daysLeft)} дн.";

        if (daysLeft == 0)
            return "🟠 Сегодня";

        if (daysLeft == 1)
            return "🟠 Завтра";

        if (daysLeft <= 7)
            return $"🟡 Через {daysLeft} дн.";

        return $"🟢 Через {daysLeft} дн.";
    }

    public bool IsOverdue()
    {
        return !IsCompleted &&
               Deadline.Date < DateTime.Today;
    }

    public bool IsToday()
    {
        return !IsCompleted &&
               Deadline.Date == DateTime.Today;
    }

    public bool IsForNextWeek()
    {
        var days =
            (Deadline.Date - DateTime.Today).Days;

        return !IsCompleted &&
               days >= 1 &&
               days <= 7;
    }
}
