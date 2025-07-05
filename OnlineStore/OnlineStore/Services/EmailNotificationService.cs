using OnlineStore.Interfaces;

namespace OnlineStore.Services;

public class EmailNotificationService : INotificationService
{
    public void Notify(string message)
    {
        Console.WriteLine($"📧 Email sent: {message}");
    }
}
