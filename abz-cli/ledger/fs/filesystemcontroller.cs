using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static abz_cli.ledger.LedgerBaseModel.LedgerStorage;
using static abz_cli.ledger.LedgerBaseModel;
using static abz_cli.utils.logger;

namespace abz_cli.ledger
{
    public class fs
    {
        public static void SaveEnvironmentVariables()
        {
            File.WriteAllText("./LedgerData.json", JsonSerializer.Serialize(LedgerStorage.LedgerData, new JsonSerializerOptions { WriteIndented = true }));
            File.WriteAllText("./LedgerS.json", JsonSerializer.Serialize(LedgerStorage.LedgerS, new JsonSerializerOptions { WriteIndented = true }));
        }
        public static void LoadEnvironmentVariables()
        {
            try
            {
                if (File.Exists("./LedgerData.json"))
                {
                    string json = File.ReadAllText("./LedgerData.json");
                    LedgerStorage.LedgerData = JsonSerializer.Deserialize<Dictionary<string, LedgerDataBaseModel>>(json) ?? new Dictionary<string, LedgerDataBaseModel>();
                }
                else
                {
                    pe("'./LedgerData' not found!, creating one now!");
                    File.WriteAllText("./LedgerData.json", JsonSerializer.Serialize(LedgerStorage.LedgerData, new JsonSerializerOptions { WriteIndented = true }));

                }

                if (File.Exists("./LedgerS.json"))
                {
                    string json = File.ReadAllText("./LedgerS.json");
                    LedgerStorage.LedgerS = JsonSerializer.Deserialize<Dictionary<string, LedgerMetadataBaseModel>>(json) ?? new Dictionary<string, LedgerMetadataBaseModel>();
                }
                else
                {
                    pe("'./LedgerS.json' not found!, creating one now!");
                    File.WriteAllText("./LedgerS.json", JsonSerializer.Serialize(LedgerStorage.LedgerS, new JsonSerializerOptions { WriteIndented = true }));
                }
            }
            catch (Exception ex)
            {
                pe($"Error loading LedgerData, LedgerS: {ex.Message}");
            }
        }
    }
}
