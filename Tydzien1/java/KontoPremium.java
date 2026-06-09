package org.example;

public class KontoPremium extends Konto{
    public double limitDebetu;

    public KontoPremium(String numerKonta, double saldo, double limitDebetu) {
        super(numerKonta, saldo);
        this.limitDebetu = limitDebetu;
    }

    @Override
    public boolean wyplac(double wyplata) {
        if(wyplata < 0){
            System.out.println("\n["+ this.numerKonta + "] - [!] Blad wyplaty, ujemna ilosc wyplacanych pieniedzy");
            return false;
        }
        else if(this.saldo - wyplata < this.limitDebetu){
            System.out.println("\n["+ this.numerKonta + "] - [!] Blad wyplaty, operacja przekroczy limit debetu");
            return false;
        }
        else{
            this.saldo -= wyplata;
            return true;
        }
    }

    public void naliczOdsetkiKarne(){
        if(this.saldo < 0){
            this.saldo -= ((this.saldo*-1)/100)*10;
        }
    }
    @Override
    public String toString() {
        String saldoFormat = String.format("%.2f", this.saldo);
        String limitFormat = String.format("%.2f", this.limitDebetu);
        return "[Konto premium] " + this.numerKonta + " | saldo: " + saldoFormat + "zł | limit: " + limitFormat + " zł";
    }
}
