using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LoanApplication.Data;
using LoanApplication.Models.Admin;
using Microsoft.AspNetCore.Authorization;

namespace LoanApplication.Controllers
{
    [Authorize]
    public class LoanListsController : Controller
    {
        private readonly LoanDbContext _context;

        public LoanListsController(LoanDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index()
        {
            var list = await _context.loanlist.ToListAsync();

            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LoanList lists)
        {
            if (ModelState.IsValid)
            {
                _context.loanlist.Add(lists);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }


            return View(lists);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loanList = await _context.loanlist.SingleOrDefaultAsync(m => m.loatypeID == id);
            if (loanList == null)
            {
                return NotFound();
            }
            return View(loanList);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LoanList loanList)
        {
            if (id != loanList.loatypeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loanList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoanListExists(loanList.loatypeID))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction("Index");
            }
            return View(loanList);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loanList = await _context.loanlist.SingleOrDefaultAsync(m => m.loatypeID == id);
            if (loanList == null)
            {
                return NotFound();
            }

            return View(loanList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loanList = await _context.loanlist.SingleOrDefaultAsync(m => m.loatypeID == id);

            _context.loanlist.Remove(loanList);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        private bool LoanListExists(int id)
        {
            return _context.loanlist.Any(e => e.loatypeID == id);
        }

    }
}
