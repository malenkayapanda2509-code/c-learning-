using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.Title = "Student Helper 2.0";

        while (true)
        {
            Console.Clear();
            ShowHeader();

            Console.WriteLine("1. Рассчитать средний балл");
            Console.WriteLine("2. Посмотреть статистику");
            Console.WriteLine("3. Получить совет");
            Console.WriteLine("0. Выход");

            Console.Write("\nВыберите действие: ");
            var choice = Console.ReadLine();

            if (choice == "0")
            {
                Console.WriteLine("\nСпасибо за использование Student Helper!");
                break;
            }

            if (choice == "1")
            {
                CalculateGrades();
            }
            else if (choice == "2")
            {
                ShowStatistics();
            }
            else if (choice == "3")
            {
                ShowAdvice();
            }
            else
            {
                ShowError("Такого пункта меню нет.");
            }

            Console.WriteLine("\nНажмите любую клавишу, чтобы продолжить...");
            Console.ReadKey();
        }
    }

    static void ShowHeader()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;

        Console.WriteLine("╔══════════════════════════════════════╗");
        Console.WriteLine("║          🎓 STUDENT HELPER           ║");
        Console.WriteLine("║              Версия 2.0              ║");
        Console.WriteLine("╚══════════════════════════════════════╝");

        Console.ResetColor();

        Console.WriteLine();
    }

    static void CalculateGrades()
    {
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("══════════ РАСЧЁТ ОЦЕНОК ══════════");
        Console.ResetColor();

        Console.Write("\nВведите имя студента: ");
        var name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name))
        {
            ShowError("Имя не может быть пустым.");
            return;
        }

        Console.WriteLine($"\nПривет, {name}!");

        var grades = ReadGrades();

        if (grades.Count == 0)
        {
            ShowError("Не удалось добавить оценки.");
            return;
        }

        ShowResults(name, grades);
    }

    static List<int> ReadGrades()
    {
        var grades = new List<int>();

        Console.WriteLine("\nВведите количество оценок (от 1 до 10): ");

        var input = Console.ReadLine();

        if (!int.TryParse(input, out var count) || count < 1 || count > 10)
        {
            ShowError("Количество оценок должно быть от 1 до 10.");
            return grades;
        }

        for (var i = 1; i <= count; i++)
        {
            Console.Write($"Введите оценку №{i} (1-5): ");

            if (!int.TryParse(Console.ReadLine(), out var grade))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ошибка! Нужно ввести целое число.");
                Console.ResetColor();

                i--;
                continue;
            }

            if (!IsValidGrade(grade))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ошибка! Оценка должна быть от 1 до 5.");
                Console.ResetColor();

                i--;
                continue;
            }

            grades.Add(grade);
        }

        return grades;
    }

    static bool IsValidGrade(int grade)
    {
        return grade >= 1 && grade <= 5;
    }

    static void ShowResults(string name, List<int> grades)
    {
        var average = grades.Average();
        var maxGrade = grades.Max();
        var minGrade = grades.Min();

        Console.WriteLine("\n╔══════════════════════════════════════╗");
        Console.WriteLine("║              РЕЗУЛЬТАТЫ              ║");
        Console.WriteLine("╚══════════════════════════════════════╝");

        Console.WriteLine($"Студент:          {name}");
        Console.WriteLine($"Оценки:           {string.Join(", ", grades)}");
        Console.WriteLine($"Количество:       {grades.Count}");
        Console.WriteLine($"Средний балл:     {average:F2}");
        Console.WriteLine($"Лучшая оценка:    {maxGrade}");
        Console.WriteLine($"Худшая оценка:    {minGrade}");

        Console.Write("\nУспеваемость: ");

        var performance = GetPerformance(average);

        if (average >= 4.5)
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
        else if (average >= 3.5)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }

        Console.WriteLine(performance);
        Console.ResetColor();

        Console.WriteLine("\n💡 " + GetAdvice(average));
    }

    static string GetPerformance(double average)
    {
        if (average >= 4.5)
        {
            return "ОТЛИЧНО! 🌟";
        }

        if (average >= 3.5)
        {
            return "ХОРОШО 👍";
        }

        if (average >= 3)
        {
            return "НОРМАЛЬНО 🙂";
        }

        return "НУЖНО ПОДТЯНУТЬСЯ 📚";
    }

    static string GetAdvice(double average)
    {
        if (average >= 4.5)
        {
            return "Отличный результат! Продолжай в том же духе.";
        }

        if (average >= 3.5)
        {
            return "Результат хороший. Есть небольшие возможности для роста.";
        }

        if (average >= 3)
        {
            return "Обрати внимание на предметы, где оценки ниже.";
        }

        return "Не расстраивайся. Попробуй уделить учебе немного больше времени.";
    }

    static void ShowStatistics()
    {
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("══════════ СТАТИСТИКА ══════════");
        Console.ResetColor();

        Console.WriteLine("\nЗдесь можно будет хранить");
        Console.WriteLine("и анализировать оценки студента.");

        Console.WriteLine("\n📊 Доступные показатели:");
        Console.WriteLine("• Средний балл");
        Console.WriteLine("• Лучшая оценка");
        Console.WriteLine("• Худшая оценка");
        Console.WriteLine("• Количество оценок");

        Console.WriteLine("\n💡 В следующей версии можно добавить");
        Console.WriteLine("сохранение результатов в файл.");
    }

    static void ShowAdvice()
    {
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("══════════ СОВЕТ СТУДЕНТУ ══════════");
        Console.ResetColor();

        Console.WriteLine("\n📚 Несколько полезных советов:");

        Console.WriteLine("\n1. Не откладывай задания на последний день.");
        Console.WriteLine("2. Разбирай ошибки после контрольных.");
        Console.WriteLine("3. Делай небольшие перерывы во время учебы.");
        Console.WriteLine("4. Храни материалы по предметам в порядке.");
        Console.WriteLine("5. Если тема непонятна — разбери её по частям.");

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n✨ Главное — заниматься регулярно!");
        Console.ResetColor();
    }

    static void ShowError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\n❌ {message}");
        Console.ResetColor();
    }
}
