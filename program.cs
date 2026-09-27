using System;

class Program
{
    static void Main()
    {
        Console.Title = "Калькулятор оценок";

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("=================================");
        Console.WriteLine("       КАЛЬКУЛЯТОР ОЦЕНОК");
        Console.WriteLine("=================================");
        Console.ResetColor();

        Console.Write("\nВведите имя студента: ");
        string name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ошибка: имя не может быть пустым.");
            Console.ResetColor();
            return;
        }

        Console.WriteLine("\nВведите три оценки от 1 до 5:");

        Console.Write("Оценка 1: ");
        int grade1 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Оценка 2: ");
        int grade2 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Оценка 3: ");
        int grade3 = Convert.ToInt32(Console.ReadLine());

        if (grade1 < 1 || grade1 > 5 ||
            grade2 < 1 || grade2 > 5 ||
            grade3 < 1 || grade3 > 5)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nОшибка: оценки должны быть от 1 до 5.");
            Console.ResetColor();
            return;
        }

        double average = (grade1 + grade2 + grade3) / 3.0;

        Console.WriteLine("\n---------------------------------");
        Console.WriteLine($"Студент:      {name}");
        Console.WriteLine($"Оценки:       {grade1}, {grade2}, {grade3}");
        Console.WriteLine($"Средний балл: {average:F2}");
        Console.WriteLine("---------------------------------");

        Console.Write("Результат: ");

        if (average >= 4.5)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("ОТЛИЧНО!");
        }
        else if (average >= 3.5)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("ХОРОШО");
        }
        else if (average >= 3)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("УДОВЛЕТВОРИТЕЛЬНО");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("НУЖНО ПОДТЯНУТЬ УЧЁБУ");
        }

        Console.ResetColor();

        Console.WriteLine("\nНажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
}
