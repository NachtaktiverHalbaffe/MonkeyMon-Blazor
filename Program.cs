using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using MonkeyMon_Blazor.Components;
using MonkeyMon_Blazor.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("EFUnitOfWork"));
});
// Add MudBlazor services
builder.Services.AddMudServices();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

try
{
    using var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
    var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    if (app.Environment.IsDevelopment())
    {
        // recreate database and fill with seed data
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
    }
    else
    {
        await context.Database.MigrateAsync();
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Failed to update database: {ex}");
}

app.Run();
