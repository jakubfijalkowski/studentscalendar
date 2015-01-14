Title:   Kalendarz studencki - sposób użycia
Authors: Jakub Fijałkowski

# Kalendarz studencki - sposób użycia

Ten plik pozwala na zapoznanie się z przykładowym scenariuszem użycia, który prowadzi użytkownika od pierwszego uruchomienia aż do stworzenia przykładowego kalendarza.

### Pierwsze uruchomienie

Tuż po pierwszym uruchomieniu, użytkownikowi ukaże się wiadomość o braku aktywnego kalendarza.
![1](images/usage/1.png "1")

Po kliknięciu "OK", użytkownikowi zostanie wyświetlony ekran listy kalendarzy, na którym może dodać nowy kalendarz używając przycisku oznaczonego `+`:
![2](images/usage/2.png "2")

Użytkownik może w dowolnym momencie przejść do tego ekranu używając przycisku "lista kalendarzy" na pasku tytułowym:
![3](images/usage/3.png "3")

### Tworzenie i edycja kalendarza

Po wciśnięciu przycisku `+` użytkownik zostaje przeniesiony do ekranu edycji kalendarza:
![4](images/usage/4.png "4")

Może tutaj uzupełnić podstawowe informacje na temat kalendarza(takie jak nazwa czy czas aktywności), dostać się do listy modyfikatorów poszczególnych dni, tygodnia oraz ogólnych. Może tutaj również edytować siatkę godzin kalendarza, czyli główną część aplikacji.

Dodawanie zajęć odbywa się przez wybranie odpowiedniego slotu, w którym początkowo mają się znaleźć zajęcia, i kliknięcie na niego. Wybierzmy np. godzinę 8:00 we wtorek:
![5](images/usage/5.png "5")

Po wybraniu odpowiedniego slotu ukaże się ekran edycji zajęć. Z jego poziomu można edytować podstawowe informacje o zajęciach oraz zmieniać modyfikatory przypisane do danych zajęć(o czym za chwilę):
![6](images/usage/6.png "6")

Po zapisaniu powyższych zajęć slot na ekranie edycji kalendarza będzie zajęty.
![7](images/usage/7.png "7")

Jak widać, mimo iż dodawaliśmy zajęcia do slotu o godzinie 8:00, to przez zmianę godziny rozpoczęcia na 7:30 pojawiły się one o godzine wcześniej. Dzieje się tak ponieważ aplikacja na szablonie siatki godzin wyświetla zajęcia tylko w slocie będącym godziną rozpoczęcia(obciętą do pełnych godzin, w tym wypadku do 7:00).

Dodajmy kolejne zajęcia, tym razem z modyfikatorem. Niech będą one w czwartek od 10:00 do 11:00. Znak `+` w prawym górnym rogu ekranu edycji zajęć pozwala na dodanie modyfikatorów - elementów, które zmieniają dane elementu tylko w określone dni. Po wciśnięciu go ukaże nam się lista dostępnych modyfikatorów:
![8](images/usage/8.png "8")

Analogicznie dodawane są modyfikatory do dni, tygodni i kalendarza - wyjątkiem jest brak możliwości edycji innych danych(wyświetlana jest tylko lista modyfikatorów).

Wracając do naszych zajęć - dodajmy modyfikator dodający test do zajęć:
![9](images/usage/9.png "9")

Każdy modyfikator posiada własny ekran, na którym można edytować informacje o nim. Tutaj dla przykładu użytkownik może nadać tytuł testowi, dodatkowe notatki i priorytet.
Informacje o tekście dodawane są do notatek. Priorytet określa, w którym miejscu się one znajdą:

 * Niski - na końcu notatek,
 * Średni - na początku notatek,
 * Wysoki - na początku notatek, zapisany WIELKIMI LITERAMI.

Każdy ekran edycji modyfikatora pozwala na zmianę przedziału aktywności, określającego kiedy modyfikator ma się uruchamiać(nie dotyczy modyfikatorów kalendarza, które są zawsze aktywne):
![10](images/usage/10.png "10")

