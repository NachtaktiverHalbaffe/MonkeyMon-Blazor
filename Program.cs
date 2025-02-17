using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using MonkeyMon_Blazor.Components;
using MonkeyMon_Blazor.Infrastructure;
using MonkeyMon_Blazor.Properties;
using MonkeyMon_Blazor.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("EFUnitOfWork"));
});

builder.Services.Configure<SpeciesApiSettings>(builder.Configuration.GetSection(nameof(SpeciesApiSettings)));
builder.Services.AddTransient<SpeciesService>();
builder.Services.AddHttpClient<SpeciesService>(configureClient: client =>
{
    var server = builder.Configuration.GetSection(nameof(SpeciesApiSettings)).GetValue<string?>("Url")!;
    var token = builder.Configuration.GetSection(nameof(SpeciesApiSettings)).GetValue<string?>("ApiToken")!;

    client.BaseAddress = new Uri(server);
    client.DefaultRequestHeaders.Add("Accept", "application/json");
    client.DefaultRequestHeaders.Add("X-API-key", token);
});

builder.Services.AddTransient<PokeApiService>();
builder.Services.AddHttpClient<PokeApiService>(configureClient: client =>
{
    client.BaseAddress = new Uri("https://pokeapi.co/api/v2/");
});
builder.Services.AddHostedService<FetchPokeApiStartupTask>();

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
        if (!context.Monkeys.Any() || !context.Pokemons.Any())
        {
            // recreate database and fill with seed data
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
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