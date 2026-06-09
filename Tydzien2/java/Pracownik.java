package org.example;

public abstract class Pracownik {
    public static int licznikPracownikow;
    public String imie;
    public String nazwisko;
    public int identyfikator;

    protected Pracownik(String imie, String nazwisko) {
        Pracownik.licznikPracownikow += 1;
        this.imie = imie;
        this.nazwisko = nazwisko;
        this.identyfikator = Pracownik.licznikPracownikow;
    }

    public abstract double obliczWynagrodzenie();

    public String progPodatkowy(){
        double wynagrodzenie = this.obliczWynagrodzenie();
        if(wynagrodzenie <= 8000) return "I próg";
        else return "II próg";
    }

    @Override
    public String toString() {
        StringBuilder idFormatKonstruktor = new StringBuilder();
        int ileZer = 3-String.valueOf(this.identyfikator).length();
        for(int i = 0; i < ileZer; i++){
            idFormatKonstruktor.append(0);
        }
        idFormatKonstruktor.append(this.identyfikator);
        String idFormat = idFormatKonstruktor.toString();
        return "Pracownik #" + idFormat + "\n" + this.imie + " " + this.nazwisko;
    }
}
