using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WebService.Models;

namespace WebService.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    /// <summary>
    /// Представление таблицы EmailMessage
    /// </summary>
    public DbSet<EmailMessage> EmailMessages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Я решил, что лучше использовать сериализацию/десериализацию для
        // сохранения списка строк, чем создовать отдельную таблицу.
        modelBuilder.Entity<EmailMessage>().Property(e => e.Recipients)
            .HasConversion(
                r => JsonConvert.SerializeObject(r),
                r => JsonConvert.DeserializeObject<List<string>>(r));
    }
}