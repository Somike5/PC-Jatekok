using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Jatekok.Models {
    public class Jatek {
        public int id { get; set; }

        [Display(Name = "Játék Neve:")]
        public string nev { get; set; }

        [Display(Name = "Kategória:")]
        public string category { get; set; }

        [Display(Name = "Műfaj:")]
        public string genre { get; set; }

        [Display(Name = "Platform:")]
        public string platform { get; set; }

        [Display(Name = "Fejlesztő:")]
        public string developer { get; set; }

        [Display(Name = "Kiadási Idő:")]
        //[Column(TypeName = "date")] // webes keresés révén, de ez a beviteli formot nem bántja
        [DataType(DataType.Date)] // Ez a jó verzió. mert ez a beviteli formot átalakítja csak dátumossá
        public DateTime releaseDate { get; set; }
    }

    internal class DateTypeAttribute : Attribute {
    }
}
