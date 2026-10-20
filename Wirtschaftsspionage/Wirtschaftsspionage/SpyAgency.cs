using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Wirtschaftsspionage
{
    /// <summary>
    /// Simuliert eine humorvolle Wirtschaftsspionage-Abteilung
    /// innerhalb einer Anwendung.
    /// </summary>
    public sealed class SpyAgency
    {
        private readonly TextWriter _output;
        private readonly List<string> _investigations = new List<string>();
        private readonly List<string> _reports = new List<string>();
        private readonly List<string> _classifiedItems = new List<string>();
        private readonly string _agentId;
        private readonly DateTime _initializedAt;

        /// <summary>
        /// Erstellt eine neue Instanz der Wirtschaftsspionage-Agentur.
        /// </summary>
        /// <param name="output">
        /// Ziel für die Ausgabe. Standardmäßig wird die Konsole verwendet.
        /// </param>
        /// <param name="agentId">
        /// Optionale Kennung des Agenten.
        /// </param>
        public SpyAgency(
            TextWriter output = null,
            string agentId = "AGENT-007")
        {
            _output = output ?? Console.Out;
            _agentId = string.IsNullOrWhiteSpace(agentId)
                ? "AGENT-007"
                : agentId;

            _initializedAt = DateTime.Now;

            WriteHeader();
            WriteMessage(
                "INITIALISIERUNG",
                $"Agent {_agentId} hat seinen Dienst aufgenommen.");
        }

        /// <summary>
        /// Anzahl der untersuchten Komponenten.
        /// </summary>
        public int InvestigationCount => _investigations.Count;

        /// <summary>
        /// Anzahl der erstellten Meldungen.
        /// </summary>
        public int ReportCount => _reports.Count;

        /// <summary>
        /// Anzahl der als geheim eingestuften Elemente.
        /// </summary>
        public int ClassifiedCount => _classifiedItems.Count;

        /// <summary>
        /// Untersucht eine Komponente der Anwendung.
        /// </summary>
        /// <param name="target">Name der untersuchten Komponente.</param>
        public void Investigate(string target)
        {
            ValidateInput(target, nameof(target));

            _investigations.Add(target);

            WriteMessage(
                "BEOBACHTUNG",
                $"{target} steht ab sofort unter Beobachtung.");

            WriteMessage(
                "BEWERTUNG",
                GetRandomInvestigationMessage());
        }

        /// <summary>
        /// Erstellt eine humorvolle Geheimdienstmeldung.
        /// </summary>
        /// <param name="message">Inhalt der Meldung.</param>
        public void Report(string message)
        {
            ValidateInput(message, nameof(message));

            _reports.Add(message);

            WriteMessage("GEHEIMBERICHT", message);
        }

        /// <summary>
        /// Klassifiziert einen Vorgang mit einer Geheimhaltungsstufe.
        /// </summary>
        /// <param name="item">Name des klassifizierten Vorgangs.</param>
        /// <param name="classification">Geheimhaltungsstufe.</param>
        public void Classify(
            string item,
            Classification classification)
        {
            ValidateInput(item, nameof(item));

            if (!Enum.IsDefined(typeof(Classification), classification))
            {
                throw new ArgumentOutOfRangeException(
                    nameof(classification),
                    classification,
                    "Unbekannte Geheimhaltungsstufe.");
            }

            _classifiedItems.Add(
                $"{item} [{classification}]");

            WriteMessage(
                $"GEHEIMSTUFE: {classification.ToString().ToUpperInvariant()}",
                $"{item} wurde erfolgreich klassifiziert.");

            WriteMessage(
                "SICHERHEITSHINWEIS",
                GetRandomClassificationMessage());
        }

        /// <summary>
        /// Erstellt einen zusammenfassenden Abschlussbericht.
        /// </summary>
        /// <returns>Der generierte Bericht als Text.</returns>
        public string SubmitSecretReport()
        {
            var duration = DateTime.Now - _initializedAt;

            var report = new StringBuilder();

            report.AppendLine("========================================");
            report.AppendLine("      GEHEIMER ABSCHLUSSBERICHT");
            report.AppendLine("========================================");
            report.AppendLine($"Agent: {_agentId}");
            report.AppendLine($"Erstellt: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            report.AppendLine($"Einsatzdauer: {duration.TotalSeconds:F0} Sekunden");
            report.AppendLine();
            report.AppendLine("STATISTIK");
            report.AppendLine($"Untersuchte Komponenten: {_investigations.Count}");
            report.AppendLine($"Erstellte Meldungen: {_reports.Count}");
            report.AppendLine($"Klassifizierte Elemente: {_classifiedItems.Count}");
            report.AppendLine();

            report.AppendLine("UNTERSUCHUNGEN");
            AppendItems(report, _investigations);

            report.AppendLine();
            report.AppendLine("GEHEIMBERICHTE");
            AppendItems(report, _reports);

            report.AppendLine();
            report.AppendLine("KLASSIFIZIERTE ELEMENTE");
            AppendItems(report, _classifiedItems);

            report.AppendLine();
            report.AppendLine(
                "ABSCHLIESSENDE BEWERTUNG: " +
                GetRandomFinalAssessment());

            report.AppendLine("========================================");

            string result = report.ToString();

            _output.WriteLine(result);

            return result;
        }

        private void WriteHeader()
        {
            _output.WriteLine();
            _output.WriteLine("╔════════════════════════════════════════╗");
            _output.WriteLine("║       Wirtschaftsspionage              ║");
            _output.WriteLine("║       ABTEILUNG FÜR GEHEIMAKTEN       ║");
            _output.WriteLine("╚════════════════════════════════════════╝");
            _output.WriteLine($"Agentenkennung: {_agentId}");
            _output.WriteLine($"Dienstbeginn: {_initializedAt:yyyy-MM-dd HH:mm:ss}");
            _output.WriteLine();
        }

        private void WriteMessage(string category, string message)
        {
            _output.WriteLine(
                $"[{DateTime.Now:HH:mm:ss}] [{category}] {message}");
        }

        private static void AppendItems(
            StringBuilder builder,
            IReadOnlyCollection<string> items)
        {
            if (items.Count == 0)
            {
                builder.AppendLine("- Keine Erkenntnisse. Die Lage ist verdächtig ruhig.");
                return;
            }

            foreach (string item in items)
            {
                builder.AppendLine($"- {item}");
            }
        }

        private static void ValidateInput(string value, string parameterName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(
                    "Der Wert darf nicht leer sein.",
                    parameterName);
            }
        }

        private static string GetRandomInvestigationMessage()
        {
            string[] messages =
            {
                "Die Komponente verhält sich verdächtig normal.",
                "Ein Zusammenhang mit dem Kaffeeautomaten wird geprüft.",
                "Die Abteilung für unnötige Meetings wurde informiert.",
                "Keine Auffälligkeiten. Die Ermittlungen werden intensiviert.",
                "Ein wichtiges Excel-Dokument wurde als Beweismittel gesichert."
            };

            return GetRandomMessage(messages);
        }

        private static string GetRandomClassificationMessage()
        {
            string[] messages =
            {
                "Zugriff nur mit gültigem Kaffeebecher.",
                "Die Akte wurde gedanklich in einen Tresor gelegt.",
                "Weitergabe an die Abteilung für offensichtliche Geheimnisse untersagt.",
                "Ein Ausdruck dieser Meldung würde die Papierknappheit verschärfen."
            };

            return GetRandomMessage(messages);
        }

        private static string GetRandomFinalAssessment()
        {
            string[] assessments =
            {
                "Die Lage ist unter Kontrolle. Niemand weiß, warum.",
                "Operation erfolgreich. Der ursprüngliche Auftrag ist unbekannt.",
                "Verdächtig viele Erkenntnisse für so wenig Kaffee.",
                "Weitere Untersuchungen sind erforderlich. Das Budget ist bereits aufgebraucht.",
                "Die Geschäftsführung wurde informiert und hat einen Termin angesetzt."
            };

            return GetRandomMessage(assessments);
        }


        private static readonly Random _random = new Random();
        private static string GetRandomMessage(string[] messages)
        {
            if (messages == null || messages.Length == 0)
                throw new ArgumentException(
                    "Es muss mindestens eine Meldung vorhanden sein.",
                    nameof(messages));

            return messages[_random.Next(messages.Length)];
        }
    }
}
