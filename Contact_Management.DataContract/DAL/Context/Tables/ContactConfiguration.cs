namespace Contact_Management.DataContract.DAL.Context.Tables
{
    class ContactConfiguration: System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Contact>
    {
        public ContactConfiguration(): this("dbo")
        {

        }
        public ContactConfiguration(string schemaName)
        {
            ToTable("Contact", schemaName);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").HasColumnType("Int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.FirstName).HasColumnName(@"FirstName").HasColumnType("nvarchar").IsRequired().HasMaxLength(50);
            Property(x => x.LastName).HasColumnName(@"LastName").HasColumnType("nvarchar").IsRequired().HasMaxLength(50);
            Property(x => x.Email).HasColumnName(@"Email").HasColumnType("nvarchar").IsRequired().HasMaxLength(50);
            Property(x => x.PhoneNumber).HasColumnName(@"PhoneNumber").HasColumnType("nvarchar").IsRequired().HasMaxLength(10);
            Property(x => x.Status).HasColumnName(@"Status").HasColumnType("bit").IsRequired();
        }
    }
}
