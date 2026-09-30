using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

class Program
{
    static string studentName = "";

    static Dictionary<string, List<int>> subjects =
        new Dictionary<string, List<int>>();

    static readonly string dataFile = "student_data.json";

    static void Main()
    {
        Console.Title = "Student Helper 4.0";

        LoadData();

        if (string.IsNullOrWhiteSpace(studentName))
        {
            SetStudentName();
        }

        while (true)
        {
            Console.Clear();

            ShowHeader();
            ShowMenu();

            Console.Write("\nВыберите действие: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddSubject();
                    break;

                case "2":
                    ShowSubjects();
                    break;

                case "3":
                    ShowSubjectResults();
                    break;

                case "4":
                    EditGrades();
                    break;

                case "5":
                    ShowStatistics();
                    break;

                case "6":
                    SearchSubject();
                    break;

                case "7":
                    ShowAdvice();
                    break;

                case "8":
                    DeleteSubject();
                    break;

                case "9":
                    ChangeStudentName();
                    break;

                case "0":
                    SaveData();
                    ExitProgram();
                    return;

                default:
                    ShowError("Такого пункта меню нет.");
                    Pause();
                    break;
            }
        }
    }

    static void SetStudentName()
    {
        Console.Clear();

        ShowTitle("👤 СОЗДАНИЕ ПРОФИЛЯ");

        Console.Write("Введите имя студента: ");
        var name = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(name))
        {
            ShowError("Имя не может быть пустым.");

            Console.Write("Введите имя ещё раз: ");
            name = Console.ReadLine();
        }

        studentName = name.Trim();

        SaveData();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\n✅ Профиль создан. Привет, {studentName}!");
        Console.ResetColor();

