using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._jobCompany = "Microsoft";
        job1.DisplayJobDetails();

        Job job2 = new Job();
        job2._jobTitle = "Software Developer";
        job2._jobCompany = "Apple";


        Resume myResume = new Resume();
        myResume._name = "Mason Anderson";
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.DisplayResume();




    }
}