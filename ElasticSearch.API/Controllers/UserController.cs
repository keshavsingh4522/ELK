using ElasticSearch.API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IElasticClient elasticClient;

        public UserController(IElasticClient elasticClient)
        {
            this.elasticClient = elasticClient;
        }

        [HttpGet("{id}")]
        public async Task<User> Get(string id)
        {
            #region method 1
            //var response =  await elasticClient.SearchAsync<User>(s=>s.Query(q=>q.Term(t=>t.Name,id) 
            //|| q.Match(m=>m.Field(f=>f.Name).Query(id))));
            #endregion
            #region method 2
            //var response = await elasticClient.SearchAsync<User>(s => s.Index("users").Query(q => q.Term(t => t.Name, id)
            // || q.Match(m => m.Field(f => f.Name).Query(id))));

            //var response = await elasticClient.SearchAsync<User>(s => s.Index("users").Query(q =>q.Match(m => m.Field(f => f.Name).Query(id))));
            #endregion


            //return response?.Documents?.FirstOrDefault();

            // other method
            var response = await elasticClient.GetAsync<User>(new DocumentPath<User>(new Id(id)),x=>x.Index("users"));
            return response?.Source;
        }

        [HttpPost]
        public async Task<string> Post ([FromBody]User user)
        {
            var res = await elasticClient.IndexAsync<User>(user,x=>x.Index("users"));
            if (res.IsValid)
                return res.Id;
            return "failed";
        }

        
    }
}
