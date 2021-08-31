namespace emailSender.Modals
{
    public class Contact
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }

        public Contact()
        {

        }

        public Contact(string name, string lastName, string email)
        {
            Name = name;
            LastName = lastName;
            Email = email;
        }
    }
}
