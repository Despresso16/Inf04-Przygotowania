using System;
using System.Collections.Generic;
using System.Text;

namespace Inf04Tydzien1Zad7
{
    internal class Zamowienie
    {
        private static int LicznikZamowien = 0;
        private List<Pozycja> pozycje { get; set; }
        public int numerZamowienia;

        public Zamowienie()
        {
            Zamowienie.LicznikZamowien += 1;
            this.pozycje = new List<Pozycja>();
            this.numerZamowienia = Zamowienie.LicznikZamowien;
        }

        public void DodajPozycje(Pozycja pozycja)
        {
            this.pozycje.Add(pozycja);
        }
        
        public double ObliczSume()
        {
            double suma = 0;
            foreach(Pozycja pozycja in this.pozycje)
            {
                suma += pozycja.cenaJednostkowa * pozycja.ilosc;
            }
            return suma;
        }

        public void ZastosujRabat(string fraza)
        {
            fraza = fraza.Trim().ToLower();
            foreach(Pozycja pozycja in this.pozycje)
            {
                if (pozycja.nazwa.ToLower().Contains(fraza))
                {
                    pozycja.cenaJednostkowa -= (pozycja.cenaJednostkowa / 100) * 20;
                }
            }
        }

        public void WyczyscListe()
        {
            List<Pozycja> nowaLista = new List<Pozycja>();
            foreach(Pozycja pozycja in this.pozycje)
            {
                if(pozycja.ilosc != 0)
                {
                    nowaLista.Add(pozycja);
                }
            }
            this.pozycje = nowaLista;
        }

        public string Podsumowanie()
        {
            StringBuilder formatNumeru = new StringBuilder();
            int ileZer = 4 - this.numerZamowienia.ToString().Length;
            for(int i = 0; i < ileZer; i++)
            {
                formatNumeru.Append('0');
            }
            formatNumeru.Append(this.numerZamowienia);
            StringBuilder podsumowanie = new StringBuilder($"=== ZAMÓWIENIE {formatNumeru.ToString()} ===\n");
            foreach(Pozycja pozycja in this.pozycje)
            {
                podsumowanie.Append($"{pozycja.nazwa}\t x {pozycja.ilosc} | {pozycja.cenaJednostkowa:F2} zł\n");
            }
            podsumowanie.Append($"---\nSUMA: {this.ObliczSume():F2} zł");
            return podsumowanie.ToString();
        }
    }
}
