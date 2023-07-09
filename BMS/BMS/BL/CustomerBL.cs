using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.BL
{
    class CustomerBL : User
    {
        private string atmId;
        private int atmPassword;
        private string accountType;
        private long amount = 0;
        public void SetAtmForCustomer(string aAtmId, int aAtmPassword, string aAcountType, long aAmount)
        {
            AtmId = aAtmId;
            AtmPassword = aAtmPassword;
            AccountType = aAcountType;
            Amount = aAmount;
        }
        public long Amount
        {
            get { return amount; }
            set
            {
                amount = value;
            }
        }
        public string AtmId
        {
            get { return atmId; }
            set
            {
                atmId = value;
            }
        }
        public int AtmPassword
        {
            get { return atmPassword; }
            set
            {
                atmPassword = value;
            }
        }

        public string AccountType
        {
            get { return accountType; }
            set
            {
                accountType = value;
            }
        }
        public CustomerBL(string aEmail, string aPassword, long aCNIC, string aAddress, long aPhoneNo, string aName, string aRole)
        {
            email = aEmail;
            password = aPassword;
            cnic = aCNIC;
            address = aAddress;
            phoneNo = aPhoneNo;
            name = aName;
            role = aRole;
        }
        public CustomerBL()
        {

        }
    }
}
