using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace WasteData.App.Commands.AddDownloadTest
{
	public class AddDownloadTestDtoValidator : AbstractValidator<AddDownloadTestDto>
	{
		public AddDownloadTestDtoValidator()
		{
			RuleFor(x => x.TotalBytesDownloaded).NotNull();
			RuleFor(x => x.StartDate).NotNull();
			RuleFor(x => x.EndDate).NotNull();
			RuleFor(x => x.IsWifi).NotNull();
			RuleFor(x => x.ConnectionName).NotNull();
			RuleFor(x => x.IpAddress).NotNull();
			RuleFor(x => x.DeviceGuid).NotNull();
			RuleFor(x => x.DeviceName).NotNull();
			RuleFor(x => x.OsId).NotNull();
			RuleFor(x => x.OsVersion).NotNull();
		}
	}
}
