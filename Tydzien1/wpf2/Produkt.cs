using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Navigation;

namespace Inf04Tydzien1Zad6
{
    internal class Produkt
    {
        public string nazwa { get; }
        public double cena { get; }
        public int ilosc { get; }
        public string kodPartii { get; }

        public string poprawnoscKodu
        {
            get
            {
                return this.WalidujKod() ? "Poprawny" : "Niepoprawny";
            }
        }

        public Produkt(string nazwa, double cena, int ilosc, string kodPartii)
        {
            this.nazwa = nazwa;
            this.cena = cena;
            this.ilosc = ilosc;
            this.kodPartii = kodPartii;
        }
        private int ObliczSumeKontrolna()
        {
            int waga = 1;
            int suma = 0;
            char[] kodTabela = kodPartii.ToCharArray();
            for(int i = 0; i < 10;  i++)
            {
                int numer = int.Parse(kodTabela[i].ToString());
                numer *= waga;
                suma += numer;
                switch (waga) 
                {
                    case 1:
                        waga = 3;
                        break;
                    case 3:
                        waga = 7;
                        break;
                    case 7:
                        waga = 9;
                        break;
                    default:
                        waga = 1;
                        break;
                }
            }
            return suma;
        }
        
        public bool WalidujKod()
        {
            char[] kodTabela = this.kodPartii.ToCharArray();
            int suma = ObliczSumeKontrolna();
            int reszta = suma % 10;
            int cyfra11 = int.Parse(kodTabela[10].ToString());
            if (reszta == 0 && cyfra11 == 0)
            {
                return true;
            }
            else if (reszta != 0 && cyfra11 == 10 - reszta)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string StworzSkroconaEtykiete()
        {
            StringBuilder budowniczyEtykiety = new StringBuilder();
            char[] nazwaTabela = this.nazwa.Trim().ToCharArray();
            for(int i = 0; i < nazwaTabela.Length; i++)
            {
                if(i < nazwaTabela.Length - 1)
                {
                    if (nazwaTabela[i] == nazwaTabela[i + 1])
                    {
                        continue;
                    }
                }
                budowniczyEtykiety.Append(nazwaTabela[i]);
            }
            nazwaTabela = budowniczyEtykiety.ToString().ToCharArray();
            budowniczyEtykiety = new StringBuilder();
            char[] samogloski = "aeiouyąęó".ToCharArray();
            foreach(char znak in nazwaTabela)
            {
                if (samogloski.Contains(znak))
                {
                    budowniczyEtykiety.Append("*");
                }
                else
                {
                    budowniczyEtykiety.Append(znak);
                }
            }
            return budowniczyEtykiety.ToString();
        }

        public override string ToString()
        {
            return $"{this.nazwa} | {this.cena:F2} zł | {this.ilosc} szt | {this.kodPartii}";
        }
    }
}
