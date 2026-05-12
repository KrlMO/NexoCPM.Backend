using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NexoCPM.Application.Commons.Ports;
using NexoCPM.Domain.Users.Entities;
using NexoCPM.Persistence.Context;

namespace NexoCPM.Persistence.Seeders.Runner;

public static class DbSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context, IPasswordHasher passwordHasher, IConfiguration configuration)
    {
        if (!await context.Users.AnyAsync(u => u.Code == "SYSA-676767"))
        {
            var sysPassword = configuration["SysAdmin:Password"] ?? "Admin123*";
            var hashedPassword = passwordHasher.Hash(sysPassword);

            var user = new User(
                firstName: "System",
                lastName: "Administrator",
                userName: "sysadmin",
                email: "admin@nexo.com",
                passwordHash: hashedPassword,
                code: "SYSA-676767"
            );

            context.Users.Add(user);

            await context.SaveChangesAsync();
        }

        var sqlPath = Path.Combine(
            AppContext.BaseDirectory,
            "Seeders",
            "Sql",
            "001_initial_context.sql"
        );

        var sql = await File.ReadAllTextAsync(sqlPath);

        await context.Database.ExecuteSqlRawAsync(sql);
    }
}
