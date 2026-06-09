using System;
using System.Collections.Generic;
using System.Text;

namespace Inf04Tydzien1Zad7
{
    internal class Pozycja
    {
        public string nazwa;
        public double cenaJednostkowa;
        public int ilosc;

        public Pozycja(string nazwa, double cenaJednostkowa, int ilosc)
        {
            this.nazwa = nazwa;
            this.cenaJednostkowa = cenaJednostkowa;
            this.ilosc = ilosc;
        }
    }
}
