using ProductManager.Domain.Notifications;

namespace ProductManager.Domain.Interfaces;

public interface INotifier
{
    bool HaveNotification();
    List<Notification> GetNotifications();
    void Handle(Notification notification);
}