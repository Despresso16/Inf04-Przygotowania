using System;
using System.Collections.Generic;
using System.Text;

namespace Inf04Tydzien2Zad11
{
    internal class Zadanie
    {
        public string opis;
        public int priorytet;
        public DateTime termin;
        public string status;

        public Zadanie(string opis, int priorytet, DateTime termin, string status)
        {
            this.opis = opis;
            this.priorytet = priorytet;
            this.termin = termin;
            this.status = status;
        }

        public override string ToString()
        {
            return $"[{this.priorytet}*] {this.opis} - " +
                $"{this.status} ({this.termin.ToString("dd.MM")})";
        }
    }
}
