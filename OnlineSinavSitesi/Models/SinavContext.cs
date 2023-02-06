using Microsoft.EntityFrameworkCore;

namespace OnlineSinavSitesi.Models
{
    public class SinavContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=Hamza_PC;Database=OnlineExamSystemDb;Trusted_Connection=True;Integrated Security=True;");
        }
        public SinavContext(DbContextOptions<SinavContext> options)
    : base(options)
        { }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExamUser>().HasKey(eu => new { eu.UId, eu.EId });

        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamUser> ExamUsers { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Image> Images { get; set; }

        //ctrl + shift + v
        
    }
}
