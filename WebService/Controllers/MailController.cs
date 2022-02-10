using FluentEmail.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WebService.Data;
using WebService.Models;
using WebService.Repositories.Implementations;
using WebService.Repositories.Interfaces;
using WebService.Services;

namespace WebService.Controllers;

[ApiController]
[Route("api/mails")]
public class MailController : ControllerBase
{
    private readonly ILogger<MailController> _logger;
    private readonly EmailMessageFormatter _messageFormatter;
    private readonly EmailMessageSender _messageSender;
    private readonly IMessagesRepository _messagesRepository;
    
    public MailController(ILogger<MailController> logger, IDbContextFactory<AppDbContext> contextFactory)
    {
        _logger = logger;
        _messagesRepository = new MessagesRepository(contextFactory);
        _messageFormatter = new EmailMessageFormatter();
        _messageSender = new EmailMessageSender();
    }

    /// <summary>
    ///     GetMessages() это GET метод, возвращающает все письма из базы данных в формате json.
    ///     Пример: /api/mails/
    /// </summary>
    /// <returns>Список всех сообщений в формате json</returns>
    [HttpGet]
    public string GetMessages()
    {
        return JsonConvert.SerializeObject(_messagesRepository.GetMessages());
    }

    /// <summary>
    ///     PostRequest() это POST метод, принимает запрос в формате json, формирует сообщение,
    ///     отправляет его, затем сохраняет объект EmailMessage в базе данных.
    ///     Пример: /api/mails/
    /// </summary>
    /// <returns>Результат отправки и текст ошибки если она произошла</returns>
    /// <param name="emailRequest">Запрос формата json</param>
    /// <param name="fluentEmail">Сервис отправки email</param>
    [HttpPost]
    public async Task PostRequest([FromBody] EmailRequest emailRequest, [FromServices] IFluentEmail fluentEmail)
    {
        var email = _messageFormatter.FormatMessage(emailRequest);
        
        try
        {
            await _messageSender.Send(email, fluentEmail);
            _logger.LogInformation($"Результат отправки: {email.Result} {email.FailedMessage}");
        }
        catch (Exception e)
        {
            _logger.LogError($"Результат отправки: {email.Result}, {e.Message}");
        }
        
        _messagesRepository.Create(email);
    }
}