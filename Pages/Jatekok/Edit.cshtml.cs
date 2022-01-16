using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PC_Jatekok.Data;
using PC_Jatekok.Models;

namespace PC_Jatekok.Pages.Jatekok
{
    public class EditModel : PageModel
    {
        private readonly PC_Jatekok.Data.PC_JatekokContext _context;

        public EditModel(PC_Jatekok.Data.PC_JatekokContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Jatek Jatek { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Jatek = await _context.Jatek.FirstOrDefaultAsync(m => m.id == id);

            if (Jatek == null)
            {
                return NotFound();
            }
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

            _context.Attach(Jatek).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JatekExists(Jatek.id))
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

        private bool JatekExists(int id)
        {
            return _context.Jatek.Any(e => e.id == id);
        }
    }
}
