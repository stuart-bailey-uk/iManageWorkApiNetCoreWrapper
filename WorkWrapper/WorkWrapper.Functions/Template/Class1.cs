using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkWrapper.Workspaces.Actions;
using WorkWrapper.Workspaces.Models;

namespace WorkWrapper.Functions.Template;

internal class CopyFromTemplateStrategy : IWorkspaceCreateStrategy
{
    public Task<IWorkspaceProfile> GetProfile()
    {
        throw new NotImplementedException();
    }
}