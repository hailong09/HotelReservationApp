using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationApp
{
    public class User
    {

        public string Name { get; }
        public IList<int> Rooms { get; set; }
        public int? Room { get; }
        public bool? Mine{get;}

        public User(string name, int? r, bool? mine)
        {


            Name = name;
            Room = r;
            Mine= mine;
        }
    }
}

