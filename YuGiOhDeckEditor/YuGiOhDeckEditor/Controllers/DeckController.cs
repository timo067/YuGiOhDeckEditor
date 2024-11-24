using Microsoft.AspNetCore.Mvc;
using YuGiOhDeckEditor.Data;
using YuGiOhDeckEditor.Entities;

namespace YuGiOhDeckEditor.Controllers
{
    public class DeckController : Controller
    {
        private readonly ApplicationDbContext _context;
        private static List<DeckInfo> decks = new List<DeckInfo>();

        public DeckController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Deck
        public IActionResult Index()
        {
            return View(decks);
        }

        // GET: Deck/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var deck = await _context.Decks
                .Include(d => d.Cards)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (deck == null)
                return NotFound();

            return View(deck);
        }

        // GET: Deck/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Deck/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DeckInfo deck)
        {
            if (ModelState.IsValid)
            {
                _context.Decks.Add(deck);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(deck);
        }

        [HttpGet]
        public async Task<IActionResult> AddCard(int deckId)
        {
            var deck = await _context.Decks.FindAsync(deckId);
            if (deck == null)
                return NotFound();

            ViewBag.DeckId = deckId;
            ViewBag.AvailableCards = await _context.Cards.ToListAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCard(int deckId, int cardId)
        {
            var deck = await _context.Decks
                .Include(d => d.Cards)
                .FirstOrDefaultAsync(d => d.Id == deckId);

            if (deck == null)
                return NotFound();

            var card = await _context.Cards.FindAsync(cardId);
            if (card == null)
                return NotFound();

            if (!deck.Cards.Contains(card))
            {
                deck.Cards.Add(card);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Details), new { id = deckId });
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
    }
}
