using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace WasteData.App.Commands
{
    public class AddDownloadTestCommand : IRequest<Unit>
    {
        public AddDownloadTestDto DownloadTest { get; set; }
    }
}
