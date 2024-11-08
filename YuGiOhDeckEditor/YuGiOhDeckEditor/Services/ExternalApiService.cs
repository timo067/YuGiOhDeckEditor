using System.Text.Json;
using YuGiOhDeckEditor.Entities;

namespace YuGiOhDeckEditor.Services
{
    public class ExternalApiService
	{
        private readonly HttpClient _httpClient;

        public ExternalApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Define GetCardsInfoAsync to retrieve card information
        public async Task<List<CardsInfo>> GetCardsInfoAsync()
        {
            var response = await _httpClient.GetAsync("https://db.ygoprodeck.com/api/v7/cardinfo.php"); // Replace with the correct API URL

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error fetching card info: {response.ReasonPhrase}");
            }

            var responseBody = await response.Content.ReadAsStringAsync();

            // Deserialize into ApiResponse first, then extract the data list
            var apiResponse = JsonSerializer.Deserialize<ApiResponse>(responseBody);

            if (apiResponse?.Data == null)
            {
                throw new Exception("Failed to retrieve card data from the API response.");
            }

            return apiResponse.Data;
        }
    }
}
