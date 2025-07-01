using CapsulaDoTempo.DbContext;
using CapsulaDoTempo.Services;
using CapsulaDoTempo.Services.Adapters;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var keyMailJet = builder.Configuration["MailJet:SecretKey"];
var secretMailJet = builder.Configuration["MailJet:ApiKey"];
builder.Services.Configure<MailJetSettings>(builder.Configuration.GetSection("MailJet"));
builder.Services.AddTransient<EmailSender>();

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection"));
});
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();