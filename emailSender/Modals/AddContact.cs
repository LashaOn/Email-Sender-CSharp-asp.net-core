using System.ComponentModel.DataAnnotations;

namespace emailSender.Modals
{
    public class AddContact
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
