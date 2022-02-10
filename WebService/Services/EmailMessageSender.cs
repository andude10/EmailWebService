using FluentEmail.Core;
using FluentEmail.Core.Models;
using WebService.Models;

namespace WebService.Services;

/// <summary>
/// EmailMessageSender сервис для отправки Email сообщений
/// </summary>
public class EmailMessageSender
{
    /// <summary>
    ///     Метод асинхронно отправляет email и записывает результат отправки
    ///     в объект EmailMessage (также если нужно сообщение об ошибке)
    /// </summary>
    /// <param name="emailMessage">Отправляемый email</param>
    /// <param name="fluentEmail">Сервис отправки email</param>
    public async Task Send(EmailMessage emailMessage, IFluentEmail fluentEmail)
    {
        try
        {
            var response = await fluentEmail.CC(emailMessage.Recipients.Select(t => new Address(t)).ToList())
                .Subject(emailMessage.Subject)
                .Body(emailMessage.Body)
                .SendAsync();
            
            emailMessage.Result = response.Successful ? "OK" : "Failed";
            emailMessage.FailedMessage = string.Join("; /n", response.ErrorMessages);
        }
        catch (Exception e)
        {
            emailMessage.Result = "Failed";
            emailMessage.FailedMessage = e.Message;
            throw;
        }
    }
}