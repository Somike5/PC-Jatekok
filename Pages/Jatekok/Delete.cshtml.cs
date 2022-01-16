using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PC_Jatekok.Data;
using PC_Jatekok.Models;

namespace PC_Jatekok.Pages.Jatekok
{
    public class DeleteModel : PageModel
    {
        private readonly PC_Jatekok.Data.PC_JatekokContext _context;

        public DeleteModel(PC_Jatekok.Data.PC_JatekokContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Jatek = await _context.Jatek.FindAsync(id);

            if (Jatek != null)
            {
                _context.Jatek.Remove(Jatek);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
