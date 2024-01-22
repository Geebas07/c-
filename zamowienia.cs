using System;
using System.Security.Authentication.ExtendedProtection;

public class HelloWorld
{
    public static void Main(string[] args)
    {
        
    }
}
public class Pozycja
{
    public string nazwatowaru;
    public int ilesztuk;
    public double cena;
    public double wynik;

    Pozycja(string nazwatowaru, int ilesztuk, double cena, double wynik)
    {
        this.nazwatowaru = nazwatowaru;
        this.ilesztuk = ilesztuk;
        this.cena = cena;
    }
    public double obliczwartosc()
    {
        wynik = cena * ilesztuk;
        return wynik;
    }
    String toString() {
        return nazwatowaru + "                " + cena + "          " + ilesztuk + "          " + wynik;
    }
    public double obliczwartosczrabatem()
    {
        if(ilesztuk>=5 && ilesztuk<=10)
        {
            wynik = wynik * 0.95;
        }
        else if(ilesztuk>10 && ilesztuk <= 20)
        {
            wynik = wynik * 0.9;
        }
        else if (ilesztuk > 20)
        {
            wynik = wynik * 0.85;
        }
        return wynik;
    }
}
public class Zamowienie
{
    List<Pozycja> lista = new List<Pozycja>();
    int iledodanych;
    int maksrozmiar;
    double rabat_sum;
    Zamowienie(int iledodanych, int maksrozmiar)
    {
        this.iledodanych = iledodanych;
        this.maksrozmiar = maksrozmiar;
    }
    Zamowienie()
    {
        maksrozmiar = 10;
    }
    void dodajpozycje(Pozycja p)
    {
        if (iledodanych < maksrozmiar)
        {
            lista.Add(p);
            iledodanych++;
        }
        else
        {
            Console.WriteLine("Maks wielkosc zostala osiagnieta");
        }
        for (int i = 0; i < lista.Count; i++)
        {
            if (lista[i].nazwatowaru == p.nazwatowaru)
            {
                lista[i].ilesztuk = lista[i].ilesztuk + p.ilesztuk;
            }
        }
    }
    public double obliczwartosc()
    {
        Console.WriteLine("Rabaty:");
        Console.WriteLine("5% dla od 5 do 10 sztuk produktu");
        Console.WriteLine("10% dla od 10 do 20 sztuk pdoruktu");
        Console.WriteLine("15% dla powyżej 20 sztuk produktu");
        for(int i=0; i<lista.Count; i++)
        {
            lista[i].obliczwartosczrabatem();
        }
        double suma = 0;
        for (int i = 0; i < lista.Count; i++)
        {
            suma = suma + lista[i].obliczwartosc();
        }
        return suma;
    }
    public string ToString(Pozycja p)
    {
        string spisPozycji = "Spis pozycji zamówienia:\n";
        double rabat_sum;
        
        for(int i=0; i< lista.Count; i++)
        {
            spisPozycji += lista[i].ToString() + "\n";
        }
        for(int i=0; i< lista.Count; i++)
        {
            if (p.ilesztuk >= 5 && p.ilesztuk <= 10)
            {
                rabat_sum += p.wynik*0.95;
            }
            else if (p.ilesztuk > 10 && p.ilesztuk <= 20)
            {
                rabat_sum += p.wynik * 0.9;
            }
            else if (p.ilesztuk > 20)
            {
                rabat_sum += p.wynik * 0.85;
            }
        }
        Console.WriteLine($"Udało ci się zaoszczędzić {rabat_sum}");
        return spisPozycji;
    }
    void usunpozycje(int indeks)
    {
        if(indeks>0 && indeks < lista.Count)
        {
            lista.RemoveAt(indeks);
        }
        else
        {
            Console.WriteLine("Indeks ktory podales nie istnieje");
        }
    }
    void edytujpozycje(int indeks)
    {
        if(indeks>0 && indeks < lista.Count)
        {
            lista[indeks].cena = 5000;
            lista[indeks].nazwatowaru = "Kremówki";
            lista[indeks].ilesztuk = 5;
        }
    }
    
}