using OnlineStore.Interfaces;

namespace OnlineStore.Services;

public class NotificationDispatcher
{
    private readonly List<INotificationService> _observers = new();

    public void Register(INotificationService observer)
    {
        _observers.Add(observer);
    }

    public void NotifyAll(string message)
    {
        foreach (var observer in _observers)
        {
            observer.Notify(message);
        }
    }
}
