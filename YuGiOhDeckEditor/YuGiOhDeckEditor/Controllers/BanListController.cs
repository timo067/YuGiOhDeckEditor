using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using YuGiOhDeckEditor.Data;
using YuGiOhDeckEditor.Entities;

namespace YuGiOhDeckEditor.Common.Entities
{
    public class BanListController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BanListController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BanList/Index
        public IActionResult Index()
        {
            var banListItems = _context.BanList.ToList();
            return View(banListItems);
        }

        public IActionResult Details(int id)
        {
            var banList = _context.BanList.FirstOrDefault(b => b.Id == id);

            if (banList == null)
            {
                return NotFound();
            }

            return View(banList);
        }


        // GET: BanList/AddToBanList
        [HttpGet]
        public IActionResult AddToBanList()
        {
            ViewBag.LimitTypes = GetLimitTypes();
            return View(new BanList());
        }

        // POST: BanList/AddToBanList
        [HttpPost]
        public IActionResult AddToBanList(BanList banList)
        {
            if (ModelState.IsValid)
            {
                _context.BanList.Add(banList);
                _context.SaveChanges();

                return RedirectToAction("Details", new { id = banList.Id });
            }

            return View(banList);  // Return the same view if validation fails
        }

        // GET: BanList/Edit/{id}
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var banListEntry = await _context.BanList.FindAsync(id);
            if (banListEntry == null)
            {
                return NotFound();
            }
            ViewBag.LimitTypes = GetLimitTypes();
            return View(banListEntry);
        }

        // POST: BanList/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BanList updatedBanList)
        {
            if (id != updatedBanList.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(updatedBanList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.BanList.Any(b => b.Id == updatedBanList.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.LimitTypes = GetLimitTypes();
            return View(updatedBanList);
        }

        private SelectList GetLimitTypes()
        {
            return new SelectList(new[] { "Limited", "Forbidden", "Semi-Limited" });
        }

        // GET: BanList/Delete/{id}
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var banList = await _context.BanList.FindAsync(id);
            if (banList == null)
            {
                return NotFound();
            }
            return View(banList);
        }
    }
}
