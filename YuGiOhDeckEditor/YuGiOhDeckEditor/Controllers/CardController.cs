using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using System.Text.Json;
using YuGiOhDeckEditor.Constants;
using YuGiOhDeckEditor.Data;
using YuGiOhDeckEditor.Entities;
using YuGiOhDeckEditor.Models;
using YuGiOhDeckEditor.Services;

namespace YuGiOhDeckEditor.Controllers
{
    public class CardController : Controller
    {
        private readonly ExternalApiService _externalApiService;

        public CardController(ExternalApiService externalApiService)
        {
            _externalApiService = externalApiService;
        }

        public async Task<IActionResult> Index(string searchQuery)
        {
            try
            {

                // Call your API service to get the cards based on the search query
                var cardsInfo = await _externalApiService.GetCardsInfoAsync(searchQuery);

                // If there are no cards, show a message
                if (cardsInfo == null || !cardsInfo.Any())
                {
                    ViewBag.Message = "No cards found.";
                }

                // Set the search query in ViewData for persistence (pre-filling the search box)
                ViewData["SearchQuery"] = searchQuery;

                // Pass the list of cards to the view
                return View(cardsInfo);
            }
            catch (Exception ex)
            {
                // Handle errors (e.g., API failure)
                ViewBag.Message = $"Error fetching card data: {ex.Message}";
                return View(new List<CardsInfo>());
            }
        }

    }
}
