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
    public class DetailsModel : PageModel
    {
        private readonly PC_Jatekok.Data.PC_JatekokContext _context;

        public DetailsModel(PC_Jatekok.Data.PC_JatekokContext context)
        {
            _context = context;
        }

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
    }
}
