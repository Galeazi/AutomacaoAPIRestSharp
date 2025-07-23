using RestSharp;
using Xunit;
using Newtonsoft.Json.Linq;
using Allure.Xunit.Attributes;
using Allure.Net.Commons;

namespace AutomacaoAPIRestSharp.Tests
{
    [AllureSuite("Posts API")]
    [AllureSubSuite("Criar Post")]
    [AllureFeature("CreatePostTest")]
    public class CreatePostTests
    {
        [AllureTag("API", "POST")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Mateus")]
        [AllureDescription("Cria um novo post e valida a resposta")]
        [Fact]
        public void CriarPost_DeveRetornarDadosCorretos()
        {
            var client = new RestClient("https://jsonplaceholder.typicode.com");
            var request = new RestRequest("/posts", Method.Post);

            var novoPost = new
            {
                title = "Teste com RestSharp",
                body = "Este é um post de teste via RestSharp",
                userId = 99
            };

            request.AddJsonBody(novoPost);

            var response = client.Execute(request);
            Assert.Equal(System.Net.HttpStatusCode.Created, response.StatusCode);

            var responseData = JObject.Parse(response.Content);

            Assert.Equal(novoPost.title, (string)responseData["title"]);
            Assert.Equal(novoPost.body, (string)responseData["body"]);
            Assert.Equal(novoPost.userId, (int)responseData["userId"]);

            Assert.True(responseData["id"] != null);
        }
    }
}
