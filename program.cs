using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите имя студента: ");
        string name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Имя не может быть пустым.");
            return;
        }

        Console.Write("Введите первую оценку: ");
        int grade1 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Введите вторую оценку: ");
        int grade2 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Введите третью оценку: ");
        int grade3 = Convert.ToInt32(Console.ReadLine());

        double average = (grade1 + grade2 + grade3) / 3.0;

        Console.WriteLine();
        Console.WriteLine($"Студент: {name}");
        Console.WriteLine($"Средний балл: {average:F2}");

        if (average >= 4.5)
        {
            Console.WriteLine("Результат: отлично!");
        }
        else if (average >= 3.5)
        {
            Console.WriteLine("Результат: хорошо.");
        }
        else if (average >= 3)
        {
            Console.WriteLine("Результат: удовлетворительно.");
        }
        else
        {
            Console.WriteLine("Результат: нужно подтянуть учебу.");
        }
    }
}
