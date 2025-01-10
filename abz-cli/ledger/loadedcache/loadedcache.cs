using abz_cli.ledger.types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abz_cli.ledger
{
    public class lc
    {
        //-- Basic/Main

        // Crypto Currensies Data Is In Here!
        public static Dictionary<Address,Cc_BM> CryptoS = new Dictionary<Address,Cc_BM>(); 
        // Transaction Data Is In Here
        public static Dictionary<Address,Tx_BM> TxS = new Dictionary<Address,Tx_BM>();

        //-- Advanced
        public static Dictionary<Address,Address> AddressChains = new Dictionary<Address, Address>();
    }
}
