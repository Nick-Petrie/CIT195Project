using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CIT195Project.Data;
using CIT195Project.Models;

namespace CIT195Project.Pages.Hawks
{
    public class DetailsModel : PageModel
    {
        private readonly CIT195Project.Data.HawksContext _context;

        public DetailsModel(CIT195Project.Data.HawksContext context)
        {
            _context = context;
        }

        public Hawk Hawk { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hawk = await _context.Hawk.FirstOrDefaultAsync(m => m.Id == id);
            if (hawk == null)
            {
                return NotFound();
            }
            else
            {
                Hawk = hawk;
            }
            return Page();
        }
    }
}
