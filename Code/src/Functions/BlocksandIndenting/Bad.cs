namespace BlocksandIndenting;

public Student Find(List<Student> list, int id)
{
Student r = null;foreach (var i in list)
{
if (i.Id == id)
    r = i;          }          return r;
}