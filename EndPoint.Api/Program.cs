using CourseStore.Config;
using CourseStore.Query.Courses.Mapper;
using EndPoint.Api.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<MongoDbSetting>(builder.Configuration.GetSection("MongoDbSettings"));
builder.Services.AddScoped<MongoDbSetting>(ef => ef.GetRequiredService<IOptions<MongoDbSetting>>().Value);
builder.Services.AddScoped<IMongoClient, MongoClient>(ef =>
{
    var setting = ef.GetRequiredService<MongoDbSetting>();
    return new MongoClient(setting.ConnectionString);
});

builder.Services.AddAutoMapper(typeof(CourseMapper).Assembly);
ProjectConfig.Init(builder.Services, builder.Configuration);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme= JwtBearerDefaults.AuthenticationScheme;
    options.DefaultSignInScheme= JwtBearerDefaults.AuthenticationScheme;
    options.DefaultSignInScheme=JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
{
    options.TokenValidationParameters=new TokenValidationParameters()
    {
        ValidIssuer="Blazor",
        ValidAudience="Blazor",

        ValidateIssuer=true,
        ValidateAudience=true,
        ValidateIssuerSigningKey=true,
        ValidateLifetime=true,

        ClockSkew=TimeSpan.Zero,

        IssuerSigningKey=new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("289ED825-904E-41BD-9C59-7121D6F63860")),
    };
    options.SaveToken=true;

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
