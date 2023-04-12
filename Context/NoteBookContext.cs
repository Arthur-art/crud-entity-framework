using CrudEntityFramework.Entity;
using Microsoft.EntityFrameworkCore;

namespace CrudEntityFramework.Context
{
    public class NoteBookContext : DbContext
    {
        public NoteBookContext(DbContextOptions<NoteBookContext> options) : base(options)
        { 

        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
