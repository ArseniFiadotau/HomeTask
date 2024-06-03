using System.ComponentModel;

namespace Core.Data
{
    public enum EmploymentStatus
    {
        [Description("Employed")]
        Employed,
        [Description("Self-Employed")]
        SelfEmployed
        // add more types later
    }
}
