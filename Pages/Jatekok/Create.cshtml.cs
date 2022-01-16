using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PC_Jatekok.Data;
using PC_Jatekok.Models;

namespace PC_Jatekok.Pages.Jatekok
{
    public class CreateModel : PageModel
    {
        private readonly PC_Jatekok.Data.PC_JatekokContext _context;

        public CreateModel(PC_Jatekok.Data.PC_JatekokContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Jatek Jatek { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Jatek.Add(Jatek);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
