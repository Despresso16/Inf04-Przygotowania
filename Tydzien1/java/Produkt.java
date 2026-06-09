package org.example;

import java.util.Arrays;

public class Produkt {
    public String nazwa;
    public double cena;
    public int ilosc;
    public String kodPartii;

    public Produkt(String nazwa, double cena, int ilosc, String kodPartii) {
        this.nazwa = nazwa;
        this.cena = cena;
        this.ilosc = ilosc;
        this.kodPartii = kodPartii;
    }


    public boolean walidujKod(){
        char[] kodPartiiTabela = this.kodPartii.trim().toCharArray();
        int suma = this.obliczSumeKontrolna();
        int reszta = suma % 10;
        int cyfra11 = Integer.parseInt(String.valueOf(kodPartiiTabela[10]));
        if(reszta == 0 && cyfra11 == 0){
            return true;
        }
        else if(reszta != 0 && cyfra11 == 10 - reszta){
            return true;
        }
        else {
            return false;
        }
    }
    private int obliczSumeKontrolna(){
        int waga = 1;
        int suma = 0;
        char[] kodPartiiTabela = this.kodPartii.trim().toCharArray();
        for(int i = 0; i < 10; i++){
            int numer = Integer.parseInt(String.valueOf(kodPartiiTabela[i]));
            numer *= waga;
            suma += numer;
            switch (waga){
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
    public String stworzEtykieteSkrocona() {
        StringBuilder budowniczyEtykiety = new StringBuilder();
        char[] nazwaTabela = this.nazwa.trim().toCharArray();
        for(int i = 0; i < nazwaTabela.length; i++){
            if(i < nazwaTabela.length-1){
                if(nazwaTabela[i] == nazwaTabela[i+1]) continue;
            }
            budowniczyEtykiety.append(nazwaTabela[i]);
        }
        nazwaTabela = budowniczyEtykiety.toString().toCharArray();
        budowniczyEtykiety = new StringBuilder();
        String samogloski = "aeiouyąęó";
        for(char znak : nazwaTabela){
            if(samogloski.indexOf(Character.toLowerCase(znak)) != -1){
                budowniczyEtykiety.append("*");
            }
            else{
                budowniczyEtykiety.append(znak);
            }
        }
        return budowniczyEtykiety.toString();
    }


    @Override
    public String toString() {
        String cenaFormat = String.format("%.2f", this.cena);
        return this.nazwa + " | " + cenaFormat + " zł | " + this.ilosc + " szt. | kod: " + this.kodPartii;
    }

}
