using Microsoft.EntityFrameworkCore;
using TestPTMK.DAL.Model;

namespace TestPTMK.DAL;

public class DBHelper: DbContext
{
    public DbSet<EmployeeModel> Employees { get; set; } = null!;

    
    public DBHelper()
    {
        Database.EnsureCreated();
        
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=TestPTMK;Username=postgres;Password=Vomber123");
    }
}