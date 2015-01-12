# Kalendarz Studencki

## Spis treści

<!-- MarkdownTOC -->

- [Opis projektu](#opis-projektu)
    - [Cel](#cel)
    - [Scenariusz użycia](#scenariusz-użycia)
- [Dokumentacja](#dokumentacja)
- [Sposób użycia](#sposób-użycia)

<!-- /MarkdownTOC -->

## Opis projektu

### Cel

"Kalendarz studencki" jest to program mający za zadanie uprościć zarządzanie
codziennym kalendarzem dla osób, których plan opiera się głównie o zajęcia
szkolne czy uczelniane. Zamiast wypełniać każdy dzień, w każdym tygodniu osobno,
użytkownik będzie musiał uzupełnić tylko szablon tygodnia, który zostanie
powielony i zaaplikowany do każdego tygodnia semestru/roku.

By nie ograniczać się do jednego, stałego szablonu, użytkownik będzie mógł
dodawać tak zwane modyfikatory, które działają tylko przez ściśle określony
czas(np. raz na miesiąc), i zmieniają główny szablon. Pozwala to np. na dodanie
zastępstw, odwołanie określonych zajęć, zmianę podstawowych informacji czy też
znane z Politechniki Warszawskiej „poniedziałki w piątki”, czyli użycie planu w
danym dniu z innego dnia tygodnia.

Każdy wpis będzie zawierał podstawowe informacji o zajęciach, tj. godzinę
rozpoczęcia, zakończenia, dane prowadzącego, lokalizację, notatki itp. Będzie
też mógł być rozszerzony o pola zdefiniowane przez użytkownika. Pozwoli to na
zapewnienie pełnych informacji o każdych zajęciach, ale również umożliwi
przejrzyste ukazanie planu tygodniowego.

### Scenariusz użycia

Użytkownik rozpoczyna użycie programu od zdefiniowania szablonu. Polega to na
wprowadzeniu zajęć, które odbywają się cyklicznie. Przez zdefiniowanie zajęcia
rozumiemy proces, w którym użytkownik określa, w które dni i w jakich godzinach
odbywają się zajęcia oraz podaje podstawowe informacje na ich temat. Ze względu
na możliwość występowania licznych modyfikatorów, na tym etapie nie jest
przeprowadzana weryfikacja.

Gdy użytkownik zdefiniuje kompletny szablon(na cały tydzień), następnym etapem
jest generowanie właściwego kalendarza. Polega to na wygenerowaniu grafiku na
konkretny zakres dat(ustalony przez użytkownika), generując każdy dzień z
osobna. Na tym etapie następuje walidacja poprawności kalendarza, jednakże
dopuszcza się istnienie błędów, które nie powodują niespójności(np. zachodzenie
na siebie wpisów). Daje się użytkownikowi możliwość przejrzenia listy błędów i
decyzji, czy zaakceptować grafik w takiej postaci, w jakiej aplikacja była go
w stanie wygenerować.

Po wygenerowaniu właściwego kalendarza jest on niezmienny – nie ma możliwości
edycji konkretnych wpisów na gotowym grafiku. Gdy użytkownik chce dokonać
modyfikacji, musi edytować cały szablon i generować kalendarz jeszcze raz.
Przewiduje się jednakże możliwość takiego skonstruowania interfejsu użytkownika,
który pozwoli na skrócenie czasu potrzebnego na proste edycje. Nie przewiduje
się w podstawowej wersji możliwości optymalizacji procesu regeneracji
kalendarza.

Gdy wygenerowany kalendarz się zdezaktualizuje, użytkownik będzie mógł edytować
istniejący szablon i zmienić zakres dat, w którym jest ważny, lub wygenerować
nowy(z możliwością przyjęcia istniejącego kalendarza, jako szkicu) i przejść
przez cały proces od nowa.


## Dokumentacja

## Sposób użycia