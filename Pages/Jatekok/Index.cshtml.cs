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
        private readonly PC_Jatekok.Data.PC_JatekokContext _context;

        [BindProperty(SupportsGet = true)]
        public string keresNev {set;get; } // Ha nincs setter-getter, akkor nem ismeri fel a BindPropertyt
        [BindProperty(SupportsGet = true)]
        public string keresFejleszto { get; set; }
        [BindProperty(SupportsGet = true)]
        public string keresKategoria { get; set; }
        [BindProperty(SupportsGet = true)]
        public string keresPlatform { get; set; }
        [BindProperty(SupportsGet = true)]
        public string keresMufaj { get; set; }
        public IndexModel(PC_Jatekok.Data.PC_JatekokContext context)
        {
            _context = context;

        }

        public IList<Jatek> Jatek { get;set; }

        public async Task OnGetAsync()
        {
            Jatek = await _context.Jatek.ToListAsync();

            var jatekok = _context.Jatek.Select(x => x);

            if (!string.IsNullOrEmpty(keresNev)) {
                jatekok = jatekok.Where(x => x.nev.Contains(keresNev));
            }
            if (!string.IsNullOrEmpty(keresFejleszto)) {
                jatekok = jatekok.Where(x => x.developer.Contains(keresFejleszto));
            }
            if (!string.IsNullOrEmpty(keresKategoria)) {
                jatekok = jatekok.Where(x => x.category.Contains(keresKategoria));
            }
            if (!string.IsNullOrEmpty(keresMufaj)) {
                jatekok = jatekok.Where(x => x.genre.Contains(keresMufaj));
            }
            if (!string.IsNullOrEmpty(keresPlatform)) {
                jatekok = jatekok.Where(x => x.platform.Contains(keresPlatform));
            }
            Jatek = await jatekok.ToListAsync();
        }



    }

}
