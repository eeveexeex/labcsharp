using System;
using System.Collections.Generic;
using System.Linq;

public class Teacher
{
    public string Name { get; set; }
    public string Department { get; set; } // кафедра
    
    public Teacher(string name, string department)
    {
        Name = name;
        Department = department;
    }
}

public class Grade
{
    public string Subject { get; set; }
    public string GradeValue { get; set; } // отл,хор,удвл
    public DateTime Date { get; set; } // дата
    public Teacher Teacher { get; set; } // кто принимал
    public string Type { get; set; } // экзамен,зачет,курсовая
    
    public Grade(string subject, string gradeValue, DateTime date, Teacher teacher, string type)
    {
        Subject = subject;
        GradeValue = gradeValue;
        Date = date;
        Teacher = teacher;
        Type = type;
    }
}

public class StudentRecordBook
{
    public string Department { get; set; } // кафедра
    public string RecordBookNumber { get; set; } // номер зачётки
    public string Specialty { get; set; } // направление
    
    public List<Grade> Grades { get; private set; } // все оценки
    public string DiplomaWork { get; set; } // тема диплома
    public string DiplomaSupervisor { get; set; } // науч рук
    
    public StudentRecordBook(string department, string recordBookNumber, string specialty)
    {
        Department = department;
        RecordBookNumber = recordBookNumber;
        Specialty = specialty;
        Grades = new List<Grade>();
    }

    // методы для добавления
    // добавить экзамен
    public void AddExam(string subject, string grade, DateTime date, Teacher teacher)
    {
        Grades.Add(new Grade(subject, grade, date, teacher, "экзамен"));
    }
    
    // добавить зачёт
    public void AddTest(string subject, DateTime date, Teacher teacher)
    {
        Grades.Add(new Grade(subject, "зачтено", date, teacher, "зачет"));
    }
    
    // добавить курсовую
    public void AddCourseWork(string subject, string grade, DateTime date, Teacher teacher)
    {
        Grades.Add(new Grade(subject, grade, date, teacher, "курсовая"));
    }
    
    // добавить диплом
    public void AddDiplomaWork(string workTitle, string supervisor)
    {
        DiplomaWork = workTitle;
        DiplomaSupervisor = supervisor;
    }
    // Методы для изменения
    
    // Изменить оценку
    public bool UpdateGrade(string subject, string newGrade)
    {
        var grade = Grades.FirstOrDefault(g => g.Subject == subject);
        if (grade != null)
        {
            string oldGrade = grade.GradeValue;
            grade.GradeValue = newGrade;
            Console.WriteLine($"\nИЗМЕНЕНИЕ ОЦЕНКИ: {subject}");
            return true;
        }
        return false;
    }
    
    // Вывод зачетной книжки
    public void DisplayInfo()
    {
        Console.WriteLine($"ЗАЧЁТНАЯ КНИЖКА №{RecordBookNumber}");
        Console.WriteLine($"Кафедра: {Department}");
        Console.WriteLine($"Направление: {Specialty}");
        Console.WriteLine();
        
        if (Grades.Count > 0)
        {
            Console.WriteLine("Сданные предметы:");
            foreach (var grade in Grades)
            {
                Console.WriteLine($"- {grade.Subject}: {grade.GradeValue} ({grade.Type}) - {grade.Date:dd.MM.yyyy}");
                Console.WriteLine($"  Преподаватель: {grade.Teacher.Name} (Кафедра: {grade.Teacher.Department})");
            }
        }
        else
        {
            Console.WriteLine("Нет оценок");
        }
        
        if (!string.IsNullOrEmpty(DiplomaWork))
        {
            Console.WriteLine($"\nДипломная работа: {DiplomaWork}");
            Console.WriteLine($"Научный руководитель: {DiplomaSupervisor}");
        }
        
    }
    
}
    
public class Program
{ 
    Console.OutputEncoding = System.Text.Encoding.UTF8;
        
    var recordBook = new StudentRecordBook(
        "Системный анализ и компьютерное моделирование",
        "231930391309131",
        "Прикладная математика и информатика"
    );
    
    var teacher1 = new Teacher("Соболев Д. О.", "Фундаметальная математика");
    var teacher2 = new Teacher("Мельникова А. В.", "Информационная безопасность");
    var teacher3 = new Teacher("Коваленко В. С.", "Информационные системы");
    
    recordBook.AddExam("Базы данных", "отлично", new DateTime(2025, 6, 25), teacher1);
    recordBook.AddTest("Интегральные уравнения", new DateTime(2025, 6, 20), teacher2);
    recordBook.AddCourseWork("Численные методы", "хорошо", new DateTime(2025, 7, 10), teacher3);
    recordBook.AddExam("Теория вероятностей и математическая статистика", "удовлетворительно", new DateTime(2025, 6, 30), teacher1);
    recordBook.AddDiplomaWork("Разработка програмного комплекса", "Волкова А. Т.");
    
    recordBook.DisplayInfo();
}



