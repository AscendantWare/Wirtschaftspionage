using System;
using Wirtschaftsspionage;


namespace Wirtschaftsspionage.Testing
{
    public class Class1
    {
        public void Main()
        {
            var agency = new SpyAgency(agentId: "AGENT-1337");

            agency.Investigate("KundenImport");
            agency.Investigate("DatabaseConnection");

            agency.Report("Datenbankverbindung hergestellt.");
            agency.Report("Der Anwender hat erneut auf Speichern geklickt.");

            agency.Classify(
                "Umsatzbericht",
                Classification.TopSecret);

            string secretReport = agency.SubmitSecretReport();
        }
    }
}
