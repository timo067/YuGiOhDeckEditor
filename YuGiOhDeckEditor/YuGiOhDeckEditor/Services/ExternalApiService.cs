using System.Security.Policy;
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

        public async Task<List<CardsInfo>> GetCardsInfoAsync(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                throw new ArgumentException("Search term cannot be empty", nameof(searchTerm));
            }

            try
            {
                var encodedSearchTerm = Uri.EscapeDataString(searchTerm);
                var url = $"https://db.ygoprodeck.com/api/v7/cardinfo.php?name={encodedSearchTerm}";

                var response = await _httpClient.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"Request failed with status code {response.StatusCode}");
                }

                var responseBody = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON response into an ApiResponse
                var apiResponse = JsonSerializer.Deserialize<ApiResponse>(responseBody);

                // Return the list of cards directly from the Data property
                return apiResponse?.Data ?? new List<CardsInfo>();  // Return empty list if Data is null
            }
            catch (Exception ex)
            {
                // Handle exceptions here
                throw new Exception("Error while fetching card information: " + ex.Message);
            }
        }
    }
}
