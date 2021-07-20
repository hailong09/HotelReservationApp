using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotelReservationApp
{
    public interface IHotelReservation
    {
        string HostName { get; set; }
        int HostPort { get; set; } 
        bool IsClosed { get; }
        string userName { get; set; }


        void Start();
        Task Login(int accNum);
        Task LogOut();
        Task Reserve(int room);
        Task Cancel_reservation(int room); 
        IProgress<string> RoomProgress { get; set;}
        IList<int> Get_layout();
        Task<IList<User>> GET_RESERVATIONS();
    }
}
