package org.example;

public class KontoOszczedniosciowe extends Konto{
    public KontoOszczedniosciowe(String numerKonta, double saldo) {
        super(numerKonta, saldo);
    }

    @Override
    public boolean wyplac(double wyplata) {
        wyplata += 5.0;
        return super.wyplac(wyplata);
    }

    @Override
    public boolean wplac(double wplata) {
        wplata += wplata / 100;
        return super.wplac(wplata);
    }

    @Override
    public String toString() {
        String saldoFormat = String.format("%.2f", this.saldo);
        return "[Konto oszczedniosciowe] " + this.numerKonta + " | saldo: " + saldoFormat + " zł";
    }
}
