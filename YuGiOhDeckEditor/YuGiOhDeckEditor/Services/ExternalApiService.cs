using Core.Entities;
using YuGiOhDeckEditor.Entities;

namespace YuGiOhDeckEditor.Services
{
    public class ExternalApiService
	{
		private readonly HttpClient _httpClient;

		// Constructor injection of HttpClient
		public ExternalApiService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		// Example of an asynchronous method to get data from an API
		public async Task<CardsInfo> GetApiResponseAsync(string apiUrl)
		{
			try
			{
				// Make an asynchronous HTTP GET request to the API
				var response = await _httpClient.GetAsync(apiUrl);

				// Ensure the response is successful (status code 200-299)
				response.EnsureSuccessStatusCode();

				// Deserialize the JSON response into an object (ApiResponseModel)
				var apiResponse = await response.Content.ReadFromJsonAsync<CardsInfo>();

				return apiResponse;
			}
			catch (Exception ex)
			{
				// Handle exceptions (like network issues or non-200 status codes)
				Console.WriteLine($"Error fetching data: {ex.Message}");
				return null;
			}
		}
	}
}
