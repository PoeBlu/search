using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bit.Search.Models;

namespace Bit.Search.Controllers
{
    public class SitesController : Controller
    {
        private readonly SearchDbContext _context;

        public SitesController(SearchDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? before = null, int? after = null, int size = 50)
        {
            if(!before.HasValue && !after.HasValue)
            {
                after = 0;
            }

            if(before.HasValue)
            {
                return View(_context.Sites.Where(s => s.Id < before.Value)
                    .OrderByDescending(s => s.Id).Take(size).ToList().OrderBy(s => s.Id));
            }
            else
            {
                return View(_context.Sites.Where(s => s.Id > after.Value)
                    .OrderBy(s => s.Id).Take(size).ToList());
            }
        }

        public IActionResult Add()
        {
            return View(new Site());
        }

        [HttpPost]
        public IActionResult Add(Site model)
        {
            _context.Sites.Add(model);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var site = _context.Sites.SingleOrDefault(s => s.Id == id);
            if(site == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(site);
        }

        [HttpPost]
        public IActionResult Edit(int id, Site model)
        {
            var site = _context.Sites.SingleOrDefault(s => s.Id == id);
            if(site == null)
            {
                return RedirectToAction(nameof(Index));
            }

            site.Name = model.Name;
            site.Uri = model.Uri;
            site.Rank = model.Rank;
            _context.SaveChanges();

            return View(site);
        }

        public IActionResult Delete(int id)
        {
            var site = _context.Sites.SingleOrDefault(s => s.Id == id);
            if(site != null)
            {
                _context.Sites.Remove(site);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
