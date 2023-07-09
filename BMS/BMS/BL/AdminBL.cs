using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMS.BL;
using BMS.DL;
using BMS.UI;

namespace BMS.BL
{
    // Child Class Of User that is a admin...................................


    class AdminBL : User
    {
        public AdminBL(string aEmail, string aPassword, long aCNIC, string aAddress, long aPhoneNo, string aName) : base(aEmail, aPassword, aCNIC, aAddress, aPhoneNo, aName)
        {

        }
        public AdminBL()
        {

        }       
        static private string bankName = "Null";
        static private string bankEmail = "NULL";
        static private string bankBranchId = "000";
        static private long bankNo = 0000000000;
        static private string bankAddress = "Null";
        static public void setBankDetails(string aBankName, string aBankEmail, string aBankBranchId, string aBankAddress, long aBankNo)
        {
            BankName = aBankEmail;
            BankEmail = aBankEmail;
            BankBranchID = aBankBranchId;
            BankAdddress = aBankAddress;
            BankNo = aBankNo;
        }
        static public string BankName
        {
            get { return bankName; }
            set
            {
                bankName = value;
            }
        }
        static public string BankEmail
        {
            get { return bankEmail; }
            set
            {
                bankEmail = value;
            }
        }
        static public string BankBranchID
        {
            get { return bankBranchId; }
            set
            {
                bankBranchId = value;
            }
        }
        static public long BankNo
        {
            get { return bankNo; }
            set
            {
                bankNo = value;
            }
        }
        static public string BankAdddress
        {
            get { return bankAddress; }
            set
            {
                bankAddress = value;
            }
        }
    }
}
