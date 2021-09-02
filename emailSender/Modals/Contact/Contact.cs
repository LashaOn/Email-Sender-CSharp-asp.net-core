namespace emailSender.Modals.Contact
{
    public class Contact
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Family { get; private set; }
        public string Email { get; private set; }

        public Contact()
        {

        }

        public Contact(string name, string family, string email)
        {
            Name = name;
            Family = family;
            Email = email;
        }
    }
}
