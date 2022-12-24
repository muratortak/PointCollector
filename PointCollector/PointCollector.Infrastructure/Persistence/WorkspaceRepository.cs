using Microsoft.EntityFrameworkCore;
using PointCollector.Application.Common.Interfaces.Persistence.Workspaces;
using PointCollector.Domain.Entities.Workspaces;
using PointCollector.Infrastructure.Data;

namespace PointCollector.Infrastructure.Persistence
{
    public class WorkspaceRepository : IWorkspaceRepository
    {
        private readonly PointCollectorContext _context;
        private static readonly List<Workspace> _workspaces = new();

        public WorkspaceRepository(PointCollectorContext context)
        {
            _context = context;
        }
        public async Task<Workspace> Add(Workspace workspace)
        {
            await _context.Workspaces.AddAsync(workspace);
            await _context.SaveChangesAsync();

            return workspace;
        }

        public async Task<Workspace>? GetWorkspaceByName(string name)
        {
            return await _context.Workspaces.FirstOrDefaultAsync(w => w.Name == name);
        }
    }
}
