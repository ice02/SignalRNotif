namespace SignalRNotif.Service
{
    public interface INotificationsService
    {
        string GetNotificationByUserId(int userId);
        void Delete(int id, int userId);
        int Create(NotificationCreateRequest model);
        bool NotificationExists(string type, int userId, int senderId);
    }
}