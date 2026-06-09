package org.example;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.time.LocalDate;
import java.time.LocalTime;
import java.util.ArrayList;
import java.util.Comparator;
import java.util.HashMap;

public class Main {
    public static String formatujDouble(double liczba){
        return String.format("%.2f", liczba);
    }
    public static void main(String[] args) {
        //zad 8.2
        System.out.println("\nZad 8.2");
        ArrayList<Pracownik> pracownicy = new ArrayList<>();
        pracownicy.add(new PracownikEtatowy("John", "Pork", 21.37));
        pracownicy.add(new PracownikEtatowy("John", "Roblox", 21.37, 67));
        pracownicy.add(new PracownikGodzinowy("Jan", "Nadprędkość", 12.34, 69));
        pracownicy.add(new PracownikGodzinowy("Waldemar", "Bialy", 12.34, 161));
        pracownicy.add(new PracownikGodzinowy("Szymom", "z Twingo", 12.34, 160));
        pracownicy.sort(Comparator.comparingDouble(Pracownik::obliczWynagrodzenie).reversed());
        double lacznyKoszt = 0;
        double kosztEtaty = 0;
        double kosztGodziny = 0;
        int minWynagrodzenieIndeks = 0;
        int maxWynagrodzenieIndeks = 0;
        double minWynagrodzenie = 999999999;
        double maxWynagrodzenie = 0.01;
        System.out.println("=== RAPORT ===");
        for(int i = 0; i < pracownicy.size(); i++){
            double wynagrodzenie = pracownicy.get(i).obliczWynagrodzenie();
            if(minWynagrodzenie > wynagrodzenie) {
                minWynagrodzenie = wynagrodzenie;
                minWynagrodzenieIndeks = i;
            }
            if(maxWynagrodzenie < wynagrodzenie){
                maxWynagrodzenie = wynagrodzenie;
                maxWynagrodzenieIndeks = i;
            }

            if(pracownicy.get(i) instanceof PracownikEtatowy){
                kosztEtaty += wynagrodzenie;
            }
            else if(pracownicy.get(i) instanceof PracownikGodzinowy){
                kosztGodziny += wynagrodzenie;
            }
            System.out.println(pracownicy.get(i).toString() + "\n");
        }
        lacznyKoszt = kosztEtaty + kosztGodziny;
        System.out.println("---\n" +
                "Wynagrodzenia:\n" +
                "Najwyższe: " + pracownicy.get(maxWynagrodzenieIndeks).imie + " " + pracownicy.get(maxWynagrodzenieIndeks).nazwisko + " " + formatujDouble(maxWynagrodzenie) + "\n" +
                "Najniższe: " + pracownicy.get(minWynagrodzenieIndeks).imie + " " + pracownicy.get(minWynagrodzenieIndeks).nazwisko + " " + formatujDouble(minWynagrodzenie) + "\n" +
                "Łącznie etaty: " + formatujDouble(kosztEtaty) + " zł\n" +
                "Łącznie godziny: " + formatujDouble(kosztGodziny) + "zł\n" +
                "Łącznie: " + formatujDouble(lacznyKoszt) + "zł\n" +
                "===");

        // zad 9.1
        System.out.println("\nZad 9.1");
        ArrayList<Log> logi = new ArrayList<>();
        InputStream sciezkaOdczytu = Main.class.getClassLoader().getResourceAsStream("dane_logowania.txt");
        int licznikLogow = 0;
        int licznikLogowOk = 0;
        try {
            assert sciezkaOdczytu != null;
            try(BufferedReader odczyt = new BufferedReader(new InputStreamReader(sciezkaOdczytu))) {
                String linia;

                while((linia = odczyt.readLine()) != null){
                    String[] dane = linia.split(";");
                    if(dane.length != 4) {
                        System.out.println("Błędny format linii, pomijam...");
                        continue;
                    }
                    licznikLogow += 1;
                    if(dane[3].trim().equalsIgnoreCase("FAIL")){
                        logi.add(new Log(LocalDate.parse(dane[0].trim()), LocalTime.parse(dane[1].trim()), dane[2].trim()));
                    }
                    else licznikLogowOk += 1;
                }
            }
        } catch (IOException e) {
            System.out.println("Blad w odczycie pliku!");
            throw new RuntimeException(e);
        }
        // zad 9.1
        System.out.println("\nZad 9.1");
        HashMap<String, Integer> loginyLiczniki = new HashMap<>();
        ArrayList<Log> loginyPozaGodzPracy = new ArrayList<>();

        for(Log log : logi){
            if(loginyLiczniki.containsKey(log.login)){
                loginyLiczniki.put(log.login, loginyLiczniki.get(log.login) + 1);
            }
            else loginyLiczniki.put(log.login, 1);
            if(log.godzina.isAfter(LocalTime.parse("22:00")) || log.godzina.isBefore(LocalTime.parse("06:00"))){
                loginyPozaGodzPracy.add(log);
            }
        }

        System.out.println("=== POWTARZAJACE SIE LOGINY===");
        loginyLiczniki.forEach((k, v) -> {
            if(v > 1){
                System.out.println(k + " - " + v + " próby");
            }
        });
        System.out.println("\n=== LOGOWANIA POZA GODZ PRACY ===");
        for(Log log : loginyPozaGodzPracy){
            System.out.println(log.data + " | " + log.godzina + " | " + log.login + " | " + log.token);
        }
    }
}