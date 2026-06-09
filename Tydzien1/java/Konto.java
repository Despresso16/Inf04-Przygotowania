package org.example;

public class Konto {
    public String numerKonta;
    public double saldo;

    public Konto(String numerKonta, double saldo) {
        this.numerKonta = numerKonta;
        this.saldo = saldo;
    }

    public boolean wyplac(double wyplata){
        if(wyplata < 0){
            System.out.println("\n["+ this.numerKonta + "] - [!] Blad wyplaty, ujemna ilosc wyplacanych pieniedzy");
            return false;
        }
        else if(this.saldo - wyplata < 0){
            System.out.println("\n["+ this.numerKonta + "] - [!] Blad wyplaty, niewystarczajaca ilosc srodkow na saldzie konta");
            return false;
        }
        else{
            this.saldo -= wyplata;
            return true;
        }
    }
    public boolean wplac(double wplata){
        if(wplata < 0){
            System.out.println("\n[!] Blad wplaty, ujemna ilosc wplacanych pieniedzy");
            return false;
        }
        else{
            this.saldo += wplata;
            return true;
        }
    }

    @Override
    public String toString() {
        String saldoFormat = String.format("%.2f", this.saldo);
        return "[Konto] " + this.numerKonta + " | saldo: " + saldoFormat + " zł";
    }
}
