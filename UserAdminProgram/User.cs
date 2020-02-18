using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAdminProgram
{
    class User
    {
        public string Name
        {
            get;
            set;
        }
        
        public string Phone
        {
            get;
            set;
        }

        public string Type
        {
            get;
            set;
        }

        public string Car_Type
        {
            get;
            set;
        }

        public string Car_Number
        {
            get;
            set;
        }
        
        public int Id
        {
            get;
            set;
        }

        public User(string name, string phone, string type, string car_type, string car_number, int id)
        {
            Name = name;
            Phone = phone;
            Type = type;
            Car_Type = car_type;
            Car_Number = car_number;
            Id = id;
        }
        
        public User()
        {
            Name = "";
            Phone = "";
            Type = "";
            Car_Type = "";
            Car_Number = "";
            Id = 0;

        }

        public string GetUserInfo()
        {
            return "Name: " + Name;
        }

        public string GetDetailUserInfo()
        {
            return " Name : " + Name  + " Phone : " + Phone  + " Type :" + Type  + " Car Type : " +  Car_Type + "Car Number : " + Car_Number; 
        }
    }
}
