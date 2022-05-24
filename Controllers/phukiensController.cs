using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using phu_kien_may_tinh.Data;
using phu_kien_may_tinh.Models;

namespace phu_kien_may_tinh.Controllers
{
    public class phukiensController : Controller
    {
        private readonly phu_kien_may_tinhContext _context;

        public phukiensController(phu_kien_may_tinhContext context)
        {
            _context = context;
        }

        // GET: phukiens
        public async Task<IActionResult> Index(string searchString)
        {
            var books = from b in _context.phukien
                        select b;
            if (!String.IsNullOrEmpty(searchString))
            {
                books = books.Where(s => s.Title!.Contains(searchString));
            }
            return View(await books.ToListAsync());
        }

        // GET: phukiens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phukien = await _context.phukien
                .FirstOrDefaultAsync(m => m.Id == id);
            if (phukien == null)
            {
                return NotFound();
            }

            return View(phukien);
        }

        // GET: phukiens/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: phukiens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price")] phukien phukien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phukien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(phukien);
        }

        // GET: phukiens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phukien = await _context.phukien.FindAsync(id);
            if (phukien == null)
            {
                return NotFound();
            }
            return View(phukien);
        }

        // POST: phukiens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price")] phukien phukien)
        {
            if (id != phukien.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phukien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!phukienExists(phukien.Id))
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
            return View(phukien);
        }

        // GET: phukiens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phukien = await _context.phukien
                .FirstOrDefaultAsync(m => m.Id == id);
            if (phukien == null)
            {
                return NotFound();
            }

            return View(phukien);
        }

        // POST: phukiens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phukien = await _context.phukien.FindAsync(id);
            _context.phukien.Remove(phukien);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool phukienExists(int id)
        {
            return _context.phukien.Any(e => e.Id == id);
        }
    }
}
