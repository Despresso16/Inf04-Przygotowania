package org.example;

import java.io.*;
import java.util.*;

public class Main {
    public static String wygenerujRaportFloty(ArrayList<Pojazd> listaPojazdow, int aktualnyRok){
        StringBuilder konstruktorRaportu = new StringBuilder("--- RAPORT SERWISU FLOTY ");
        konstruktorRaportu.append(aktualnyRok).append(" ---\n");
        int liczbaPojazdowWRaporcie = 0;
        for(Pojazd pojazd : listaPojazdow){
            if(pojazd.czyPotrzebnySerwis()){
                liczbaPojazdowWRaporcie += 1;
                konstruktorRaportu.append(pojazd.toString()).append("\n");
            }
        }
        konstruktorRaportu.append("\nLiczba pojazdow wymagajacych serwisu: ").append(liczbaPojazdowWRaporcie).append(" z ").append(listaPojazdow.size()).append(" ").append((liczbaPojazdowWRaporcie/listaPojazdow.size())*100).append("%");
        return konstruktorRaportu.toString();
    }
    public static void main(String[] args) {
        Calendar kalendarz = Calendar.getInstance();
        Scanner skaner = new Scanner(System.in);
        // zad 1.2
        System.out.println("\nZad 1.2");
        ArrayList<Pojazd>  flota = new ArrayList<>();
        flota.add(new Pojazd("ABC123", "osobowy", 2000, 1000));
        flota.add(new Pojazd("ABC124", "dostawczy", 2025, 1000));
        flota.add(new Pojazd("ABC125", "motocykl", 2020, 1000));
        flota.add(new Pojazd("ABC126", "osobowy", 2024, 1000));
        flota.add(new Pojazd("ABC127", "osobowy", 2024, 100000));
        flota.add(new Pojazd("ABC2137", "osobowy", 1984, 1000));
        flota.sort(Comparator.comparingInt(Pojazd::getRokProdukcji));
        System.out.println(wygenerujRaportFloty(flota, kalendarz.get(Calendar.YEAR)));

        // zad 2.2
        System.out.println("\nZad 2.2");
        System.out.println("Licznik: " + Egzaminator.getLicznikEgzaminatorow());
        Egzaminator egz1 = new Egzaminator("Grzegorz", Egzaminator.specjalizacje.INF02);
        System.out.println("Egzaminator 1: " + egz1.toString());
        System.out.println("Licznik: " + Egzaminator.getLicznikEgzaminatorow());
        Egzaminator egz2 = new Egzaminator("Rysiek", Egzaminator.specjalizacje.INF04);
        System.out.println("Egzaminator 2: " + egz2.toString());
        System.out.println("Licznik: " + Egzaminator.getLicznikEgzaminatorow());

        //zad 3.1
        System.out.println("\nZad 3.1");
        ArrayList<Produkt> produkty = new ArrayList<>();
        ArrayList<Produkt> produktyZNiezgodnymKodem = new ArrayList<>();
        ArrayList<Produkt> produktyZPoprawnymKodem = new ArrayList<>();
        InputStream input = Main.class.getClassLoader().getResourceAsStream("produkty.txt");
        try(BufferedReader odczyt = new BufferedReader(new InputStreamReader(input))) {
            String linia;

            while((linia =odczyt.readLine())!=null)
            {
                String[] dane = linia.split(";");
                if (dane.length < 4) continue;
                else if (dane[1].trim().equals("BRAK")) {
                    System.out.println("\n[POMINIĘTO] " + dane[0] + " - błędna CENA: \"BRAK\"");
                    continue;
                }
                double cena = Double.parseDouble(dane[1].trim());
                int ilosc = Integer.parseInt(dane[2].trim());
                produkty.add(new Produkt(dane[0].trim(), cena, ilosc, dane[3].trim()));
            }
        }catch (IOException e) {
            throw new RuntimeException(e);
        }
        System.out.println("\nWczytano " + produkty.size() + " produktów.");
        if(!produkty.isEmpty()){
            for(Produkt produkt : produkty) {
                if (produkt.walidujKod()) produktyZPoprawnymKodem.add(produkt);
                else produktyZNiezgodnymKodem.add(produkt);
            }
            System.out.println("Produkty z poprawnym kodem [" + produktyZPoprawnymKodem.size() + "]:");
            for(Produkt poprawnyProdukt : produktyZPoprawnymKodem){
                System.out.println(poprawnyProdukt.toString());
            }
            System.out.println("\nProdukty z niepoprawnym kodem [" + produktyZNiezgodnymKodem.size() + "]:");
            for(Produkt niepoprawnyProdukt : produktyZNiezgodnymKodem){
                System.out.print(niepoprawnyProdukt.nazwa + ", ");
            }
            System.out.println();
        }

        // zad 3.2
        System.out.println("\nZad 3.2");
        System.out.println("Etykiety skrócone dla produktów z poprawnych kodem: ");
//        produktyZPoprawnymKodem.add(new Produkt("Appple", 0.0, 0, "10433218198"));
        for(Produkt produkt : produktyZPoprawnymKodem){
            System.out.println("\t" + produkt.nazwa + " -> " + produkt.stworzEtykieteSkrocona());
        }

        //zad 4.1
        System.out.println("\nZad 4.1");
        Konto[] konta = new Konto[]{new Konto("PL001", 1000), new KontoOszczedniosciowe("PL002", 1000), new KontoPremium("Pl003", 1000, 500)};
        for(var konto : konta){
            System.out.println(konto.toString());
        }

        //zad 4.2
        System.out.println("\nZad 4.2");
        for(var konto : konta){
            konto.wplac(1000);
            konto.wyplac(1200);
            if(konto instanceof KontoPremium){
                ((KontoPremium) konto).naliczOdsetkiKarne();
            }
            System.out.println(konto.toString());
        }
        
    }
}