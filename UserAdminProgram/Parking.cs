using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAdminProgram
{
    class Parking
    {
        public int Id
        {
            get;
            set;
        }
        public DateTime InTime
        {
            get;
            set;
        }
        public DateTime OutTime
        {
            get;
            set;
        }
        public int Amount
        {
            get;
            set;
        }
        public string CarNumber
        {
            get;
            set;
        }

        public Parking(string car_number)
        {
            Id = 0;
            InTime = new DateTime();
            CarNumber = car_number;
        }
        public Parking()
        {
            Id = 0;
            InTime = new DateTime();
            CarNumber = "";
        }

    }
}
