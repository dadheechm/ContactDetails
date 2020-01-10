using Contact_Management.DataContract.DAL.Context.Tables;
using System.Data.Entity;

namespace Contact_Management.DataContract.DAL.Context
{
    class CMContext: DbContext
    {
        public CMContext()
        {
        }

        public CMContext(string connString): base(connString)
        {
            Database.SetInitializer<CMContext>(null);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public DbSet<Contact> Contact { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new ContactConfiguration());
        }
    }
}
