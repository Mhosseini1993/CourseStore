using CourseStore.Config;
using EndPoint.SPA.Model;
using EndPoint.UI.Client.Pages;
using EndPoint.UI.Components;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
                .AddInteractiveWebAssemblyComponents();

builder.Services.AddHttpClient();
builder.Services.AddControllers();

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("Cors", options =>
//    {
//        options.AllowAnyOrigin();
//        options.AllowAnyHeader();
//        options.AllowAnyMethod();   
//    });
//});


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
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseRouting();
//app.UseCors("Cors");

app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(CourseListPage).Assembly);


app.MapControllers();

app.Run();
