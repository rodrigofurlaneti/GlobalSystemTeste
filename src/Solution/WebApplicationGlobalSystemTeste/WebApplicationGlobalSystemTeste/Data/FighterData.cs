using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WebApplicationGlobalSystemTeste.Models;

namespace WebApplicationGlobalSystemTeste.Data
{
    public class FighterData
    {
        #region Properties

        HttpClient httpClient = new HttpClient();

        #endregion

        #region Constructor

        public FighterData()
        {
            httpClient.BaseAddress = new Uri("https://apidev-mbb.t-systems.com.br:8443/edgemicro_tsdev/torneioluta/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add("x-api-key", "29452a07-5ff9-4ad3-b472-c7243f548a33");
        }

        #endregion

        #region Methods

        public async Task<List<FighterModel>> GetFightersAsync()
        {
            HttpResponseMessage responseMessage = await httpClient.GetAsync("api/competidores");
            if (responseMessage.IsSuccessStatusCode)
            {
                var data = await responseMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<FighterModel>>(data);
            }
            return new List<FighterModel>();
        }

        #endregion
    }
}
