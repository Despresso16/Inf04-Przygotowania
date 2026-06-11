using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Inf04Tydzien2Zad14
{
    internal class SprzetKomputerowy
    {
        public static int LicznikSprzetu { get; private set; }
        public int NumerInwentarzowy { get; set; }
        public string Nazwa { get; set; }
        public enum RodzajSprzetu
        {
            Komputer,
            Monitor,
            Drukarka,
            Inne
        }
        public RodzajSprzetu Typ { get; set; }
        public int RokZakupu { get; set; }
        public double Wartosc {  get; set; }
        public string PrzypisanaSala { get; set; }

        public string ZamortyzowanieFormat
        {
            get
            {
                return this.Zamortyzowanie() ? "Tak" : "Nie";
            }
        }
        public string TypFormat
        {
            get
            {
                switch (this.Typ)
                {
                    case RodzajSprzetu.Komputer:
                        return "Komputer";
                    case RodzajSprzetu.Monitor:
                        return "Monitor";
                    case RodzajSprzetu.Drukarka:
                        return "Drukarka";
                    default:
                        return "Inne";
                }

            }
        }
        public string WartoscFormat
        {
            get
            {
                return $"{this.Wartosc:F2} zł";
            }
        }


        public SprzetKomputerowy(string nazwa, RodzajSprzetu typ, int rokZakupu, double wartosc, string przypisanaSala)
        {
            SprzetKomputerowy.LicznikSprzetu += 1;
            this.NumerInwentarzowy = SprzetKomputerowy.LicznikSprzetu;
            this.Nazwa = nazwa;
            this.Typ = typ;
            this.RokZakupu = rokZakupu;
            this.Wartosc = wartosc;
            this.PrzypisanaSala = przypisanaSala;
        }

        public bool Zamortyzowanie()
        {
            DateTime dzis = DateTime.Now;
            if(dzis.Year - this.RokZakupu > 5)
            {
                return true;
            }
            else return false;
        }

        public double CenaPoAmortyzacjiLiniowej()
        {
            double cena = this.Wartosc;
            DateTime dzis = DateTime.Now;
            if(this.Zamortyzowanie())
            {
                int ileLat = this.RokZakupu - dzis.Year;
                for(int i = 0; i < ileLat; i++)
                {
                    cena -= (this.Wartosc / 100) * 10;
                }
            }
            return cena;
        }

    }
}
