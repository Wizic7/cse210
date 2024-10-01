using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job() 
        { 
            _company = "Microsoft", 
            _jobTitle = "Software Engineer",
            _endYear = 2022, 
            _startYear = 2019
        };
        Job job2 = new Job();
        job2._company = "Apple";
        job2._jobTitle = "Manager";
        job2._startYear = 2022;
        job2._endYear = 2023;
        
        Resume resume= new Resume();
        resume._name = "Allison Rose";
        resume._jobs.Add(job1);
        resume._jobs.Add(job2);
        
        resume.Display();

    }
}