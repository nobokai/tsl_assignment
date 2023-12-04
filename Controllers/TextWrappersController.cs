using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TSLAssignment.Data;
using TSLAssignment.Models;

namespace TSLAssignment.Controllers
{
    public class TextWrappersController : Controller
    {
        private readonly TSLAssignmentContext _context;

        public TextWrappersController(TSLAssignmentContext context)
        {
            _context = context;
        }

        // GET: TextWrappers
        public async Task<IActionResult> Index()
        {
              return _context.TextWrapper != null ? 
                          View(await _context.TextWrapper.ToListAsync()) :
                          Problem("Entity set 'TSLAssignmentContext.TextWrapper'  is null.");
        }

        // GET: TextWrappers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TextWrapper == null)
            {
                return NotFound();
            }

            var textWrapper = await _context.TextWrapper
                .FirstOrDefaultAsync(m => m.Id == id);
            if (textWrapper == null)
            {
                return NotFound();
            }

            return View(textWrapper);
        }

        // GET: TextWrappers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TextWrappers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Text,EnableReversed,CreatedTime")] TextWrapper textWrapper)
        {
            if (ModelState.IsValid)
            {
                if(textWrapper.Text == null)
                {
                    return NotFound();
                }
                if (textWrapper.EnableReversed)
                {
                    char[] stringArray = textWrapper.Text.ToCharArray();
                    Array.Reverse(stringArray);
                    string reversedText = new string(stringArray);
                    textWrapper.ReversedText = reversedText;
                }
                _context.Add(textWrapper);
                await _context.SaveChangesAsync();
                return View(textWrapper);
                //return RedirectToAction(nameof(Index));
            }
            return View(textWrapper);
        }

        // GET: TextWrappers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TextWrapper == null)
            {
                return NotFound();
            }

            var textWrapper = await _context.TextWrapper.FindAsync(id);
            if (textWrapper == null)
            {
                return NotFound();
            }
            return View(textWrapper);
        }

        // POST: TextWrappers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Text,EnableReversed,CreatedTime")] TextWrapper textWrapper)
        {
            if (id != textWrapper.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(textWrapper);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TextWrapperExists(textWrapper.Id))
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
            return View(textWrapper);
        }

        // GET: TextWrappers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TextWrapper == null)
            {
                return NotFound();
            }

            var textWrapper = await _context.TextWrapper
                .FirstOrDefaultAsync(m => m.Id == id);
            if (textWrapper == null)
            {
                return NotFound();
            }

            return View(textWrapper);
        }

        // POST: TextWrappers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TextWrapper == null)
            {
                return Problem("Entity set 'TSLAssignmentContext.TextWrapper'  is null.");
            }
            var textWrapper = await _context.TextWrapper.FindAsync(id);
            if (textWrapper != null)
            {
                _context.TextWrapper.Remove(textWrapper);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TextWrapperExists(int id)
        {
          return (_context.TextWrapper?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
