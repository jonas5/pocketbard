namespace BardSongHelper_WF
{
    partial class Form1
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
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Select_POLID = new System.Windows.Forms.Button();
            this.POLID = new MetroFramework.Controls.MetroComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SongGroup1_Song1_ComboBox = new MetroFramework.Controls.MetroComboBox();
            this.SongGroup1_Song2_ComboBox = new MetroFramework.Controls.MetroComboBox();
            this.SongGroup1_Timer1_Label = new System.Windows.Forms.Label();
            this.SongGroup1_Timer2_Label = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.SongStatus_Label = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.AddonActive = new System.Windows.Forms.Button();
            this.ActivityButton = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.ReloadParty = new System.Windows.Forms.Button();
            this.PartyMembersGroup1_ListBox = new System.Windows.Forms.ListBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.FollowerTarget = new MetroFramework.Controls.MetroTextBox();
            this.Song_Timer = new System.Windows.Forms.Timer(this.components);
            this.Follow_Timer = new System.Windows.Forms.Timer(this.components);
            this.AddonReader = new System.ComponentModel.BackgroundWorker();
            this.metroToolTip1 = new MetroFramework.Components.MetroToolTip();
            this.DEBUG = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.PauseOnZone_Switch = new MetroFramework.Controls.MetroToggle();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.PauseTimersChecks = new System.Windows.Forms.Timer(this.components);
            this.groupBoxSongGroup2 = new System.Windows.Forms.GroupBox();
            this.SongGroup2_Song1_ComboBox = new MetroFramework.Controls.MetroComboBox();
            this.SongGroup2_Song2_ComboBox = new MetroFramework.Controls.MetroComboBox();
            this.SongGroup2_Timer1_Label = new System.Windows.Forms.Label();
            this.SongGroup2_Timer2_Label = new System.Windows.Forms.Label();
            this.groupBoxPartyGroup2 = new System.Windows.Forms.GroupBox();
            this.PartyMembersGroup2_ListBox = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBoxSongGroup2.SuspendLayout();
            this.groupBoxPartyGroup2.SuspendLayout();
            this.SuspendLayout();





            //
            // groupBox1
            //
            this.groupBox1.Controls.Add(this.Select_POLID);
            this.groupBox1.Controls.Add(this.POLID);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(11, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(397, 55);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " SELECT PROCESS ";
            //
            // Select_POLID
            //
            this.Select_POLID.Location = new System.Drawing.Point(280, 15);
            this.Select_POLID.Name = "Select_POLID";
            this.Select_POLID.Size = new System.Drawing.Size(111, 31);
            this.Select_POLID.TabIndex = 3;
            this.Select_POLID.Text = "SELECT";
            this.Select_POLID.UseVisualStyleBackColor = true;
            this.Select_POLID.Click += new System.EventHandler(this.Select_POLID_Click);
            //
            // POLID
            //
            this.POLID.FormattingEnabled = true;
            this.POLID.ItemHeight = 23;
            this.POLID.Location = new System.Drawing.Point(7, 16);
            this.POLID.Name = "POLID";
            this.POLID.Size = new System.Drawing.Size(266, 29);
            this.POLID.TabIndex = 2;
            this.POLID.UseSelectable = true;
            //
            // groupBox2
            //
            this.groupBox2.Controls.Add(this.SongGroup1_Song1_ComboBox);
            this.groupBox2.Controls.Add(this.SongGroup1_Song2_ComboBox);
            this.groupBox2.Controls.Add(this.SongGroup1_Timer1_Label);
            this.groupBox2.Controls.Add(this.SongGroup1_Timer2_Label);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(11, 124);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(300, 94);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " SONG GROUP 1 ";



            //
            // SongGroup1_Song1_ComboBox
            //
            this.SongGroup1_Song1_ComboBox.FormattingEnabled = true;
            this.SongGroup1_Song1_ComboBox.ItemHeight = 23;
            this.SongGroup1_Song1_ComboBox.Items.AddRange(new object[] {
            "Corsair\'s Roll ", "Ninja Roll ", "Hunter\'s Roll ", "Chaos Roll ", "Magus\'s Roll ", "Healer\'s Roll ", "Drachen Roll ", "Choral Roll ", "Monk\'s Roll ", "Beast Roll ", "Samurai Roll ", "Evoker\'s Roll ", "Rogue\'s Roll ", "Warlock\'s Roll ", "Fighter\'s Roll ", "Puppet Roll ", "Gallant\'s Roll ", "Wizard\'s Roll ", "Dancer\'s Roll ", "Scholar\'s Roll ", "Naturalist\'s Roll ", "Runeist\'s Roll ", "Bolter\'s Roll ", "Caster\'s Roll ", "Courser\'s Roll ", "Blitzer\'s Roll ", "Tactician\'s Roll ", "Allies\' Roll ", "Miser\'s Roll ", "Companion\'s Roll ", "Avenger\'s Roll "});
            this.SongGroup1_Song1_ComboBox.Location = new System.Drawing.Point(6, 19);
            this.SongGroup1_Song1_ComboBox.MaxDropDownItems = 5;
            this.SongGroup1_Song1_ComboBox.Name = "SongGroup1_Song1_ComboBox";
            this.SongGroup1_Song1_ComboBox.Size = new System.Drawing.Size(227, 29);
            this.SongGroup1_Song1_ComboBox.TabIndex = 2;
            this.SongGroup1_Song1_ComboBox.UseSelectable = true;
            //
            // SongGroup1_Song2_ComboBox
            //
            this.SongGroup1_Song2_ComboBox.FormattingEnabled = true;
            this.SongGroup1_Song2_ComboBox.ItemHeight = 23;
            this.SongGroup1_Song2_ComboBox.Items.AddRange(new object[] {
            "Corsair\'s Roll ", "Ninja Roll ", "Hunter\'s Roll ", "Chaos Roll ", "Magus\'s Roll ", "Healer\'s Roll ", "Drachen Roll ", "Choral Roll ", "Monk\'s Roll ", "Beast Roll ", "Samurai Roll ", "Evoker\'s Roll ", "Rogue\'s Roll ", "Warlock\'s Roll ", "Fighter\'s Roll ", "Puppet Roll ", "Gallant\'s Roll ", "Wizard\'s Roll ", "Dancer\'s Roll ", "Scholar\'s Roll ", "Naturalist\'s Roll ", "Runeist\'s Roll ", "Bolter\'s Roll ", "Caster\'s Roll ", "Courser\'s Roll ", "Blitzer\'s Roll ", "Tactician\'s Roll ", "Allies\' Roll ", "Miser\'s Roll ", "Companion\'s Roll ", "Avenger\'s Roll "});
            this.SongGroup1_Song2_ComboBox.Location = new System.Drawing.Point(7, 55);
            this.SongGroup1_Song2_ComboBox.MaxDropDownItems = 5;
            this.SongGroup1_Song2_ComboBox.Name = "SongGroup1_Song2_ComboBox";
            this.SongGroup1_Song2_ComboBox.Size = new System.Drawing.Size(226, 29);
            this.SongGroup1_Song2_ComboBox.TabIndex = 3;
            this.SongGroup1_Song2_ComboBox.UseSelectable = true;
            //
            // SongGroup1_Timer1_Label
            //
            this.SongGroup1_Timer1_Label.Location = new System.Drawing.Point(238, 24);
            this.SongGroup1_Timer1_Label.Name = "SongGroup1_Timer1_Label";
            this.SongGroup1_Timer1_Label.Size = new System.Drawing.Size(50, 23);
            this.SongGroup1_Timer1_Label.TabIndex = 4;
            this.SongGroup1_Timer1_Label.Text = "00:00";
            //
            // SongGroup1_Timer2_Label
            //
            this.SongGroup1_Timer2_Label.Location = new System.Drawing.Point(238, 60);
            this.SongGroup1_Timer2_Label.Name = "SongGroup1_Timer2_Label";
            this.SongGroup1_Timer2_Label.Size = new System.Drawing.Size(50, 23);
            this.SongGroup1_Timer2_Label.TabIndex = 5;
            this.SongGroup1_Timer2_Label.Text = "00:00";
            //
            // groupBox3
            //
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(11, 224);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(239, 50);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = " BARD OPTIONS (Group 1) ";
            //
            // groupBoxSongGroup2
            //
            this.groupBoxSongGroup2.Controls.Add(this.SongGroup2_Song1_ComboBox);
            this.groupBoxSongGroup2.Controls.Add(this.SongGroup2_Song2_ComboBox);
            this.groupBoxSongGroup2.Controls.Add(this.SongGroup2_Timer1_Label);
            this.groupBoxSongGroup2.Controls.Add(this.SongGroup2_Timer2_Label);
            this.groupBoxSongGroup2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxSongGroup2.Location = new System.Drawing.Point(11, 280);
            this.groupBoxSongGroup2.Name = "groupBoxSongGroup2";
            this.groupBoxSongGroup2.Size = new System.Drawing.Size(300, 94);
            this.groupBoxSongGroup2.TabIndex = 11;
            this.groupBoxSongGroup2.TabStop = false;
            this.groupBoxSongGroup2.Text = " SONG GROUP 2 ";
            //
            // SongGroup2_Song1_ComboBox
            //
            this.SongGroup2_Song1_ComboBox.FormattingEnabled = true;
            this.SongGroup2_Song1_ComboBox.ItemHeight = 23;
            this.SongGroup2_Song1_ComboBox.Location = new System.Drawing.Point(6, 19);
            this.SongGroup2_Song1_ComboBox.MaxDropDownItems = 5;
            this.SongGroup2_Song1_ComboBox.Name = "SongGroup2_Song1_ComboBox";
            this.SongGroup2_Song1_ComboBox.Size = new System.Drawing.Size(227, 29);
            this.SongGroup2_Song1_ComboBox.TabIndex = 2;
            this.SongGroup2_Song1_ComboBox.UseSelectable = true;
            //
            // SongGroup2_Song2_ComboBox
            //
            this.SongGroup2_Song2_ComboBox.FormattingEnabled = true;
            this.SongGroup2_Song2_ComboBox.ItemHeight = 23;
            this.SongGroup2_Song2_ComboBox.Location = new System.Drawing.Point(7, 55);
            this.SongGroup2_Song2_ComboBox.MaxDropDownItems = 5;
            this.SongGroup2_Song2_ComboBox.Name = "SongGroup2_Song2_ComboBox";
            this.SongGroup2_Song2_ComboBox.Size = new System.Drawing.Size(226, 29);
            this.SongGroup2_Song2_ComboBox.TabIndex = 3;
            this.SongGroup2_Song2_ComboBox.UseSelectable = true;
            //
            // SongGroup2_Timer1_Label
            //
            this.SongGroup2_Timer1_Label.Location = new System.Drawing.Point(238, 24);
            this.SongGroup2_Timer1_Label.Name = "SongGroup2_Timer1_Label";
            this.SongGroup2_Timer1_Label.Size = new System.Drawing.Size(50, 23);
            this.SongGroup2_Timer1_Label.TabIndex = 4;
            this.SongGroup2_Timer1_Label.Text = "00:00";
            //
            // SongGroup2_Timer2_Label
            //
            this.SongGroup2_Timer2_Label.Location = new System.Drawing.Point(238, 60);
            this.SongGroup2_Timer2_Label.Name = "SongGroup2_Timer2_Label";
            this.SongGroup2_Timer2_Label.Size = new System.Drawing.Size(50, 23);
            this.SongGroup2_Timer2_Label.TabIndex = 5;
            this.SongGroup2_Timer2_Label.Text = "00:00";
            //
            // groupBoxPartyGroup2
            //
            
            this.groupBoxPartyGroup2.Controls.Add(this.ReloadParty);
            this.groupBoxPartyGroup2.Controls.Add(this.PartyMembersGroup2_ListBox);
            this.groupBoxPartyGroup2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxPartyGroup2.Location = new System.Drawing.Point(317, 280);
            this.groupBoxPartyGroup2.Name = "groupBoxPartyGroup2";
            this.groupBoxPartyGroup2.Size = new System.Drawing.Size(152, 210);
            this.groupBoxPartyGroup2.TabIndex = 12;
            this.groupBoxPartyGroup2.TabStop = false;
            this.groupBoxPartyGroup2.Text = " GROUP 2 TARGETS ";
            //
            // PartyMembersGroup2_ListBox
            //
            this.PartyMembersGroup2_ListBox.FormattingEnabled = true;
            this.PartyMembersGroup2_ListBox.ItemHeight = 12;
            this.PartyMembersGroup2_ListBox.Location = new System.Drawing.Point(6, 19);
            this.PartyMembersGroup2_ListBox.Name = "PartyMembersGroup2_ListBox";
            this.PartyMembersGroup2_ListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.PartyMembersGroup2_ListBox.Size = new System.Drawing.Size(136, 148);
            this.PartyMembersGroup2_ListBox.TabIndex = 0;
            this.PartyMembersGroup2_ListBox.SelectedValueChanged += new System.EventHandler(this.PartyMembersGroup2_ListBox_SelectedValueChanged);




            //
            // groupBox6
            //
            this.groupBox6.Controls.Add(this.PartyMembersGroup1_ListBox);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(317, 124);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(152, 210);
            this.groupBox6.TabIndex = 7;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = " GROUP 1 TARGETS ";


            //
            // ReloadParty
            //
            // THEN, define ReloadParty and its properties
            this.ReloadParty.Location = new System.Drawing.Point(37, 180);
            this.ReloadParty.Name = "ReloadParty";
            this.ReloadParty.Size = new System.Drawing.Size(75, 23);
            this.ReloadParty.TabIndex = 1;
            this.ReloadParty.Text = "reload";
            this.ReloadParty.UseVisualStyleBackColor = true;
            this.ReloadParty.Click += new System.EventHandler(this.ReloadParty_Click);
            
                        
            //
            // groupBox4
            //
            this.groupBox4.Controls.Add(this.SongStatus_Label);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(11, 534); // Adjusted Y
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(106, 103);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = " SONG STATUS ";
            //
            // SongStatus_Label
            //
            this.SongStatus_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SongStatus_Label.Location = new System.Drawing.Point(3, 15);
            this.SongStatus_Label.Name = "SongStatus_Label";
            this.SongStatus_Label.Size = new System.Drawing.Size(100, 85);
            this.SongStatus_Label.TabIndex = 0;
            this.SongStatus_Label.Text = "No songs active.";
            this.SongStatus_Label.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            //
            // groupBox5
            //
            this.groupBox5.Controls.Add(this.AddonActive);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(123, 534); // Adjusted Y
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(116, 103);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = " ADDON ACTIVE ";
            this.metroToolTip1.SetToolTip(this.groupBox5, "Click this to send a request for verification.");
            //
            // AddonActive
            //
            this.AddonActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddonActive.Location = new System.Drawing.Point(8, 20);
            this.AddonActive.Name = "AddonActive";
            this.AddonActive.Size = new System.Drawing.Size(100, 71);
            this.AddonActive.TabIndex = 0;
            this.AddonActive.Text = "NO";
            this.metroToolTip1.SetToolTip(this.AddonActive, "Click this to send a request for verification.");
            this.AddonActive.UseVisualStyleBackColor = true;
            this.AddonActive.Click += new System.EventHandler(this.AddonActive_Click);
            //
            // ActivityButton
            //
            this.ActivityButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ActivityButton.Location = new System.Drawing.Point(245, 594); // Adjusted Y
            this.ActivityButton.Name = "ActivityButton";
            this.ActivityButton.Size = new System.Drawing.Size(163, 43);
            this.ActivityButton.TabIndex = 6;
            this.ActivityButton.Text = "START";
            this.ActivityButton.UseVisualStyleBackColor = true;
            this.ActivityButton.Click += new System.EventHandler(this.ActivityButton_Click);


            //
            // PartyMembersGroup1_ListBox
            //
            this.PartyMembersGroup1_ListBox.FormattingEnabled = true;
            this.PartyMembersGroup1_ListBox.ItemHeight = 12;
            this.PartyMembersGroup1_ListBox.Location = new System.Drawing.Point(6, 19);
            this.PartyMembersGroup1_ListBox.Name = "PartyMembersGroup1_ListBox";
            this.PartyMembersGroup1_ListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.PartyMembersGroup1_ListBox.Size = new System.Drawing.Size(136, 148);
            this.PartyMembersGroup1_ListBox.TabIndex = 0;
            this.PartyMembersGroup1_ListBox.SelectedValueChanged += new System.EventHandler(this.PartyMembersGroup1_ListBox_SelectedValueChanged);
            //
            // groupBox7
            //
            this.groupBox7.Controls.Add(this.label1);
            this.groupBox7.Controls.Add(this.FollowerTarget);
            this.groupBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox7.Location = new System.Drawing.Point(245, 534); // Adjusted Y
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(163, 54);
            this.groupBox7.TabIndex = 8;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = " FOLLOW TARGET ";
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(136, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "X";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            //
            // FollowerTarget
            //
            this.FollowerTarget.CustomButton.Image = null;
            this.FollowerTarget.CustomButton.Location = new System.Drawing.Point(129, 1);
            this.FollowerTarget.CustomButton.Name = "";
            this.FollowerTarget.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.FollowerTarget.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.FollowerTarget.CustomButton.TabIndex = 1;
            this.FollowerTarget.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.FollowerTarget.CustomButton.UseSelectable = true;
            this.FollowerTarget.CustomButton.Visible = false;
            this.FollowerTarget.Lines = new string[] { "Follower target name." };
            this.FollowerTarget.Location = new System.Drawing.Point(6, 19);
            this.FollowerTarget.MaxLength = 32767;
            this.FollowerTarget.Name = "FollowerTarget";
            this.FollowerTarget.PasswordChar = '\0';
            this.FollowerTarget.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.FollowerTarget.SelectedText = "";
            this.FollowerTarget.SelectionLength = 0;
            this.FollowerTarget.SelectionStart = 0;
            this.FollowerTarget.ShortcutsEnabled = true;
            this.FollowerTarget.Size = new System.Drawing.Size(151, 23);
            this.FollowerTarget.TabIndex = 6;
            this.FollowerTarget.Text = "Follower target name.";
            this.FollowerTarget.UseSelectable = true;
            this.FollowerTarget.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.FollowerTarget.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            //
            // Song_Timer
            //
            this.Song_Timer.Enabled = true;
            this.Song_Timer.Interval = 500;
            this.Song_Timer.Tick += new System.EventHandler(this.Song_Timer_TickAsync);
            //
            // AddonReader
            //
            this.AddonReader.WorkerReportsProgress = true;
            this.AddonReader.WorkerSupportsCancellation = true;
            this.AddonReader.DoWork += new System.ComponentModel.DoWorkEventHandler(this.AddonReader_DoWork);
            this.AddonReader.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.AddonReader_RunWorkerCompleted);
            //
            // metroToolTip1
            //
            this.metroToolTip1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroToolTip1.StyleManager = null;
            this.metroToolTip1.Theme = MetroFramework.MetroThemeStyle.Light;
            //
            // DEBUG
            //
            this.DEBUG.Location = new System.Drawing.Point(333, 34);
            this.DEBUG.Name = "DEBUG";
            this.DEBUG.Size = new System.Drawing.Size(75, 23);
            this.DEBUG.TabIndex = 9;
            this.DEBUG.Text = "DEBUG";
            this.DEBUG.UseVisualStyleBackColor = true;
            this.DEBUG.Visible = false;
            this.DEBUG.Click += new System.EventHandler(this.DEBUG_Click);
            //
            // groupBox8
            //
            this.groupBox8.Controls.Add(this.metroLabel5);
            this.groupBox8.Controls.Add(this.PauseOnZone_Switch);
            this.groupBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox8.Location = new System.Drawing.Point(11, 490); // Adjusted Y
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(233, 38);
            this.groupBox8.TabIndex = 10;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = " PROGRAM OPTIONS ";
            //
            // PauseOnZone_Switch
            //
            this.PauseOnZone_Switch.AutoSize = true;
            this.PauseOnZone_Switch.DisplayStatus = false;
            this.PauseOnZone_Switch.Location = new System.Drawing.Point(122, 13);
            this.PauseOnZone_Switch.Name = "PauseOnZone_Switch";
            this.PauseOnZone_Switch.Size = new System.Drawing.Size(50, 16);
            this.PauseOnZone_Switch.TabIndex = 0;
            this.PauseOnZone_Switch.Text = "Off";
            this.PauseOnZone_Switch.UseSelectable = true;
            //
            // metroLabel5
            //
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(6, 13);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(95, 19);
            this.metroLabel5.TabIndex = 1;
            this.metroLabel5.Text = "Pause on Zone";
            //
            // PauseTimersChecks
            //
            this.PauseTimersChecks.Enabled = true;
            this.PauseTimersChecks.Interval = 500;
            this.PauseTimersChecks.Tick += new System.EventHandler(this.PauseTimersChecks_Tick);
            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 683); // Adjusted ClientSize
            this.Controls.Add(this.groupBoxPartyGroup2);
            this.Controls.Add(this.groupBoxSongGroup2);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.DEBUG);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.ActivityButton);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Purple;
            this.Text = "Corsair Roll Bot v2.0.4"; // This will be changed by Form1.cs
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBoxSongGroup2.ResumeLayout(false);
            this.groupBoxPartyGroup2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label SongStatus_Label;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button ActivityButton;
        private MetroFramework.Controls.MetroComboBox SongGroup1_Song2_ComboBox;
        private MetroFramework.Controls.MetroComboBox SongGroup1_Song1_ComboBox;
        private System.Windows.Forms.Label SongGroup1_Timer1_Label;
        private System.Windows.Forms.Label SongGroup1_Timer2_Label;
        private MetroFramework.Controls.MetroComboBox POLID;
        private System.Windows.Forms.Button Select_POLID;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Timer Song_Timer;
        private System.Windows.Forms.Timer Follow_Timer;
        private System.ComponentModel.BackgroundWorker AddonReader;
        private MetroFramework.Components.MetroToolTip metroToolTip1;
        private System.Windows.Forms.Button AddonActive;
        private System.Windows.Forms.Button DEBUG;
        private System.Windows.Forms.ListBox PartyMembersGroup1_ListBox;
        private System.Windows.Forms.Button ReloadParty;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroTextBox FollowerTarget;
        private System.Windows.Forms.GroupBox groupBox8;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroToggle PauseOnZone_Switch;
        private System.Windows.Forms.Timer PauseTimersChecks;
        private System.Windows.Forms.GroupBox groupBoxSongGroup2;
        private MetroFramework.Controls.MetroComboBox SongGroup2_Song1_ComboBox;
        private MetroFramework.Controls.MetroComboBox SongGroup2_Song2_ComboBox;
        private System.Windows.Forms.Label SongGroup2_Timer1_Label;
        private System.Windows.Forms.Label SongGroup2_Timer2_Label;
        private System.Windows.Forms.GroupBox groupBoxPartyGroup2;
        private System.Windows.Forms.ListBox PartyMembersGroup2_ListBox;
    }
}
