using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using stagiaireCRUD.Models;
namespace stagiaireCRUD.Data;
public class AppDbContext : DbContext
{
    public DbSet<Etudiant> Etudiants
    {
        get;
        set;
    } 

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EtudiantDB;Trusted_Connection=True;");
        }

    }

    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EtudiantDB;Trusted_Connection=True;");
        return new AppDbContext(optionsBuilder.Options);
    }
}

}