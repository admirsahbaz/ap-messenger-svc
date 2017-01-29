using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ApIosMessenger.EF.Models;

namespace ApIosMessenger.EF
{
    public class EFContext: DbContext
    {
        public EFContext(): base("name=ApIosChat") 
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<UserContact> UserContacts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<EFContext>(null);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Contacts)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.UserId);
        }

    }
}
