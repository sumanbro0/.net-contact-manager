
public interface ContactDetails
{
    int Id { get; set; }
    string Name { get; set; }
    string Number { get; set; }

}
// File: Contact.cs
namespace Contacts
{
    public class Contact : ContactDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }

        public Contact(int id, string name, string number)
        {
            Id = id;
            Name = name;
            Number = number;
        }
    }
}
