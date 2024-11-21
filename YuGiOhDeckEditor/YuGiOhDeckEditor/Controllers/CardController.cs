using Microsoft.AspNetCore.Mvc;
using YuGiOhDeckEditor.Entities;
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
                cards = await _externalApiService.GetCardsInfoAsync(searchQuery);
            }

            ViewData["SearchQuery"] = searchQuery;
            return View(cards);
        }

		public IActionResult XYZDetails()
		{
			return View();
		}

        public IActionResult PendulumDetails()
        {
            return View();
        }
    }
}
