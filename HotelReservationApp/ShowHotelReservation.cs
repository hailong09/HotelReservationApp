using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelReservationApp
{
    public partial class ShowHotelReservation : Form
    {
        IHotelReservation m_session;
        IList<int> lay_out = new List<int>();
        IList<User> userReservList = new List<User>();
        IList<string> reserved;
        IList<int> Rooms;
        int Room;
        bool isDeleted = true;
        bool isReserve;
        public ShowHotelReservation(IHotelReservation session)
        {
            InitializeComponent();
            m_session = session;
        }

        private async void ShowHotelReservation_Load(object sender, EventArgs e)
        {
            try
            {
                if (Connect())
                {

                    this.Text = $"Hotel reservation for {m_session.userName}";
                    Reservebutton.Enabled = true;
                    lay_out = await Task.Run(() => m_session.Get_layout());
                    lay_out.ToArray();
                    LayOutlabel.Text = $"Layout: Floors={lay_out[0]}, Rooms Per Floor={lay_out[1]}";

                    for (int i = 1; i <= lay_out[0]; i++)
                    {
                        if (i != 13)
                        {
                            FloorcomboBox.Items.Add(i);
                        }
                    }

                    for (int i = 1; i <= lay_out[1]; i++)
                    {
                        RoomcomboBox.Items.Add(i);
                    }

                    FloorcomboBox.SelectedItem = 1;
                    RoomcomboBox.SelectedItem = 1;

                    Room = int.Parse(FloorcomboBox.SelectedItem.ToString()) * 100 + int.Parse(RoomcomboBox.SelectedItem.ToString());
                    SelectedRoomlabel.Text = $"Room {Room} selected.";

                }
                else
                {
                    Application.Exit();
                }


            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Server Unavailable", "Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            
        }
      
        private bool Connect() => new LoginForm(m_session).ShowDialog(this) == DialogResult.OK;

        private async void ShowHotelReservation_FormClosed(object sender, FormClosedEventArgs e) => await m_session.LogOut();


        private void FloorcomboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if(FloorcomboBox.SelectedItem != null && RoomcomboBox.SelectedItem != null) {
                Room = int.Parse(FloorcomboBox.SelectedItem.ToString()) * 100 + int.Parse(RoomcomboBox.SelectedItem.ToString());
                SelectedRoomlabel.Text = $"Room {Room} selected.";
                Reservebutton.Enabled = true;
            }
            
        }

        private void RoomcomboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (FloorcomboBox.SelectedItem != null && RoomcomboBox.SelectedItem != null) {
                Room = int.Parse(FloorcomboBox.SelectedItem.ToString()) * 100 + int.Parse(RoomcomboBox.SelectedItem.ToString());
                SelectedRoomlabel.Text = $"Room {Room} selected.";
                Reservebutton.Enabled = true;
            }
        }

        private async void Reservebutton_Click(object sender, EventArgs e)
        {
            try {
                reserved = new List<string>();
                Rooms = new List<int>();
                isReserve = true;
                await m_session.Reserve(Room);
                if (isReserve)
                {
                    Reservebutton.Enabled = false;
                    CurrentResvlistBox.Items.Add($"Room:{Room} currently booked by {m_session.userName}");
                    try
                    {
                        userReservList = await m_session.GET_RESERVATIONS();
                        reserved = await Task.Run(() =>
                        {

                            IList<string> userRoomReserve = new List<string>();
                            foreach (User u in userReservList)
                            {
                                userRoomReserve.Add($"Room:{u.Room} currently booked by {u.Name}");
                                Rooms.Add((int)u.Room);
                            }
                            return userRoomReserve;

                        });
                    }
                    catch (InvalidOperationException)
                    {


                    }
                }

               

            }
            catch (InvalidOperationException err){
                isReserve = false;
                if ("NOT_AVAILABLE" == err.Message)
                {
                    MessageBox.Show("Room is unavailable!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if ("ROOM_NOT_VALID" == err.Message)
                {
                    MessageBox.Show("Uknown Room!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if ("MAX_RESERVED" == err.Message)
                {
                    MessageBox.Show("Maximum Reservation!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Server Unavailable", "Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
               
            }
           
            

        }

        private void CurrentResvlistBox_Click(object sender, EventArgs e)
        {
            if(CurrentResvlistBox.SelectedItem != null)
            {
                CancelReservebutton.Enabled = true;
            }
            
        }

        private async void CancelReservebutton_Click(object sender, EventArgs e)
        {            
            try
            {
                int index = reserved.IndexOf(CurrentResvlistBox.SelectedItem.ToString());
               
                try
                {
                    await m_session.Cancel_reservation(Rooms[index]);

                }
                catch (InvalidOperationException)
                {
                    isDeleted = false;
                    MessageBox.Show("Client is not currently have the specified room reserved!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                if (isDeleted)
                {
                    CurrentResvlistBox.Items.Remove(CurrentResvlistBox.SelectedItem.ToString());

                }
                CancelReservebutton.Enabled = false;
               
            
            }
            catch(InvalidOperationException)
            {
               
                    MessageBox.Show("Server Unavailable", "Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
             
            }
           

        }

        private async void Refreshbutton_Click(object sender, EventArgs e)
        {
            
            try
            {

                reserved = new List<string>();
                Rooms = new List<int>();
                userReservList = await Task.Run(() => m_session.GET_RESERVATIONS());

                reserved = await Task.Run(() =>
                {

                    IList<string> userRoomReserve = new List<string>();
                    foreach (User u in userReservList)
                    {
                        userRoomReserve.Add($"Room:{u.Room} currently booked by {u.Name}");
                        Rooms.Add((int)u.Room);
                    }
                    return userRoomReserve;
                });

                //test.Text = reserved[0];
                CurrentResvlistBox.Items.Clear();

                foreach (string val in reserved)
                {
                    CurrentResvlistBox.Items.Add(val);
                }
                CurrentResvlistBox.Update();

            } catch (InvalidOperationException)
            {
                Reservebutton.Enabled = false;
                MessageBox.Show("Server Unavailable", "Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

        }
     
    }
}
