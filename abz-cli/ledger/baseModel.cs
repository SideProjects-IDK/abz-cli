using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static abz_cli.ledger.LedgerBaseModel.LedgerStorage;
using static abz_cli.utils.logger;

namespace abz_cli.ledger
{
    public class LedgerBaseModel
    {
        public static bool TEST_ALL_FUNC()
        {
            LedgerStorage._LOAD_ALL_LEDGER_DATA___LOADSLEDGERDATA();
            LedgerStorage.CREATE_NEW_LEDGER___NEWLEDGER("new", "new", "new");
            LedgerStorage._SAVE_ALL_LEDGER_DATA___SAVESLEDGERDATA();

            //--

            //File.Delete("./LedgerS.json");
            //File.Delete("./LedgerData.json");
            return true;
        }

        public class LedgerIO
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

        public class LedgerStorage
        {
            public static Dictionary<string, LedgerDataBaseModel> LedgerData = new Dictionary<string, LedgerDataBaseModel>();
            public static Dictionary<string, LedgerMetadataBaseModel> LedgerS = new Dictionary<string, LedgerMetadataBaseModel>();
            public static bool CREATE_NEW_LEDGER___NEWLEDGER(string Name_X_Addr, string Dad_Account_Addr, string Chain_Account_Addr)
            {
                string LedgerAddr = abz_cli.sex.hashes.ComputeSha256Hash(Name_X_Addr);

                if (!LedgerS.ContainsKey(LedgerAddr))
                {
                    LedgerS[LedgerAddr] = new LedgerMetadataBaseModel
                    {
                        Name = Name_X_Addr,
                        Address = LedgerAddr,
                        DadAddr = Dad_Account_Addr,
                        ChainAddr = Chain_Account_Addr,
                        TimeStamp = DateTime.Now
                    };
                    pl("Ledger Created: Not Verified!");
                }
                else
                {
                    pe($"Ledger with address: {LedgerAddr} already exists!");
                    return false;
                }
                return true;
            }

            /// <summary>
            /// Not iMPLEMENTED: Will verify the ledger origin and ledger itself!
            /// </summary>
            //public static bool VERIFY_LEDGER___VERIFIEDLEDGER(string LedgerAddr)
            //{
            //    if (LedgerS.ContainsKey(LedgerAddr))
            //    {
            //        pl("Ledger Created: Verification process started!");

            //        List<string> ItemsToVerify = [];

            //        pl($"Address Verified? {UTIL__VERIFYLEDGER__FOREACH_ASSERT(
            //                LedgerS[LedgerAddr].Address,
            //                abz_cli.sex.hashes.ComputeSha256Hash(LedgerS[LedgerAddr].Name)
            //                )}");

            //        pl($"Dad-Account Verified? {UTIL__VERIFYLEDGER__FOREACH_ASSERT(
            //                LedgerS[LedgerAddr].DadAddr,
            //                abz_cli.sex.hashes.ComputeSha256Hash(Blockchain_View_Controller.zho_ledger.UserLedger.UsersL[LedgerS[LedgerAddr].DadAddr].Address)
            //                )}");
            //    }
            //    else
            //    {
            //        pe($"Ledger with address: {LedgerAddr} not found!");
            //        return false;
            //    }
            //    return true;
            //}
            public static bool UTIL__VERIFYLEDGER__FOREACH_ASSERT(string item1, string item2)
            {
                if (item1 == item2)
                    return true;
                else
                    return false;
            }
            public static bool _LOAD_ALL_LEDGER_DATA___LOADSLEDGERDATA()
            {
                LedgerIO.LoadEnvironmentVariables();
                return true;
            }
            public static bool _SAVE_ALL_LEDGER_DATA___SAVESLEDGERDATA()
            {
                LedgerIO.SaveEnvironmentVariables();
                return true;
            }

            public class LedgerDataBaseModel
            {
                public string Address { get; set; }
                public string PreviousAddr { get; set; }
                public string Data { get; set; }
                public DateTime TimeStamp { get; set; }

            }
            public class LedgerMetadataBaseModel
            {
                public string Name { get; set; }
                public string DadAddr { get; set; }
                public string Address { get; set; }
                public string ChainAddr { get; set; }
                public DateTime TimeStamp { get; set; }

            }
        }
    }
}
