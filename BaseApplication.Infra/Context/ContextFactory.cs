using System.Text.Json;
using System.Text.Json.Nodes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BaseApplication.Infra.Context;

public class ContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var ambiente = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        var file = Path.Combine("..", "BaseApplication.Api", $"appsettings.{ambiente}.json");
        Console.WriteLine(file);
        var jsonString = File.ReadAllText(file);
        var json = JsonSerializer.Deserialize<JsonNode>(jsonString);
        string connectionString = (string)json!["ConnectionStrings"]!["Base"]!;
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

        optionsBuilder.UseNpgsql(connectionString);
        return new ApplicationDbContext(optionsBuilder.Options);
    }
}