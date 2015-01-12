# Kalendarz studencki - projekt główny

Ta część dokumentacji opisuje projekt-serce aplikacji - opis, mechanizm
generowania oraz sposób przechowywania kalendarzy. 

## Spis treści

- [Dane](#dane)
    - [Szablon zajęć](#szablon-zajec)
    - [Szablon dzienny](#szablon-dzienny)
    - [Szablon tygodniowy](#szablon-tygodniowy)
    - [Szablon kalendarza](#szablon-kalendarza)
    - [Dane pośrednie](#dane-posrednie)
    - [Kalendarz – dane finalne](#kalendarz-dane-finalne)
- [Przedział aktywności](#przedzia-aktywnosci)
    - [Ogólny opis](#ogolny-opis)
    - [Specyfika działania](#specyfika-dziaania)
    - [Istniejące przedziały aktywności](#istniejace-przedziay-aktywnosci)
- [Modyfikatory](#modyfikatory)
    - [Opis ogólny](#opis-ogolny)
    - [Specyfika działania](#specyfika-dziaania_1)
    - [Istniejące modyfikatory](#istniejace-modyfikatory)
    - [Dodanie przerw w blokach wielogodzinnych](#dodanie-przerw-w-blokach-wielogodzinnych)
- [Proces generowania kalendarza](#proces-generowania-kalendarza)
    - [Inicjalizacja](#inicjalizacja)
    - [Generowanie obiektu kalendarza](#generowanie-obiektu-kalendarza)
    - [Poprawianie obiektów i finalizacja](#poprawianie-obiektow-i-finalizacja)
- [Przechowywanie kalendarzy](#przechowywanie-kalendarzy)

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

### Specyfika działania

Przedział aktywności, czy raczej generator przedziału, może pracować na dwa
sposoby - absolutny i relatywny. Przez sposób "absolutny" rozumiemy konkretny
zakres dat(np. 1 listopada 2014), w których przedział jest aktywny. Sposób
relatywny operuje na odległości między "datą bazową" a aktualną datą i sprawdza
ilość wystapień pewnej "jednostki czasu"(w rozumieniu NodaTime - np. dnia,
tygodnia, miesiąca).

Przez "datę bazową" rozumiemy datę pierwszego wystąpienia danego obiektu.
Np. dla tygodnia rozumiemy datę pierwszego tygodnia aktywności kalendarza
(poniedziałek). Dla poszczególnych dni, np. dla środy, datę wystąpienia
pierwszej środy w pierwszym tygodniu.
"Data bazowa" może zostać nadpisana przez użytkownika, jeśli dana klasa na to
pozwala.

Generator musi implementować interfejs `IDailyActivitySpan` lub
`IWeeklyActivitySpan` oraz metodę `IsActive` z danego interfejsu. Metoda ta
określa, czy data przekazana jako parametr jest aktywna(względem daty bazowej,
również przekazywanej jako parametr).

### Istniejące przedziały aktywności

Przedziały oznaczone _*_ są również modyfikatorami tygodniowymi.

 * Zawsze aktywny,
 * Zawsze nieaktywny,
 * Aktywny w określone dni,
 * Aktywny w określone tygodnie*,
 * Aktywny zawsze oprócz określonych dni,
 * Aktywny w określone tygodnie*,
 * Aktywny co X tygodni*,
 * Aktywny co X miesięcy*,
 * Aktywny w określonym przedziale.

## Modyfikatory

### Opis ogólny

*Modyfikator* ma za zadanie zmianę ogólnych reguł generowania kalendarza tak, by
nie ograniczać użytkownika tylko do najprostszych zajęć. Modyfikatory pracują
zawsze po wygenerowaniu danego etapu, lecz mają dostęp do infrastruktury
generującej kalendarz. Kolejność aplikowania modyfikatorów jest dowolna
(modyfikatory nie mogą polegać jeden na drugim).

Wyróżnia się następujące typy modyfikatorów:

 * Zajęciowy,
 * Dzienny,
 * Tygodniowy,
 * Ogólny.

Każdy modyfikator działa przez określony czas - przedział aktywności - który
definiuje, czy należy go uruchomić. Modyfikator nie jest odpowiedzialny za
egzekwowanie, kiedy jest aktywny. Obiekt, który aplikuje go do danych jest
obowiązany sprawdzić, czy dany modyfikator powinien zostać uruchomiony.

### Specyfika działania

Modyfikator to klasa, która implementuje jeden z interfejsów modyfikatorów:

 * `IClassesModifier`,
 * `IDayModifier`,
 * `IWeekModifier`,
 * `ICalendarModifier`.

Każdy modyfikator zawiera właściwość określającą kiedy jest aktywny(wyjątek:
modyfikator ogólny), która może być zmieniona przez użytkownika, oraz metodę
`Apply`, która aplikuje modyfikator na wskazany w parametrze obiekt.

Modyfikator może operować na istniejących obiektach pośrednich, ale również może
je podmieniać. Metoda `Apply` musi zwrócić obiekt, który zostanie finalnie
dodany do kalendarza. Wyjątkiem jest modyfikator zajęć, który może zwrócić
`null`, jeśli zajęcia zostały odwołane.

Metoda `Apply` ma dostęp do `GenerationContext`(opisany dalej), który
reprezentuje kontekst pracy generatora.

### Istniejące modyfikatory

Zajęciowe:

 * Odwołaj zajęcia,
 * Zmodyfikuj dane podstawowe zajęć,
 * Zmodyfikuj dane lokalizacji,
 * Zmodyfikuj dane prowadzącego,
 * Dodaj test/sprawdzian/kolokwium.

Dzienne:

 * Odwołaj zajęcia w całym dniu,
 * Zmień plan na inny dzień tygodnia.

Tygodniowe:

 * Odwołaj zajęcia w całym tygodniu.

Ogólny:

 * Odwołanie zajęc w podanym zakresie dat,
 * Dodanie przerw w blokach wielogodzinnych.

Wyżej wymienione modyfikatory nie są specjalnie skomplikowane - modyfikują
odpowiednie pola obiektów pośrednich. Wyjątkiem jest ostatni z wymienionych.

### Dodanie przerw w blokach wielogodzinnych

Modyfikator ten operuje na całym kalendarzu i modyfikuje każdy blok zajęciowy,
który wpada w kryteria. Modyfikator jest opisywany następującymi właściwościami:

 * `BreakDuration` - określa czas trwania przerwy, którą należy dodać,
 * `ClassesDuration` - określa, ile czasu trwa jedna godzina zajęć(bez przerwy),
 * `AddAtBeginning` - określa, czy przerwa powinna zostać przed zajęciami
   (domyślnie dodawana jest po).

Modyfikator jest silnie dostosowany do realiów panujących na Politechnice
Warszawskiej(ze względu na niską wygodę używania bardziej elastycznych
algorytmów) oraz zakłada następujące rzeczy:

 * Przerwa jest wliczona w zajęcia w kalendarzu przed zaaplikowaniem
   modyfikatora,
 * Uwzględniane są tylko zajęcia będące wielokrotnością `BreakDuration` +
   `ClassesDuration`.

Proces dodania polega na wyszukaniu wszystkich bloków zajęć, które spełniają w/w
warunki, podzieleniu zajęć na odpowiednią ilość pojedynczych zajęć, dodanie
przerw i podmienienie obiektów w konkretnych dniach.

Przykładowy scenariusz:

W opisie zakładamy, że `BreakDuration` = 15, `ClassesDuration` = 45 i
`AddAtBeginning` = `true`.

Zajęcia reprezentowane są jako pełne godziny, które mogą być połączone w bloki
(np. 2 zajęcia ciągiem). Zajęcia przeważnie zaczynają się 15 minut po pełnej
godzinie, ale to 15 minut jest traktowane przez ten modyfikator jako przerwa
którą musi dodać.

I tak np. dla zajęć, które w rzeczywistości trwają od godz. 9:15 do 10:00, i są
w aplikacji reprezentowane jako zajęcia od 9:00 do 10:00, modyfikator obetnie 15
minut na początku i wynikiem będą zajęcia w godzinach zgodnych z rzeczywistymi.

Dla bloku dwugodzinnego, trwającego od 9:15 do 11:00 z 15 minutową przerwą od
10:00 do 10:15, reprezentowanego jako zajęcia od 9:00 do 11:00, modyfikator
wyprodukuje dwa zajęcia - 9:15 - 10:00 oraz 10:15 - 11:00.

Na PW sztandarowym wyjątkiem od reguły są zajęcia WF-u, trwające 90 minut bez
przerwy. Modyfikator nie zmieni takich zajęć, ponieważ bierze pod uwagę tylko
te, które trwają co najmniej 60 minut(`BreakDuration` + `ClassesDuration`) i są
wielokrotnością tej liczby(60, 120, 180, ...). 

## Proces generowania kalendarza

Proces ten składa się z kilku punktów:

 * Inicjalizacji(stworzeniu kontekstu),
 * Wygenerowaniu obiektu kalendarza,
 * Poprawieniu obiektów i finalizacja.

Procesem tym steruje klasa `GenerationEngine`.

### Inicjalizacja

W punkcie tym tworzony jest kontekst generowania, reprezentowany przez obiekt
`GenerationContext`, na który składają się następujące właściwości:

 * Generator zajęć,
 * Generator dni,
 * Generator tygodni,
 * Generator pełnego kalendarza,
 * Szablon kalendarza,
 * Zakres dat generowanego kalendarza.

Obiekt ten daje dostęp poszczególnym sub-generatorom dostęp do innych etapów
procesu, dzięki czemu nie muszą polegać tylko na istniejących danych (i mogą być
używane np. w modyfikatorach).

Zakres dat, który jest zawarty w kontekście reprezentuje zakres aktywności
kalendarza zaokrąglony do pełnych tygodni, tj. jeśli kalendarz zaczyna się we
środę i kończy w piątek, to zakres dat będzie od poniedziałku, bezpośrednio
poprzedzającego tą środę, do niedzieli bezpośrednio po wskazanym piątku.

### Generowanie obiektu kalendarza

Proces ten polega na wygenerowaniu obiektów od najbardziej ogólnego, do
najbardziej szczegółowego, tj. kalendarz -> tygodnie -> dni w tygodniu ->
zajęcia w dniu. Wszystkie etapy przebiegają podobnie, tj.

 1. Stwórz obiekt pośredni i skopiuj do niego podstawowe dane,
 2. Oblicz odpowiednią datę bazową dla obiektów-dzieci,
 3. Wygeneruj obiekty-dzieci(np. zajęcia dla dnia; nie dotyczy generatora
    zajęć),
 4. Zaaplikuj modyfikatory do wygenerowanego obiektu,
 5. Zwróć wygenerowany obiekt.

Za proces ten odpowiadają następujące klasy:

 * `DefaultClassesGenerator`,
 * `DefaultDayGenerator`,
 * `DefaultWeekGenerator`,
 * `DefaultCalendarGenerator`,

które implementują odpowiadające im interfejsy.

Wynikiem tego etapu będzie obiekt kalendarza (`IntermediateCalendar`) aktywny
przez cały zakres dat z kontekstu. 

### Poprawianie obiektów i finalizacja

Proces ten jest stosunkowo prosty i polega na posortowaniu zajęć w
poszczególnych po godzinie rozpoczęcia oraz usunięciu nadmiarowych zajęć.

Finalizacja polega na zmapowaniu obiektów pośrednich na finalne.

Wynikiem tego etapu będzie finalny kalendarz - reprezentowany przez
`FinalCalendar`.

## Przechowywanie kalendarzy

Aplikacja do przechowywania kalendarzy używa formatu JSON - zapisuje do pliku
zserializowany obiekt `CalendarTemplate`. Oprócz samych kalendarzy aplikacja
przechowuje również **listę** istniejących kalendarzy wraz z dodawkowymi danymi
(m.in. to, który kalendarz jest aktywny).

Kalendarz jest identyfikowany przez unikalny identyfikator nadawany przez
aplikację (będący *GUID*-em).

Do zarządzania listą kalendarzy aplikacja wykorzystuje klasę `CalendarsManager`,
która odpowiada za zarządzanie listą kalendarzy i przekazywanie kalendarzy dalej
do aplikacji, w celu jej zapisania.

Klasa ta nie serializuje kalendarzy ani nie zapisuje ich na dysk. Używa do tego
celu klasy `ContentProvider` i abstrakcji na system plików - `IStorage`. To te
klasy serializują obiekty i zapisują je na dysk.

Ta część aplikacji zarządza również aktualnie wybranym kalendarzem. Odpowiada za
to klasa `CurrentCalendar`, która nadzoruje aktualny kalendarz i odpowiada za
wygenerowanie finalnego kalendarza, gdy zmieni się aktywny.

W/w klasy są przystosowane do wykorzystania wzorca *event aggregator*. Ze
względu na to, że jest to jedyne miejsce, gdzie ten wzorzec rzeczywiście by się
sprawdził, nie wykorzystują tego i polegają na użytkowniku, który powinien
wywołać odpowiednie metody w reakcji na określone zdarzenia.