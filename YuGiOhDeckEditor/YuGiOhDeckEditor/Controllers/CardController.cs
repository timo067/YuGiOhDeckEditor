using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using YuGiOhDeckEditor.Constants;
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

        public async Task<IActionResult> Index()
        {
            var cards = await _externalApiService.GetCardsInfoAsync();

            return View(cards);
        }
    }
}
