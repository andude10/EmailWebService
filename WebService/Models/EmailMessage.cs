using System.ComponentModel.DataAnnotations;

namespace WebService.Models;

public class EmailMessage
{
    [Key] public int Id { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
    public string Result { get; set; }
    public string? FailedMessage { get; set; }
    public List<string> Recipients { get; set; } = new();
}