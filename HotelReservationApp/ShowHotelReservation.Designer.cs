
namespace HotelReservationApp
{
    partial class ShowHotelReservation
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
            this.CurrentResvlabel = new System.Windows.Forms.Label();
            this.CurrentResvlistBox = new System.Windows.Forms.ListBox();
            this.LayOutlabel = new System.Windows.Forms.Label();
            this.Floorlabel = new System.Windows.Forms.Label();
            this.FloorcomboBox = new System.Windows.Forms.ComboBox();
            this.Roomlabel = new System.Windows.Forms.Label();
            this.RoomcomboBox = new System.Windows.Forms.ComboBox();
            this.Reservebutton = new System.Windows.Forms.Button();
            this.CancelReservebutton = new System.Windows.Forms.Button();
            this.Refreshbutton = new System.Windows.Forms.Button();
            this.SelectedRoomlabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CurrentResvlabel
            // 
            this.CurrentResvlabel.AutoSize = true;
            this.CurrentResvlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentResvlabel.Location = new System.Drawing.Point(12, 23);
            this.CurrentResvlabel.Name = "CurrentResvlabel";
            this.CurrentResvlabel.Size = new System.Drawing.Size(168, 20);
            this.CurrentResvlabel.TabIndex = 0;
            this.CurrentResvlabel.Text = "Current Reservations";
            // 
            // CurrentResvlistBox
            // 
            this.CurrentResvlistBox.FormattingEnabled = true;
            this.CurrentResvlistBox.HorizontalScrollbar = true;
            this.CurrentResvlistBox.ItemHeight = 16;
            this.CurrentResvlistBox.Location = new System.Drawing.Point(16, 68);
            this.CurrentResvlistBox.Name = "CurrentResvlistBox";
            this.CurrentResvlistBox.Size = new System.Drawing.Size(488, 372);
            this.CurrentResvlistBox.TabIndex = 1;
            this.CurrentResvlistBox.Click += new System.EventHandler(this.CurrentResvlistBox_Click);
            // 
            // LayOutlabel
            // 
            this.LayOutlabel.AutoSize = true;
            this.LayOutlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LayOutlabel.Location = new System.Drawing.Point(525, 23);
            this.LayOutlabel.Name = "LayOutlabel";
            this.LayOutlabel.Size = new System.Drawing.Size(53, 20);
            this.LayOutlabel.TabIndex = 2;
            this.LayOutlabel.Text = "label1";
            // 
            // Floorlabel
            // 
            this.Floorlabel.AutoSize = true;
            this.Floorlabel.Location = new System.Drawing.Point(526, 54);
            this.Floorlabel.Name = "Floorlabel";
            this.Floorlabel.Size = new System.Drawing.Size(40, 17);
            this.Floorlabel.TabIndex = 3;
            this.Floorlabel.Text = "Floor";
            // 
            // FloorcomboBox
            // 
            this.FloorcomboBox.FormattingEnabled = true;
            this.FloorcomboBox.Location = new System.Drawing.Point(529, 86);
            this.FloorcomboBox.Name = "FloorcomboBox";
            this.FloorcomboBox.Size = new System.Drawing.Size(71, 24);
            this.FloorcomboBox.TabIndex = 4;
            this.FloorcomboBox.SelectedValueChanged += new System.EventHandler(this.FloorcomboBox_SelectedValueChanged);
            // 
            // Roomlabel
            // 
            this.Roomlabel.AutoSize = true;
            this.Roomlabel.Location = new System.Drawing.Point(638, 54);
            this.Roomlabel.Name = "Roomlabel";
            this.Roomlabel.Size = new System.Drawing.Size(45, 17);
            this.Roomlabel.TabIndex = 5;
            this.Roomlabel.Text = "Room";
            // 
            // RoomcomboBox
            // 
            this.RoomcomboBox.FormattingEnabled = true;
            this.RoomcomboBox.Location = new System.Drawing.Point(641, 86);
            this.RoomcomboBox.Name = "RoomcomboBox";
            this.RoomcomboBox.Size = new System.Drawing.Size(71, 24);
            this.RoomcomboBox.TabIndex = 6;
            this.RoomcomboBox.SelectedValueChanged += new System.EventHandler(this.RoomcomboBox_SelectedValueChanged);
            // 
            // Reservebutton
            // 
            this.Reservebutton.Enabled = false;
            this.Reservebutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Reservebutton.Location = new System.Drawing.Point(754, 79);
            this.Reservebutton.Name = "Reservebutton";
            this.Reservebutton.Size = new System.Drawing.Size(111, 35);
            this.Reservebutton.TabIndex = 7;
            this.Reservebutton.Text = "Reserve";
            this.Reservebutton.UseVisualStyleBackColor = true;
            this.Reservebutton.Click += new System.EventHandler(this.Reservebutton_Click);
            // 
            // CancelReservebutton
            // 
            this.CancelReservebutton.Enabled = false;
            this.CancelReservebutton.Location = new System.Drawing.Point(529, 337);
            this.CancelReservebutton.Name = "CancelReservebutton";
            this.CancelReservebutton.Size = new System.Drawing.Size(336, 32);
            this.CancelReservebutton.TabIndex = 8;
            this.CancelReservebutton.Text = "Cancel Rooms Reservation";
            this.CancelReservebutton.UseVisualStyleBackColor = true;
            this.CancelReservebutton.Click += new System.EventHandler(this.CancelReservebutton_Click);
            // 
            // Refreshbutton
            // 
            this.Refreshbutton.Location = new System.Drawing.Point(529, 397);
            this.Refreshbutton.Name = "Refreshbutton";
            this.Refreshbutton.Size = new System.Drawing.Size(336, 32);
            this.Refreshbutton.TabIndex = 9;
            this.Refreshbutton.Text = "Refresh Reservation";
            this.Refreshbutton.UseVisualStyleBackColor = true;
            this.Refreshbutton.Click += new System.EventHandler(this.Refreshbutton_Click);
            // 
            // SelectedRoomlabel
            // 
            this.SelectedRoomlabel.AutoSize = true;
            this.SelectedRoomlabel.Location = new System.Drawing.Point(532, 141);
            this.SelectedRoomlabel.Name = "SelectedRoomlabel";
            this.SelectedRoomlabel.Size = new System.Drawing.Size(46, 17);
            this.SelectedRoomlabel.TabIndex = 10;
            this.SelectedRoomlabel.Text = "label1";
            // 
            // ShowHotelReservation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 455);
            this.Controls.Add(this.SelectedRoomlabel);
            this.Controls.Add(this.Refreshbutton);
            this.Controls.Add(this.CancelReservebutton);
            this.Controls.Add(this.Reservebutton);
            this.Controls.Add(this.RoomcomboBox);
            this.Controls.Add(this.Roomlabel);
            this.Controls.Add(this.FloorcomboBox);
            this.Controls.Add(this.Floorlabel);
            this.Controls.Add(this.LayOutlabel);
            this.Controls.Add(this.CurrentResvlistBox);
            this.Controls.Add(this.CurrentResvlabel);
            this.Name = "ShowHotelReservation";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ShowHotelReservation_FormClosed);
            this.Load += new System.EventHandler(this.ShowHotelReservation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CurrentResvlabel;
        private System.Windows.Forms.ListBox CurrentResvlistBox;
        private System.Windows.Forms.Label LayOutlabel;
        private System.Windows.Forms.Label Floorlabel;
        private System.Windows.Forms.ComboBox FloorcomboBox;
        private System.Windows.Forms.Label Roomlabel;
        private System.Windows.Forms.ComboBox RoomcomboBox;
        private System.Windows.Forms.Button Reservebutton;
        private System.Windows.Forms.Button CancelReservebutton;
        private System.Windows.Forms.Button Refreshbutton;
        private System.Windows.Forms.Label SelectedRoomlabel;
    }
}