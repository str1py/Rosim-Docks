using Dadata;
using Dadata.Model;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace RosreestDocks.Helpers
{
    public class EgrulService
    {
        private readonly ILogger<EgrulService> _logger;

        private readonly string token = "12808f894ea95b42fadb5d3589a38dc5664ca572";
        private readonly string secret = "f714df62ebbbb6cc4a24c184db525ee130e6b24c";
        public EgrulService(ILogger<EgrulService> logger )
        {
            _logger = logger;
        }

  
        public async Task<Suggestion<Party>> GetAgencyInfo(string inn)
        {
            var api = new SuggestClientAsync(token);
            var response = await api.FindParty(inn);
            //data.adress.unrestricted_value
            //data.management.name
            //data.management.post
            //data.name.full
            //data.name.@short
            //data.state.status
            //data.opf.full - full acronim
            // data.opf.@short - acronim

            if(response.suggestions.Count == 0)
            {
                _logger.LogError($"Нет информации (Suggestions count : {response.suggestions.Count}");
                return null;
            }
            else
            {
                foreach (var suggest in response.suggestions)
                {
                    _logger.LogInformation("Agency info {0}", suggest.value);
                    _logger.LogInformation("Agency info {0}", suggest.unrestricted_value);
                    _logger.LogInformation("Agency info {0}", suggest.data);
                }
                return response.suggestions[0] ?? null;
            }
        }
        //public async void UpdateAgencies()
        //{
        //    var list = db.Agency.ToList();

        //    var api = new SuggestClientAsync(token);

        //    foreach (var agency in list)
        //    {
        //        if (!String.IsNullOrEmpty(agency.AgencyINN))
        //        {
        //            var response = await api.FindParty(agency.AgencyINN);
        //            var b = response;
        //        }
        //        else
        //        {
        //            var response = await api.SuggestParty(agency.Name);
        //            var b = response;
        //        }
        //    }

        //    //var response = await api.FindParty("7707083893"); //by inn
        //    //var response = await api.SuggestParty("сбер");  //by name

        //    return Redirect(Request.Headers["Referer"].ToString());
        //}
    }
}
