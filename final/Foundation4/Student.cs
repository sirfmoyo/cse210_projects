public class Student
{
    public string Name { get; set; }
    public Subject Subject { get; set; }
    public double FinalMark { get; set; }

    public Student()
    {
        Subject = new Subject();
    }
}