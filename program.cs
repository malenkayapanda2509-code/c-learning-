using System;

public class TaskItem
{
    public string Title { get; set; }

    public bool IsCompleted { get; set; }

    public DateTime Deadline { get; set; }

    public TaskItem(string title, DateTime deadline)
    {
        Title = title;
        Deadline = deadline;
        IsCompleted = false;
    }

    public string GetStatus()
    {
        if (IsCompleted)
        {
            return "✅ Выполнено";
        }

        var daysLeft = (Deadline.Date - DateTime.Today).Days;

        if (daysLeft < 0)
        {
            return "🔴 Просрочено";
        }

        if (daysLeft == 0)
        {
            return "🔴 Сегодня";
        }

        if (daysLeft <= 3)
        {
            return $"🟠 Через {daysLeft} дн.";
        }

        return $"🟢 Через {daysLeft} дн.";
    }
}
