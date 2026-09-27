```csharp
using System;

class Program
{
    static void Main()
    {
        Console.Title = "Student Helper";

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("╔════════════════════════════════════╗");
        Console.WriteLine("║        🎓 STUDENT HELPER 🎓        ║");
        Console.WriteLine("║       Твой маленький помощник      ║");
        Console.WriteLine("╚════════════════════════════════════╝");
        Console.ResetColor();

        Console.Write("\nВведите имя студента: ");
        string name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Имя не может быть пустым!");
            Console.ResetColor();
            return;
        }

        Console.WriteLine($"\nПривет, {name}! Давай посчитаем твой средний балл.");

        Console.Write("\nВведите оценку 1 (1-5): ");
        int grade1 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Введите оценку 2 (1-5): ");
        int grade2 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Введите оценку 3 (1-5): ");
        int grade3 = Convert.ToInt32(Console.ReadLine());

        if (grade1 < 1 || grade1 > 5 ||
            grade2 < 1 || grade2 > 5 ||
            grade3 < 1 || grade3 > 5)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nОшибка! Оценки должны быть от 1 до 5.");
            Console.ResetColor();
            return;
        }

        double average = (grade1 + grade2 + grade3) / 3.0;

        Console.WriteLine("\n╔════════════════════════════════════╗");
        Console.WriteLine("║            РЕЗУЛЬТАТЫ             ║");
        Console.WriteLine("╚════════════════════════════════════╝");

        Console.WriteLine($"Студент:      {name}");
        Console.WriteLine($"Оценки:       {grade1}, {grade2}, {grade3}");
        Console.WriteLine($"Средний балл: {average:F2}");

        Console.Write("\nУспеваемость: ");

        if (average >= 4.5)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("ОТЛИЧНО! 🌟");
            Console.WriteLine("Так держать!");
        }
        else if (average >= 3.5)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("ХОРОШО 👍");
            Console.WriteLine("Есть куда расти!");
        }
        else if (average >= 3)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("НОРМАЛЬНО 🙂");
            Console.WriteLine("Можно немного постараться.");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("НУЖНО ПОДТЯНУТЬСЯ 📚");
            Console.WriteLine("Не сдавайся!");
        }

        Console.ResetColor();

        Console.WriteLine("\n------------------------------------");

        if (average == 5)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("🏆 Идеальный результат!");
            Console.ResetColor();
        }
        else
        {
            Console.WriteLine("💡 Совет: продолжай учиться и всё получится!");
        }

        Console.WriteLine("\nНажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
}
```
