using System.Collections.Generic;

namespace ResumeScreeningSystem
{
    public abstract class JobRole
    {
        public string RoleName { get; protected set; }
        public List<string> RequiredSkills { get; protected set; }

        protected JobRole(string roleName, List<string> requiredSkills)
        {
            RoleName = roleName;
            RequiredSkills = requiredSkills;
        }
    }
}
