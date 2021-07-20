using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Sockets;
using System.IO;

namespace HotelReservationApp
{
    class HandleServer : IHotelReservation
    {
        public string HostName { get; set; } = "localhost"; // Default host name - localhost means that the server is running on the same computer as this client
        public int HostPort { get; set; } = 55211; // Default host port - note that the port number is the same one as in the server code
        public string userName { get; set; }
        private TcpClient m_tcpClient = null;
        private StreamReader m_reader;
        private StreamWriter m_writer;
        public bool IsClosed => null == m_tcpClient;

        public User user { get; set; }
        public IProgress<string> RoomProgress { get; set; } = null;

        public void Start()
        {
            try {
                m_tcpClient = new TcpClient(); // Default constructor only allows IPv4
                m_tcpClient.Connect(HostName, HostPort);
                NetworkStream stream = m_tcpClient.GetStream();
                m_reader = new StreamReader(stream);
                m_writer = new StreamWriter(stream);
            }
            catch (SocketException se) {
                m_tcpClient = null;
                throw new InvalidOperationException("Server Unavailable", se);
            }
        }
        public async Task Login(int accNum)
        {
            try
            {


                await m_writer.WriteLineAsync($"LOGIN:{accNum}");
                await m_writer.FlushAsync();
                string line = await m_reader.ReadLineAsync();

                if (line.Contains("SUCCESS") && string.IsNullOrEmpty(userName))
                {
                    string[] name = line.Substring(8).Split(',');
                    userName = $"{name[0]} {name[1]}";
                   

                }
                else if ("LOGIN_ERROR" == line)
                {
                    m_tcpClient = null;
                    throw new InvalidOperationException("Not Right User!");
                }
                else if ("LOGIN_INVALID" == line)
                {
                    userName = "";
                    m_tcpClient = null;
                    throw new InvalidOperationException("Already Loged in!");
                }
               
            } catch (IOException err) {
                Close();
                m_tcpClient = null;
                throw new InvalidOperationException("Server Unavailable!", err);
            } catch (SocketException err){

                Close();
                m_tcpClient = null;
                throw new InvalidOperationException("Server Unavailable!",err);
            } catch (OutOfMemoryException err)  {

                Close();
                m_tcpClient = null;
                throw new InvalidOperationException("Server Unavailable!",err);

            }


        }
        public IList<int> Get_layout()
        {

            try {
                IList<int> list = new List<int>();
                // Default constructor only allows IPv4
                m_writer.WriteLine("GET_LAYOUT");
                m_writer.Flush();
                string line = m_reader.ReadLine();

                if (line != "NOT_LOGGED_IN")
                {

                    string[] floor = line.Substring(7).Split(',');
                    list.Add(int.Parse(floor[0]));
                    list.Add(int.Parse(floor[1]));

                }
                else { throw new IOException("Not Login!"); }

                return list;


            } catch (IOException err) {

                Close();     
                throw new InvalidOperationException("Server Unavailable", err);
            }


        }
        public async Task LogOut()
        {
            try {
                if (m_tcpClient != null)
                {
                   await m_writer.WriteLineAsync("LOGOUT");
                   await m_writer.FlushAsync();
                }
            }
            catch (IOException) { }
            catch (NullReferenceException) { }
            catch (ArgumentNullException) { }
            finally {
                Close();

            }
        }
        private void Close()
        {
            m_tcpClient?.Close();
            m_tcpClient = null;
        }
        public async Task Reserve(int room)
        {
            if (IsClosed)
                throw new InvalidOperationException("Client Closed");
            try
            {
                await m_writer.WriteLineAsync($"RESERVE:{room}");
                await m_writer.FlushAsync();
                string line = await m_reader.ReadLineAsync();

                if ("RESERVED" != line)
                {

                    throw new InvalidOperationException(line);
                }

            }
            catch (IOException err)
            {
                Close();
                m_tcpClient = null;
                throw new InvalidOperationException("Server Unavailable!", err);
            }
            catch (SocketException err)
            {

                Close();
                m_tcpClient = null;
                throw new InvalidOperationException("Server Unavailable!", err);

            }
            catch (OutOfMemoryException err)
            {
                Close();
                m_tcpClient = null;
                throw new InvalidOperationException("Server Unavailable!", err);
            }
        }

        public async Task<IList<User>> GET_RESERVATIONS()
        {
            
            if (IsClosed)
            {
                throw new InvalidOperationException("Client Closed");
            }
               
            try {
                IList<User> list = new List<User>();
                await m_writer.WriteLineAsync($"GET_RESERVATIONS");
                await m_writer.FlushAsync();
                string line =  await m_reader.ReadLineAsync();
                if(line != "NOT_LOGGED_IN" && ((line?.Length ?? 0) > 0)){
                   
                    foreach (string reserve in line.Substring("RESERVATIONS:".Length).Split('|')) {
                        string[] user = reserve.Split(',');
                        if(4 == user.Length && int.TryParse(user[0], out int room) && bool.TryParse(user[3], out bool mine)) {
                            list.Add(new User(user[1]+ " " + user[2], room, mine));

                        }
                    }

                }  

             return list;

            }
            catch (SocketException se)
            {
                m_tcpClient = null;
                throw new InvalidOperationException("Server Unavailable", se);
            }catch (IOException ioe) {
                
              
                Close(); // Close on error
                throw new InvalidOperationException("Server Unavailable", ioe);
                
            }catch(ObjectDisposedException err)
            {
                Close(); // Close on error
                
               
                throw new InvalidOperationException("Server Unavailable", err);
                
            }


        }
        public async Task Cancel_reservation(int room)
        {
            if (IsClosed)
            {
                throw new InvalidOperationException("Client Closed");
            }

            try
            {
               await m_writer.WriteLineAsync($"CANCEL_RESERVATION:{room}");
               await  m_writer.FlushAsync();
                string line = await m_reader.ReadLineAsync();
                if (line != "CANCELLED")
                {

                    throw new InvalidOperationException(line);

                }
            }
            catch (IOException ioe)
            {
                Close(); // Close on error
                throw new InvalidOperationException("Server Unavailable", ioe);
            }
          
        }

      }
}
