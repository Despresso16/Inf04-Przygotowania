package org.example;

public class Egzaminator {
    private static int licznikEgzaminatorow;
    private final int ID;
    public String imie;
    public enum specjalizacje{
        INF02,
        INF03,
        INF04
    }
    public specjalizacje specjalizacja;

    public Egzaminator(String imie, specjalizacje specjalizacja) {
        this.ID = licznikEgzaminatorow;
        this.imie = imie;
        this.specjalizacja =specjalizacja;
        Egzaminator.licznikEgzaminatorow += 1;
    }

    public String formatSpecjalizacji(){
        switch (this.specjalizacja){
            case INF02 :
                return "INF.02";
            case INF03 :
                return "INF.03";
            case INF04 :
                return "INF.04";
        }
        return "-";
    }

    public static int getLicznikEgzaminatorow() {
        return licznikEgzaminatorow;
    }

    public int getID() {
        return ID;
    }

    @Override
    public String toString() {
        StringBuilder konstruktorID = new StringBuilder();
        int ileZerPrzed = 3 - String.valueOf(this.ID).length();
        for(int i = 0; i < ileZerPrzed; i++){
            konstruktorID.append("0");
        }
        konstruktorID.append(this.ID);
        String IDstring = konstruktorID.toString();
        return "[ID:" + IDstring + "] " + this.imie + " | " + this.formatSpecjalizacji();
    }
}
