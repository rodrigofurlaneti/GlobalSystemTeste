using Newtonsoft.Json;

namespace WebApplicationGlobalSystemTeste.Models
{
    public class FighterModel
    {
        #region Properties

        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("nome")]
        public string Name { get; set; }
        [JsonProperty("idade")]
        public string Age { get; set; }
        [JsonProperty("artesMarciais")]
        public string[] MartialArts { get; set; }
        [JsonProperty("lutas")]
        public string Fights { get; set; }
        [JsonProperty("derrotas")]
        public string Defeats { get; set; }
        [JsonProperty("vitorias")]
        public string Victories { get; set; }

        #endregion
    }
}
