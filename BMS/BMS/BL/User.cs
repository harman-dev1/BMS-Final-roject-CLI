using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMS.UI;
using BMS.DL;


namespace BMS.BL
{
    class User
    {
        protected string email;
        protected string password;
        protected string role;
        protected string name;
        protected long phoneNo;
        protected string address;
        protected long cnic;

        
        public User(string aEmail, string aPassword,long aCNIC,string aAddress,long aPhoneNo,string aName)
        {
            Email = aEmail;
            Password = aPassword;
            role = "admin";
            CNIC = aCNIC;
            Address = aAddress;
            PhoneNo = aPhoneNo;
            Name = aName;
        }
        public User()
        {

        }
        public string Email
        {
            get { return email; }
            set 
            {
                email = value;
            }
        }
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
            }
        }
        public string Role
        {
            get { return role; }
            set
            {
                role = value;
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
            }
        }
        public  long PhoneNo
        {
            get {return phoneNo; }
            set
            {
                phoneNo = value;
            }
        }
        public string Address
        {
            get { return address; }
            set
            {
                address = value; 
            }
        }
        public long CNIC
        {
            get { return cnic; }
            set
            {
                cnic = value;
            }
        }
        
        
        
        


        

        

        
        
    } 


    //Child Class Of Customer...............................................

    class Customer : User
    {

    }
}