Znajduje się tam lista rozwija, która pozwala na wybranie pasującego przedziału:
![11](images/usage/11.png "11")

Po wybraniu żądanego przedziału można edytować jego właściwości:
![12](images/usage/12.png "12")

Po zapisaniu modyfikatora(tutaj: aktywnego tylko 15 stycznia 2015) zostanie on wyświetlony na liście, gdzie można go edytować(ikona ołówka) lub usunąć(ikona kosza):
![13](images/usage/13.png "13")

Po zapisaniu powyższych zajęć, zostaną one dodane do siatki. Zajęcia można edytować klikając na nie lewym przyciskiem myszy(procedura analogiczna do powyższej). Dodatkowo, naciskając prawym przyciskiem myszy na zapełniony slot, można dodać kolejne zajęcia w tym samym slocie, usunąć go lub jawnie wybrać edycję:
![14](images/usage/14.png "14")

W ramach tego dokumentu dodamy dodatkowe zajęcia w tym samym dniu i tych samych godzinach co *MDZ*, jednakże będą one odwołane w każdy dzień oprócz 22 stycznia 2015:
![15](images/usage/15.png "15")
![16](images/usage/16.png "16")
![17](images/usage/17.png "17")

Finalnie siatka przykładowego kalendarza będzie wyglądać tak:
![18](images/usage/18.png "18")

Po zapisaniu ukaże się on na liście kalendarzy, gdzie można go edytować(ikona ołówka), usunąć(ikona kosza) lub wskazać jako aktywny(ikona serca):
![19](images/usage/19.png "19")

Aplikacja pozwala na utrzymywanie wielu kalendarzy(nawet nakładających się), ale tylko jeden może być aktywny w danym momencie. Aplikacja nie pozwala też na usunięcie aktywnego kalendarza.
Na potrzeby tekstu utworzony kalendarz zostanie wybrany:
![20](images/usage/20.png "20")

### Wyświetlanie kalendarza

Aplikacja pozwala na dwa tryby wyświetlania kalendarza: widok tygodnia i widok miesiąca. Dostęp do nich jest z poziomu paska tytułowego i obecnych tam przycisków:
![26](images/usage/26.png "26")

Widok tygodnia wyświetla plan w aktualnym tygodniu z podziałem na dni. Aplikacja stara się umieścić jak najwięcej informacji na ekranie(m.in. dodaje notatki), ale stara się też pozostać przejrzystą i dlatego dostosowuje się do szerokości okna.

Używając wcześniej utworzonego kalendarza, tak wygląda plan na wtorek 13.01.2015:
![21](images/usage/21.png "21")

na czwartek 15.01.2015
![22](images/usage/22.png "22")

oraz na czwartek 22.01.2015:
![23](images/usage/23.png "23")

Widok miesiąca pokazuje aktualny tydzień oraz co najwyżej dwa tygodnie wstecz i wprzód. Nie ma tutaj podziału na dni, więc wszystkie zajęcia z całego tygodnia są wyświetlane na jednym ekranie. Pozwala to wyświetlić mniej informacji, jednak daje możliwość rozeznania się w planie na cały tydzień.

Oto plany na kolejne dwa tygodnie(2 i 3 tydzień stycznia) używając powyższego kalendarza:
![24](images/usage/24.png "24")

![25](images/usage/25.png "25")

### Dalsze użycie aplikacji

Przy następnych uruchomieniach aplikacja domyślnie wyświetla widok tygodnia. Kalendarz jest wygenerowany na cały okres zaznaczony w ustawieniach, więc po utworzeniu go nie ma potrzeby żadnych zmian. Gdy kalendarz się przedawni, aplikacja wyświetli stosowny komunikat. Można wtedy utworzyć nowy kalendarz(i go aktywować) lub zmienić daty rozpoczęcia/zakończenia i używać istniejącego kalendarza.