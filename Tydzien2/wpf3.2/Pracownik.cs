using System;
using System.Collections.Generic;
using System.Text;

namespace Inf04Tydzien2Zad12._1
{
    internal class Pracownik
    {
        public string imie;
        public string nazwisko;
        public string typ;

        public Pracownik(string imie, string nazwisko, string typ)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.typ = typ;
        }
        public override string ToString()
        {
            return $"{this.imie} {this.nazwisko} | Typ: {this.typ}";
        }
    }
}
