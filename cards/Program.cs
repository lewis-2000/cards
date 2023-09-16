using cards.Models;
using cards.Services;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDB"));
builder.Services.AddSingleton<CardDBService>();
builder.Services.AddSingleton<DiscoverDBService>();
builder.Services.AddSingleton<PurchaseCreditDBService>();
builder.Services.AddSingleton<StoreDBService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Cards API",
        Description = "ASP.Net core WebApi for managing school operations",
        Contact = new OpenApiContact
        {
            Name = "Lewis Nganga",
            Email = "lewisnganga1@outlook.com"
        },
        License = new OpenApiLicense
        {
            Name = "MIT License",
            Url = new Uri("https://OpenSource.org/licences/MIT")
        }
    });
    //Generate xml Docs that will drive the Swagger Docs
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    // var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFile));
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.DisplayOperationId();
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
