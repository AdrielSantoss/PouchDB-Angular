using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Api.Repositories
{
    public interface IRepository
    {
        Task PostDocumentAsync(User user);
        Task<Task<string>> GetDocumentAsync(string id);
    }
}
