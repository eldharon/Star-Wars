using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Star_Wars.Model;

namespace Star_Wars.ModelsDTO
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class CharacterEpisodeDTO
    {
        public string Name { get; set; }
        public string Planet { get; set; }
        public List<string> Friends { get; set; }
        public List<string> Episodes { get; set; }
    }
}