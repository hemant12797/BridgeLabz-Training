namespace LabelManagement.HttpClients
{
    /// <summary>
    /// Fetches user data from the UserManagement service via HTTP.
    /// Used by ReminderService to get the user's email for notifications.
    /// </summary>
    public interface IUserServiceClient
    {
        Task<string?> GetUserEmailAsync(int userId, string jwtToken);
    }
}
