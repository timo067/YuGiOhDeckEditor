using Common.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YuGiOhDeckEditor.Data;
using YuGiOhDeckEditor.Entities;
using YuGiOhDeckEditor.Services;

namespace YuGiOhDeckEditor.Controllers
{
    public class DeckController : Controller
    {
        private readonly ExternalApiService _externalApiService;
        private static List<DeckInfo> decks = new List<DeckInfo>();

        public DeckController(ExternalApiService externalApiService)
        {
            _externalApiService = externalApiService;
        }

        // GET: Deck
        public IActionResult Index()
        {
            return View(decks); // decks is List<DeckInfo>
        }

        // GET: Deck/Details/5
        public IActionResult Details(int id)
        {
            var deck = decks.FirstOrDefault(d => d.Id == id);
            if (deck == null) return NotFound();
            return View(deck); // Passes a DeckInfo object to the view
        }

        // GET: Deck/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Deck/Create
        [HttpPost]
        public IActionResult Create(DeckInfo deckInfo)
        {
            if (ModelState.IsValid)
            {
                deckInfo.Id = decks.Count + 1;
                decks.Add(deckInfo);
                return RedirectToAction(nameof(Index));
            }
            return View(deckInfo);
        }

        // GET: Deck/Edit/5
        public IActionResult Edit(int id)
        {
            var deck = decks.FirstOrDefault(d => d.Id == id);
            if (deck == null) return NotFound();
            return View(deck);
        }

        // POST: Deck/Edit/5
        [HttpPost]
        public IActionResult Edit(int id, DeckInfo deckInfo)
        {
            if (ModelState.IsValid)
            {
                var deck = decks.FirstOrDefault(d => d.Id == id);
                if (deck == null) return NotFound();

                deck.Name = deckInfo.Name;
                deck.Description = deckInfo.Description;
                return RedirectToAction(nameof(Index));
            }
            return View(deckInfo);
        }

        // GET: Deck/Delete/5
        public IActionResult Delete(int id)
        {
            var deck = decks.FirstOrDefault(d => d.Id == id);
            if (deck == null) return NotFound();
            return View(deck);
        }

        // POST: Deck/Delete/5
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var deck = decks.FirstOrDefault(d => d.Id == id);
            if (deck != null)
            {
                decks.Remove(deck);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Deck/AddCard/5
        public async Task<IActionResult> AddCard(int id, string searchTerm = "")
        {
            var deck = decks.FirstOrDefault(d => d.Id == id);
            if (deck == null) return NotFound();

            var cards = string.IsNullOrEmpty(searchTerm)
                ? new List<CardsInfo>()
                : await _externalApiService.GetCardsInfoAsync(searchTerm);

            var viewModel = new AddCardViewModel
            {
                Id = id,  // Deck ID
                Deck = deck,  // DeckInfo
                Cards = cards,  // List of Cards
                SearchTerm = searchTerm
            };

            return View(viewModel);  // Pass AddCardViewModel to the view
        }

        // POST: Deck/AddCard/5
        [HttpPost]
        public IActionResult AddCardToDeck(int deckId, int cardId)
        {
            var deck = decks.FirstOrDefault(d => d.Id == deckId);
            if (deck == null) return NotFound();

            var card = new CardsInfo { Id = cardId, Name = $"Card {cardId}" }; // Replace with real API data
            if (!deck.Cards.Any(c => c.Id == cardId)) // Avoid duplicate cards
            {
                deck.Cards.Add(card);
            }

            return RedirectToAction("Details", new { id = deckId });
        }
    }
}
