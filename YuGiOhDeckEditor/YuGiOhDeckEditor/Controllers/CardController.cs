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
            var cards = new List<CardsInfo>();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                cards = await _externalApiService.GetCardsInfoAsync(searchQuery); // Assuming the API returns a list of cards
            }

            ViewData["SearchQuery"] = searchQuery;
            return View(cards);
        }
    }
}
