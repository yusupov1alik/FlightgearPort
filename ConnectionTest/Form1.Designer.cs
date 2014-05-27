namespace ConnectionTest
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.CreateConnectionButton = new System.Windows.Forms.Button();
            this.Cloack = new System.Windows.Forms.Timer(this.components);
            this.CordBox = new System.Windows.Forms.GroupBox();
            this.LRoll = new System.Windows.Forms.Label();
            this.LPitch = new System.Windows.Forms.Label();
            this.LYaw = new System.Windows.Forms.Label();
            this.LAlt = new System.Windows.Forms.Label();
            this.LLat = new System.Windows.Forms.Label();
            this.LLong = new System.Windows.Forms.Label();
            this.TBRoll = new System.Windows.Forms.TextBox();
            this.TBPitch = new System.Windows.Forms.TextBox();
            this.TBYaw = new System.Windows.Forms.TextBox();
            this.TBAlt = new System.Windows.Forms.TextBox();
            this.TBLat = new System.Windows.Forms.TextBox();
            this.TBLong = new System.Windows.Forms.TextBox();
            this.LZ = new System.Windows.Forms.Label();
            this.TBZ = new System.Windows.Forms.TextBox();
            this.LY = new System.Windows.Forms.Label();
            this.TBY = new System.Windows.Forms.TextBox();
            this.LX = new System.Windows.Forms.Label();
            this.TBX = new System.Windows.Forms.TextBox();
            this.LVz = new System.Windows.Forms.Label();
            this.TBVz = new System.Windows.Forms.TextBox();
            this.LVy = new System.Windows.Forms.Label();
            this.TBVy = new System.Windows.Forms.TextBox();
            this.LVx = new System.Windows.Forms.Label();
            this.TBVx = new System.Windows.Forms.TextBox();
            this.RunFlightGearButton = new System.Windows.Forms.Button();
            this.BreakConnectionButton = new System.Windows.Forms.Button();
            this.PauseButton = new System.Windows.Forms.Button();
            this.ChangeFolderButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TBFy = new System.Windows.Forms.TextBox();
            this.LFx = new System.Windows.Forms.Label();
            this.LFy = new System.Windows.Forms.Label();
            this.TBFx = new System.Windows.Forms.TextBox();
            this.TBFz = new System.Windows.Forms.TextBox();
            this.LFz = new System.Windows.Forms.Label();
            this.CordBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CreateConnectionButton
            // 
            this.CreateConnectionButton.Location = new System.Drawing.Point(331, 60);
            this.CreateConnectionButton.Name = "CreateConnectionButton";
            this.CreateConnectionButton.Size = new System.Drawing.Size(108, 23);
            this.CreateConnectionButton.TabIndex = 0;
            this.CreateConnectionButton.Text = "CreateConnection";
            this.CreateConnectionButton.UseVisualStyleBackColor = true;
            this.CreateConnectionButton.Click += new System.EventHandler(this.CreateConnectionEventHandler);
            // 
            // Cloack
            // 
            this.Cloack.Tick += new System.EventHandler(this.CloackEventHandler);
            // 
            // CordBox
            // 
            this.CordBox.Controls.Add(this.LRoll);
            this.CordBox.Controls.Add(this.LPitch);
            this.CordBox.Controls.Add(this.LYaw);
            this.CordBox.Controls.Add(this.LAlt);
            this.CordBox.Controls.Add(this.LLat);
            this.CordBox.Controls.Add(this.LLong);
            this.CordBox.Controls.Add(this.TBRoll);
            this.CordBox.Controls.Add(this.TBPitch);
            this.CordBox.Controls.Add(this.TBYaw);
            this.CordBox.Controls.Add(this.TBAlt);
            this.CordBox.Controls.Add(this.TBLat);
            this.CordBox.Controls.Add(this.TBLong);
            this.CordBox.Location = new System.Drawing.Point(12, 12);
            this.CordBox.Name = "CordBox";
            this.CordBox.Size = new System.Drawing.Size(150, 203);
            this.CordBox.TabIndex = 1;
            this.CordBox.TabStop = false;
            this.CordBox.Text = "SendingData";
            // 
            // LRoll
            // 
            this.LRoll.AutoSize = true;
            this.LRoll.Location = new System.Drawing.Point(10, 173);
            this.LRoll.Name = "LRoll";
            this.LRoll.Size = new System.Drawing.Size(25, 13);
            this.LRoll.TabIndex = 10;
            this.LRoll.Text = "Roll";
            // 
            // LPitch
            // 
            this.LPitch.AutoSize = true;
            this.LPitch.Location = new System.Drawing.Point(10, 143);
            this.LPitch.Name = "LPitch";
            this.LPitch.Size = new System.Drawing.Size(31, 13);
            this.LPitch.TabIndex = 9;
            this.LPitch.Text = "Pitch";
            // 
            // LYaw
            // 
            this.LYaw.AutoSize = true;
            this.LYaw.Location = new System.Drawing.Point(10, 113);
            this.LYaw.Name = "LYaw";
            this.LYaw.Size = new System.Drawing.Size(28, 13);
            this.LYaw.TabIndex = 8;
            this.LYaw.Text = "Yaw";
            // 
            // LAlt
            // 
            this.LAlt.AutoSize = true;
            this.LAlt.Location = new System.Drawing.Point(10, 83);
            this.LAlt.Name = "LAlt";
            this.LAlt.Size = new System.Drawing.Size(19, 13);
            this.LAlt.TabIndex = 7;
            this.LAlt.Text = "Alt";
            // 
            // LLat
            // 
            this.LLat.AutoSize = true;
            this.LLat.Location = new System.Drawing.Point(10, 53);
            this.LLat.Name = "LLat";
            this.LLat.Size = new System.Drawing.Size(22, 13);
            this.LLat.TabIndex = 6;
            this.LLat.Text = "Lat";
            // 
            // LLong
            // 
            this.LLong.AutoSize = true;
            this.LLong.Location = new System.Drawing.Point(10, 23);
            this.LLong.Name = "LLong";
            this.LLong.Size = new System.Drawing.Size(31, 13);
            this.LLong.TabIndex = 2;
            this.LLong.Text = "Long";
            // 
            // TBRoll
            // 
            this.TBRoll.Enabled = false;
            this.TBRoll.Location = new System.Drawing.Point(40, 170);
            this.TBRoll.Name = "TBRoll";
            this.TBRoll.Size = new System.Drawing.Size(100, 20);
            this.TBRoll.TabIndex = 5;
            // 
            // TBPitch
            // 
            this.TBPitch.Enabled = false;
            this.TBPitch.Location = new System.Drawing.Point(40, 140);
            this.TBPitch.Name = "TBPitch";
            this.TBPitch.Size = new System.Drawing.Size(100, 20);
            this.TBPitch.TabIndex = 4;
            // 
            // TBYaw
            // 
            this.TBYaw.Enabled = false;
            this.TBYaw.Location = new System.Drawing.Point(40, 110);
            this.TBYaw.Name = "TBYaw";
            this.TBYaw.Size = new System.Drawing.Size(100, 20);
            this.TBYaw.TabIndex = 3;
            // 
            // TBAlt
            // 
            this.TBAlt.Enabled = false;
            this.TBAlt.Location = new System.Drawing.Point(40, 80);
            this.TBAlt.Name = "TBAlt";
            this.TBAlt.Size = new System.Drawing.Size(100, 20);
            this.TBAlt.TabIndex = 2;
            // 
            // TBLat
            // 
            this.TBLat.Enabled = false;
            this.TBLat.Location = new System.Drawing.Point(40, 50);
            this.TBLat.Name = "TBLat";
            this.TBLat.Size = new System.Drawing.Size(100, 20);
            this.TBLat.TabIndex = 1;
            // 
            // TBLong
            // 
            this.TBLong.Enabled = false;
            this.TBLong.Location = new System.Drawing.Point(40, 20);
            this.TBLong.Name = "TBLong";
            this.TBLong.Size = new System.Drawing.Size(100, 20);
            this.TBLong.TabIndex = 0;
            // 
            // LZ
            // 
            this.LZ.AutoSize = true;
            this.LZ.Location = new System.Drawing.Point(13, 83);
            this.LZ.Name = "LZ";
            this.LZ.Size = new System.Drawing.Size(14, 13);
            this.LZ.TabIndex = 22;
            this.LZ.Text = "Z";
            // 
            // TBZ
            // 
            this.TBZ.Enabled = false;
            this.TBZ.Location = new System.Drawing.Point(43, 80);
            this.TBZ.Name = "TBZ";
            this.TBZ.Size = new System.Drawing.Size(100, 20);
            this.TBZ.TabIndex = 21;
            // 
            // LY
            // 
            this.LY.AutoSize = true;
            this.LY.Location = new System.Drawing.Point(13, 53);
            this.LY.Name = "LY";
            this.LY.Size = new System.Drawing.Size(14, 13);
            this.LY.TabIndex = 20;
            this.LY.Text = "Y";
            // 
            // TBY
            // 
            this.TBY.Enabled = false;
            this.TBY.Location = new System.Drawing.Point(43, 50);
            this.TBY.Name = "TBY";
            this.TBY.Size = new System.Drawing.Size(100, 20);
            this.TBY.TabIndex = 19;
            // 
            // LX
            // 
            this.LX.AutoSize = true;
            this.LX.Location = new System.Drawing.Point(13, 23);
            this.LX.Name = "LX";
            this.LX.Size = new System.Drawing.Size(14, 13);
            this.LX.TabIndex = 18;
            this.LX.Text = "X";
            // 
            // TBX
            // 
            this.TBX.Enabled = false;
            this.TBX.Location = new System.Drawing.Point(43, 20);
            this.TBX.Name = "TBX";
            this.TBX.Size = new System.Drawing.Size(100, 20);
            this.TBX.TabIndex = 17;
            // 
            // LVz
            // 
            this.LVz.AutoSize = true;
            this.LVz.Location = new System.Drawing.Point(13, 173);
            this.LVz.Name = "LVz";
            this.LVz.Size = new System.Drawing.Size(19, 13);
            this.LVz.TabIndex = 16;
            this.LVz.Text = "Vz";
            // 
            // TBVz
            // 
            this.TBVz.Enabled = false;
            this.TBVz.Location = new System.Drawing.Point(43, 170);
            this.TBVz.Name = "TBVz";
            this.TBVz.Size = new System.Drawing.Size(100, 20);
            this.TBVz.TabIndex = 15;
            // 
            // LVy
            // 
            this.LVy.AutoSize = true;
            this.LVy.Location = new System.Drawing.Point(13, 143);
            this.LVy.Name = "LVy";
            this.LVy.Size = new System.Drawing.Size(19, 13);
            this.LVy.TabIndex = 14;
            this.LVy.Text = "Vy";
            // 
            // TBVy
            // 
            this.TBVy.Enabled = false;
            this.TBVy.Location = new System.Drawing.Point(43, 140);
            this.TBVy.Name = "TBVy";
            this.TBVy.Size = new System.Drawing.Size(100, 20);
            this.TBVy.TabIndex = 13;
            // 
            // LVx
            // 
            this.LVx.AutoSize = true;
            this.LVx.Location = new System.Drawing.Point(13, 113);
            this.LVx.Name = "LVx";
            this.LVx.Size = new System.Drawing.Size(19, 13);
            this.LVx.TabIndex = 12;
            this.LVx.Text = "Vx";
            // 
            // TBVx
            // 
            this.TBVx.Enabled = false;
            this.TBVx.Location = new System.Drawing.Point(43, 110);
            this.TBVx.Name = "TBVx";
            this.TBVx.Size = new System.Drawing.Size(100, 20);
            this.TBVx.TabIndex = 11;
            // 
            // RunFlightGearButton
            // 
            this.RunFlightGearButton.Location = new System.Drawing.Point(331, 150);
            this.RunFlightGearButton.Name = "RunFlightGearButton";
            this.RunFlightGearButton.Size = new System.Drawing.Size(108, 23);
            this.RunFlightGearButton.TabIndex = 2;
            this.RunFlightGearButton.Text = "Run FlightGear";
            this.RunFlightGearButton.UseVisualStyleBackColor = true;
            this.RunFlightGearButton.Click += new System.EventHandler(this.RunFlightGear);
            // 
            // BreakConnectionButton
            // 
            this.BreakConnectionButton.Location = new System.Drawing.Point(331, 105);
            this.BreakConnectionButton.Name = "BreakConnectionButton";
            this.BreakConnectionButton.Size = new System.Drawing.Size(108, 23);
            this.BreakConnectionButton.TabIndex = 3;
            this.BreakConnectionButton.Text = "Break connection";
            this.BreakConnectionButton.UseVisualStyleBackColor = true;
            this.BreakConnectionButton.Click += new System.EventHandler(this.BreakConnectionEventHandler);
            // 
            // PauseButton
            // 
            this.PauseButton.Location = new System.Drawing.Point(331, 195);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(108, 23);
            this.PauseButton.TabIndex = 5;
            this.PauseButton.Text = "Pause/Play";
            this.PauseButton.UseVisualStyleBackColor = true;
            this.PauseButton.Click += new System.EventHandler(this.Pause_Click);
            // 
            // ChangeFolderButton
            // 
            this.ChangeFolderButton.Location = new System.Drawing.Point(12, 245);
            this.ChangeFolderButton.Name = "ChangeFolderButton";
            this.ChangeFolderButton.Size = new System.Drawing.Size(136, 23);
            this.ChangeFolderButton.TabIndex = 6;
            this.ChangeFolderButton.Text = "Change FlightGear Folder";
            this.ChangeFolderButton.UseVisualStyleBackColor = true;
            this.ChangeFolderButton.Click += new System.EventHandler(this.ChooseNewFolder);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TBFy);
            this.groupBox1.Controls.Add(this.LFx);
            this.groupBox1.Controls.Add(this.LFy);
            this.groupBox1.Controls.Add(this.TBFx);
            this.groupBox1.Controls.Add(this.TBFz);
            this.groupBox1.Controls.Add(this.LFz);
            this.groupBox1.Controls.Add(this.TBZ);
            this.groupBox1.Controls.Add(this.LZ);
            this.groupBox1.Controls.Add(this.TBVy);
            this.groupBox1.Controls.Add(this.LVx);
            this.groupBox1.Controls.Add(this.LVy);
            this.groupBox1.Controls.Add(this.LY);
            this.groupBox1.Controls.Add(this.TBVx);
            this.groupBox1.Controls.Add(this.TBVz);
            this.groupBox1.Controls.Add(this.TBY);
            this.groupBox1.Controls.Add(this.LVz);
            this.groupBox1.Controls.Add(this.TBX);
            this.groupBox1.Controls.Add(this.LX);
            this.groupBox1.Location = new System.Drawing.Point(175, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(150, 290);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dynamic";
            // 
            // TBFy
            // 
            this.TBFy.Enabled = false;
            this.TBFy.Location = new System.Drawing.Point(43, 230);
            this.TBFy.Name = "TBFy";
            this.TBFy.Size = new System.Drawing.Size(100, 20);
            this.TBFy.TabIndex = 25;
            // 
            // LFx
            // 
            this.LFx.AutoSize = true;
            this.LFx.Location = new System.Drawing.Point(13, 203);
            this.LFx.Name = "LFx";
            this.LFx.Size = new System.Drawing.Size(18, 13);
            this.LFx.TabIndex = 24;
            this.LFx.Text = "Fx";
            // 
            // LFy
            // 
            this.LFy.AutoSize = true;
            this.LFy.Location = new System.Drawing.Point(13, 233);
            this.LFy.Name = "LFy";
            this.LFy.Size = new System.Drawing.Size(18, 13);
            this.LFy.TabIndex = 26;
            this.LFy.Text = "Fy";
            // 
            // TBFx
            // 
            this.TBFx.Enabled = false;
            this.TBFx.Location = new System.Drawing.Point(43, 200);
            this.TBFx.Name = "TBFx";
            this.TBFx.Size = new System.Drawing.Size(100, 20);
            this.TBFx.TabIndex = 23;
            // 
            // TBFz
            // 
            this.TBFz.Enabled = false;
            this.TBFz.Location = new System.Drawing.Point(43, 260);
            this.TBFz.Name = "TBFz";
            this.TBFz.Size = new System.Drawing.Size(100, 20);
            this.TBFz.TabIndex = 27;
            // 
            // LFz
            // 
            this.LFz.AutoSize = true;
            this.LFz.Location = new System.Drawing.Point(13, 263);
            this.LFz.Name = "LFz";
            this.LFz.Size = new System.Drawing.Size(18, 13);
            this.LFz.TabIndex = 28;
            this.LFz.Text = "Fz";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 315);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ChangeFolderButton);
            this.Controls.Add(this.PauseButton);
            this.Controls.Add(this.BreakConnectionButton);
            this.Controls.Add(this.RunFlightGearButton);
            this.Controls.Add(this.CordBox);
            this.Controls.Add(this.CreateConnectionButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "UAV control";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.CordBox.ResumeLayout(false);
            this.CordBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CreateConnectionButton;
        private System.Windows.Forms.Timer Cloack;
        private System.Windows.Forms.GroupBox CordBox;
        private System.Windows.Forms.TextBox TBLong;
        private System.Windows.Forms.Label LRoll;
        private System.Windows.Forms.Label LPitch;
        private System.Windows.Forms.Label LYaw;
        private System.Windows.Forms.Label LAlt;
        private System.Windows.Forms.Label LLat;
        private System.Windows.Forms.Label LLong;
        private System.Windows.Forms.TextBox TBRoll;
        private System.Windows.Forms.TextBox TBPitch;
        private System.Windows.Forms.TextBox TBYaw;
        private System.Windows.Forms.TextBox TBAlt;
        private System.Windows.Forms.TextBox TBLat;
        private System.Windows.Forms.Button RunFlightGearButton;
        private System.Windows.Forms.Button BreakConnectionButton;
        private System.Windows.Forms.Button PauseButton;
        private System.Windows.Forms.Button ChangeFolderButton;
        private System.Windows.Forms.Label LVz;
        private System.Windows.Forms.TextBox TBVz;
        private System.Windows.Forms.Label LVy;
        private System.Windows.Forms.TextBox TBVy;
        private System.Windows.Forms.Label LVx;
        private System.Windows.Forms.TextBox TBVx;
        private System.Windows.Forms.Label LZ;
        private System.Windows.Forms.TextBox TBZ;
        private System.Windows.Forms.Label LY;
        private System.Windows.Forms.TextBox TBY;
        private System.Windows.Forms.Label LX;
        private System.Windows.Forms.TextBox TBX;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TBFy;
        private System.Windows.Forms.Label LFx;
        private System.Windows.Forms.Label LFy;
        private System.Windows.Forms.TextBox TBFx;
        private System.Windows.Forms.TextBox TBFz;
        private System.Windows.Forms.Label LFz;
    }
}

