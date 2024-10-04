using Microsoft.AspNetCore.Builder;

namespace BaseApplication.Infra.Configurations;

public static class ConfigureMigrationDatabase
{
    public static void MigrateDatabase(this IApplicationBuilder app)
    {
        // using (var scope = app.ApplicationServices.CreateScope())
        // {
        //     var services = scope.ServiceProvider;
        //     try
        //     {
        //         var db = services.GetRequiredService<ApplicationDbContext>();
        //         db.Database.Migrate();
        //         Console.WriteLine("Migrações executadas");
        //     }
        //     catch (Exception e)
        //     {
        //         Console.WriteLine($"Erro ao realizar migração automática: {e.Message}");
        //         throw new Exception(
        //             $"Erro ao realizar migração: {e.Message}");
        //     }    
        // }
    }
}