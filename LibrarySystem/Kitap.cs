using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem
{
    internal class Kitap
    {
        public string ad { get; set; }
        public string yazar { get; set; }
        public int fiyat { get; set; }

        public int stok { get; set; }

        public Kitap(string _ad, string _yazar, int _fiyat, int _stok)
        {
            ad = _ad;
            yazar = _yazar;
            fiyat = _fiyat;
            stok = _stok;
        }

        public override string ToString()
        {
            return $"Kitap İsmi: {ad} Yazar: {yazar} Fiyat: {fiyat} Stok: {stok}";
        }
    }
}
