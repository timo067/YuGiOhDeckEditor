using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YuGiOhDeckEditor.Data;
using YuGiOhDeckEditor.Entities;

namespace YuGiOhDeckEditor.Controllers
{
    public class DeckController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DeckController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Add a card to a deck

        // GET: Deck
        // DeckController.cs
        public async Task<IActionResult> Index()
        {
            var decks = await _context.DeckInfo.ToListAsync();

            if (!decks.Any())
            {
                Console.WriteLine("No decks found in the database.");
            }
            else
            {
                Console.WriteLine($"Retrieved {decks.Count} decks.");
            }

            return View(decks);
        }



        // GET: Deck/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var deck = await _context.DeckInfo
                                      .Include(d => d.DeckCards)
                                          .ThenInclude(dc => dc.Card)  // Include the related CardsInfo
                                      .FirstOrDefaultAsync(d => d.Id == id);
            if (deck == null)
            {
                return NotFound();
            }

            return View(deck);
        }

        // GET: Deck/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Deck/Create
        [HttpPost]
        public async Task<IActionResult> Create(DeckInfo deckInfo)
        {
            if (ModelState.IsValid)
            {
                _context.DeckInfo.Add(deckInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(deckInfo);
        }

        // GET: Deck/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var deck = await _context.DeckInfo.FindAsync(id);
            if (deck == null) return NotFound();
            return View(deck);
        }

        // POST: Deck/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, DeckInfo deckInfo)
        {
            if (ModelState.IsValid)
            {
                var deck = await _context.DeckInfo.FindAsync(id);
                if (deck == null) return NotFound();

                deck.Name = deckInfo.Name;
                deck.Description = deckInfo.Description;

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(deckInfo);
        }

        // GET: Deck/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var deck = await _context.DeckInfo.FindAsync(id);
            if (deck == null) return NotFound();
            return View(deck);
        }

        // POST: Deck/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deck = await _context.DeckInfo.FindAsync(id);
            if (deck != null)
            {
                _context.DeckInfo.Remove(deck);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
