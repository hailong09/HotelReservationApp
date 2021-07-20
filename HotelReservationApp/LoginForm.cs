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
    public partial class LoginForm : Form
    {
        private readonly IHotelReservation m_session;
        bool isLogin;
        public LoginForm(IHotelReservation session)
        {
            InitializeComponent();
            m_session = session;
            
        }

        private void Acc_NotextBox_TextChanged(object sender, EventArgs e) => Connect_Btn.Enabled = !string.IsNullOrEmpty(Acc_NotextBox.Text);

        private void HostNametextBox_TextChanged(object sender, EventArgs e) => m_session.HostName = HostNametextBox.Text;

        private async void Connect_Btn_Click(object sender, EventArgs e)
        {
            try
            {

                isLogin = true;
                if (m_session.IsClosed)
                {

                 
                    m_session.Start();
                    if (int.TryParse(Acc_NotextBox.Text, out int acc))
                    {
                        try
                        {
                            
                            await  m_session.Login(acc);
                       

                        }
                        catch (InvalidOperationException err)
                        {
                            isLogin = false;
                          if("Not Right User!" == err.Message)
                            {
                                MessageBox.Show("account_no invalid", "Unsuccessful login attempt", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Acc_NotextBox.Text = "";
                                
                            }
                          else if("Already Loged in!" == err.Message || !string.IsNullOrEmpty(m_session.userName))
                            {

                                MessageBox.Show("already logged in", "Unsuccessful login attempt", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Close();
                            } else
                            {
                                MessageBox.Show("Server Unavailable", "Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Close();
                            }

                        }

                        if (isLogin)
                        {
                            //m_session.user = user;
                            
                            this.DialogResult = DialogResult.OK;
                            this.Close();

                        }
                    }
                }


            }

            catch (InvalidOperationException)
            {
                MessageBox.Show("Server Unavailable", "Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();

            }
          
  






         }
        

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
