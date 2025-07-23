using RestSharp;
using Xunit;
using Newtonsoft.Json.Linq;
using Allure.Xunit.Attributes;
using Allure.Net.Commons;

namespace AutomacaoAPIRestSharp.Tests
{
    [AllureSuite("Posts API")]
    [AllureSubSuite("Buscar Post")]
    [AllureFeature("DeletePostTest")]
    public class GetPostTests
    {
        [AllureTag("API", "GET")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("Mateus")]
        [AllureDescription("Valida o schema do retorno ao buscar um post")]
        [Fact]
        public void GetPost_DeveRetornarStatus200EValidarSchema()
        {
            var client = new RestClient("https://jsonplaceholder.typicode.com");
            var request = new RestRequest("/posts/1", Method.Get);

            var response = client.Execute(request);
            Assert.Equal(200, (int)response.StatusCode);
            Assert.False(string.IsNullOrEmpty(response.Content));

            var json = JObject.Parse(response.Content!);

            Assert.True(json.ContainsKey("userId"));
            Assert.True(json.ContainsKey("id"));
            Assert.True(json.ContainsKey("title"));
            Assert.True(json.ContainsKey("body"));

            Assert.IsType<int>(json["userId"]!.Value<int>());
            Assert.IsType<int>(json["id"]!.Value<int>());
            Assert.IsType<string>(json["title"]!.Value<string>());
            Assert.IsType<string>(json["body"]!.Value<string>());
        }
    }
}