        Pause();
    }

    static void ShowHeader()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;

        Console.WriteLine("╔══════════════════════════════════════════╗");
        Console.WriteLine("║            🎓 STUDENT HELPER             ║");
        Console.WriteLine("║                 Версия 4.0                ║");
        Console.WriteLine("╚══════════════════════════════════════════╝");

        Console.ResetColor();

        Console.WriteLine();
        Console.WriteLine($"👤 Студент: {studentName}");
        Console.WriteLine($"📚 Предметов: {subjects.Count}");
        Console.WriteLine();
    }

    static void ShowMenu()
    {
        Console.WriteLine("══════════════════ МЕНЮ ══════════════════");
        Console.WriteLine();

        Console.WriteLine("1. ➕ Добавить предмет");
        Console.WriteLine("2. 📚 Показать предметы");
        Console.WriteLine("3. 📊 Результаты по предмету");
        Console.WriteLine("4. ✏️ Изменить оценки");
        Console.WriteLine("5. 📈 Общая статистика");
        Console.WriteLine("6. 🔎 Найти предмет");
        Console.WriteLine("7. 💡 Получить совет");
        Console.WriteLine("8. 🗑️ Удалить предмет");
        Console.WriteLine("9. 👤 Изменить имя");
        Console.WriteLine("0. 🚪 Выход");
    }

    static void AddSubject()
    {
        Console.Clear();

        ShowTitle("➕ ДОБАВЛЕНИЕ ПРЕДМЕТА");

        Console.Write("Введите название предмета: ");
        var subjectName = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(subjectName))
        {
            ShowError("Название предмета не может быть пустым.");
            Pause();
            return;
        }

        subjectName = subjectName.Trim();

        if (subjects.ContainsKey(subjectName))
        {
            ShowError("Такой предмет уже существует.");
            Pause();
            return;
        }

        Console.Write("\nВведите количество оценок (1-10): ");

        if (!int.TryParse(Console.ReadLine(), out var count))
        {
            ShowError("Введите целое число.");
            Pause();
            return;
        }

        if (count < 1 || count > 10)
        {
            ShowError("Количество оценок должно быть от 1 до 10.");
            Pause();
            return;
        }

        var grades = new List<int>();

        for (var i = 1; i <= count; i++)
        {
            grades.Add(ReadGrade(i));
        }

        subjects.Add(subjectName, grades);

        SaveData();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\n✅ Предмет «{subjectName}» добавлен!");
        Console.ResetColor();

        ShowMiniResult(grades);

        Pause();
    }

    static int ReadGrade(int number)
    {
        while (true)
        {
            Console.Write($"Введите оценку №{number} (1-5): ");

            if (!int.TryParse(Console.ReadLine(), out var grade))
            {
                ShowError("Нужно ввести целое число.");
                continue;
            }

            if (grade < 1 || grade > 5)
            {
                ShowError("Оценка должна быть от 1 до 5.");
                continue;
            }

            return grade;
        }
    }

    static void ShowSubjects()
    {
        Console.Clear();

        ShowTitle("📚 МОИ ПРЕДМЕТЫ");

        if (subjects.Count == 0)
        {
            Console.WriteLine("📭 У тебя пока нет предметов.");
            Pause();
            return;
        }

        var number = 1;

        foreach (var subject in subjects.OrderBy(x => x.Key))
        {
            var average = subject.Value.Average();

            Console.WriteLine(
                $"{number}. {subject.Key} — " +
                $"{average:F2} ({subject.Value.Count} оценок)");

            number++;
        }

        Pause();
    }

    static void ShowSubjectResults()
    {
        Console.Clear();

        ShowTitle("📊 РЕЗУЛЬТАТЫ ПО ПРЕДМЕТУ");

        var subjectName = FindExistingSubject();

        if (subjectName == null)
        {
            return;
        }

        var grades = subjects[subjectName];

        Console.WriteLine($"📖 Предмет: {subjectName}");
        Console.WriteLine();

        ShowResults(grades);

        Pause();
    }

    static void ShowResults(List<int> grades)
    {
        var average = grades.Average();
        var maxGrade = grades.Max();
        var minGrade = grades.Min();

        Console.WriteLine($"Оценки:           {string.Join(", ", grades)}");
        Console.WriteLine($"Количество:       {grades.Count}");
        Console.WriteLine($"Средний балл:     {average:F2}");
        Console.WriteLine($"Лучшая оценка:    {maxGrade}");
        Console.WriteLine($"Худшая оценка:    {minGrade}");

        Console.Write("\nУспеваемость: ");

        ShowPerformance(average);

        Console.WriteLine($"\n💡 {GetAdvice(average)}");
    }

    static void EditGrades()
    {
        Console.Clear();

        ShowTitle("✏️ ИЗМЕНЕНИЕ ОЦЕНОК");

        var subjectName = FindExistingSubject();

        if (subjectName == null)
        {
            return;
        }

        var grades = subjects[subjectName];

        Console.WriteLine("\nТекущие оценки:");

        for (var i = 0; i < grades.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {grades[i]}");
        }

        Console.Write("\nВведите номер оценки для изменения: ");

        if (!int.TryParse(Console.ReadLine(), out var number))
        {
            ShowError("Введите номер.");
            Pause();
            return;
        }

        if (number < 1 || number > grades.Count)
        {
            ShowError("Такой оценки нет.");
            Pause();
            return;
        }

        Console.WriteLine($"\nТекущая оценка: {grades[number - 1]}");

        var newGrade = ReadGrade(number);

        grades[number - 1] = newGrade;

        SaveData();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n✅ Оценка успешно изменена.");
        Console.ResetColor();

        Pause();
    }

    static void ShowStatistics()
    {
        Console.Clear();

        ShowTitle("📈 ОБЩАЯ СТАТИСТИКА");

        if (subjects.Count == 0)
        {
            Console.WriteLine("📭 Добавь хотя бы один предмет.");
            Pause();
            return;
        }

        var allGrades = GetAllGrades();

        var average = allGrades.Average();

        var bestSubject = subjects
            .OrderByDescending(x => x.Value.Average())
            .First();

        var worstSubject = subjects
            .OrderBy(x => x.Value.Average())
            .First();

        var excellentGrades = allGrades.Count(x => x == 5);
        var goodGrades = allGrades.Count(x => x == 4);
        var averageGrades = allGrades.Count(x => x == 3);
        var badGrades = allGrades.Count(x => x <= 2);

        Console.WriteLine($"👤 Студент:              {studentName}");
        Console.WriteLine($"📚 Предметов:            {subjects.Count}");
        Console.WriteLine($"📝 Всего оценок:         {allGrades.Count}");
        Console.WriteLine($"📊 Общий средний балл:   {average:F2}");

        Console.WriteLine();
        Console.WriteLine("РАСПРЕДЕЛЕНИЕ ОЦЕНОК:");
        Console.WriteLine($"⭐ Пятёрок:              {excellentGrades}");
        Console.WriteLine($"👍 Четвёрок:             {goodGrades}");
        Console.WriteLine($"🙂 Троек:                {averageGrades}");
        Console.WriteLine($"📚 Двоек:                {badGrades}");

        Console.WriteLine();

        Console.WriteLine(
            $"🏆 Лучший предмет: {bestSubject.Key} " +
            $"({bestSubject.Value.Average():F2})");

        Console.WriteLine(
            $"📌 Предмет для внимания: {worstSubject.Key} " +
            $"({worstSubject.Value.Average():F2})");

        Console.Write("\nОбщая успеваемость: ");
        ShowPerformance(average);

        Pause();
    }

    static void SearchSubject()
    {
        Console.Clear();

        ShowTitle("🔎 ПОИСК ПРЕДМЕТА");

        if (subjects.Count == 0)
        {
            Console.WriteLine("📭 Предметов пока нет.");
            Pause();
            return;
        }

        Console.Write("Введите название или часть названия: ");
        var search = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(search))
        {
            ShowError("Поисковый запрос пуст.");
            Pause();
            return;
        }

        var results = subjects
            .Where(x => x.Key.Contains(
                search,
                StringComparison.OrdinalIgnoreCase))
            .ToList();

        if (results.Count == 0)
        {
            Console.WriteLine("\n🔍 Ничего не найдено.");
        }
        else
        {
            Console.WriteLine("\nНайдено:");

            foreach (var subject in results)
            {
                Console.WriteLine(
                    $"📚 {subject.Key} — " +
                    $"средний балл {subject.Value.Average():F2}");
            }
        }

        Pause();
    }

    static void ShowAdvice()
    {
        Console.Clear();

        ShowTitle("💡 СОВЕТ СТУДЕНТУ");

        if (subjects.Count == 0)
        {
            Console.WriteLine(
                "Добавь предметы и оценки, " +
                "чтобы получить персональный совет.");

            Pause();
            return;
        }

        var allGrades = GetAllGrades();
        var average = allGrades.Average();

        Console.WriteLine($"Твой средний балл: {average:F2}");
        Console.WriteLine();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(GetAdvice(average));
        Console.ResetColor();

        Console.WriteLine("\n📌 Полезные привычки:");
        Console.WriteLine("• Не откладывай задания на последний день.");
        Console.WriteLine("• Разбирай ошибки после контрольных.");
        Console.WriteLine("• Повторяй сложные темы небольшими частями.");
        Console.WriteLine("• Следи за дедлайнами.");
        Console.WriteLine("• Делай небольшие перерывы во время учёбы.");

        Pause();
    }

    static void DeleteSubject()
    {
        Console.Clear();

        ShowTitle("🗑️ УДАЛЕНИЕ ПРЕДМЕТА");

        var subjectName = FindExistingSubject();

        if (subjectName == null)
        {
            return;
        }

        Console.Write(
            $"\nТочно удалить «{subjectName}»? (да/нет): ");

        var answer = Console.ReadLine();

        if (answer?.ToLower() != "да")
        {
            Console.WriteLine("\nУдаление отменено.");
            Pause();
            return;
        }

        subjects.Remove(subjectName);

        SaveData();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n✅ Предмет удалён.");
        Console.ResetColor();

        Pause();
    }

    static string FindExistingSubject()
    {
        if (subjects.Count == 0)
        {
            Console.WriteLine("📭 Предметов пока нет.");
            return null;
        }

        ShowSubjectsWithoutPause();

        Console.Write("\nВведите название предмета: ");
        var input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            ShowError("Название не может быть пустым.");
            return null;
        }

        var subjectName = subjects.Keys.FirstOrDefault(
            x => x.Equals(input.Trim(),
            StringComparison.OrdinalIgnoreCase));

        if (subjectName == null)
        {
            ShowError("Такого предмета нет.");
            return null;
        }

        return subjectName;
    }

    static void ShowSubjectsWithoutPause()
    {
        Console.WriteLine("Доступные предметы:\n");

        foreach (var subject in subjects)
        {
            Console.WriteLine($"• {subject.Key}");
        }
    }

    static void ChangeStudentName()
    {
        Console.Clear();

        ShowTitle("👤 ИЗМЕНЕНИЕ ИМЕНИ");

        Console.WriteLine($"Текущее имя: {studentName}");

        Console.Write("\nВведите новое имя: ");
        var newName = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(newName))
        {
            ShowError("Имя не может быть пустым.");
            Pause();
            return;
        }

        studentName = newName.Trim();

        SaveData();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n✅ Имя изменено.");
        Console.ResetColor();

        Pause();
    }

    static List<int> GetAllGrades()
    {
        var allGrades = new List<int>();

        foreach (var subject in subjects)
        {
            allGrades.AddRange(subject.Value);
        }

        return allGrades;
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
            return "🌟 Отличный результат! Продолжай заниматься регулярно.";
        }

        if (average >= 3.5)
        {
            return "👍 Хороший результат. Можно немного улучшить слабые предметы.";
        }

        if (average >= 3)
        {
            return "📚 Обрати внимание на предметы с более низкими оценками.";
        }

        return "💪 Не сдавайся. Разбирай сложные темы по одной и проси помощь, если она нужна.";
    }

    static void ShowPerformance(double average)
    {
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

        Console.WriteLine(GetPerformance(average));

        Console.ResetColor();
    }

    static void ShowMiniResult(List<int> grades)
    {
        var average = grades.Average();

        Console.WriteLine();
        Console.WriteLine($"📊 Средний балл: {average:F2}");
        Console.WriteLine($"📈 Результат: {GetPerformance(average)}");
    }

    static void ShowTitle(string title)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;

        Console.WriteLine("══════════════════════════════════════════");
        Console.WriteLine($"             {title}");
        Console.WriteLine("══════════════════════════════════════════");

        Console.ResetColor();
        Console.WriteLine();
    }

    static void ShowError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\n❌ {message}");
        Console.ResetColor();
    }

    static void Pause()
    {
        Console.WriteLine("\nНажмите любую клавишу, чтобы продолжить...");
        Console.ReadKey();
    }

    static void SaveData()
    {
        try
        {
            var data = new StudentData
            {
                StudentName = studentName,
                Subjects = subjects
            };

            var json = JsonSerializer.Serialize(
                data,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                });

            File.WriteAllText(dataFile, json);
        }
        catch
        {
            Console.WriteLine(
                "\n⚠️ Не удалось сохранить данные.");
        }
    }

    static void LoadData()
    {
        try
        {
            if (!File.Exists(dataFile))
            {
                return;
            }

            var json = File.ReadAllText(dataFile);

            var data = JsonSerializer.Deserialize<StudentData>(json);

            if (data == null)
            {
                return;
            }

            studentName = data.StudentName ?? "";

            if (data.Subjects != null)
            {
                subjects = data.Subjects;
            }
        }
        catch
        {
            studentName = "";
            subjects = new Dictionary<string, List<int>>();
        }
    }

    static void ExitProgram()
    {
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Green;

        Console.WriteLine("╔══════════════════════════════════════════╗");
        Console.WriteLine("║        Спасибо за использование!         ║");
        Console.WriteLine("║            Удачи в учёбе! 📚             ║");
        Console.WriteLine("╚══════════════════════════════════════════╝");

        Console.ResetColor();
    }
}

class StudentData
{
    public string StudentName { get; set; } = "";

    public Dictionary<string, List<int>> Subjects { get; set; }
        = new Dictionary<string, List<int>>();
}
