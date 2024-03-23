using Newtonsoft.Json;
using ISP.Entities;

namespace ISP.Services;

public class RateService : IRateService
{
    HttpClient _httpClient;
    public RateService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Rate>?> GetRates(DateTime date)
    {
        IEnumerable<Rate>? rates = null;
        var formattedDate = date.ToString("yyyy-MM-dd");
        HttpResponseMessage response = await _httpClient.GetAsync($"https://api.nbrb.by/exrates/rates?ondate={formattedDate}&periodicity=0");

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            rates = JsonConvert.DeserializeObject<IEnumerable<Rate>>(content);
            return rates;
        }
        return rates;
    }
}