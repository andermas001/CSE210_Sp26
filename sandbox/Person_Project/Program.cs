class Program
{
    public static void main(string args)
    {
        Person person1 = new Person("John", "Hanks", 29, 200);
        Console.WriteLine(person1.GetPersonInformation());

        Police police = new Police("gun","24058B", "John", "Smith", 32, 195);
        Console.WriteLine(police.getPoliceInformation());

        Doctor doctor = new Doctor("Suregeon", "Rexburg Hospitol", "Smith", "Johnson", 54, 175);
        Console.WriteLine(doctor.getDoctorInformation());
    }
}