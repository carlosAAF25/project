using OnlineStore.Interfaces;

namespace OnlineStore.Decorators;

public class LoggingNotificationDecorator : NotificationDecorator
{
    public LoggingNotificationDecorator(INotificationService wrapped)
        : base(wrapped) { }

    public override void Notify(string message)
    {
        Console.WriteLine($"[LOG] Enviando notificación: {message}");
        base.Notify(message);
    }
}
