using System;


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
    
    