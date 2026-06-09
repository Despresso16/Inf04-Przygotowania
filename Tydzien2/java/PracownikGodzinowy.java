package org.example;

public class PracownikGodzinowy extends Pracownik{
    public double stawkaGodzinowa;
    public int liczbaGodzin;

    public PracownikGodzinowy(String imie, String nazwisko, double stawkaGodzinowa, int liczbaGodzin) {
        super(imie, nazwisko);
        this.stawkaGodzinowa = stawkaGodzinowa;
        this.liczbaGodzin = liczbaGodzin;
    }

    @Override
    public double obliczWynagrodzenie() {
        if(this.liczbaGodzin <= 160){
            return this.stawkaGodzinowa * this.liczbaGodzin;
        }
        else{
            return (this.stawkaGodzinowa * 1.5) * this.liczbaGodzin;
        }
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
        String stawkaFormat = String.format("%.2f", this.stawkaGodzinowa);
        String wynagrodzenieFormat = String.format("%.2f", this.obliczWynagrodzenie());
        return "Pracownik #" + idFormat + " [Prac. Godzinowy]\n" + this.imie + " " + this.nazwisko +
                " " + this.liczbaGodzin + "h x " + stawkaFormat + " zł/h " +
                (this.liczbaGodzin > 160 ? "(" + (this.liczbaGodzin - 160) + "h nadgodzin)\n" : "\n") +
                "Wynagrodzenie: " + wynagrodzenieFormat + " zł | " + this.progPodatkowy();
    }
}
