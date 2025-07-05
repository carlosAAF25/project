using OnlineStore.Interfaces;

namespace OnlineStore.Factories;

public static class NotificationFactory
{
    public static INotificationService Create(string type)
    {
        return type.ToLower() switch
        {
            "email" => new Services.EmailNotificationService(),
            "sms" => new Services.SmsNotificationService(),
            _ => throw new ArgumentException("Invalid notification type")
        };
    }
}
