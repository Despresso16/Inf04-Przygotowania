using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Inf04Tydzien2Zad11
{
    internal class Projekt
    {
        public ObservableCollection<Zadanie> zadania;

        public Projekt()
        {
            this.zadania = new ObservableCollection<Zadanie>();
        }
    }
}
