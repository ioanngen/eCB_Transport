using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eCB_Transport.Data;
using eCB_Transport.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using System.Security.Claims;

namespace eCB_Transport.Controllers
{
    public class TicketsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TicketsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tickets
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var Id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (User.IsInRole("Customer"))
            {
                return _context.Ticket != null ?
                          View(await _context.Ticket.Where(j => j.UserId == Id).ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Route'  is null.");

            }else
            {
                return _context.Ticket != null ?
                              View(await _context.Ticket.ToListAsync()) :
                              Problem("Entity set 'ApplicationDbContext.Ticket'  is null.");

            }
        }

        // GET: Tickets/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RouteId,UserId")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                if (User.IsInRole("Administrator"))
                {
                    _context.Add(ticket);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var Id = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    ticket.UserId = Id;
                    _context.Add(ticket);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Ticket == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Ticket == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Ticket'  is null.");
            }
            var ticket = await _context.Ticket.FindAsync(id);
            if (ticket != null)
            {
                _context.Ticket.Remove(ticket);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TicketExists(Guid id)
        {
          return (_context.Ticket?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
