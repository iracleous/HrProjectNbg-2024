using HrProjectNbg_2024.Models;
using Microsoft.EntityFrameworkCore;

namespace HrProjectNbg_2024.Data;

public class HrDbContext:DbContext
{
    public DbSet<Department> Departments { get; set; }
    public DbSet<Employee> Employees { get; set; }

    public HrDbContext()
    {
    }

    public HrDbContext(DbContextOptions<HrDbContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var MyConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        var connectionString = MyConfig.GetValue<string>("ConnectionStrings:Con1");
        optionsBuilder.UseSqlServer(connectionString);
    }

}
