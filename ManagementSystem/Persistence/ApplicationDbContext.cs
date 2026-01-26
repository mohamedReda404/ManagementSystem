

namespace ManagementSystem.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Departments>().HasMany(d => d.Employee).WithOne(e => e.Department).HasForeignKey(e => e.Id);

            modelBuilder.Entity<Employees>().HasMany(d=>d.Requests).WithOne(e=>e.Employee).HasForeignKey(e=>e.Id);
            base.OnModelCreating(modelBuilder);

        }
        public DbSet<Departments> departments { get;set;}
        public DbSet<Employees> employees { get; set; }
        public DbSet<Requests>requests { get; set; }
        public DbSet<Operations> operations {  get; set; }
    }
}
