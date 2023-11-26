namespace G19_20231125
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"D:\Gela.txt";

            Person person = new Person();
            person.Id = 4;
            person.Firstname = "Nika";
            person.Lastname = "Chichua";
            person.BirthDate = new DateTime(2004, 8, 4);
            person.Gender = GenderType.Male;

            Person person2 = new Person(3, "Gulbaza", "Gulbazadze", new DateTime (1993, 3, 1), GenderType.Female);

            Person person3 = new Person();
            person3.Id = 4;
            person3.Firstname = "Gela";
            person3.Lastname = "Geladze";
            person3.BirthDate= new DateTime(2022, 1, 3);
            person3.Gender = GenderType.Female;

            PersonList personList = new();
            personList.Add(person);
            personList.Add(person2);
            personList.Add(person3);

            personList.Save(filePath);
            personList.Load(filePath);

            Console.WriteLine(person);
            Console.WriteLine(person2);
            Console.WriteLine(person3);

        }
    }
}