using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MostAspNetCore.Data;
using MostLib;

namespace MostAspNetCore.Controllers
{
    [Authorize]
    public class TransportsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TransportsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Transports
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Transports.Include(t => t.CurrentRoute).Include(t => t.ResponsibleDriver).Include(t => t.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Transports/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transport = await _context.Transports
                .Include(t => t.CurrentRoute)
                .Include(t => t.ResponsibleDriver)
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.TransportId == id);
            if (transport == null)
            {
                return NotFound();
            }

            return View(transport);
        }

        // GET: Transports/Create
        public IActionResult Create()
        {
            ViewData["CurrentRouteId"] = new SelectList(_context.Routes, "RouteId", "UserId");
            ViewData["ResponsibleDriverId"] = new SelectList(_context.Drivers, "DriverId", "DriverLicenseNumber");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Transports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TransportId,Brand,Model,ReleaseDate,VinNumber,LicensePlateNumber,Mileage,MaxFuel,TransportTypeId,CanAttachTrailer,MaxWeight,Length,Width,Height,AxesTypeId,ResponsibleDriverId,CurrentRouteId,UserId")] Transport transport)
        {
            ModelState.Remove("User");
            if (ModelState.IsValid)
            {
                transport.TransportId = Guid.NewGuid();
                _context.Add(transport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CurrentRouteId"] = new SelectList(_context.Routes, "RouteId", "UserId", transport.CurrentRouteId);
            ViewData["ResponsibleDriverId"] = new SelectList(_context.Drivers, "DriverId", "DriverLicenseNumber", transport.ResponsibleDriverId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", transport.UserId);
            return View(transport);
        }

        // GET: Transports/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transport = await _context.Transports.FindAsync(id);
            if (transport == null)
            {
                return NotFound();
            }
            ViewData["CurrentRouteId"] = new SelectList(_context.Routes, "RouteId", "UserId", transport.CurrentRouteId);
            ViewData["ResponsibleDriverId"] = new SelectList(_context.Drivers, "DriverId", "DriverLicenseNumber", transport.ResponsibleDriverId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", transport.UserId);
            return View(transport);
        }

        // POST: Transports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("TransportId,Brand,Model,ReleaseDate,VinNumber,LicensePlateNumber,Mileage,MaxFuel,TransportTypeId,CanAttachTrailer,MaxWeight,Length,Width,Height,AxesTypeId,ResponsibleDriverId,CurrentRouteId,UserId")] Transport transport)
        {
            if (id != transport.TransportId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransportExists(transport.TransportId))
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
            ViewData["CurrentRouteId"] = new SelectList(_context.Routes, "RouteId", "UserId", transport.CurrentRouteId);
            ViewData["ResponsibleDriverId"] = new SelectList(_context.Drivers, "DriverId", "DriverLicenseNumber", transport.ResponsibleDriverId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", transport.UserId);
            return View(transport);
        }

        // GET: Transports/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transport = await _context.Transports
                .Include(t => t.CurrentRoute)
                .Include(t => t.ResponsibleDriver)
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.TransportId == id);
            if (transport == null)
            {
                return NotFound();
            }

            return View(transport);
        }

        // POST: Transports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var transport = await _context.Transports.FindAsync(id);
            if (transport != null)
            {
                _context.Transports.Remove(transport);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransportExists(Guid id)
        {
            return _context.Transports.Any(e => e.TransportId == id);
        }
    }
}
