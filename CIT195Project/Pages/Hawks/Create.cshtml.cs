using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CIT195Project.Data;
using CIT195Project.Models;

namespace CIT195Project.Pages.Hawks
{
    public class CreateModel : PageModel
    {
        private readonly CIT195Project.Data.HawksContext _context;

        public CreateModel(CIT195Project.Data.HawksContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Hawk Hawk { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Hawk.Add(Hawk);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
