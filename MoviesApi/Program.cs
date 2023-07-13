using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.VisualBasic;
using MoviesApi.Model;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDBContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddCors();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("V1", new OpenApiInfo { 
    Title="TestApi",
    Version="v1",
    Description="my first api",
    TermsOfService=new Uri("http://www.google.com"),
    Contact=new OpenApiContact
    {
        Name="mohamed",
        Url= new Uri("http://www.google.com"),
        Email="mohamed@gmail.com"

    },
    License=new OpenApiLicense
    {
        Name="Mohamden",
        Url=new Uri("http://www.google.com")
        
    }

    });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name="Authorization",
        Type=SecuritySchemeType.ApiKey,
        BearerFormat="JWT",
        Scheme="Bearer",
        In=ParameterLocation.Header,
        Description="Enter your JWT KEY"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference=new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"


                },Name="Bearer",
                 In=ParameterLocation.Header
            },
            new List<String>()
        }
    }) ;

    
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();
