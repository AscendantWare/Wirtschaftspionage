# 🕵️ Wirtschaftsspionage

> *Ihre Anwendung weiß mehr, als sie zugibt.*

Wenn Sie sich schon immer gefragt haben, was Ihre Komponenten *wirklich* treiben – hier ist die Antwort!

## 📦 Installation

```bash
dotnet add package Wirtschaftsspionage
```

Oder über den NuGet Package Manager:
```
Install-Package Wirtschaftsspionage
```

## 🎯 Wofür braucht man das?

Stellen Sie sich vor, Sie könnten die verdächtig ruhige Aktivität Ihrer Anwendung von einer echten Abteilung für Geheimakten überwachen lassen. Diese Bibliothek bietet genau das – natürlich ohne Sicherheitsauswirkungen!

Perfect für:
- 😄 Humorvolle Logs in Ihren Anwendungen
- 🕵️ Spielerische Code-Reviews
- ☕ Meetings, bei denen man über die Anwendung lachen möchte
- 📋 Lehrmaterialien mit Unterhaltungswert

## 🚀 Quickstart

### Basis-Setup

```csharp
using Wirtschaftsspionage;

// Agent 007 nimmt seinen Dienst auf
var agency = new SpyAgency();

// Oder mit eigener Agenten-ID
var agency = new SpyAgency(agentId: "AGENT-COFFEE-007");
```

### Unter Beobachtung stellen

```csharp
// Eine Komponente verdächtig machen
agency.Investigate("DatabaseConnection");
agency.Investigate("AuthenticationModule");

// Anzahl der Untersuchungen abfragen
int count = agency.InvestigationCount; // 2
```

### Geheimberichte erstellen

```csharp
// Eine Geheimdienstmeldung verfassen
agency.Report("Das Datenbankmodul zeigt verdächtig normale Performance");
agency.Report("Eine Excel-Datei wurde als Beweismittel gesichert");

// Anzahl der Berichte abfragen
int reports = agency.ReportCount;
```

### Klassifizierung von Vorgängen

Die `Classification` Enum bietet folgende Geheimhaltungsstufen:

```csharp
public enum Classification
{
    Public,              // Jeder darf davon wissen
    Confidential,        // Nur unter Freunden
    Secret,              // Wird der Kaffeepause anvertraut
    TopSecret,           // Geht niemanden was an
    CoffeeClassified     // Nur mit gültigem Kaffeebecher zugänglich
}
```

Nutzungsbeispiel:

```csharp
agency.Classify("EmployeeDatabase", Classification.TopSecret);
agency.Classify("CoffeeLog", Classification.CoffeeClassified);

int classified = agency.ClassifiedCount;
```

### Der große Geheime Abschlussbericht

```csharp
string report = agency.SubmitSecretReport();
```

Dies erzeugt einen wunderschönen, tabellarischen Bericht, der folgende Informationen enthält:

```
========================================
      GEHEIMER ABSCHLUSSBERICHT
========================================
Agent: AGENT-007
Erstellt: 2024-01-15 14:23:45
Einsatzdauer: 42 Sekunden

STATISTIK
Untersuchte Komponenten: 5
Erstellte Meldungen: 12
Klassifizierte Elemente: 3

UNTERSUCHUNGEN
- DatabaseConnection
- AuthenticationModule
- ErrorHandler
- ...

GEHEIMBERICHTE
- Das Datenbankmodul verhält sich verdächtig normal
- Ein Zusammenhang mit dem Kaffeeautomaten wird geprüft
- ...

KLASSIFIZIERTE ELEMENTE
- EmployeeDatabase [TopSecret]
- SecretFormula [Secret]
- ...

ABSCHLIESSENDE BEWERTUNG: Die Lage ist unter Kontrolle. 
Niemand weiß, warum.
========================================
```

## 💬 Humorvolle Features

### Zufällige Ermittlungsmeldungen

Bei jeder Untersuchung erhalten Sie eine zufällige, witzige Bewertung:

- 🔍 "Die Komponente verhält sich verdächtig normal."
- ☕ "Ein Zusammenhang mit dem Kaffeeautomaten wird geprüft."
- 📊 "Ein wichtiges Excel-Dokument wurde als Beweismittel gesichert."
- 🤷 "Die Abteilung für unnötige Meetings wurde informiert."

