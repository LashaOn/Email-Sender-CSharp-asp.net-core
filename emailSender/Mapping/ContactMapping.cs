using emailSender.Modals;
using emailSender.Modals.Contact;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace emailSender.Mapping
{
    public class ContactMapping : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contact");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Family).IsRequired();
        }
    }
}
