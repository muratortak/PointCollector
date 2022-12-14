using ErrorOr;

namespace PointCollector.Domain.Common.Errors
{
    public static class Errors
    {
        public static class User
        {
            public static Error DuplicateEmail => Error.Conflict(code: "User.DuplicateEmail", description: "User exists.");
            public static Error InvalidEmailOrPassword => Error.Validation(code: "User.InvalidEmailOrPassword", description: "Invalid Email or Password.");
        }

        public static class Workspace
        {
            public static Error DuplicateName => Error.Conflict(code: "Workspace.DuplicateName", description: "Workspace exists.");
        }
    }
}
