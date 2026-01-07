Kundenverwaltung – C# / MVVM / Avalonia
Projektübersicht
Dieses Projekt ist eine grafische Kundenverwaltungsanwendung, die im Rahmen eines Softwareprojekts entwickelt wurde.
Die Anwendung ermöglicht das Anlegen, Bearbeiten, Löschen und Suchen von Kundendaten.
Besonderer Fokus liegt auf sauberer Architektur, Datenintegrität und Benutzerfreundlichkeit.
________________________________________
Ziel des Projekts
Ziel ist die Entwicklung einer übersichtlichen und wartbaren Desktop-Anwendung zur Verwaltung von Kundendaten.
Dabei sollen moderne Softwarekonzepte wie das MVVM-Architekturmuster sowie eine relationale Datenbank eingesetzt werden.
________________________________________
Funktionen
•	Kunden anlegen
•	Kunden bearbeiten
•	Kunden löschen
•	Kunden suchen / filtern
•	Eingabevalidierung (Pflichtfelder, Formatprüfung)
•	Duplikatprüfung (Name + Email + Telefon)
•	Fehlerbehandlung ohne Abstürze
________________________________________
Verwendete Technologien
•	Programmiersprache: C#
•	Framework: .NET 9.0
•	UI: Avalonia UI
•	Architektur: MVVM (Model-View-ViewModel)
•	Datenbank: SQLite
•	ORM: Entity Framework Core
•	MVVM-Hilfsmittel: CommunityToolkit.Mvvm
•	Versionsverwaltung: GitHub
________________________________________
Projektstruktur
CustomerManager ├── CustomerManager.App │ ├── Views │ ├── ViewModels │ ├── App.axaml │ └── Program.cs ├── CustomerManager.Core │ ├── Models │ ├── Data │ └── Services └── README.md
________________________________________
Architektur (MVVM)
•	Model: Definiert die Datenstruktur (Customer)
•	View: Enthält ausschließlich die Benutzeroberfläche (Avalonia XAML)
•	ViewModel: Beinhaltet Logik, Validierung und Commands
•	Repository: Kapselt den Datenbankzugriff
Diese Trennung sorgt für gute Wartbarkeit und Erweiterbarkeit.
________________________________________
Datenbank
•	SQLite-Datenbank
•	Automatische Erstellung beim ersten Start
•	Zusammengesetzter Unique-Index auf:
o	Name
o	Email
o	Telefon
Dadurch wird sichergestellt, dass identische Kundendatensätze nicht mehrfach gespeichert werden.
________________________________________
Validierung & Qualitätssicherung
•	Pflichtfelder: Name, Email, Telefon
•	Formatprüfung für Email und Telefon
•	Duplikatprüfung auf Anwendungsebene
•	Zusätzliche Absicherung durch Datenbank-Constraint
•	Fehlerbehandlung mittels try/catch
•	Manuelle Funktionstests anhand definierter Testfälle
________________________________________
Testfälle (Auszug)
•	Kunde mit gültigen Daten anlegen
•	Speichern mit leeren Pflichtfeldern verhindern
•	Ungültige Email/Telefonnummer blockieren
•	Duplikate verhindern
•	Kunden bearbeiten und löschen
________________________________________
Erweiterungsmöglichkeiten
•	Benutzerverwaltung
•	Export (CSV / PDF)
•	Kalender- oder Terminverwaltung
•	Sortier- und Filterfunktionen
•	Mehrsprachigkeit
________________________________________
Autor
Name: [Martin Schwarz]
________________________________________
Lizenz
Dieses Projekt dient ausschließlich zu Lern- und Ausbildungszwecken.

