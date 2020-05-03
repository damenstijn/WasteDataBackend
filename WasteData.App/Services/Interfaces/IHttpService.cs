using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WasteData.App.Services.DTO;

namespace WasteData.App.Services.Interfaces
{
    public interface IHttpService
    {
        Task<string> GetCountryByIpAddress(string ipAddress);
    }
}
