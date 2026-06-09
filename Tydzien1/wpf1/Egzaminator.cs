using System;
using System.Collections.Generic;
using System.Text;

namespace Inf04Tydzien1Zad5
{
    internal class Egzaminator
    {
        private static int LicznikEgzaminatorow {  get; set; }
        private int ID {  get; set; }
        public string Imie;
        public string Nazwisko;
        public enum Specjalizacje
        {
            INF02,
            INF03,
            INF04
        }
        public Specjalizacje Specjalizacja;

        public Egzaminator ( string imie, string nazwisko, Specjalizacje specjalizacja)
        {
            ID = Egzaminator.LicznikEgzaminatorow;
            Imie = imie;
            Nazwisko = nazwisko;
            Specjalizacja = specjalizacja;
            Egzaminator.LicznikEgzaminatorow += 1;
        }
        
        public static int getLicznikEgzaminatorow()
        {
            return Egzaminator.LicznikEgzaminatorow;
        }
        
        public int getID()
        {
            return this.ID;
        }



        public string FormatSpecjalizacji()
        {
            switch (this.Specjalizacja) 
            {
                case Specjalizacje.INF02:
                    return "INF.02";
                case Specjalizacje.INF03:
                    return "INF.03";
                case Specjalizacje.INF04:
                    return "INF.04";
                default:
                    return "-";
            }
        }

        override public string ToString()
        {
            StringBuilder formatId = new StringBuilder();
            int ileZerPrzed = 3 - this.ID.ToString().Length;
            for(int i = 0; i < ileZerPrzed; i++)
            {
                formatId.Append(0);
            }
            formatId.Append(this.ID);
            return $"[ID:{formatId.ToString()}] {this.Imie} {this.Nazwisko} | {this.FormatSpecjalizacji()}";
        }


    }
}
