using System.ComponentModel;

namespace VerticalSlicingSimpleApp.Common.Enums
{
    public enum ErrorCode
    {
        NoError = 0,
        InvalidCouseID = 100,
        CourseNotFound = 101,


        InstructorNotFound = 201,
        [Description("Validation errors")]
        ValidationErrors = 1,
        [Description("Author name already exists")]
        AuthorNameExist = 30001,
    }
}
