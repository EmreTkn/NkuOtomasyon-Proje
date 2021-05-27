using System.Runtime.Serialization;

namespace Core.Entities
{
    public enum Types
    {
        [EnumMember(Value = nameof(Entities.Student))]
        Student,
        [EnumMember(Value = "Teacher")]
        Teacher,
        [EnumMember(Value = "StudentAffairs")]
        StudentAffairs
    }
}
