using Microsoft.Extensions.Options;
using NetViewer.Infrastructure.Entities;
using NetViewer.Infrastructure.ScannerApi;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace NetworkViewer.Web.Data
{
    /// <summary>
    /// https://www.code4it.dev/blog/openapi-code-generation-vs2019
    /// https://www.code4it.dev/blog/swagger-integration
    /// </summary>
    public class FoundDeviceService
    {
        private string BaseUri { get; }
        public FoundDeviceService(IOptions<ApiOptions> options) => BaseUri = options.Value.ApiUri;

        public async Task<ICollection<FoundDevice>> GetDevicesAsync()
        {
            try
            {
                using var httpClient = new HttpClient();
                var client = new Client(BaseUri, httpClient);
                return await client.ApiDeviceAsync().ConfigureAwait(false);
            } catch (Exception)
            {
                return new List<FoundDevice>();
            }
        }
    }
}
