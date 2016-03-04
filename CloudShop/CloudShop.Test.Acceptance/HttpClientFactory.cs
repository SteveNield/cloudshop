using System;
using System.Net.Http;
using System.Web.Http.SelfHost;
using CloudShop.Api;

namespace CloudShop.Test.Acceptance
{
    public static class HttpClientFactory
    {
        private const string BaseAddressUrl = "http://localhost:9876";

        public static HttpClient Create(string overrideUrl = null)
        {
            var url = overrideUrl ?? BaseAddressUrl;
            var baseAddress = new Uri(url);
            var config = new HttpSelfHostConfiguration(baseAddress);
            new WebApiConfig(WindsorContainerFactory.Create()).Configure(config);
            var server = new HttpSelfHostServer(config);
            var client = new HttpClient(server) {BaseAddress = baseAddress};
            return client;
        }
    }
}
