# Kalendarz studencki - projekt główny

## Spis treści

<!-- MarkdownTOC -->

- [Dane](#dane)
    - [Szablon zajęć](#szablon-zajęć)
    - [Szablon dzienny](#szablon-dzienny)
    - [Szablon tygodniowy](#szablon-tygodniowy)
    - [Szablon kalendarza](#szablon-kalendarza)
    - [Dane pośrednie](#dane-pośrednie)
    - [Kalendarz – dane finalne](#kalendarz-–-dane-finalne)
- [Przedział aktywności](#przedział-aktywności)
    - [Ogólny opis](#ogólny-opis)
    - [Istniejące przedziały aktywności](#istniejące-przedziały-aktywności)

<!-- /MarkdownTOC -->

## Dane

### Szablon zajęć

Przez *zajęcia* rozumiemy obiekt, który definiuje czynność mającą się odbyć w
danym dniu o konkretnych godzinach. Reprezentowany jest przez następujące
elementy:

 * Krótką oraz pełną nazwę(np. nazwę przedmiotu),
 * Godzinę rozpoczęcia oraz zakończenia,
 * Lokalizację:
   - Nazwę,
   - Adres budynku,
   - Sala zajęciowa,
 * Prowadzącą/prowadzącego:
   - Imię i nazwisko,
   - Dane kontaktowe,
 * Notatki,
 * Modyfikatory(zajęciowe),

Zakłada się, że *zajęcia* trwają nieprzerwanie od godziny rozpoczęcia do godziny
zakończenia. Nie przewiduje się możliwości dzielenia pojedynczych zajęć na kilka
zakresów godzinowych(wyjątek - modyfikatory).

### Szablon dzienny

*Szablon dzienny* to zbiór wpisów, które pozwalają na utworzenie na ich
podstawie właściwego kalendarza na konkretny dzień tygodnia. Każdy taki szablon
zawiera listę zajęć, które występują danego dnia w ramach całego okresu
aktywności kalendarza.

*Szablon dzienny* składa się z:
 * Dnia tygodnia(predefiniowany przez szablon tygodniowy),
 * Listy zajęć,
 * Przedziału aktywności(dzienny),
 * Notatki,
 * Modyfikatorów(dzienne),

### Szablon tygodniowy

*Szablon tygodniowy* to kompletna lista szablonów dziennych dla każdego dnia
tygodnia, na podstawie której można wygenerować właściwy kalendarz na cały
tydzień. Składa się z:
 * 7 szablonów dziennych, odpowiadających dniom tygodnia,
 * Modyfikatorów(tygodniowych).

### Szablon kalendarza

Przez *szablon kalendarza*, zwany dalej szablonem, rozumiemy właściwy opis
kalendarza. Zawiera on:
 * Szablon tygodniowy, będący bazą kalendarza,
 * Początek aktywności kalendarza,
 * Koniec aktywności kalendarza,
 * Modyfikatorów(ogólnych).

### Dane pośrednie

Każdemu z powyższych typów danych odpowiada typ *pośredni*, który zawiera
dokładnie te same dane(za wyjątkiem modyfikatorów) oraz jest przyporządkowany do
konkretnej daty/zakresu dat. Używane są w trakcie generowania kalendarza, by
pozwolić modyfikatorom na edycje danych już wygenerowanych, ale jeszcze
niezatwierdzonych.

### Kalendarz – dane finalne

Finalna wersja wygenerowanych danych, uzyskana na koniec procesu generowania
kalendarza z danych pośrednich. Posiada dokładnie taką samą strukturę jak dane
pośrednie, jednak w odróżnieniu od nich jest niemodyfikowalny.

Kalendarz składa się z listy tygodni, w którym jest aktywny, podzielonych na dni
zawierające listę zajęć.


## Przedział aktywności

### Ogólny opis

*Przedział aktywności* to zbiór dni(konkretnych dat), w którym dany obiekt
(zajęcie, szablon lub modyfikator) będzie aktywny. Właściwy wynik uzyskuje się
na podstawie bardziej ogólnych przedziałów aktywności, stworzonych za pomocą
odpowiednich **generatorów** i operacji między nimi.

Przez *generator* przedziału aktywności rozumiemy obiekt, który określa czy
konkretna data/tydzień jest aktywna, czy też nie. Nie generuje on żadnego
zakresu w ogólnym rozumieniu tego słowa, lecz po zaaplikowaniu generatorów do
ogólnego przedziału otrzymamy wynik taki sam, jak przez rzeczywiste
wygenerowanie przedziałów.

Każdy generator przedziału aktywności ma rozdzielczość jednego dnia, tj. wynik
musi wskazywać na pełne dni, nie może zawierać ich fragmentów.

Wyróżnia się dwa typu generatorów – dzienny i tygodniowy. Generator tygodniowy
jest generatorem dziennym, lecz generator dzienny nie jest generatorem
tygodniowym. Generator tygodniowy generuje pełne tygodnie, generator dzienny
może generować pojedyncze dni. Dopuszcza się możliwość rozszerzenia generatora
dziennego na tygodniowy przez uwzględnienie tylko tych tygodni, w których każdy
dzień został wygenerowany.

### Istniejące przedziały aktywności

Przedziały oznaczone __*__ są również modtfikatorami tygodniowymi.

 * Zawsze aktywny,
 * Zawsze nieaktywny,
 * Aktywny w określone dni,
 * Aktywny w określone tygodnie*,
 * Aktywny zawsze oprócz określonych dni,
 * Aktywny w określone tygodnie*,
 * Aktywny co X tygodni*,
 * Aktywny co X miesięcy*,
 * Aktywny w określonym przedziale.
