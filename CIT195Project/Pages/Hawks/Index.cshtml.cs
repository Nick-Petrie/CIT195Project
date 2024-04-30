using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CIT195Project.Data;
using CIT195Project.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CIT195Project.Pages.Hawks
{
    public class IndexModel : PageModel
    {
        private readonly CIT195Project.Data.HawksContext _context;

        public IndexModel(CIT195Project.Data.HawksContext context)
        {
            _context = context;
        }

        public IList<Hawk> Hawk { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? SortOrder { get; set; }
        public SelectList SortOptions { get; set; }
        public async Task OnGetAsync()
        {
            IQueryable<Hawk> hawksQuery = from h in _context.Hawk
                                          select h;

            if (!string.IsNullOrEmpty(SearchString))
            {
                hawksQuery = hawksQuery.Where(s => s.Name.Contains(SearchString));
            }

            switch (SortOrder)
            {
                case "latin_name":
                    hawksQuery = hawksQuery.OrderBy(h => h.LatinName);
                    break;
                case "wingspan":
                    hawksQuery = hawksQuery.OrderBy(h => h.Wingspan);
                    break;
                case "endangered":
                    hawksQuery = hawksQuery.OrderBy(h => h.IsEndangered);
                    break;
                case "rarity":
                    hawksQuery = hawksQuery.OrderBy(h => h.Rarity);
                    break;
                default:
                    hawksQuery = hawksQuery.OrderBy(h => h.Name);
                    break;
            }

            Hawk = await hawksQuery.ToListAsync();
        }
    }
}