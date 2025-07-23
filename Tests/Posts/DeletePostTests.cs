using RestSharp;
using Xunit;
using Allure.Xunit.Attributes;
using Allure.Net.Commons;

namespace AutomacaoAPIRestSharp.Tests
{
    [AllureSuite("Posts API")]
    [AllureSubSuite("Deletar Post")]
    [AllureFeature("DeletePostTest")]
    public class DeletePostTests
    {
        [AllureTag("API", "DELETE")]
        [AllureSeverity(SeverityLevel.minor)]
        [AllureOwner("Mateus")]
        [AllureDescription("Deleta um post e valida o status 200")]
        [Fact]
        public void DeletePost_DeveRetornarStatus200()
        {
            var client = new RestClient("https://jsonplaceholder.typicode.com");
            var request = new RestRequest("/posts/1", Method.Delete);

            var response = client.Execute(request);
            Assert.Equal(200, (int)response.StatusCode);
        }
    }
}
