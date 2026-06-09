package org.example;

import java.util.Calendar;

public class Pojazd {
    private String numerRejestracyjny;
    private String rodzajPojazdu;
    private int rokProdukcji;
    private double przebieg;

    public Pojazd(String numerRejestracyjny, String rodzajPojazdu, int rokProdukcji, double przebieg) {
        this.numerRejestracyjny = numerRejestracyjny;
        rodzajPojazdu = rodzajPojazdu.trim().toLowerCase();
        if(!rodzajPojazdu.equals("osobowy") && !rodzajPojazdu.equals("dostawczy") && !rodzajPojazdu.equals("motocykl")){
            System.out.println("Nieprawidlowy rodzaj pojazdu, ustawiono \"osobowy\"");
            rodzajPojazdu = "osobowy";
        }
        this.rodzajPojazdu = rodzajPojazdu;
        Calendar kalendarz = Calendar.getInstance();
        if(rokProdukcji < 1900){
            System.out.println("Nieprawidlowy rok produkcji, ustawiam \"1900\"");
            rokProdukcji = 1900;
        }
        else if(rokProdukcji > kalendarz.get(Calendar.YEAR)){
            System.out.println("Nieprawidlowy rok produkcji, ustawiam \"" + kalendarz.get(Calendar.YEAR) + "\"");
            rokProdukcji = kalendarz.get(Calendar.YEAR);
        }
        this.rokProdukcji = rokProdukcji;
        if(przebieg < 0){
            System.out.println("Nieprawidlowy przebieg, ustawiam \"0\"");
            przebieg = 0;
        }
        this.przebieg = przebieg;
    }

    public boolean czyPotrzebnySerwis(){
        Calendar kalendarz = Calendar.getInstance();
        int aktualnyRok = kalendarz.get(Calendar.YEAR);
        if(aktualnyRok-this.rokProdukcji > 5 || przebieg > 20000){
            return true;
        }
        return false;
    }

    @Override
    public String toString() {
        return "[" + numerRejestracyjny + "] " + rodzajPojazdu +", "+ rokProdukcji + "r., " + przebieg + " km - SERWIS - " + (this.czyPotrzebnySerwis() ? "TAK" : "NIE");
    }

    public void setPrzebieg(double przebieg) {
        if(przebieg <= this.przebieg){
            System.out.println("Nieprawidlowy nowy przebieg, przebieg musi byc wiekszy od: " + this.przebieg);
            return;
        }
        this.przebieg = przebieg;
    }

    public String getNumerRejestracyjny() {
        return numerRejestracyjny;
    }

    public String getRodzajPojazdu() {
        return rodzajPojazdu;
    }

    public int getRokProdukcji() {
        return rokProdukcji;
    }

    public double getPrzebieg() {
        return przebieg;
    }
}
