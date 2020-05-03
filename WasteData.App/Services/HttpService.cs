using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WasteData.App.Services.Interfaces;
using WasteData.App.Services.DTO;

namespace WasteData.App.Services
{
    public class HttpService : IHttpService
    {
        public async Task<string> GetCountryByIpAddress(string ipAddress) 
        {
            try
            {
                using (var client = new HttpClient())
                using (var request = new HttpRequestMessage(HttpMethod.Get, $"http://api.ipstack.com/{ipAddress}?access_key=c67733d05edce7b32b2d410b68c24d53"))
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var content = await response.Content.ReadAsStringAsync();
                    var ipAddressLookup = JsonConvert.DeserializeObject<IpAddressLookupDto>(content);
                    return ipAddressLookup.CountryCode;
                }
            }
            catch (Exception ex) 
            {
                return string.Empty;
            }
        }
    }
}
