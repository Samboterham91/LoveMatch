namespace Lovematch.NotificationsAPI.Models
{
    public class MatchNotificationRequest
    {
        public string DeviceToken { get; set; } = "";
        public string MatchedUserName { get; set; } = "";
    }
}