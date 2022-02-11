using Microsoft.EntityFrameworkCore;
using WebService.Data;
using WebService.Models;
using WebService.Repositories.Interfaces;

namespace WebService.Repositories.Implementations;

/// <summary>
/// Реализация репозитория для взаимодействия с EmailMessage в базе данных
/// </summary>
public class EmailMessagesRepository : IEmailMessagesRepository
{
    private readonly IDbContextFactory<AppDbContext> _contextFactory;

    public EmailMessagesRepository(IDbContextFactory<AppDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    /// <summary>
    /// Create() метод сохраняет сообщение в базу данных
    /// </summary>
    /// <param name="emailMessage">Сохраняемое сообщение</param>
    public void Create(EmailMessage emailMessage)
    {
        using var context = _contextFactory.CreateDbContext();
        context.EmailMessages.Add(emailMessage);
        context.SaveChanges();
    }

    /// <summary>
    /// GetMessages() возвращает лист всех сохраненных сообщений
    /// </summary>
    /// <returns>Лист всех сохраненных сообщений</returns>
    public IEnumerable<EmailMessage> GetMessages()
    {
        using var context = _contextFactory.CreateDbContext();
        return context.EmailMessages.ToList();
    }
}