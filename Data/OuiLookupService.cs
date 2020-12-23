using Microsoft.Extensions.Options;
using NetViewer.Infrastructure.Entities;
using NetViewer.Infrastructure.ScannerApi;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace NetworkViewer.Web.Data
{
    public class OuiLookupService
    {
        private string BaseUri { get; }
        public OuiLookupService(IOptions<ApiOptions> options)
            => BaseUri = options.Value.ApiUri;

        public async Task<ICollection<OuiLookup>> LookupByBase16(string search)
        {
            try
            {
                using var httpClient = new HttpClient();
                var client = new Client(BaseUri, httpClient);
                return await client.Base16FindAsync(search).ConfigureAwait(false);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<ICollection<OuiLookup>> LookupByHex(string search)
        {
            try
            {
                using var httpClient = new HttpClient();
                var client = new Client(BaseUri, httpClient);
                return await client.HexFindAsync(search).ConfigureAwait(false);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
