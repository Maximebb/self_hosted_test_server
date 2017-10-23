using SelfHostWebApi.Model;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;

namespace SelfHostWebApi.Controllers
{
    [RoutePrefix("api/Test")]
    public class TestController : ApiController
    {
        private readonly ValueContainer valuesContainer = new ValueContainer();

        [Route("Values")]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            Trace(HttpMethod.Get, Request.RequestUri.GetLeftPart(System.UriPartial.Path));
            return valuesContainer.GetAllValues();
        }
        
        [Route("Value/{id}")]
        [HttpGet]
        public string Get(int id)
        {
            Trace(HttpMethod.Get, Request.RequestUri.GetLeftPart(System.UriPartial.Path));
            return valuesContainer.Get(id);
        }
        
        [Route("Value")]
        [HttpPost]
        public void Post([FromBody]IdValuePair idValuePair)
        {
            Trace(HttpMethod.Get, Request.RequestUri.GetLeftPart(System.UriPartial.Path));
            valuesContainer.Add(idValuePair.id, idValuePair.value);
        }
        
        [Route("Value")]
        [HttpPut]
        public void Put([FromBody]IdValuePair idValuePair)
        {
            Trace(HttpMethod.Get, Request.RequestUri.GetLeftPart(System.UriPartial.Path));
            valuesContainer.Add(idValuePair.id, idValuePair.value);
        }
        
        [Route("Value/{id}")]
        [HttpDelete]
        public void Delete(int id)
        {
            Trace(HttpMethod.Get, Request.RequestUri.GetLeftPart(System.UriPartial.Path));
            valuesContainer.Remove(id);
        }

        [Route("Ping")]
        [HttpGet]
        public string Ping()
        {
            Trace(HttpMethod.Get, Request.RequestUri.GetLeftPart(System.UriPartial.Path));
            return "Ok";
        }

        public void Trace(HttpMethod method, string route )
        {
            Trace(method, route, "Received http request");
        }
        private void Trace(HttpMethod method, string route, string message)
        {
            System.Console.WriteLine(message + ": " + method.ToString() + " at " + route);
        }
    }
}