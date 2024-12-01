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
using System.Text.Json;
using MostAspNetCore.Models.Route;

namespace MostAspNetCore.Controllers
{
    [Authorize]
    public class RoutesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RoutesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Routes
        public async Task<IActionResult> Index()
        {
            var routes = _context.Routes.Include(r => r.Driver).Include(r => r.Trailer).Include(r => r.Transport).Include(r => r.User).Include(r => r.StartBuilding);
            return View(await routes.ToListAsync());
        }

        // GET: Routes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var route = await _context.Routes
                .Include(r => r.Driver)
                .Include(r => r.Trailer)
                .Include(r => r.Transport)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.RouteId == id);
            if (route == null)
            {
                return NotFound();
            }

            return View(route);
        }

        // GET: Routes/Cargo
        public async Task<IActionResult> Cargo()
        {
            var cargo = new Cargo();
            cargo.ProductsList = new List<Product>();
            foreach (var product in _context.Products)
            {
                product.Quantity = 0;
                cargo.ProductsList.Add(product);
            }
            return View(cargo);
        }

        // GET: Routes/Create
        public IActionResult Create(Cargo cargo)
        {
            var model = new RouteCreateViewModel()
            { 
                DriversList = new SelectList(_context.Drivers, "DriverId", "FullName"),
                TrailersList = new SelectList(_context.Trailers, "TrailerId", "Brand"),
                TransportsList = new SelectList(_context.Transports, "TransportId", "Brand"),
                BuildingsList = new SelectList(_context.Buildings, "BuildingId", "BuildingDescription"),
            };
            cargo.DestinationBuilding = _context.Buildings.First(); //ТЕСТОВОЕ ЗДАНИЕ - УБРАТЬ
            model.CargosList.Add(cargo);

            /*
            var route = new MostLib.Route();
            route.Cargos = new List<Cargo>();
            route.Cargos.Add(cargo);

            ViewData["DriverId"] = new SelectList(_context.Drivers, "DriverId", "FullName");
            ViewData["TrailerId"] = new SelectList(_context.Trailers, "TrailerId", "Brand");
            ViewData["TransportId"] = new SelectList(_context.Transports, "TransportId", "Brand");
            ViewData["StartBuildingId"] = new SelectList(_context.Buildings, "BuildingId", "BuildingName");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");*/
            return View(model);
        }

        // POST: Routes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RouteCreateViewModel model)
        {

            var route = new MostLib.Route();
            if (ModelState.IsValid)
            {
                
                route.RouteId = Guid.NewGuid();
                _context.Add(route);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DriverId"] = new SelectList(_context.Drivers, "DriverId", "DriverLicenseNumber", route.DriverId);
            ViewData["TrailerId"] = new SelectList(_context.Trailers, "TrailerId", "Brand", route.TrailerId);
            ViewData["TransportId"] = new SelectList(_context.Transports, "TransportId", "Brand", route.TransportId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", route.UserId);
            return View(route);
        }

        // GET: Routes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var route = await _context.Routes.FindAsync(id);
            if (route == null)
            {
                return NotFound();
            }
            ViewData["DriverId"] = new SelectList(_context.Drivers, "DriverId", "DriverLicenseNumber", route.DriverId);
            ViewData["TrailerId"] = new SelectList(_context.Trailers, "TrailerId", "Brand", route.TrailerId);
            ViewData["TransportId"] = new SelectList(_context.Transports, "TransportId", "Brand", route.TransportId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", route.UserId);
            return View(route);
        }

        // POST: Routes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("RouteId,DriverId,TransportId,TrailerId,Buildings,Cargos,UserId")] MostLib.Route route)
        {
            if (id != route.RouteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(route);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RouteExists(route.RouteId))
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
            ViewData["DriverId"] = new SelectList(_context.Drivers, "DriverId", "DriverLicenseNumber", route.DriverId);
            ViewData["TrailerId"] = new SelectList(_context.Trailers, "TrailerId", "Brand", route.TrailerId);
            ViewData["TransportId"] = new SelectList(_context.Transports, "TransportId", "Brand", route.TransportId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", route.UserId);
            return View(route);
        }

        // GET: Routes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var route = await _context.Routes
                .Include(r => r.Driver)
                .Include(r => r.Trailer)
                .Include(r => r.Transport)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.RouteId == id);
            if (route == null)
            {
                return NotFound();
            }

            return View(route);
        }

        // POST: Routes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var route = await _context.Routes.FindAsync(id);
            if (route != null)
            {
                _context.Routes.Remove(route);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RouteExists(Guid id)
        {
            return _context.Routes.Any(e => e.RouteId == id);
        }
    }
}
