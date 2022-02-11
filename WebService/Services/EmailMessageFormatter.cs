using Newtonsoft.Json;
using WebService.Models;

namespace WebService.Services;

/// <summary>
/// EmailMessageFormatter объект отвечает за формирование
/// сообщения из запроса json
/// </summary>
public class EmailMessageFormatter
{
    /// <summary>
    ///     Формирует объект email из запроса
    /// </summary>
    /// <param name="emailRequest">Запрос</param>
    /// <returns>Сформированное сообщение</returns>
    public EmailMessage? FormatMessage(EmailRequest emailRequest)
    {
        return JsonConvert.DeserializeObject<EmailMessage>(JsonConvert.SerializeObject(emailRequest));
    }
}