using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WasteData.App.Interfaces
{
    public interface IHttpService
    {
        Task<string> GetCountryByIpAddress(string ipAddress);
    }
}
