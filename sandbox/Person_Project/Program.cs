class Program
{

    public static void DisplayPersonInformation(Person person)
    {
        // if (person is Doctor doctor)
        // Console.WriteLine(doctor.GetDoctorInformation());
        // else if (person is Police police)
        // {
        //     Console.WriteLine(police.GetPoliceInformation());
        // }
        // else
            Console.WriteLine(person.GetPersonInformation());
        
    }

    public static void main(string args)
    {
       //  Person person1 = new Person("John", "Hanks", 29, 200);

        Police police = new Police("gun","24058B", "John", "Smith", 32, 195);

        Doctor doctor = new Doctor("Suregeon", "Rexburg Hospitol", "Smith", "Johnson", 54, 175);

        List<Person> myPeople = new List<Person>{};
        // myPeople.Add(person1);
        myPeople.Add(police);
        myPeople.Add(doctor);

        foreach (Person person in myPeople)
        {
            DisplayPersonInformation(person);
            Console.WriteLine(person.GetSalary());
        }



    }
}