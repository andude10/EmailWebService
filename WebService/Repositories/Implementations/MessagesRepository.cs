using Microsoft.EntityFrameworkCore;
using WebService.Data;
using WebService.Models;
using WebService.Repositories.Interfaces;

namespace WebService.Repositories.Implementations;

public class MessagesRepository : IMessagesRepository
{
    private readonly IDbContextFactory<AppDbContext> _contextFactory;

    public MessagesRepository(IDbContextFactory<AppDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public void Create(EmailMessage emailMessage)
    {
        using var context = _contextFactory.CreateDbContext();
        context.EmailMessages.Add(emailMessage);
        context.SaveChanges();
    }

    public IEnumerable<EmailMessage> GetMessages()
    {
        using var context = _contextFactory.CreateDbContext();
        return context.EmailMessages.ToList();
    }
}