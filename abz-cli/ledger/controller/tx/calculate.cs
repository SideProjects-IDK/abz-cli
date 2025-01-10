using abz_cli.ledger.types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abz_cli.ledger.controller
{
    public class tx_calculate
    {
        public static pwv_M CalcAmount(Address UserAddressAmount, Address Cc_Address)
        {
            pwv_M RET = new pwv_M {Cc_Addr = Cc_Address,Amount = 0 };



            return RET;
        }
    }
}
