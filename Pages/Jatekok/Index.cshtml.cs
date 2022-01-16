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
    public class IndexModel : PageModel
    {

        //[BindProperty(SupportsGet = true)]
        public string keresNev;
        public string keresKiado;

        private readonly PC_Jatekok.Data.PC_JatekokContext _context;

        public IndexModel(PC_Jatekok.Data.PC_JatekokContext context)
        {
            _context = context;

        }

        public IList<Jatek> Jatek { get;set; }

        public async Task OnGetAsync()
        {
            Console.WriteLine("onGetAsync.....");
            Jatek = await _context.Jatek.ToListAsync();

            var emberek = _context.Jatek.Select(x => x);

            if (!string.IsNullOrEmpty(keresNev)) {
                emberek = emberek.Where(x => x.nev.Contains(keresNev));
            }
            if (!string.IsNullOrEmpty(keresKiado)) {
                emberek = emberek.Where(x => x.developer.Contains(keresKiado));
            }
            Jatek = await emberek.ToListAsync();
        }



    }

}
