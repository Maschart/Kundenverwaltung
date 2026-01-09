# Kundenverwaltung – C# / MVVM / Avalonia

## Projektübersicht
Dieses Projekt ist eine grafische Kundenverwaltungsanwendung, die im Rahmen eines Softwareprojekts entwickelt wurde.  
Die Anwendung ermöglicht das Anlegen, Bearbeiten, Löschen und Suchen von Kundendaten.  
Besonderer Fokus liegt auf sauberer Architektur, Datenintegrität und Benutzerfreundlichkeit.

---

## Ziel des Projekts
Ziel ist die Entwicklung einer übersichtlichen und wartbaren Desktop-Anwendung zur Verwaltung von Kundendaten.  
Dabei sollen moderne Softwarekonzepte wie das MVVM-Architekturmuster sowie eine relationale Datenbank eingesetzt werden.

---

## Funktionen
- Kunden anlegen
- Kunden bearbeiten
- Kunden löschen
- Kunden suchen / filtern
- Eingabevalidierung (Pflichtfelder, Formatprüfung)
- Duplikatprüfung (Name + Email + Telefon)
- Fehlerbehandlung ohne Abstürze

---

## Verwendete Technologien
- **Programmiersprache:** C#
- **Framework:** .NET 9.0
- **UI:** Avalonia UI
- **Architektur:** MVVM (Model-View-ViewModel)
- **Datenbank:** SQLite
- **ORM:** Entity Framework Core
- **MVVM-Hilfsmittel:** CommunityToolkit.Mvvm
- **Versionsverwaltung:** GitHub

---

## Projektstruktur
CustomerManager
├── CustomerManager.App
│ ├── Views
│ ├── ViewModels
│ ├── App.axaml
│ └── Program.cs
├── CustomerManager.Core
│ ├── Models
│ ├── Data
│ └── Services
└── README.md

---

## Architektur (MVVM)
- **Model:** Definiert die Datenstruktur (Customer)
- **View:** Enthält ausschließlich die Benutzeroberfläche (Avalonia XAML)
- **ViewModel:** Beinhaltet Logik, Validierung und Commands
- **Repository:** Kapselt den Datenbankzugriff

Diese Trennung sorgt für gute Wartbarkeit und Erweiterbarkeit.

---

## Datenbank
- SQLite-Datenbank
- Automatische Erstellung beim ersten Start
- Zusammengesetzter Unique-Index auf:
  - Name
  - Email
  - Telefon

Dadurch wird sichergestellt, dass identische Kundendatensätze nicht mehrfach gespeichert werden.

---

## Validierung & Qualitätssicherung
- Pflichtfelder: Name, Email, Telefon
- Formatprüfung für Email und Telefon
- Duplikatprüfung auf Anwendungsebene
- Zusätzliche Absicherung durch Datenbank-Constraint
- Fehlerbehandlung mittels try/catch
- Manuelle Funktionstests anhand definierter Testfälle

---

## Testfälle (Auszug)
- Kunde mit gültigen Daten anlegen
- Speichern mit leeren Pflichtfeldern verhindern
- Ungültige Email/Telefonnummer blockieren
- Duplikate verhindern
- Kunden bearbeiten und löschen

---

## Erweiterungsmöglichkeiten
- Benutzerverwaltung
- Export (CSV / PDF)
- Kalender- oder Terminverwaltung
- Sortier- und Filterfunktionen
- Mehrsprachigkeit

---

## Autor
Name: *[Martin Schwarz]*  


---

## Lizenz
Dieses Projekt dient ausschließlich zu Lern- und Ausbildungszwecken.

