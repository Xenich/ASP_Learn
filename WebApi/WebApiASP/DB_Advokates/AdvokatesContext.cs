using Microsoft.EntityFrameworkCore;



namespace WebApiASP.DB_Advokates
{
    public class AdvokatesContext : DbContext
    {
        // не забыть добавить строку подключения и контекст в настройках сервисов в startup.cs!!!!
        public AdvokatesContext() { }
        public AdvokatesContext(DbContextOptions<AdvokatesContext> options) : base(options) { }

        public DbSet<Advokate> Advokates { get; set; }
        public DbSet<Case> Cases { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Company> Companies { get; set; }

        public DbSet<WebApiASP.Outputs.Advokate> AdvokatesList { get; set; }        // сет для вывода списка авокатов
        public DbSet<WebApiASP.Outputs.Case> CasesList { get; set; }                // сет для вывода списка дел



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var configCompany = modelBuilder.Entity<Company>();
            configCompany.ToTable("Company");

            //var configCase = modelBuilder.Entity<Case>();
            //configCase.ToTable("Case");

            //var configAdvokate = modelBuilder.Entity<Advokate>();
            //configAdvokate.ToTable("Advokate");

            //var configNote = modelBuilder.Entity<Note>();
            //configNote.ToTable("Note");

            modelBuilder.Entity<Case>(entity =>
            {
                entity.ToTable("Case");
                entity.HasOne(p => p.Advokate)
                .WithMany(d => d.Cases)
                .HasForeignKey(f => f.AdvokateId);
                //.HasConstraintName("FK_Case_Advokate");


            });

            modelBuilder.Entity<Note>(entity =>
            {
                entity.ToTable("Note");
                entity.HasOne(p => p.Case)
                .WithMany(d => d.Notes);

                //.HasForeignKey(f => f.CaseId);


            });

            modelBuilder.Entity<Advokate>(entity =>
            {
                entity.ToTable("Advokate");
                entity.HasMany(d => d.Cases)
                .WithOne(p=>p.Advokate);
            });

        }
    }
}
