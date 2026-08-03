using Goke.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Goke.Core.Extensions;

namespace Goke.Bank.WebServer.Data;

public class ApplicationSeeder
{
    public static async Task SeedAllAsync(IServiceProvider sp)
    {
        var context = sp.GetRequiredService<ApplicationDbContext>();

        //reset the database
        await context.Database.EnsureDeletedAsync();

        //migrate the database
        await context.Database.MigrateAsync();

        //Seed Roles
        await AddRolesAsync(sp);

        //Seed Users
        await AddUsersAsync(sp);

        //Seed other data
        await SeedDataAsync(context);


        await context.SaveChangesAsync();
    }

    private static async Task AddRolesAsync(IServiceProvider sp)
    {
        var roleManager = sp.GetRequiredService<RoleManager<IdentityRole>>();
        var configuration = sp.GetRequiredService<IConfiguration>();

        await AddRoleAsync(roleManager, configuration);
    }

    public static async Task AddRoleAsync(RoleManager<IdentityRole> roleManager, IConfiguration configuration)
    {
        var rolesSection = configuration.GetSection("SeedRoles");
        var rolesFromConfig = rolesSection.Get<string[]>();
        var roles = rolesFromConfig is { Length: > 0 }
            ? [.. rolesFromConfig]
            : new List<string> { "Administrators", "Users" };

        foreach (var roleName in roles)
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }
    }

    private static async Task AddUsersAsync(IServiceProvider sp)
    {
        var userManager = sp.GetRequiredService<UserManager<ApplicationUser>>();
        //var appEmailSender = sp.GetRequiredService<ApplicationEmailSender>();
        var configuration = sp.GetRequiredService<IConfiguration>();

        var seeded = await AddUsersAsync(userManager, /*appEmailSender,*/ configuration);
        if (!seeded)
        {
            await EnsureDevelopmentUsersAsync(userManager);
        }
    }

    public static async Task<bool> AddUsersAsync(
        UserManager<ApplicationUser> userManager,
        //ApplicationEmailSender appEmailSender,
        IConfiguration configuration)
    {
        var usersSection = configuration.GetSection("SeedUsers");
        var usersFromConfig = usersSection.Get<SeedUserOptions[]>();

        if (usersFromConfig == null || usersFromConfig.Length == 0)
        {
            return false;
        }

        foreach (var userOptions in usersFromConfig)
        {
            var existingUser = await userManager.FindByNameAsync(userOptions.UserName);
            if (existingUser != null)
            {
                continue;
            }

            var user = new ApplicationUser
            {
                UserName = userOptions.UserName,
                Email = userOptions.Email,
                EmailConfirmed = true
            };

            var passwordToUse = GetPasswordToUse(userOptions.Password);

            // Send email to user with password
            //var htmlMessage = $"Hello {userOptions.UserName},<br><br>Your account has been created. Please use the following password to log in: {passwordToUse}";
            //await appEmailSender.SendEmailAsync(userOptions.Email, $"Create User: {userOptions.UserName}", htmlMessage);

            var result = await userManager.CreateAsync(user, passwordToUse);
            if (result.Succeeded && !string.IsNullOrEmpty(userOptions.Role))
            {
                await userManager.AddToRoleAsync(user, userOptions.Role);
            }
        }

        return true;
    }

    private static async Task EnsureDevelopmentUsersAsync(UserManager<ApplicationUser> userManager)
    {
        await EnsureDevelopmentUserAsync(userManager, "admin@ark.com", "admin@goke.local", "Administrators", "Pass123$");
        await EnsureDevelopmentUserAsync(userManager, "lola@ark.com", "lola@goke.local", "Users", "Pass123$");
        await EnsureDevelopmentUserAsync(userManager, "olu@ark.com", "olu@goke.local", "Users", "Pass123$");
    }

    private static async Task EnsureDevelopmentUserAsync(
        UserManager<ApplicationUser> userManager,
        string userName,
        string email,
        string role,
        string password)
    {
        var existingUser = await userManager.FindByNameAsync(userName);
        if (existingUser != null)
        {
            if (!await userManager.IsInRoleAsync(existingUser, role))
            {
                await userManager.AddToRoleAsync(existingUser, role);
            }

            return;
        }

        var user = new ApplicationUser
        {
            UserName = userName,
            Email = email,
            EmailConfirmed = true
        };

        var result = await userManager.CreateAsync(user, password);
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(user, role);
        }
    }

    private static string GetPasswordToUse(string? password)
    {
        return string.IsNullOrEmpty(password)
            ? string.GeneratePassword(20)
            : password;
    }

    private static async Task SeedDataAsync(ApplicationDbContext context)
    {
        //throw new NotImplementedException();
    }
}