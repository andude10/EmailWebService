using System.Net;
using System.Net.Mail;
using Microsoft.EntityFrameworkCore;
using WebService.Data;

var builder = WebApplication.CreateBuilder(args);

#region ConfigureServices

builder.Services.AddControllers();

builder.Services.AddDbContextFactory<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var smtpServerConfiguration = builder.Configuration.GetSection("SmtpServerConfiguration");
var smtpClient = new SmtpClient
{
    Host = smtpServerConfiguration.GetSection("Host").Value,
    Port = int.Parse(smtpServerConfiguration.GetSection("Port").Value),
    EnableSsl = true,
    DeliveryMethod = SmtpDeliveryMethod.Network,
    Credentials = new NetworkCredential("xxx", "xxx")
};
builder.Services.AddFluentEmail(smtpServerConfiguration.GetSection("DefaultSenderEmail").Value)
    .AddSmtpSender(smtpClient);

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) app.UseDeveloperExceptionPage();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();