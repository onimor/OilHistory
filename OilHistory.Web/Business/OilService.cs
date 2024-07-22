using Newtonsoft.Json;

namespace OilHistory.Web.Business
{
    public class OilService
    {
        private HttpClient _client = new HttpClient();
        private List<string> _superPuperDatabase = new List<string>();

        public async Task<bool> GetData()
        {
            try
            {
                var response = await _client.PostAsync("https://gpnbonus.ru/api/stations/3228", null);
                GazpromNeft.Root? myDeserializedClass = JsonConvert.DeserializeObject<GazpromNeft.Root>(await response.Content.ReadAsStringAsync());

                foreach (var xxx in myDeserializedClass.Data)
                {
                    _superPuperDatabase.Add(xxx.Product.ShortTitle + " " + xxx.Price.Value + " " + xxx.Price.Currency);
                }
                _superPuperDatabase.Add("bla bla 1");
                _superPuperDatabase.Add("bla bla 2");
                _superPuperDatabase.Add("bla bla 3");
                _superPuperDatabase.Add("bla bla 4");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            return true;
        }

        public async Task<string[]> GetOilHistory()
        {
            var response = await _client.PostAsync("https://gpnbonus.ru/api/stations/3228", null);
            GazpromNeft.Root? myDeserializedClass = JsonConvert.DeserializeObject<GazpromNeft.Root>(await response.Content.ReadAsStringAsync());

            foreach (var xxx in myDeserializedClass.Data)
            {
                _superPuperDatabase.Add(xxx.Product.ShortTitle + " " + xxx.Price.Value + " " + xxx.Price.Currency);
            }
            _superPuperDatabase.Add("bla bla x");
            _superPuperDatabase.Add("bla bla y");
            _superPuperDatabase.Add("bla bla й");

            return _superPuperDatabase.Take(3).ToArray();
        }
    }
}
