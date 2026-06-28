using System.Text.Json;

namespace IssLocationTracker
{
    public class IssLocationService
    {
        private readonly HttpClient _httpClient;

        private const string ApiUrl =
            "https://api.wheretheiss.at/v1/satellites/25544";

        public IssLocationService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<IssLocation?> GetCurrentLocationAsync()
        {
            try
            {
                HttpResponseMessage response =
                    await _httpClient.GetAsync(ApiUrl);

                response.EnsureSuccessStatusCode();

                string json =
                    await response.Content.ReadAsStringAsync();

                IssLocation? location =
                    JsonSerializer.Deserialize<IssLocation>(json);

                return location;
            }
            catch
            {
                return null;
            }
        }
    }
}