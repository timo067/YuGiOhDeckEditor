using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Core.Entities;
using YuGiOhDeckEditor.Data;
using YuGiOhDeckEditor.Services;

namespace YuGiOhDeckEditor.Controllers
{
	public class CardController : Controller
	{
		private readonly ExternalApiService _externalApiService;

		// Constructor injection of ExternalApiService
		public CardController(ExternalApiService externalApiService)
		{
			_externalApiService = externalApiService;
		}

		public async Task<IActionResult> GetCardInfo(string cardId)
		{
			// URL of the external API endpoint
			string apiUrl = $"https://api.yugioh.com/cards/{cardId}";

			// Call the asynchronous method to get the API response
			var apiResponse = await _externalApiService.GetApiResponseAsync(apiUrl);

			if (apiResponse != null)
			{
				// Use the response to populate a view model or take some action
				return View(apiResponse);
			}
			else
			{
				// Handle case where API call failed (e.g., return an error view)
				return View("Error");
			}
		}
	}
}
