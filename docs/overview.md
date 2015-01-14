Title:   Kalendarz studencki - dokumentacja
Authors: Jakub Fijałkowski

# Kalendarz Studencki

Dokumentacja projektu "Kalendarz Studencki" - opis ogólny

## Spis treści

[TOC]

## Opis projektu

### Cel

"Kalendarz studencki" jest to program mający za zadanie uprościć zarządzanie codziennym kalendarzem dla osób, których plan opiera się głównie o zajęcia szkolne czy uczelniane. Zamiast wypełniać każdy dzień, w każdym tygodniu osobno, użytkownik będzie musiał uzupełnić tylko szablon tygodnia, który zostanie powielony i zaaplikowany do każdego tygodnia semestru/roku.

By nie ograniczać się do jednego, stałego szablonu, użytkownik będzie mógł dodawać tak zwane modyfikatory, które działają tylko przez ściśle określony czas(np. raz na miesiąc), i zmieniają główny szablon. Pozwala to np. na dodanie zastępstw, odwołanie określonych zajęć, zmianę podstawowych informacji czy też znane z Politechniki Warszawskiej "poniedziałki w piątki", czyli użycie planu w danym dniu z innego dnia tygodnia.

### Ogólny scenariusz użycia

Użytkownik rozpoczyna użycie programu od zdefiniowania szablonu. Polega to na wprowadzeniu zajęć, które odbywają się cyklicznie. Przez zdefiniowanie zajęcia rozumiemy proces, w którym użytkownik określa, w które dni i w jakich godzinach odbywają się zajęcia oraz podaje podstawowe informacje na ich temat.

Gdy użytkownik zdefiniuje kompletny szablon(na cały tydzień), następnym etapem jest generowanie właściwego kalendarza. Polega to na wygenerowaniu grafiku na konkretny zakres dat(ustalony przez użytkownika), generując każdy dzień z osobna. Po wygenerowaniu właściwego kalendarza jest on niezmienny – nie ma możliwości edycji konkretnych wpisów na gotowym grafiku. Gdy użytkownik chce dokonać modyfikacji, musi edytować szablon i generować kalendarz jeszcze raz.

Gdy wygenerowany kalendarz się zdezaktualizuje, użytkownik będzie mógł edytować istniejący szablon i zmienić zakres dat, w którym jest ważny, lub zdefiniować nowy kalendarz.

## Aplikacja

Aplikacja została oparta na wzorcu *MVVM* oraz technologii *WPF*. Zaprojektowana jest zgodnie z wytycznymi *inversion of control*(dokładniej: *dependency injection*) i dość silnie wykorzystuje możliwości użytego kontenera IoC.

Projekt jest podzielony na trzy *assembly*:

 * *Core* - główna część odpowiedzialna za zarządzanie właściwym szablonem, szerzej opisana w pliku `core.md`. Odpowiada *model*owi.
 * *UI* - część związana z zarządzaniem interfejsem użytkownika i powiązaniu UI z częścią główną. Pełna dokumentacja znajduje się w pliku `ui.md`. Odpowiada *view-model*owi.
 * *Desktop* - widoki i *bootstrapping* aplikacji(m.in. stworzenie kontenera DI, inicjalizacja zewnętrznych bibliotek) oraz implementacje interfejsów zależnych od platformy uruchomieniowej. Nie posiada szerszego opisu ze względu na brak logiki biznesowej w tej części projektu.

Główne części są kompilowane jako *Portable Class Library* ze względu na to, że projekt w założeniu miał być wieloplatformowy(z czego zrezygnowałem).

### Użyte biblioteki

 * [NodaTime](http://nodatime.org/) - alternatywne API do dat, zamiennik dla `System.DateTime`, który jawnie rozgranicza różne rodzaje dat i pozwala na łatwiejsze zarządzanie nimi.
 * [AutoFac](http://autofac.org/) - kontener IoC.
 * [JSON.Net](http://james.newtonking.com/json) - biblioteka do obsługi serializacji JSON - dużo bardziej elastyczna od wbudowanych mechanizmów .NET.
 * [Caliburn.Micro](http://caliburnmicro.com/) - biblioteka wspomagająca pisanie aplikacji z wykorzystaniem wzorca MVVM.
 * [MahApps.Metro](http://mahapps.com/) - styl aplikacji a'la Modern(Metro).
 * [Extended WPF Toolkit](http://wpftoolkit.codeplex.com/) - dodatkowe kontrolki WPF.

## Dokumentacja

Dokumentacja podzielona jest na kilka dokumentów:

 * *Overview*([MD](overview.md)/[HTML](overview.html)) - ogólny opis aplikacji, ten dokument.
 * *Core*([MD](core.md)/[HTML](core.html)) - opis projektu głównego(*model*u).
 * *UI*([MD](ui.md)/[HTML](ui.html)) - opis projektu UI(*view-model*u)
 * *Usage*([MD](usage.md)/[HTML](usage.html)) - opis sposobu użycia aplikacji wraz z przykładowymi grafikami.

W/w pliki nie zawierają dokładnych opisów kodu - kod jest stosownie skomentowany i nie ma potrzeby powielać tych informacji.