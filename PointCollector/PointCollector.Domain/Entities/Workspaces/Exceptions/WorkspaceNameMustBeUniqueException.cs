using PointCollector.Domain.Common.Exceptions;
using PointCollector.Domain.Common.Interfaces;

namespace PointCollector.Domain.Entities.Workspaces.Exceptions
{
    public class WorkspaceNameMustBeUniqueException : BusinessRuleValidationException
    {
        public WorkspaceNameMustBeUniqueException(IBusinessRule brokenRule) : base(brokenRule)
        {
        }
    }
}
