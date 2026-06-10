using System;
using System.Collections.Generic;
using System.Text;

namespace Inf04Tydzien2Zad13
{
    internal class Gra
    {
        public string tytul {  get; set; }
        public string gatunek { get; set; }
        public int rokWydania { get; set; }
        public double ocena { get; set; }
        public string opis { get; set; }
        public string nazwaGrafiki { get; set; }

        public Gra(string tytul, string gatunek, int rokWydania, double ocena, string opis, string nazwaGrafiki)
        {
            this.tytul = tytul;
            this.gatunek = gatunek;
            this.rokWydania = rokWydania;
            this.ocena = ocena;
            this.opis = opis;
            this.nazwaGrafiki = nazwaGrafiki;
        }

        
    }
}
