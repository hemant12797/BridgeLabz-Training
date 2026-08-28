namespace LabelManagement.HttpClients
{
    /// <summary>
    /// Fetches note data from the NotesManagement service via HTTP.
    /// Used by ReminderService to get the note title for email notifications.
    /// </summary>
    public interface INoteServiceClient
    {
        Task<string?> GetNoteTitleAsync(int noteId, int userId, string jwtToken);
    }
}
