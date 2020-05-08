using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WasteData.Infra.Services.DTO;

namespace WasteData.Infra.Services.Interfaces
{
    public interface IHttpService
    {
        Task<string> GetCountryByIpAddress(string ipAddress);
    }
}
