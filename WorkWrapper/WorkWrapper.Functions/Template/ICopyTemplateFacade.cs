using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkWrapper.Comms;
using WorkWrapper.Workspaces.Models;

namespace WorkWrapper.Functions.Template;

internal interface ICopyTemplateFacade
{
    Task<DataResponse<Workspace>> CopyTemplate(string templateId);
}
