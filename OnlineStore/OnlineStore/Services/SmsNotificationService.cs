using OnlineStore.Interfaces;

namespace OnlineStore.Services;

public class SmsNotificationService : INotificationService
{
    public void Notify(string message)
    {
        Console.WriteLine($"📱 SMS sent: {message}");
    }
}
