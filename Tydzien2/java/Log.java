package org.example;

import java.time.LocalDate;
import java.time.LocalTime;
import java.util.Date;

public class Log {
    public LocalDate data;
    public LocalTime godzina;
    public String login;
    public String token;

    public Log(LocalDate data, LocalTime godzina, String login) {
        this.data = data;
        this.godzina = godzina;
        this.login = login;
        this.token = wygenerujToken();
    }

    private String wygenerujToken(){
        StringBuilder konstruktorTokenu = new StringBuilder();
        char[] loginTablica = this.login.trim().toUpperCase().toCharArray();
        for(int i = 0; i < loginTablica.length; i++){
            if("1234567890".indexOf(loginTablica[i]) == -1){
                konstruktorTokenu.append(loginTablica[i]);
            }
        }
        konstruktorTokenu.reverse();
        return konstruktorTokenu.toString();
    }
}
