using WebService.Models;

namespace WebService.Repositories.Interfaces;

public interface IMessagesRepository
{
    void Create(EmailMessage emailMessage);
    IEnumerable<EmailMessage> GetMessages();
}