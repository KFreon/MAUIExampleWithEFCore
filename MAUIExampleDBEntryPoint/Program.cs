using MAUIExampleDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

Console.WriteLine("This is the efcore CLI migrations entrypoint. Use 'dotnet ef migrations add <migration name> --project MAUIExampleDB/MAUIExampleDB.csproj --startup-project MAUIExampleDBEntryPoint/MAUIExampleDBEntryPoint.csproj' to add a new migration");

// This is required by the CLI tools.
// Note that this project requires the EFCore.Design nuget package to function with those tools.
public class DesignRepo : IDesignTimeDbContextFactory<Repo>
{
    public Repo CreateDbContext(string[] args)
    {
        return new Repo(new DbContextOptionsBuilder<Repo>().UseSqlite("doesnt matter").Options);
    }
}