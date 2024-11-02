using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MostAspNetCore.Data;
using MostLib;

namespace MostAspNetCore.Controllers
{
    [Authorize]
    public class TrailersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public TrailersController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Trailers
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Trailers.Include(t => t.CurrentRoute).Include(t => t.ResponsibleDriver).Include(t => t.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Trailers/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trailer = await _context.Trailers
                .Include(t => t.CurrentRoute)
                .Include(t => t.ResponsibleDriver)
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.TrailerId == id);
            if (trailer == null)
            {
                return NotFound();
            }

            return View(trailer);
        }

        // GET: Trailers/Create
        public IActionResult Create()
        {
            ViewData["CurrentRouteId"] = new SelectList(_context.Routes, "RouteId", "UserId");
            ViewData["ResponsibleDriverId"] = new SelectList(_context.Drivers, "DriverId", "DriverLicenseNumber");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Trailers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TrailerId,Brand,Model,ReleaseDate,VinNumber,LicensePlateNumber,TrailerTypeId,MaxWeight,Length,Width,Height,TrailerAxesTypeId,ResponsibleDriverId,CurrentRouteId,UserId")] Trailer trailer)
        {
            ModelState.Remove("User");
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                if (user == null)
                    return Unauthorized();

                trailer.TrailerId = Guid.NewGuid();
                trailer.User = user;
                _context.Add(trailer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CurrentRouteId"] = new SelectList(_context.Routes, "RouteId", "UserId", trailer.CurrentRouteId);
            ViewData["ResponsibleDriverId"] = new SelectList(_context.Drivers, "DriverId", "DriverLicenseNumber", trailer.ResponsibleDriverId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", trailer.UserId);
            return View(trailer);
        }

        // GET: Trailers/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trailer = await _context.Trailers.FindAsync(id);
            if (trailer == null)
            {
                return NotFound();
            }
            ViewData["CurrentRouteId"] = new SelectList(_context.Routes, "RouteId", "UserId", trailer.CurrentRouteId);
            ViewData["ResponsibleDriverId"] = new SelectList(_context.Drivers, "DriverId", "DriverLicenseNumber", trailer.ResponsibleDriverId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", trailer.UserId);
            return View(trailer);
        }

        // POST: Trailers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("TrailerId,Brand,Model,ReleaseDate,VinNumber,LicensePlateNumber,TrailerTypeId,MaxWeight,Length,Width,Height,TrailerAxesTypeId,ResponsibleDriverId,CurrentRouteId,UserId")] Trailer trailer)
        {
            if (id != trailer.TrailerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trailer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrailerExists(trailer.TrailerId))
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
            ViewData["CurrentRouteId"] = new SelectList(_context.Routes, "RouteId", "UserId", trailer.CurrentRouteId);
            ViewData["ResponsibleDriverId"] = new SelectList(_context.Drivers, "DriverId", "DriverLicenseNumber", trailer.ResponsibleDriverId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", trailer.UserId);
            return View(trailer);
        }

        // GET: Trailers/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trailer = await _context.Trailers
                .Include(t => t.CurrentRoute)
                .Include(t => t.ResponsibleDriver)
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.TrailerId == id);
            if (trailer == null)
            {
                return NotFound();
            }

            return View(trailer);
        }

        // POST: Trailers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var trailer = await _context.Trailers.FindAsync(id);
            if (trailer != null)
            {
                _context.Trailers.Remove(trailer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrailerExists(Guid id)
        {
            return _context.Trailers.Any(e => e.TrailerId == id);
        }
    }
}
