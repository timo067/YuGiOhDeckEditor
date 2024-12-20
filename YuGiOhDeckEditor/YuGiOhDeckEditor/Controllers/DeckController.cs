﻿using Common.Entities;
using Microsoft.AspNetCore.Mvc;
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

            return View(deck); // Ensure this deck contains the updated Cards list
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

        public async Task<IActionResult> AddCard(int id, string searchTerm = "")
        {
            var deck = decks.FirstOrDefault(d => d.Id == id);
            if (deck == null) return NotFound();

            // Fetch cards based on search term using the ExternalApiService
            var cards = string.IsNullOrEmpty(searchTerm)
                ? new List<CardsInfo>() // Empty list if no search term provided
                : await _externalApiService.GetCardsInfoAsync(searchTerm);

            var viewModel = new AddCardViewModel
            {
                Id = id,         // Deck ID
                Deck = deck,     // The specific deck
                Cards = cards,   // Cards fetched from the API
                SearchTerm = searchTerm
            };

            return View(viewModel);  // Pass the view model to the view
        }


        // POST: Deck/AddMultipleCards
        [HttpPost]
        public IActionResult AddMultipleCards(int deckId, List<int> cardIds)
        {
            var deck = decks.FirstOrDefault(d => d.Id == deckId);
            if (deck == null) return NotFound();

            // Add multiple cards to the deck
            foreach (var cardId in cardIds)
            {
                if (!deck.Cards.Any(c => c.Id == cardId))
                {
                    var card = new CardsInfo { Id = cardId, Name = $"Card {cardId}" }; // Simulate card fetch
                    deck.Cards.Add(card);
                }
            }

            return RedirectToAction("Details", new { id = deckId });
        }


        // POST: Deck/AddCard/5
        [HttpPost]
        public async Task<IActionResult> AddCardsToDeck(int deckId, List<string> cardNames)
        {
            var deck = decks.FirstOrDefault(d => d.Id == deckId);
            if (deck == null) return NotFound();

            if (cardNames == null || !cardNames.Any())
            {
                return BadRequest("No card names provided.");
            }

            // For each card name entered, fetch card info from the external API
            foreach (var cardName in cardNames)
            {
                // Fetch the card's actual information using the External API Service
                var cardInfo = await _externalApiService.GetCardsInfoAsync(cardName);

                // Ensure the card is found in the fetched data
                var card = cardInfo.FirstOrDefault();
                if (card == null)
                {
                    // If card is not found, continue to the next card
                    continue;
                }

                // Check if the card is already in the deck to prevent duplicates
                if (!deck.Cards.Any(c => c.Id == card.Id))
                {
                    deck.Cards.Add(card);  // Add the card to the deck
                }
            }

            // Save the deck back to the decks list (if you're storing in memory)
            var existingDeck = decks.FirstOrDefault(d => d.Id == deckId);
            if (existingDeck != null)
            {
                existingDeck.Cards = deck.Cards; // Ensure the updated card list is saved back
            }

            // Debugging: Check if all cards were added
            Console.WriteLine($"Updated Cards for Deck ID {deckId}:");
            foreach (var card in deck.Cards)
            {
                Console.WriteLine($"- {card.Name}");
            }

            return RedirectToAction("Details", new { id = deckId });
        }

    }
}
