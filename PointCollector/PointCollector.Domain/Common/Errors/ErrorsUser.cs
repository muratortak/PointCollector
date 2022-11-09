using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointCollector.Domain.Common.Errors
{
    public static class Errors
    {
        public static class User
        {
            public static Error DuplicateEmail => Error.Conflict(code: "User.DuplicateEmail", description: "User exists.");
            public static Error InvalidEmailOrPassword => Error.Validation(code: "User.InvalidEmailOrPassword", description: "Invalid Email or Password.");
        }
    }
}