### Sicherheitshinweise bei Klassifizierung

- 🔒 "Zugriff nur mit gültigem Kaffeebecher."
- 🧠 "Die Akte wurde gedanklich in einen Tresor gelegt."
- 📄 "Ein Ausdruck dieser Meldung würde die Papierknappheit verschärfen."

### Finale Bewertungen

- ✅ "Die Lage ist unter Kontrolle. Niemand weiß, warum."
- 🎉 "Operation erfolgreich. Der ursprüngliche Auftrag ist unbekannt."
- ☕ "Verdächtig viele Erkenntnisse für so wenig Kaffee."
- 💰 "Weitere Untersuchungen sind erforderlich. Das Budget ist bereits aufgebraucht."

## ⚙️ Erweiterte Nutzung

### Custom TextWriter

Sie können die Ausgabe auch an einen custom `TextWriter` lenken:

```csharp
using (var writer = new StreamWriter("spy_log.txt"))
{
    var agency = new SpyAgency(output: writer, agentId: "AGENT-FILEWRITER");
    agency.Investigate("MyComponent");
    var report = agency.SubmitSecretReport();
}
```

### Vollständiges Beispiel

```csharp
using System;
using System.IO;
using Wirtschaftsspionage;

class Program
{
    static void Main()
    {
        // Agentur initialisieren
        var agency = new SpyAgency(agentId: "CHIEF-INVESTIGATOR");

        // Ermittlungen durchführen
        agency.Investigate("UserService");
        agency.Investigate("DatabaseLayer");
        agency.Investigate("CacheManager");

        // Berichte verfassen
        agency.Report("Verdächtige Datenbankaktivität erkannt");
        agency.Report("Cache-Hit-Rate überraschend hoch");

        // Klassifizieren
        agency.Classify("UserPasswords", Classification.TopSecret);
        agency.Classify("APIKeys", Classification.Secret);
        agency.Classify("LogFiles", Classification.Confidential);

        // Finale Erkenntnis
        string finalReport = agency.SubmitSecretReport();
        Console.WriteLine(finalReport);
    }
}
```

## 📊 Properties

| Property | Typ | Beschreibung |
|----------|-----|-------------|
| `InvestigationCount` | int | Anzahl der untersuchten Komponenten |
| `ReportCount` | int | Anzahl der erstellten Meldungen |
| `ClassifiedCount` | int | Anzahl der klassifizierten Elemente |

## 🔧 Anforderungen

- **.NET Standard 2.0** oder höher
- **C# 7.3** oder höher

## ⚠️ Wichtige Hinweise

- Diese Bibliothek ist **satirisch und zu Unterhaltungszwecken** gedacht
- Sie bietet **keine echte Sicherheit** oder Zugriffskontrolle
- Alle Ausgaben erfolgen auf der Konsole oder dem angegebenen `TextWriter`
- Sie sollte **nicht für echte sicherheitskritische Anwendungen** verwendet werden
- Ihr Budget wird bei echter Nutzung möglicherweise aufgebraucht, aber nicht bei simulierter! 😄

## 🎓 Bildungswert

Perfect für:
- **Code-Reviews** mit Humor
- **Dokumentation** von Systemverhalten
- **Team-Workshops** zur Anwendungsarchitektur
- **Abschlussarbeiten** über satirische Softwaredesign-Patterns
- **Meetings**, bei denen sonst niemand aufpasst

## 📃 Lizenz

© AscendantWare e.K.

```
Dieses Paket wird ohne Garantie bereitgestellt.
Jede Ähnlichkeit mit echten Spionageaktivitäten 
ist rein satirisch gemeint.
```

## 🔗 Links

- **GitHub:** https://github.com/AscendantWare/Wirtschaftsspionage
- **Website:** www.ascendant-ware.com
- **NuGet:** https://www.nuget.org/packages/Wirtschaftsspionage

---

**"Ihre Anwendung weiß mehr, als sie zugibt."** ✨

*So intelligent kann Ihre Überwachung sein!* 🕵️‍♂️☕