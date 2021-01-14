using Api.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Api.Repositories
{
    public class Repository : IRepository
    {
        private readonly string _couchDbUrl;
        private readonly string _couchDbName;
        private readonly string _couchDbUser;
        private readonly IConfiguration _configuration;


        public Repository()
        {
           
            //_couchDbUrl = this._configuration["CouchDB:URL"];
            //_couchDbName = this._configuration["CouchDB:DbName"];
            //_couchDbUser = this._configuration["CouchDB:User"];
        }

        public async Task PostDocumentAsync(User user)
        {
            var client = new HttpClient();
            var jsonData = JsonConvert.SerializeObject(user);

            var data = new StringContent(jsonData, Encoding.UTF8, "application/json");

            //CouchDB URL : POST http://{hostname_or_IP}:{Port}/{couchDbName}  
            var postResult = await client.PostAsync("http://localhost:5984/pouachform/", data).ConfigureAwait(true);

            var result = postResult.Content.ReadAsStringAsync();

        }

        public async Task<Task<string>> GetDocumentAsync(string id)
        {
            var client = new HttpClient();
            var result = await client.GetAsync("http://localhost:5984/pouachform/" + id);

            return result.Content.ReadAsStringAsync();

        }
    }
}
