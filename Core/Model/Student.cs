namespace Core.Model
{
    public class Student
    {
        public int Id { get; private set; }
        public string Name  { get; set; }
        public string Address { get; set; }
        public int Zipcode { get; set; }
        public string City { get; set; }
        public string Email { get; set; }

        public Student(int id, string name, string address, int zipcode, string city, string email)
        {
            Id = id;
            Name = name;
            Address = address;
            Zipcode = zipcode;
            City = city;
            Email = email;
        }

        public Student(int id, string name, string address, int zipcode, string city)
            : this(id, name, address, zipcode, city, null)
        { }
    }
}
