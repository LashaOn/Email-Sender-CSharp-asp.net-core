using emailSender.Mapping;
using emailSender.Modals;
using Microsoft.EntityFrameworkCore;

namespace emailSender.Data
{
    public class ContactContext : DbContext
    {

        public DbSet<Contact> Contacts { get; set; }


        public ContactContext(DbContextOptions<ContactContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContactMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
