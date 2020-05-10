using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WasteData.Infra.Services.DTO;
using Microsoft.Extensions.Logging;
using WasteData.App.Interfaces;

namespace WasteData.Infra.Services
{
    public class HttpService : IHttpService
    {
        private readonly ILogger<IHttpService> _logger;
        public HttpService(ILogger<IHttpService> logger)
        {
            _logger = logger;
        }

        public async Task<string> GetCountryByIpAddress(string ipAddress) 
        {
            try
            {
                using var client = new HttpClient();
                using var request = new HttpRequestMessage(HttpMethod.Get, $"http://api.ipstack.com/{ipAddress}?access_key=c67733d05edce7b32b2d410b68c24d53");
                using var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                var ipAddressLookup = JsonConvert.DeserializeObject<IpAddressLookupDto>(content);

                _logger.LogInformation($"GetCountryByIpAddress - IP:{ipAddress} - Country:{ipAddressLookup.CountryCode}");

                return ipAddressLookup.CountryCode;
            }
            catch (Exception ex) 
            {
                _logger.LogError("GetCountryByIpAddress", ex);
                return string.Empty;
            }
        }
    }
}
