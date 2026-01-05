
using System;
class Program
{
    static void Main()
    {
        Course.UpdateInstituteName("BridgeLabz");
        Course c = new Course("C#", 30, 5000);
        c.DisplayCourseDetails();
    }
}
