using System.ComponentModel.DataAnnotations;

namespace emailSender.Modals.Contact
{
    public class AddContact
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Family { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
