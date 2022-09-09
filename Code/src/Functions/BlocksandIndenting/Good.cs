namespace BlocksandIndenting;

public class Good
{
    public Student Find(List<Student> Students, int id)
    {
        Student result = null;
        foreach (var student in Students)
            if (student.Id == id)
                result = student;
        return result;
    }
}