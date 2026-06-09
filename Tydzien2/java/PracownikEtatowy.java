package org.example;

public class PracownikEtatowy extends Pracownik{
    public double pensjaBazowa;
    public double premiaRocznaProcentowa;

    public PracownikEtatowy(String imie, String nazwisko, double pensjaBazowa) {
        super(imie, nazwisko);
        this.pensjaBazowa = pensjaBazowa;
        this.premiaRocznaProcentowa = 0;
    }

    public PracownikEtatowy(String imie, String nazwisko, double pensjaBazowa, double premiaRocznaProcentowa) {
        super(imie, nazwisko);
        this.pensjaBazowa = pensjaBazowa;
        this.premiaRocznaProcentowa = premiaRocznaProcentowa;
    }


    @Override
    public double obliczWynagrodzenie() {
        if(premiaRocznaProcentowa == 0) return  this.pensjaBazowa;
        return this.pensjaBazowa + (this.pensjaBazowa * (this.premiaRocznaProcentowa / 12));
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
        String pensjaFormat = String.format("%.2f", this.pensjaBazowa);
        String premiaProcentFormat = String.format("%.2f", this.premiaRocznaProcentowa);
        String wynagrodzenieFormat = String.format("%.2f", this.obliczWynagrodzenie());
        return "Pracownik #" + idFormat + " [Prac. Etatowy]\n" + this.imie + " " + this.nazwisko +
                " - pensja: " + pensjaFormat + " zł, premia: " + premiaProcentFormat + "%\nWynagrodzenie: " +
                wynagrodzenieFormat + " | " + this.progPodatkowy();
    }
}
