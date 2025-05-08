using System;
using System.Linq;

// ===== Частина 1: Ієрархія персон =====
class Persona
{
    public string Name { get; set; }
    public string Surname { get; set; }

    public Persona(string name, string surname)
    {
        Name = name;
        Surname = surname;
    }

    public virtual void Show()
    {
        Console.WriteLine($"Персона: {Name} {Surname}");
    }
}

class Student : Persona
{
    public string Group { get; set; }
    public int Year { get; set; }

    public Student(string name, string surname, string group, int year)
        : base(name, surname)
    {
        Group = group;
        Year = year;
    }

    public override void Show()
    {
        Console.WriteLine($"Студент: {Name} {Surname}, Група: {Group}, Курс: {Year}");
    }
}

class Teacher : Persona
{
    public string Subject { get; set; }

    public Teacher(string name, string surname, string subject)
        : base(name, surname)
    {
        Subject = subject;
    }

    public override void Show()
    {
        Console.WriteLine($"Викладач: {Name} {Surname}, Предмет: {Subject}");
    }
}

class HeadOfDepartment : Teacher
{
    public string DepartmentName { get; set; }

    public HeadOfDepartment(string name, string surname, string subject, string department)
        : base(name, surname, subject)
    {
        DepartmentName = department;
    }

    public override void Show()
    {
        Console.WriteLine($"Завідувач кафедри: {Name} {Surname}, Кафедра: {DepartmentName}, Предмет: {Subject}");
    }
}

static class University
{
    public static void FillPeopleArray(Persona[] people)
    {
        people[0] = new Student("Олена", "Іваненко", "КІ-21", 2);
        people[1] = new Teacher("Ігор", "Коваленко", "Програмування");
        people[2] = new Student("Андрій", "Петренко", "КН-23", 1);
        people[3] = new HeadOfDepartment("Наталія", "Шевченко", "Математика", "Вища математика");
        people[4] = new Teacher("Микола", "Гончар", "Мережі");
    }

    public static void ShowSortedPeople(Persona[] people)
    {
        var sorted = people.OrderBy(p => p.Surname).ToArray();
        Console.WriteLine("Список персон (відсортовано за прізвищем):\n");
        foreach (var person in sorted)
        {
            person.Show();
            Console.WriteLine();
        }
    }
}

// ===== Частина 2: Клас DRomb =====
class DRomb
{
    protected int d1, d2; // діагоналі
    protected int color;  // колір

    public DRomb(int d1, int d2, int color)
    {
        this.d1 = d1;
        this.d2 = d2;
        this.color = color;
    }

    public int D1
    {
        get { return d1; }
        set { d1 = value; }
    }

    public int D2
    {
        get { return d2; }
        set { d2 = value; }
    }

    public int Color => color;

    public void PrintDiagonals()
    {
        Console.WriteLine($"Діагоналі: D1 = {d1}, D2 = {d2}");
    }

    public double GetArea()
    {
        return (d1 * d2) / 2.0;
    }

    public double GetPerimeter()
    {
        double side = Math.Sqrt(Math.Pow(d1 / 2.0, 2) + Math.Pow(d2 / 2.0, 2));
        return 4 * side;
    }

    public bool IsSquare()
    {
        return d1 == d2;
    }
}

static class RombProcessor
{
    public static void ShowRombs(DRomb[] rombs)
    {
        int squareCount = 0;

        Console.WriteLine("Інформація про ромби:\n");
        foreach (var r in rombs)
        {
            r.PrintDiagonals();
            Console.WriteLine($"Площа: {r.GetArea()}");
            Console.WriteLine($"Периметр: {r.GetPerimeter():F2}");
            Console.WriteLine($"Колір: {r.Color}");
            Console.WriteLine(r.IsSquare() ? "Це квадрат." : "Це не квадрат.");
            Console.WriteLine();

            if (r.IsSquare()) squareCount++;
        }

        Console.WriteLine($"Кількість квадратів: {squareCount}");
    }
}

// ===== Головний клас програми =====
class Program
{
    static void Main()
    {
        Console.WriteLine("=== Частина 1: Ієрархія класів Persona ===\n");
        Persona[] people = new Persona[5];
        University.FillPeopleArray(people);
        University.ShowSortedPeople(people);

        Console.WriteLine("=== Частина 2: Ромби ===\n");
        DRomb[] rombs = new DRomb[]
        {
            new DRomb(10, 10, 1),
            new DRomb(8, 6, 2),
            new DRomb(5, 5, 3),
            new DRomb(12, 8, 4)
        };

        RombProcessor.ShowRombs(rombs);
    }
}
