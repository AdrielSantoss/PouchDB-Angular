using Api.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Tests
{
    public class UnitTest1
    {
        [Fact]
        public async Task Post_User()
        {
            var client = new HttpClient();

            var User = new User();
            User.name = "marquin";
            User.email = "marquin@gmail.com";

            var json = JsonConvert.SerializeObject(User);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var postResult = await client.PostAsync("http://localhost:5000/Users", data); 
            

            Assert.Equal(postResult.StatusCode.ToString(), "OK");

        }
        
        [Theory]
        [InlineData("1c2a845a01d2158954c003b21")]
        public async Task Get_user(string id)
        {
            var client = new HttpClient();
            var resutlt = await client.GetAsync("http://localhost:5000/Users/"+id);

            Assert.Equal(resutlt.StatusCode.ToString(), "OK");
            
        }
    }
}
