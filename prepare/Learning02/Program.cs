using System;

class Job
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Teacher";
        job1._company = "Delta";
        job1._startYear = 2021;
        job1._endYear = 2023;

        Job job2 = new Job();
        job2._jobTitle = "Teacher";
        job2._company = "Mpopoma";
        job2._startYear = 2009;
        job2._endYear = 2021;

        Resume myResume = new Resume();
        myResume._name = "Freeman Moyo";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}