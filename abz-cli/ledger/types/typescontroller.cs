using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abz_cli.ledger.types
{
    //-- Transaction
    public class Tx_BM
    {
        public Address Address { get; set; }
        public Address PreviousAddr { get; set; }
        public Tx_Data_M Data { get; set; }
        public DateTime TimeStamp { get; set; }

    }
    public class Tx_Data_M
    { 
        public Address From { get; set; }
        public Address To { get; set; }
        public Tx_Cc_M Cc { get; set; }
    }
    public class Tx_Cc_M
    { 
        public Address Cc_Addr { get; set; }
        public double Amount { get; set; }
    }
    public class Address
    {
        public string Addr { get; set; }
        public bool IsValid(string Other_Addr) 
        {
            string Addr1 = abz_cli.sex.hashes.ComputeSha256Hash(this.Addr);
            string Addr2 = abz_cli.sex.hashes.ComputeSha256Hash(Other_Addr);

            if (Addr1 == Addr2)
                return true;
            else 
                return false;
        }
    }

    //-- CryptoCurrency

    public class Cc_BM
    {
        public Address Cc_Addr { get; set; }
        public Address CcDad_Addr { get; set; }
        public Address CcMom_Addr { get; set; }

        //-- Metadata
        public Metadata_BM MetaData { get; set; }


        //-- For Educational Purposes Only!
        public double LastValue { get; set; }
        public double CurrentValue { get; set; }
        public double IncreaseTillLastValue { get; set; }
        public double ExpectedValue { get; set; }
        public double StartedWith { get; set; }
    }

    //-- MetaData
    public class Metadata_BM
    {
        public string Name { get; set; }
        public string DadAddr { get; set; }
        public string Address { get; set; }
        public string ChainAddr { get; set; }
        public DateTime TimeStamp { get; set; }

    }

    //-- UserAccount
    public class User_Account_BM
    {
        public string Addr { get; set; }
        public string PrivKey { get; set; }

        //-- RealBusiness: money!!
        public List<pwv_M> MoneyS { get; set; }
        
    }
    public class pwv_M
    {
        public Address Cc_Addr { get; set; }
        public double Amount { get; set; }
    }
}
