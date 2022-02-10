using System.ComponentModel.DataAnnotations.Schema;

namespace WebService.Models;

/// <summary>
/// EmailRequest это представление json POST запроса /api/mails/
/// </summary>
[NotMapped]
public class EmailRequest
{
    public string Subject { get; set; }
    public string Body { get; set; }
    public List<string> Recipients { get; set; } = new();
}