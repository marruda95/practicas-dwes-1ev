namespace Students;
using Subjects;

public class Student
{
    public string Username { get; set; }
    public string Password { get; set;}
    public string Name { get; set; }
    public int Age { get; set; }
    public decimal Average { get; set; }
    public Boolean isHere {get; set;}
    public DateTime dateAdded { get; set; }

    public List<Subject> enrolled { get; set;}
}