using System;

class Program
{
    static void Main()
    {
        Console.Title = "Student Helper 2.0";

        ShowHeader();

        Console.Write("Введите имя студента: ");
        var name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name))
        {
            ShowError("Имя не может быть пустым!");
            return;
        }

        Console.WriteLine($"\nПривет, {name}! 👋");
        Console.WriteLine("Давай проверим твою успеваемость.\n");

        var grade1 = ReadGrade(1);
        var grade2 = ReadGrade(2);
        var grade3 = ReadGrade(3);
        var grade4 = ReadGrade(4);
        var grade5 = ReadGrade(5);

        var average = (grade1 + grade2 + grade3 + grade4 + grade5) / 5.0;
        var maxGrade = Math.Max(Math.Max(Math.Max(grade1, grade2), Math.Max(grade3, grade4)), grade5);
        var minGrade = Math.Min(Math.Min(Math.Min(grade1, grade2), Math.Min(grade3, grade4)), grade5);

        ShowResults(name, grade1, grade2, grade3, grade4, grade5,
            average, maxGrade, minGrade);

        Console.WriteLine("\nНажмите любую клавишу для выхода...");
        Console.ReadKey();
    }

    static void ShowHeader()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;

        Console.WriteLine("╔══════════════════════════════════════╗");
        Console.WriteLine("║       🎓 STUDENT HELPER 2.0 🎓      ║");
        Console.WriteLine("║        Твой помощник в учёбе         ║");
        Console.WriteLine("╚══════════════════════════════════════╝");

        Console.ResetColor();
    }

    static int ReadGrade(int number)
    {
        while (true)
        {
            Console.Write($"Введите оценку {number} (1-5): ");
            var input = Console.ReadLine();

            if (int.TryParse(input, out var grade) && grade >= 1 && grade <= 5)
            {
                return grade;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ошибка! Введите целое число от 1 до 5.");
            Console.ResetColor();
        }
    }

    static void ShowResults(
        string name,
        int grade1,
        int grade2,
        int grade3,
        int grade4,
        int grade5,
        double average,
        int maxGrade,
        int minGrade)
    {
        Console.WriteLine("\n╔══════════════════════════════════════╗");
        Console.WriteLine("║              РЕЗУЛЬТАТЫ              ║");
        Console.WriteLine("╚══════════════════════════════════════╝");

        Console.WriteLine($"Студент:        {name}");
        Console.WriteLine($"Оценки:         {grade1}, {grade2}, {grade3}, {grade4}, {grade5}");
        Console.WriteLine($"Средний балл:   {average:F2}");
        Console.WriteLine($"Лучшая оценка:  {maxGrade}");
        Console.WriteLine($"Минимальная:    {minGrade}");

        Console.Write("\nУспеваемость: ");

        if (average >= 4.5)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("ОТЛИЧНО! 🌟");
            Console.WriteLine("Очень высокий результат!");
        }
        else if (average >= 3.5)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("ХОРОШО 👍");
            Console.WriteLine("Результат хороший, но можно ещё лучше!");
        }
        else if (average >= 3)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("НОРМАЛЬНО 🙂");
            Console.WriteLine("Есть темы, которые стоит повторить.");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("НУЖНО ПОДТЯНУТЬСЯ 📚");
            Console.WriteLine("Не переживай — всё можно исправить!");
        }

        Console.ResetColor();

        Console.WriteLine("\n--------------------------------------");

        if (average == 5)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("🏆 ИДЕАЛЬНЫЙ РЕЗУЛЬТАТ!");
            Console.ResetColor();
        }
        else if (minGrade == 1)
        {
            Console.WriteLine("💡 Совет: обрати внимание на предмет с самой низкой оценкой.");
        }
        else
        {
            Console.WriteLine("💡 Совет: продолжай заниматься и результат станет ещё лучше!");
        }
    }

    static void ShowError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\nОшибка: {message}");
        Console.ResetColor();
    }
}
