using System.Xml.Linq;

namespace G19_20231125
{
    public class Person
    {
        public int Id { get; set; }
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public GenderType Gender { get; set; }

        
        public Person()
        {
            // default კონსტრუქტორი.
        }

        public Person(int Id, string Firstname, string Lastname, DateTime BirthDate, GenderType Gender)
        {
            this.Id = Id;
            this.Firstname = Firstname;
            this.Lastname = Lastname;
            this.BirthDate = BirthDate;
            this.Gender = Gender;
        }
        public override string ToString()
        {
            return $"{Id} {Firstname} {Lastname} {BirthDate} {Gender}";
        }
    }


    public enum GenderType : byte
    {
        Male = 0,
        Female = 1,
    }
}
