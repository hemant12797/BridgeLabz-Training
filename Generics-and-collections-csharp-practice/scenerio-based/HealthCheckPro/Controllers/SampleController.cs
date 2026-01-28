using HealthCheckPro.Attributes;

namespace HealthCheckPro.Controllers
{
    public class SampleController
    {
        [PublicAPI("Retrieves lab test results")]
        public void GetLabResults()
        {
            // Implementation
        }

        [RequiresAuth("Admin")]
        public void UpdateLabTest()
        {
            // Implementation
        }

        public void DeleteLabTest()
        {
            // Implementation - missing annotation
        }

        [PublicAPI]
        public void GetPatientInfo()
        {
            // Implementation
        }
    }
}
