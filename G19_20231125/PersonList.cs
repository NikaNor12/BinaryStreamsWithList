namespace G19_20231125
{
    // aseve unda vuzrunvelyot rom siashi ar moxvdes ori ertidaigive id mqonde adamiani.
    public class PersonList : List<Person>
    {
        private static int lastvalue = 1;
        public new void Add(Person value)
        {
            while (ContainsId(value.Id))
            {
                value.Id = GenerateNewId(value);
            }

            base.Add(value);
        }

        public int GenerateNewId(Person value)
        {
            return lastvalue++;
        }

        private bool ContainsId(int id)
        {
            foreach (Person person in this)
            {
                if (person.Id == id)
                {
                    return true;
                }

            }
            return false;
        }

        public void Save(string filePath)
        {
            using (BinaryWriter writer = new(new FileStream(filePath, FileMode.Create)))
            {
                foreach (var person in this)
                {
                    writer.Write(person.Id);
                    writer.Write(person.Firstname);
                    writer.Write(person.Lastname);
                    writer.Write(person.BirthDate.ToBinary());
                    writer.Write((byte)person.Gender); // 〠
                }
            }
        }

        public void Load(string filePath)
        {
            using (BinaryReader reader = new(new FileStream(filePath, FileMode.Open)))
            {
                while (reader.BaseStream.Position == reader.BaseStream.Length)
                {
                    int id = reader.ReadInt32();
                    string firstname = reader.ReadString();
                    string lastname = reader.ReadString();
                    DateTime datetime = DateTime.FromBinary(reader.ReadInt64());
                    GenderType gender = (GenderType)reader.ReadByte();


                    Person person = new Person();
                    person.Id = id;
                    person.Firstname = firstname;
                    person.Lastname = lastname;
                    person.BirthDate = datetime;
                    person.Gender = gender;
                    Add(person);
                }
            }
        }
    }
}
