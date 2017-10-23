using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHostWebApi.Model
{
    public class IdValuePair
    {
        [JsonProperty(PropertyName ="id")]
        public int id { get; set; }

        [JsonProperty(PropertyName = "value")]
        public string value { get; set; }
    }
}
