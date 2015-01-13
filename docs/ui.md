# Kalendarz studencki - projekt UI

Ta część dokumentacji opisuje *view-model* i bezpośrednio powiązane z nim
części.

## Spis treści

- [Ogólny zarys interfejsu](#ogolny-zarys-interfejsu)
- [*Shell*](#shell)
- [Główne ekrany](#gowne-ekrany)
    - [Wyświetlanie planu zajęć](#wyswietlanie-planu-zajec)
    - [Wyświetlanie listy kalendarzy](#wyswietlanie-listy-kalendarzy)
- [Edycja](#edycja)
    - [Edycja kalendarza](#edycja-kalendarza)
    - [Edycja zajęć](#edycja-zajec)
    - [Lista modyfikatorów](#lista-modyfikatorow)
    - [Edycja modyfikatorów i przedziałów aktywności](#edycja-modyfikatorow-i-przedziaow-aktywnosci)
    - [EditableObject](#editableobject)

## Ogólny zarys interfejsu

Interfejs jest podzielony na kilka różnych poziomów:

 * *Shell* - główne okno wraz z belką tytułową i menu:
   ![shell window](images/shell.png "shell window")
 * *Main* - główne ekrany(np. lista kalendarzy):
   ![main](images/main.png "main")
 * *Popup* - okna, które są wyświetlane ponad głównym ekranem:
   ![popup](images/popup.png "popup")
 * *Dialog* - okna dialogowe, np. okna komunikatów czy błędów:
   ![dialog](images/dialog.png "dialog")

Każdy element wyświetlany na ekranie(w szczególności wymienione powyżej), który
odznacza się logiką w ramach tego projektu(czyli rzeczywiście dotyczy projektu a
nie jest np. kontrolką WPF), posiada swoją klasę *view-model*u.

Większość *view-model*i jest autonomiczna i jest co najwyżej wywoływana z
poziomu innego *view-model*u (np. w celu modyfikacji któregoś z obiektu-dzieci).
Wyjątkiem są *view-model*e obsługujące przedziały aktywności - są one jawnie
osadzane w *view-model*u odpowiadającym za edycję modyfikatorów.

## *Shell*

*Shell* reprezentuje główne okno aplikacji. Udostępnia on mechanizmy pozwalające
zmienić aktualnie wyświetlany główny ekran, wyświetlenie *popup*u o wskazanym
typie i wyświetlenie okna dialogowego o wskazanym modelu.

Reprezentowany w aplikacji jest przez interfejs `IShell`, który jest
implementowany w projekcie `StudentsCalendar.Desktop` w klasie `ShellViewModel`.

## Główne ekrany

W aplikacji istnieją trzy ekrany główne:

 1. `CurrentWeekViewModel` - wyświetla plan aktualnego tygodnia(podzielonego
    na poszczególne dni).
 2. `MonthViewModel` - wyświetla aktualny "miesiąc", tj. dwa tygodnie w przód i
    w tył. Plan jest wyświetlany całościowo dla całego tygodnia, bez podziału
    na poszczególne dni.
 3. `CalendarsViewModel` - wyświetla listę kalendarzy i pozwala nią zarządzać,
    jest to też miejsce, gdzie rozpoczyna się edycja szablonów.

### Wyświetlanie planu zajęć

Wyświetlenie planu polega na pobraniu aktualnego kalendarza(o ile to możliwe),
zaaranżowaniu układu planu i przekazanie odpowiednich danych do widoku.

`CurrentWeekViewModel` pobiera tylko jeden, aktualny, tydzień(o ile to możliwe).
Wymaga to tylko sprawdzenia, czy kalendarz dla danego tygodnia istnieje.
`MonthViewModel` - pobiera nie więcej niż dwa tygodnie wstecz i dwa w przód (o
ile to możliwe, jeśli nie ma wygenerowanych danych tygodni, to pobiera tylko
tyle, ile może).

Proces aranżowania wykonywany jest przez `ILayoutArranger`(`LayoutArranger`) i
polega na rozłożeniu zajęć w odpowiednie sloty(jedna godzina). Ze względu na
możliwość nakładania się zajęć, są one też dzielone na kolumny - zadania
nakładające się są rozkładane do różnych kolumn(sortując po godzinie
rozpoczęcia).

By wyświetlanie planu było bardziej przejrzyste, procedura aranżacji zakłada, że
ilość slotów danego dnia będzie równa w całym tygodniu. Dodatkowo produkuje
sloty dla co najmniej 8 godzin(od 8:00 do 16:00).

### Wyświetlanie listy kalendarzy

Ekran listy kalendarzy pozwala na zarządzanie dostępnymi kalendarzami(edycja,
usuwanie), tworzenie nowych i wybór aktywnego.

*View-model* pobiera listę kalendarzy z `CalendarsManager` i udostępnia
odpowiednie metody pozwalające na usunięcie danej pozycji, otworzenie okna
edycji, czy wybranie kalendarza jako aktualnego. Każda z tych rzeczy
wykonywana jest na obiekcie `CalendarsManager`. Dodatkowo przy zmianie aktywnego
kalendarza powiadamiany jest obiekt `CurrentCalendars` o tym fakcie.

Z tego miejsca jest też dostęp do pozostałych części aplikacji - edycji
kalendarzy.

## Edycja

Każdy ekran edycji pozwala na zmianę jednego, ściśle określonego obiektu. Ekrany
pozwalające na edycje mają nazwę(przeważnie) kończącą się na `EditViewModel`.
Pozwalają na cofnięcie zmian przez wykorzystanie `EditableObject`.

### Edycja kalendarza

Głównym ekranem pozwalającym na edycje kalendarza jest
`CalendarEntryEditViewModel`. Pozwala on na edycję podstawowych informacji o
szablonie oraz edycję siatki zajęć. Zajęcia są przypisywane do odpowiednich
slotów(reprezentujących godzinę) na siatce 24 godziny x 7 dni (pon - nd).
Zajęcia mogą się znajdować tylko w jednym slocie, który reprezentuje ich godzinę
rozpoczęcia. Jeśli więcej niż jedne zajęcia rozpoczynają się o tej samej
godzinie, to trafiają do tego samego slotu.

Sloty są generowane raz, przy utworzeniu *view-model*u. Zajęcia są przypisywane
do slotu przy każdej edycji (lub przy inicjalizacji). Pozwala to na uproszczenie
kodu związanego z zarządzaniem slotami, a nie generuje zauważalnego narzutu.

Z tego ekranu można dostać się do list modyfikatorów(dziennych, tygodniowych,
ogólnych) i do ekranu edycji zajęć.

### Edycja zajęć

Ekran edycji zajęć, reprezentowany przez `ClassesEditViewModel`, pozwala na
edycję podstawowych informacji o zajęciach oraz modyfikatorów przypisanych do
danych zajęć. Edycja zarówno danych jak i listy modyfikatorów zrealizowana jest
przez rozszerzenie klasy bazowej dla list.

### Lista modyfikatorów

Każda z list modyfikatorów spełnia bardzo podobną rolę, dlatego są one
implementowane na bazie klasy `ModifiersEditViewModelBase`, która wydziela
główną logikę.

*View-model* udostępnia widokowi listę *wyrenderowanych* modyfikatorów(wraz z
opisem). Proces renderowania polega na konwersji obiektu modyfikatora oraz
odpowiadającego mu przedziału aktywności na tekst, który potem może być
wyświetlony użytkownikowi. Wykorzystywany jest do tego `DefaultModifierRenderer`
oraz `DefaultActivitySpanRenderer`. Obie klasy wykorzystują zbiór
predefiniowanych wiadomości dla każdego z domyślnych modyfikatorów/przedziałów
aktywności.

Lista modyfikatorów daje możliwość dodania nowego modyfikatora i edycji
istniejącego. Lista dostępnych modyfikatorów uzyskiwana jest z wykorzystaniem
usługi `CoreDataProvider`, która skanuje główną *assembly* w poszukiwaniu
odpowiednich klas a następnie udostępnia mechanizm do tworzenia nowych instancji
tych obiektów.

### Edycja modyfikatorów i przedziałów aktywności

Każdy modyfikator ma odpowiadający sobie edycyjny *view-model*, który dziedziczy
z bazowej klasy `BaseModifierViewModel`, która opakowuje mechanikę związaną z
zapisywaniem i odwoływaniem zmian. Każdy *view-model* dziedziczący z tej klasy
może odpowiednio modyfikować proces zapisu/odwołania zmian(np. *view-model*
modyfikatora danych o zajęciach pozwala na wybranie które pola są używane).
Klasa bazowa jest też *popup*em, który jest autonomiczny względem ekranu listy
modyfikatorów.

Analogicznie do edycji modyfikatorów zrealizowana jest edycja przedziałów
aktywności - każdy przedział ma odpowiadający mu edycyjny *view-model* który
odpowiada za zapisanie/odwołanie danych. Podobnie jak lista modyfikatorów,
pobiera dane o istniejących przedziałach z `CoreDataProvider`. W odróżnieniu od
ekranu edycji modyfikatorów, nie są one autonomiczne, lecz są wyświetlane
wewnątrz *view-model*u modyfikatora.

Ekran edycji modyfikatorów wykorzystuje do tego celu `ActivitySpanEditViewModel`
(i odpowiadającą mu kontrolkę), która pozwala na wybór konretnego przedziału
aktywności i zmianę jego właściwości.

Ze względu na dynamiczne tworzenie w/w ekranów, aplikacja wykorzystuje do tego
kontener IoC i to, że każdy taki *view-model* dziedziczy ze znanej(generycznej)
klasy bazowej. Do wyświetlenia ekranu edycji modyfikatorów wykorzystywane są
mechanizmy *shell*a, który odpowiada za wybranie odpowiedniej implementacji i
instancjacje obiektu. Ze względu na to, że ekran edycji przedziałów aktywności
jest osadzony wewnątrz innego ekranu i nie można wykorzystać mechanizów
*shell*a, aplikacja wykorzystuje `ActivitySpanEditor`, który realizuje
analogiczną funkcjonalność.

### EditableObject

Klasa ta pozwala na łatwe odwołanie zmian w obiekcie. W trakcie tworzenia
instancji `EditableObject`, wykonuje ona głęboką kopię obiektu, serializując go
do formatu BSON i zapisując w tablicy bajtów(`byte[]`). Gdy użytkownik chce
anulować zmiany, odczytuje obiekt z tejże tablicy i zapisuje go do istniejącego
obiektu, z którego zostały odczytane zmiany.