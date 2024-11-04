using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Core.Entities;
using YuGiOhDeckEditor.Data;

namespace YuGiOhDeckEditor.Controllers
{
    public class BanListsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BanListsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BanLists
        public async Task<IActionResult> Index()
        {
            return View(await _context.BanList.ToListAsync());
        }

        // GET: BanLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var banList = await _context.BanList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (banList == null)
            {
                return NotFound();
            }

            return View(banList);
        }

        // GET: BanLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BanLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,CardId,LimitType,Id")] BanList banList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(banList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(banList);
        }

        // GET: BanLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var banList = await _context.BanList.FindAsync(id);
            if (banList == null)
            {
                return NotFound();
            }
            return View(banList);
        }

        // POST: BanLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,CardId,LimitType,Id")] BanList banList)
        {
            if (id != banList.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(banList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BanListExists(banList.Id))
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
            return View(banList);
        }

        // GET: BanLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var banList = await _context.BanList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (banList == null)
            {
                return NotFound();
            }

            return View(banList);
        }

        // POST: BanLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var banList = await _context.BanList.FindAsync(id);
            if (banList != null)
            {
                _context.BanList.Remove(banList);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BanListExists(int id)
        {
            return _context.BanList.Any(e => e.Id == id);
        }
    }
}
