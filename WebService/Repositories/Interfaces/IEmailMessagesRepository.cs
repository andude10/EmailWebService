using WebService.Models;

namespace WebService.Repositories.Interfaces;

/// <summary>
/// Интерфейс репозитория для взаимодействия с EmailMessage в базе данных
/// </summary>
public interface IEmailMessagesRepository
{
    /// <summary>
    /// Create() метод сохраняет сообщение в базу данных
    /// </summary>
    /// <param name="emailMessage">Сохраняемое сообщение</param>
    void Create(EmailMessage emailMessage);
    
    /// <summary>
    /// GetMessages() возвращает лист всех сохраненных сообщений
    /// </summary>
    /// <returns>Лист всех сохраненных сообщений</returns>
    IEnumerable<EmailMessage> GetMessages();
}