using OnlineStore.Interfaces;

namespace OnlineStore.Decorators;

public class NotificationDecorator : INotificationService
{
    protected readonly INotificationService _wrapped;

    public NotificationDecorator(INotificationService wrapped)
    {
        _wrapped = wrapped;
    }

    public virtual void Notify(string message)
    {
        _wrapped.Notify(message);
    }
}
