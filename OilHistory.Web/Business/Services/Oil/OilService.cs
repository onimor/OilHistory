using OilHistory.Web.Business.Dto;

namespace OilHistory.Web.Business.Services.Oil
{
    public class OilService: IOilService
    {
        private readonly HttpClient _client = new() { BaseAddress = new Uri("https://gpnbonus.ru/") };
   
        private List<string> _superPuperDatabase = [];

        public async Task GetData()
        {
            var response = await _client.PostAsJsonAsync<object?>("api/stations/3228", null);
            if (response.IsSuccessStatusCode == false)
                throw new HttpRequestException($"Не смогли отправить запрос - {response.StatusCode}");
            
            var result = await response.Content.ReadFromJsonAsync<GazpromNeftDto.Root>();
            if (result is null || result.Data is null)
                throw new NullReferenceException("Сервер вернул пустоту");

            foreach (var xxx in result.Data)
            {
                _superPuperDatabase.Add(xxx.Product.ShortTitle + " " + xxx.Price.Price + " " + xxx.Price.Currency);
            }
            _superPuperDatabase.Add("bla bla 1");
            _superPuperDatabase.Add("bla bla 2");
            _superPuperDatabase.Add("bla bla 3");
            _superPuperDatabase.Add("bla bla 4"); 
        } 

        public async Task<string[]> GetOilHistory()
        {
            var response = await _client.PostAsJsonAsync<object?>("https://gpnbonus.ru/api/stations/3228", null);
            if (response.IsSuccessStatusCode == false)
                throw new HttpRequestException($"Не смогли отправить запрос - {response.StatusCode}");

            var result = await response.Content.ReadFromJsonAsync<GazpromNeftDto.Root>();
            if (result is null || result.Data is null)
                throw new NullReferenceException("Сервер вернул пустоту");

            foreach (var xxx in result.Data)
            {
                _superPuperDatabase.Add(xxx.Product.ShortTitle + " " + xxx.Price.Price + " " + xxx.Price.Currency);
            }
            _superPuperDatabase.Add("bla bla x");
            _superPuperDatabase.Add("bla bla y");
            _superPuperDatabase.Add("bla bla й");

            return _superPuperDatabase.Take(3).ToArray(); 
        }
    }
}
