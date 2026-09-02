# Casa de Schimb Valutar

Aplicatie desktop in Windows Forms pentru o casa de schimb valutar: tine evidenta valutelor, a cursurilor zilnice si a tranzactiilor de cumparare/vanzare.

## Ce face

- Valute - adaugi, editezi sau stergi valutele cu care lucrezi (cod, nume, simbol).
- Cursuri valutare - setezi cursul de schimb in RON pentru fiecare valuta, cu istoric pe date.
- Tranzactii - inregistrezi cumparari si vanzari de valuta; suma in RON se calculeaza automat dupa cursul curent al valutei alese.
- Fereastra principala - un meniu simplu duce la ferestrele de Valute, Cursuri valutare si Tranzactii, fiecare deschisa o singura data (nu se dubleaza daca o redeschizi din meniu).

## Tehnologii folosite

- C# pe .NET Framework 4.8
- Windows Forms
- SQL Server LocalDB (baza de date atasata, fisier .mdf), acces la date prin ADO.NET

## Structura proiectului

CasaSchimbValutar/
Database/            # conexiunea la baza de date si crearea tabelelor
Forms/             # ferestrele aplicatiei
Models/             # Valuta, CursValutar, Tranzactie
Repositories/       # operatiile CRUD pentru fiecare entitate
Properties/          # setari si resurse
Program.cs           # punctul de pornire al aplicatiei

## Baza de date

| Tabel             | Ce contine                                                    |
|-------------------|----------------------------------------------------------------|
| Valute            | codul, numele si simbolul fiecarei valute                     |
| CursuriValutare   | cursul in RON al unei valute, la o anumita data                |
| Tranzactii        | cumparari/vanzari, cu suma, cursul folosit si data              |

Tabelele se creeaza automat la prima rulare, daca nu exista deja.

## Ce iti trebuie

- Windows cu .NET Framework 4.8
- SQL Server LocalDB
- Visual Studio 2019/2022

## Cum il pornesti

1. Clonezi repo-ul:
   git clone https://github.com/augustinbuzatu/CasaSchimbValutar.git
  
2. Deschizi *CasaSchimbValutar.sln* in Visual Studio.
3. Apesi F5. La prima pornire aplicatia isi creeaza singura baza de date si tabelele.

## Cum se foloseste

1. Adaugi valutele cu care vrei sa lucrezi (EUR, USD etc) din meniul *Valute*.
2. Setezi cursul curent pentru fiecare valuta din *Cursuri valutare*.
3. Inregistrezi cumpararile/vanzarile din *Tranzactii* - suma in RON iese automat, dupa cursul valutei alese.

## Autor
Buzatu Cristian
