using static abz_cli.utils.logger;
using static abz_cli.utils.helplogger;

using static abz_cli.ledger.lc;
using static abz_cli.ledger.fs;
using static abz_cli.ledger.cnt;
using abz_cli.ledger.types;

namespace abz_cli
{
    internal class Program
    {
        public static string AppName = "AbZ";
        public static string AppVersion = "0.1";
        static void Main(string[] args)
        {
            //--

            //Helps["-auth"] = ["-h", "-login", "-logout"];
            Helps["-h"] = ["-h","-cc"];

            Helps["-cc"] = ["-h","-new", "-load", "-save", "-backup", "-load_backup"];
            Helps["-me"] = ["-h", "-balance","-transactions","-about"];

            args = ["-me", "-balance"];

            //--
            // The Cli (Command Line Interface)
            //--


            #region Testing Init
            Cc_BM CryptoMax = new Cc_BM {
                Cc_Addr = new Address { Addr = sex.hashes.ComputeSha256Hash("wtf")},
                CurrentValue = 1000,
                MetaData = new Metadata_BM { 
                Name = "HamzaCoin"
                }
            };
            Cc_BM CryptoMax2 = new Cc_BM
            {
                Cc_Addr = new Address { Addr = sex.hashes.ComputeSha256Hash("wtf2") },
                CurrentValue = 14000,
                MetaData = new Metadata_BM
                {
                    Name = "HamzaCoin2"
                }
            };
            Cc_BM CryptoMax3 = new Cc_BM
            {
                Cc_Addr = new Address { Addr = sex.hashes.ComputeSha256Hash("wtf3") },
                CurrentValue = 521000,
                MetaData = new Metadata_BM
                {
                    Name = "HamzaCoin3"
                }
            };

            User_Account_BM CurrentUser = new User_Account_BM { 
                Addr = "",
                PrivKey = "",
                MoneyS = []
            };

            CryptoS[CryptoMax.Cc_Addr] = CryptoMax;
            CryptoS[CryptoMax2.Cc_Addr] = CryptoMax2;
            CryptoS[CryptoMax3.Cc_Addr] = CryptoMax3;

            CurrentUser.MoneyS.Add(new pwv_M {Cc_Addr = CryptoMax.Cc_Addr, Amount = 500.523425});
            CurrentUser.MoneyS.Add(new pwv_M {Cc_Addr = CryptoMax2.Cc_Addr, Amount = 255.42365 });
            CurrentUser.MoneyS.Add(new pwv_M {Cc_Addr = CryptoMax3.Cc_Addr, Amount = 1240.0005 });

            #endregion


            if (args.Length == 0) { Console.WriteLine($"{AppName}@{AppVersion}"); Environment.Exit(-1); }
            
            switch (args[0])
            {
                case "-h":
                    ph(args[0]);
                    break;
                case "-cc":
                    if (args.Length > 1)
                    {
                        switch (args[1])
                        {
                            case "-new":
                                if (args.Length >= 2)
                                {
                                    Address LedgerAddr = new Address { Addr = sex.hashes.ComputeSha256Hash(args[2]) };
                                    CryptoS[LedgerAddr] = new ledger.types.Cc_BM
                                    {
                                        CcDad_Addr = LedgerAddr,
                                    };
                                }
                                else
                                {
                                    ra("-cc -new <crypto_currency_name>");
                                }
                                break;
                            case "-load":
                                break;
                            case "-save":
                                break;
                            case "-savebackup":
                                break;
                            case "-loadbackup":
                                break;
                            case "-print":
                                break;
                            case "-h":
                                ph(args[0]);
                                break;
                            default:
                                pee();
                                break;
                        }
                    }
                    else
                    {
                        ph(args[0]);
                    }
                    break;
                case "-me":
                    if (args.Length > 1)
                    {
                        switch (args[1])
                        {
                            case "-balance":
                                foreach (pwv_M Cc in CurrentUser.MoneyS)
                                {
                                    plx($"{CryptoS[Cc.Cc_Addr].MetaData.Name,-13}|{Cc.Amount,-10}|{Cc.Amount * CryptoS[Cc.Cc_Addr].CurrentValue,-20}");
                                }
                                break;
                            case "-transactions":
                                break;
                            case "-about":
                                pl($"Addr: {CurrentUser.Addr}");
                                break;
                            case "-h":
                                ph(args[0]);
                                break;
                            default:
                                pee();
                                break;
                        }
                    }
                    else
                    {
                        ph(args[0]);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
