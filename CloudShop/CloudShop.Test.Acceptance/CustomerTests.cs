using System.Net.Http;
using Xunit;

namespace CloudShop.Test.Acceptance
{
    public class CustomerTests
    {
        [Fact]
        public void Get_Returns_200()
        {
            using (var client = HttpClientFactory.Create())
            {
                var response = client.GetAsync("").Result;

                Assert.True(response.IsSuccessStatusCode, $"Actual status code: {response.StatusCode}");
            }
        }

        [Fact]
        public void Get_Returns_Appropriate_Message()
        {
            using (var client = HttpClientFactory.Create())
            {
                var response = client.GetAsync("").Result;

                Assert.Equal("OK", response.Content.ReadAsAsync<string>().Result);
            }
        }
    }
}
