using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace SelfHostWebApi.Model
{
    public class ValueContainer
    {
        Dictionary<int, string> valuesLookup;

        public ValueContainer(Dictionary<int, string> init)
        {
            valuesLookup = init;
        }

        public ValueContainer()
        {
            valuesLookup = new Dictionary<int, string>();
        }

        public void Remove( int id )
        {
            if(valuesLookup.ContainsKey(id))
            {
                valuesLookup.Remove(id);
                return;
            }
            throw new HttpRequestException("Id not found");
        }

        public void Add( int id, string value)
        {
            string existingValue;
            if (!valuesLookup.TryGetValue(id, out existingValue))
            {
                valuesLookup.Add( id, value);
                return;
            }
            throw new HttpRequestException($"Id: {{{id}}} already exist. Value: {{{existingValue}}}");
        }

        public string Get(int id)
        {
            string value;
            if(valuesLookup.TryGetValue(id, out value))
            {
                return value; 
            }
            throw new HttpRequestException("Id not found");
        }

        public IEnumerable<string> GetAllValues()
        {
            return valuesLookup.Select( kvp => kvp.Value);
        }
    }
}
