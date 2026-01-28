using EventTracker.Attributes;

namespace EventTracker.Services
{
    public class UserService
    {
        [AuditTrail("Login")]
        public void Login(string username)
        {
            // Implementation
        }

        [AuditTrail("FileUpload")]
        public void UploadFile(string filename)
        {
            // Implementation
        }

        public void Logout()
        {
            // Implementation - no audit
        }
    }
}
