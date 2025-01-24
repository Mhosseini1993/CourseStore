using CourseStore.Config;
using EndPoint.SPA.Components;
using EndPoint.SPA.Middlewares;
using EndPoint.SPA.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders().AddConsole();

// Add services to the container.
builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

builder.Services.Configure<MongoDbSetting>(builder.Configuration.GetSection("MongoDbSettings"));
builder.Services.AddScoped<MongoDbSetting>(ef => ef.GetRequiredService<IOptions<MongoDbSetting>>().Value);
builder.Services.AddScoped<IMongoClient, MongoClient>(ef =>
{
    var setting = ef.GetRequiredService<MongoDbSetting>();
    return new MongoClient(setting.ConnectionString);
});

ProjectConfig.Init(builder.Services, builder.Configuration);


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

app.UseCatchException();

app.Run();
