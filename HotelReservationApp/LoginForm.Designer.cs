
namespace HotelReservationApp
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Acc_Nolabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Acc_NotextBox = new System.Windows.Forms.TextBox();
            this.HostNametextBox = new System.Windows.Forms.TextBox();
            this.Connect_Btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Acc_Nolabel
            // 
            this.Acc_Nolabel.AutoSize = true;
            this.Acc_Nolabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Acc_Nolabel.Location = new System.Drawing.Point(12, 26);
            this.Acc_Nolabel.Name = "Acc_Nolabel";
            this.Acc_Nolabel.Size = new System.Drawing.Size(101, 20);
            this.Acc_Nolabel.TabIndex = 0;
            this.Acc_Nolabel.Text = "Account No:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Host Name";
            // 
            // Acc_NotextBox
            // 
            this.Acc_NotextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Acc_NotextBox.Location = new System.Drawing.Point(171, 24);
            this.Acc_NotextBox.Name = "Acc_NotextBox";
            this.Acc_NotextBox.Size = new System.Drawing.Size(366, 27);
            this.Acc_NotextBox.TabIndex = 2;
            this.Acc_NotextBox.TextChanged += new System.EventHandler(this.Acc_NotextBox_TextChanged);
            // 
            // HostNametextBox
            // 
            this.HostNametextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HostNametextBox.Location = new System.Drawing.Point(171, 94);
            this.HostNametextBox.Name = "HostNametextBox";
            this.HostNametextBox.Size = new System.Drawing.Size(366, 27);
            this.HostNametextBox.TabIndex = 3;
            this.HostNametextBox.Text = "localhost";
            this.HostNametextBox.TextChanged += new System.EventHandler(this.HostNametextBox_TextChanged);
            // 
            // Connect_Btn
            // 
            this.Connect_Btn.Enabled = false;
            this.Connect_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Connect_Btn.Location = new System.Drawing.Point(224, 169);
            this.Connect_Btn.Name = "Connect_Btn";
            this.Connect_Btn.Size = new System.Drawing.Size(122, 33);
            this.Connect_Btn.TabIndex = 4;
            this.Connect_Btn.Text = "Connect";
            this.Connect_Btn.UseVisualStyleBackColor = true;
            this.Connect_Btn.Click += new System.EventHandler(this.Connect_Btn_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 214);
            this.Controls.Add(this.Connect_Btn);
            this.Controls.Add(this.HostNametextBox);
            this.Controls.Add(this.Acc_NotextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Acc_Nolabel);
            this.Name = "LoginForm";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Acc_Nolabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Acc_NotextBox;
        private System.Windows.Forms.TextBox HostNametextBox;
        private System.Windows.Forms.Button Connect_Btn;
    }
}

