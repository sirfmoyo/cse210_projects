using System.Collections.Generic;

public class Subject
{
    public List<Paper> Papers { get; set; }

    public Subject()
    {
        Papers = new List<Paper>();
    }
}