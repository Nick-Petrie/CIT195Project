using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CIT195Project.Data;
using CIT195Project.Models;

namespace CIT195Project.Pages.Hawks
{
    public class EditModel : PageModel
    {
        private readonly CIT195Project.Data.HawksContext _context;

        public EditModel(CIT195Project.Data.HawksContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Hawk Hawk { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hawk =  await _context.Hawk.FirstOrDefaultAsync(m => m.Id == id);
            if (hawk == null)
            {
                return NotFound();
            }
            Hawk = hawk;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Hawk).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HawkExists(Hawk.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool HawkExists(int id)
        {
            return _context.Hawk.Any(e => e.Id == id);
        }
    }
}
