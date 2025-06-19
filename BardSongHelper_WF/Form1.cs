﻿using EliteMMO.API;
using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BardSongHelper_WF
{
    public partial class Form1 : MetroForm

    {
        #region "CUSTOM CLASS: SongData" // Renamed

        public class SongData // Replaced RollData, does not inherit List<SongData>
        {
            public string SongName { get; set; }
            public int BuffId { get; set; }
            public int DurationSeconds { get; set; }
            public int CastTimeSeconds { get; set; }
            public int AreaOfEffectYalms { get; set; }
            public int Position { get; set; }
        }

        #endregion

        #region "CUSTOM CLASS: PartyRequirements"

        public class PartyRequirements
        {
            public string CharacterName { get; set; }
            public bool Checked { get; set; }
        }

        #endregion

        #region "CUSTOM CLASS: ActiveSongEffect" // Added
        public class ActiveSongEffect
        {
            public string SongName { get; set; }
            public string TargetName { get; set; }
            public int RemainingDurationSeconds { get; set; }
            public System.Windows.Forms.Timer AssociatedTimer { get; set; }
            public int AppliedByGroup { get; set; }
            public System.Windows.Forms.Label SongUITimerLabel { get; set; }
            public DateTime StartTime { get; set; }
        }
        #endregion

        #region "CUSTOM CLASS: BadgeValue"
        public class ViewModel : INotifyPropertyChanged
        {
            private int _badgeValue;
            public int BadgeValue
            {
                get => _badgeValue;
                set { _badgeValue = value; NotifyPropertyChanged(); }
            }

            public event PropertyChangedEventHandler PropertyChanged;
            private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region "PUBLIC METHODS"

        public List<PartyRequirements> Member_List_Group1 = new List<PartyRequirements>(); // Renamed
        public List<PartyRequirements> Member_List_Group2 = new List<PartyRequirements>(); // Added

        // For tracking active songs per target
        private Dictionary<string, List<ActiveSongEffect>> activeSongEffectsByTarget = new Dictionary<string, List<ActiveSongEffect>>();
        // Flat list of all active songs for easier global management if needed
        private List<ActiveSongEffect> allActiveSongEffects = new List<ActiveSongEffect>>();

        public ListBox processids = new ListBox();

        public static EliteAPI _api;

        public List<SongData> Songs = new List<SongData>(); // Changed from RollData rolls

        public string WindowerMode = "Windower";

        private bool botRunning = false;

        private int CurrentCastingSongValue = 0; // Renamed from CurrentRoll
        private int LastCastingSongValue = 0; // Renamed from LastKnownRoll

        private bool firstSelect = false;

        public int lastCommand = 0;

        public bool timerBusy = false;

        public bool followBusy = false;

        public bool isMoving = false;

        private bool FollowerStuck = false;

        private int ListeningPort = 19701;

        // public bool Blocked = false; // Removed
        public bool AllInRange = false;


        private string IP_Address = "127.0.0.1";

        public List<int> knownCities = new List<int> { 50, 80, 94, 87, 222, 223, 224, 225, 226, 230, 231, 232, 233, 234, 235, 236, 237, 238, 239,
                                                                240, 241, 242, 243, 244, 245, 246, 247, 248, 249, 250, 251, 252, 256, 257 };

        // public int SongProcessActiveForGroup = 0; // Removed


        #endregion

        public Form1()
        {
            InitializeComponent();

            // Removed: RollOne_ComboBox.SelectedIndex = 3;
            // Removed: RollTwo_ComboBox.SelectedIndex = 10;

            #region "ADD ALL THE SONGS TO THE CUSTOM CLASS" // Renamed region

            Songs.Add(new SongData { SongName = "Valor Minuet", BuffId = 101, DurationSeconds = 180, CastTimeSeconds = 8, AreaOfEffectYalms = 7, Position = 0 });
            Songs.Add(new SongData { SongName = "Blade Madrigal", BuffId = 102, DurationSeconds = 180, CastTimeSeconds = 8, AreaOfEffectYalms = 7, Position = 1 });
            Songs.Add(new SongData { SongName = "Army's Paeon", BuffId = 103, DurationSeconds = 180, CastTimeSeconds = 8, AreaOfEffectYalms = 7, Position = 2 });
            Songs.Add(new SongData { SongName = "Knight's Minne", BuffId = 104, DurationSeconds = 180, CastTimeSeconds = 8, AreaOfEffectYalms = 7, Position = 3 });
            Songs.Add(new SongData { SongName = "Hunter's Prelude", BuffId = 105, DurationSeconds = 180, CastTimeSeconds = 8, AreaOfEffectYalms = 7, Position = 4 });
            Songs.Add(new SongData { SongName = "Shepherd's Etude", BuffId = 106, DurationSeconds = 180, CastTimeSeconds = 8, AreaOfEffectYalms = 7, Position = 5 });
            Songs.Add(new SongData { SongName = "Victory March", BuffId = 107, DurationSeconds = 180, CastTimeSeconds = 8, AreaOfEffectYalms = 7, Position = 6 });
            Songs.Add(new SongData { SongName = "Advancing March", BuffId = 108, DurationSeconds = 180, CastTimeSeconds = 8, AreaOfEffectYalms = 7, Position = 7 });
            Songs.Add(new SongData { SongName = "Foe Requiem VII", BuffId = 109, DurationSeconds = 180, CastTimeSeconds = 8, AreaOfEffectYalms = 7, Position = 8 });
            Songs.Add(new SongData { SongName = "Horde Lullaby II", BuffId = 110, DurationSeconds = 180, CastTimeSeconds = 8, AreaOfEffectYalms = 7, Position = 9 });

            #endregion

            PopulateSongComboBoxes(); // Added call

            #region "Check for the Elite API and POL instances"

            if (File.Exists("eliteapi.dll") && File.Exists("elitemmo.api.dll"))
            {
                Process[] pol = Process.GetProcessesByName("pol");

                if (pol.Length < 1)
                {
                    MetroMessageBox.Show(this, "No POL instances were able to be located." + "\n\n" +
                        "Please note: If you use a private server make sure the program used to access it has been renamed to POL " +
                        "otherwise this bot will not be able to locate it.", "Notice:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    for (int i = 0; i < pol.Length; i++)
                    {
                        POLID.Items.Add(pol[i].MainWindowTitle);
                        processids.Items.Add(pol[i].Id);
                    }
                    POLID.SelectedIndex = 0;
                    processids.SelectedIndex = 0;
                }
            }
            else
            {
                MessageBox.Show("This program can not function without EliteMMO.API.dll and EliteAPI.dll");
                // this.Close();
            }

            #endregion

            this.Text = "Bard Song Helper v1.0"; // Added
        }

        private void ActivityButton_Click(object sender, EventArgs e)
        {

            if (botRunning == false)
            {
                if (ActivityButton.InvokeRequired)
                {
                    ActivityButton.Invoke(new MethodInvoker(delegate () { ActivityButton.BackColor = Color.Green; ActivityButton.Text = "RUNNING!"; }));
                }
                else
                {
                    ActivityButton.BackColor = Color.Green; ActivityButton.Text = "RUNNING!";
                }

                botRunning = true;
            }
            else
            {
                if (ActivityButton.InvokeRequired)
                {
                    ActivityButton.Invoke(new MethodInvoker(delegate () { ActivityButton.BackColor = Color.Red; ActivityButton.Text = "PAUSED!"; }));
                }
                else
                {
                    ActivityButton.BackColor = Color.Red; ActivityButton.Text = "PAUSED!";
                }

                botRunning = false;
            }
        }

        #region "A POLID was selected so create an API instance and run the Addon"

        private void Select_POLID_Click(object sender, EventArgs e)
        {

            processids.SelectedIndex = POLID.SelectedIndex;
            _api = new EliteAPI((int)processids.SelectedItem);
            Select_POLID.Text = "SELECTED";
            Select_POLID.BackColor = Color.Green;

            foreach (Process dats in Process.GetProcessesByName("pol").Where(dats => POLID.Text == dats.MainWindowTitle))
            {
                for (int i = 0; i < dats.Modules.Count; i++)
                {
                    if (dats.Modules[i].FileName.Contains("Ashita.dll"))
                    {
                        WindowerMode = "Ashita";
                    }
                    else if (dats.Modules[i].FileName.Contains("Hook.dll"))
                    {
                        WindowerMode = "Windower";
                    }
                }
            }

            if (firstSelect == false)
            {

                EliteAPI.ChatEntry cl = _api.Chat.GetNextChatLine();
                while (cl != null)
                {
                    cl = _api.Chat.GetNextChatLine();
                }

                if (WindowerMode == "Windower")
                {
                    _api.ThirdParty.SendString("//lua load crb_addon");
                }
                else if (WindowerMode == "Ashita")
                {
                    _api.ThirdParty.SendString("/addon load crb_addon");
                }


                AddonReader.RunWorkerAsync();


                GrabParty();

                firstSelect = true;
            }
        }

        #endregion "A POLID was selected so create an API instance and run the Addon"






        private async void Song_Timer_TickAsync(object sender, EventArgs e)
        {
            if (_api == null)
            {
                return;
            }

            if (_api.Player.LoginStatus != (int)LoginStatus.LoggedIn || _api.Player.LoginStatus == (int)LoginStatus.Loading)
            {
                await Task.Delay(TimeSpan.FromSeconds(17));
                return;
            }

            if (timerBusy == true || (LastCastingSongValue == CurrentCastingSongValue && BuffChecker(309) == true)) // Updated variable names
            {
                return;
            }

            // if (BuffChecker(309) == false) // Corsair's "Bust" specific?
            // {
            //     LastCastingSongValue = 0;
            // }

            try
            {
                timerBusy = true;

                // Removed Corsair-specific buff check for Double-Up (BuffChecker(308))
                // and related CurrentCastingSongValue = 0 / SongStatus_Label.Text = "0" logic.
                // AddonReader still updates SongStatus_Label if addon sends data.

                if (botRunning == true && !knownCities.Contains(_api.Player.ZoneId) && isMoving == false)
                {
                    FollowTargetAsync(); // Keep follow logic

                    // Process Group 1
                    await ProcessSongGroup(
                        new List<SongData> {
                            Songs.FirstOrDefault(s => s.Position == SongGroup1_Song1_ComboBox.SelectedIndex),
                            Songs.FirstOrDefault(s => s.Position == SongGroup1_Song2_ComboBox.SelectedIndex)
                        },
                        Member_List_Group1,
                        new List<Label> { SongGroup1_Timer1_Label, SongGroup1_Timer2_Label },
                        1 // Group Number
                    );

                    // Process Group 2
                    await ProcessSongGroup(
                        new List<SongData> {
                            Songs.FirstOrDefault(s => s.Position == SongGroup2_Song1_ComboBox.SelectedIndex),
                            Songs.FirstOrDefault(s => s.Position == SongGroup2_Song2_ComboBox.SelectedIndex)
                        },
                        Member_List_Group2,
                        new List<Label> { SongGroup2_Timer1_Label, SongGroup2_Timer2_Label },
                        2 // Group Number
                    );
                }
                await Task.Delay(TimeSpan.FromMilliseconds(500)); // Main timer tick delay
            }
            finally
            {
                timerBusy = false;
            }
        }


        private uint GetTargetIdByName(string name)
        {
            for (int x = 0; x < 2048; x++)
            {
                EliteAPI.XiEntity ID = _api.Entity.GetEntity(x);

                if (ID.Name != null && ID.Name.ToLower() == name.ToLower())
                {
                    return ID.TargetID;
                }
            }
            return 0;
        }

        private async void FollowTargetAsync()
        {
            // Check if you have the required Buffs active, if not then run them.
            if (_api == null || _api.Player.LoginStatus != (int)LoginStatus.LoggedIn || _api.Player.LoginStatus == (int)LoginStatus.Loading)
            {
                return;
            }

            if (FollowerTarget.Text == string.Empty || FollowerTarget.Text == "Follower target name")
            {
                return;
            }

            uint followID = GetTargetIdByName(FollowerTarget.Text);

            if (followID == 0)
            {
                return;
            }

            EliteAPI.XiEntity FollowedCharacter = _api.Entity.GetEntity(Convert.ToInt32(followID));
            EliteAPI.PlayerTools PlayerCharacter = _api.Player;

            isMoving = true;
            while (Math.Truncate(FollowedCharacter.Distance) >= (float)6)
            {
                _api.AutoFollow.SetAutoFollowCoords(FollowedCharacter.X - PlayerCharacter.X,
                                                   FollowedCharacter.Y - PlayerCharacter.Y,
                                                   FollowedCharacter.Z - PlayerCharacter.Z);

                _api.AutoFollow.IsAutoFollowing = true;

                await Task.Delay(TimeSpan.FromSeconds(0.1));
            }
            _api.AutoFollow.IsAutoFollowing = false;
            isMoving = false;

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_api != null)
            {
                if (WindowerMode == "Ashita")
                {
                    _api.ThirdParty.SendString("/addon unload crb_addon");
                }
                else if (WindowerMode == "Windower")
                {
                    _api.ThirdParty.SendString("//lua unload crb_addon");
                }
            }

            _api = null;
        }

        #region "ADDON READER BACKGROUND TASK"

        private void AddonReader_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            bool done = false;

            int listenPort = Convert.ToInt32(ListeningPort);

            UdpClient listener = new UdpClient(listenPort);
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Parse(IP_Address), listenPort);

            string received_data;

            byte[] receive_byte_array;

            try
            {
                while (!done)
                {
                    receive_byte_array = listener.Receive(ref groupEP);

                    received_data = Encoding.ASCII.GetString(receive_byte_array, 0, receive_byte_array.Length);

                    //MessageBox.Show("FOUND " + received_data);

                    string[] data_received = received_data.Split(' ');



                    if (data_received[0] == "crollbot_addon")
                    {

                        LastCastingSongValue = CurrentCastingSongValue; // Updated variable name


                        // UPDATE SONG CASTING INFORMATION (if addon sends this)
                        CurrentCastingSongValue = Convert.ToInt32(data_received[1]); // Updated variable name

                        if (SongStatus_Label.InvokeRequired) // Updated control name
                        {
                            SongStatus_Label.Invoke(new MethodInvoker(delegate () { SongStatus_Label.Text = data_received[1]; }));
                        }
                        else
                        {
                            SongStatus_Label.Text = data_received[1];
                        }

                    }
                    else if (data_received[0] == "crb")
                    {
                        if (data_received[1].ToLower() == "validated")
                        {
                            if (AddonActive.InvokeRequired)
                            {
                                AddonActive.Invoke(new MethodInvoker(delegate () { AddonActive.Text = "YES"; AddonActive.BackColor = Color.Green; }));
                            }
                            else
                            {
                                AddonActive.Text = "YES"; AddonActive.BackColor = Color.Green;
                            }
                        }
                        else if (data_received[1].ToLower() == "toggle")
                        {
                            if (botRunning == false)
                            {
                                if (ActivityButton.InvokeRequired)
                                {
                                    ActivityButton.Invoke(new MethodInvoker(delegate () { ActivityButton.BackColor = Color.Green; ActivityButton.Text = "RUNNING!"; }));
                                }
                                else
                                {
                                    ActivityButton.BackColor = Color.Green; ActivityButton.Text = "RUNNING!";
                                }

                                botRunning = true;
                            }
                            else
                            {
                                if (ActivityButton.InvokeRequired)
                                {
                                    ActivityButton.Invoke(new MethodInvoker(delegate () { ActivityButton.BackColor = Color.Red; ActivityButton.Text = "PAUSED!"; }));
                                }
                                else
                                {
                                    ActivityButton.BackColor = Color.Red; ActivityButton.Text = "PAUSED!";
                                }

                                botRunning = false;
                            }

                        }
                        else if (data_received[1].ToLower() == "stop" || data_received[1].ToLower() == "pause")
                        {

                            if (ActivityButton.InvokeRequired)
                            {
                                ActivityButton.Invoke(new MethodInvoker(delegate () { ActivityButton.BackColor = Color.Red; ActivityButton.Text = "PAUSED!"; }));
                            }
                            else
                            {
                                ActivityButton.BackColor = Color.Red; ActivityButton.Text = "PAUSED!";
                            }
                            botRunning = false;
                        }
                        else if (data_received[1].ToLower() == "start" || data_received[1].ToLower() == "unpause")
                        {
                            if (ActivityButton.InvokeRequired)
                            {
                                ActivityButton.Invoke(new MethodInvoker(delegate () { ActivityButton.BackColor = Color.Green; ActivityButton.Text = "RUNNING!"; }));
                            }
                            else
                            {
                                ActivityButton.BackColor = Color.Green; ActivityButton.Text = "RUNNING!";
                            }
                            botRunning = true;
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                listener.Close();

            }

            Thread.Sleep(TimeSpan.FromSeconds(1));

            AddonReader.CancelAsync();
        }

        private void AddonReader_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            AddonReader.RunWorkerAsync();
        }

        #endregion

        #region "ADDON ACTIVE CHECKER"

        private void AddonActive_Click(object sender, EventArgs e)
        {
            if (_api != null)
            {
                if (WindowerMode == "Windower")
                {
                    _api.ThirdParty.SendString("//CorsairRollBot verify");
                }
                else if (WindowerMode == "Ashita")
                {
                    _api.ThirdParty.SendString("/CorsairRollBot verify");
                }
            }
        }

        #endregion

        #region "DISTANCE CHECKER"

        public bool DistanceChecker(string MemberName, uint maxDistance = 8) // Default to 8 if not specified
        {
            string CharName = MemberName.ToLower();
            for (int x = 0; x < 2048; x++)
            {
                EliteAPI.XiEntity entity2 = _api.Entity.GetEntity(x);
                if (entity2.Name != null && entity2.Name.ToLower() == CharName && (int)entity2.Distance < maxDistance)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region "FUNCTION TO CHECK IF AVAILABLE BUFF IS ACTIVE - BuffChecker(int ID)"

        public bool BuffChecker(int buffID)
        {
            if (_api.Player.GetPlayerInfo().Buffs.Any(b => b == buffID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region "PARTY MEMBER CHECKER TIMER"

        private void GrabParty()
        {
            if (_api != null)
            {
                List<EliteAPI.PartyMember> PartyMembers = _api.Party.GetPartyMembers();

                PartyMembersGroup1_ListBox.Items.Clear(); // Updated control name
                PartyMembersGroup2_ListBox.Items.Clear(); // Added for Group 2

                if (PartyMembers.Count() > 1)
                {
                    foreach (EliteAPI.PartyMember PT_Data in PartyMembers)
                    {
                        if (PT_Data.Name != _api.Player.Name && !PartyMembersGroup1_ListBox.Items.Contains(PT_Data.Name) && PT_Data.Name != "" && PT_Data.Active >= 1)
                        {
                            PartyMembersGroup1_ListBox.Items.Add(PT_Data.Name); // Updated control name
                            PartyMembersGroup2_ListBox.Items.Add(PT_Data.Name); // Added for Group 2
                        }
                    }
                }
            }
        }

        #endregion

        // Handles the countdown timer for an individual active song effect.
        // Updates the UI timer label and cleans up when the song expires.
        private void ActiveSong_Tick(object sender, EventArgs e, ActiveSongEffect songEffect)
        {
            songEffect.RemainingDurationSeconds--;
            if (songEffect.SongUITimerLabel != null)
            {
                if (songEffect.SongUITimerLabel.InvokeRequired)
                {
                    songEffect.SongUITimerLabel.Invoke(new MethodInvoker(delegate {
                        songEffect.SongUITimerLabel.Text = $"{songEffect.SongName.Split(' ')[0]}: {TimeSpan.FromSeconds(songEffect.RemainingDurationSeconds):mm\\:ss}";
                    }));
                }
                else
                {
                    songEffect.SongUITimerLabel.Text = $"{songEffect.SongName.Split(' ')[0]}: {TimeSpan.FromSeconds(songEffect.RemainingDurationSeconds):mm\\:ss}";
                }
            }

            if (songEffect.RemainingDurationSeconds <= 0)
            {
                songEffect.AssociatedTimer.Stop();
                songEffect.AssociatedTimer.Dispose();

                if (activeSongEffectsByTarget.ContainsKey(songEffect.TargetName))
                {
                    activeSongEffectsByTarget[songEffect.TargetName].Remove(songEffect);
                    if (activeSongEffectsByTarget[songEffect.TargetName].Count == 0)
                    {
                        activeSongEffectsByTarget.Remove(songEffect.TargetName);
                    }
                }
                allActiveSongEffects.Remove(songEffect);

                if (songEffect.SongUITimerLabel != null)
                {
                     if (songEffect.SongUITimerLabel.InvokeRequired)
                    {
                        songEffect.SongUITimerLabel.Invoke(new MethodInvoker(delegate { songEffect.SongUITimerLabel.Text = "00:00"; }));
                    }
                    else
                    {
                        songEffect.SongUITimerLabel.Text = "00:00";
                    }
                }
            }
        }

        // Processes the selected songs for a given group, applying them to checked targets.
        // Handles distance checks, existing song effects, song overwriting, and initiates song timers.
        private async Task ProcessSongGroup(List<SongData> selectedSongs, List<PartyRequirements> targets, List<Label> uiTimerLabels, int groupNumber)
        {
            if (_api == null || !botRunning) return;

            for (int i = 0; i < selectedSongs.Count; i++)
            {
                SongData songToApply = selectedSongs[i];
                Label songLabel = (uiTimerLabels.Count > i) ? uiTimerLabels[i] : null;

                if (songToApply == null) continue;

                List<PartyRequirements> currentGroupTargets = targets.Where(t => t.Checked).ToList();
                if (!currentGroupTargets.Any()) continue;

                foreach (var targetMember in currentGroupTargets)
                {
                    if (!DistanceChecker(targetMember.CharacterName, (uint)songToApply.AreaOfEffectYalms))
                    {
                        continue;
                    }

                    if (!activeSongEffectsByTarget.ContainsKey(targetMember.CharacterName))
                    {
                        activeSongEffectsByTarget[targetMember.CharacterName] = new List<ActiveSongEffect>();
                    }
                    List<ActiveSongEffect> targetEffects = activeSongEffectsByTarget[targetMember.CharacterName];

                    if (targetEffects.Any(eff => eff.SongName == songToApply.SongName))
                    {
                        continue;
                    }

                    // If target already has 2 songs, overwrite the oldest one
                    if (targetEffects.Count >= 2)
                    {
                        ActiveSongEffect oldestEffect = targetEffects.OrderBy(eff => eff.StartTime).FirstOrDefault();
                        if (oldestEffect != null)
                        {
                            oldestEffect.AssociatedTimer.Stop();
                            oldestEffect.AssociatedTimer.Dispose();
                            targetEffects.Remove(oldestEffect);
                            allActiveSongEffects.Remove(oldestEffect);
                            if (oldestEffect.SongUITimerLabel != null) {
                                if (oldestEffect.SongUITimerLabel.InvokeRequired) {
                                    oldestEffect.SongUITimerLabel.Invoke(new MethodInvoker(delegate { oldestEffect.SongUITimerLabel.Text = "00:00"; }));
                                } else {
                                    oldestEffect.SongUITimerLabel.Text = "00:00";
                                }
                            }
                        }
                    }

                    // Apply the new song by sending the command
                    _api.ThirdParty.SendString($"/ma \"{songToApply.SongName}\" \"{targetMember.CharacterName}\"");
                    await Task.Delay(250);

                    ActiveSongEffect newEffect = new ActiveSongEffect
                    {
                        SongName = songToApply.SongName,
                        TargetName = targetMember.CharacterName,
                        RemainingDurationSeconds = songToApply.DurationSeconds,
                        AssociatedTimer = new System.Windows.Forms.Timer(),
                        AppliedByGroup = groupNumber,
                        SongUITimerLabel = songLabel,
                        StartTime = DateTime.UtcNow
                    };

                    newEffect.AssociatedTimer.Interval = 1000;
                    newEffect.AssociatedTimer.Tick += (senderObj, eventArgs) => ActiveSong_Tick(senderObj, eventArgs, newEffect);
                    newEffect.AssociatedTimer.Start();

                    targetEffects.Add(newEffect);
                    allActiveSongEffects.Add(newEffect);

                    if (songLabel != null) {
                         if (songLabel.InvokeRequired) {
                            songLabel.Invoke(new MethodInvoker(delegate { songLabel.Text = $"{newEffect.SongName.Split(' ')[0]}: {TimeSpan.FromSeconds(newEffect.RemainingDurationSeconds):mm\\:ss}"; }));
                        } else {
                            songLabel.Text = $"{newEffect.SongName.Split(' ')[0]}: {TimeSpan.FromSeconds(newEffect.RemainingDurationSeconds):mm\\:ss}";
                        }
                    }

                    await Task.Delay(TimeSpan.FromSeconds(songToApply.CastTimeSeconds));
                }
            }
        }

        // Populates all song selection ComboBoxes with names from the Songs list
        // and sets default selections.
        private void PopulateSongComboBoxes()
        {
            var songNames = Songs.Select(s => s.SongName).ToArray();

            SongGroup1_Song1_ComboBox.Items.Clear();
            SongGroup1_Song1_ComboBox.Items.AddRange(songNames);
            SongGroup1_Song2_ComboBox.Items.Clear();
            SongGroup1_Song2_ComboBox.Items.AddRange(songNames);
            SongGroup2_Song1_ComboBox.Items.Clear();
            SongGroup2_Song1_ComboBox.Items.AddRange(songNames);
            SongGroup2_Song2_ComboBox.Items.Clear();
            SongGroup2_Song2_ComboBox.Items.AddRange(songNames);

            if (songNames.Length > 0) {
                SongGroup1_Song1_ComboBox.SelectedIndex = 0;
                SongGroup1_Song2_ComboBox.SelectedIndex = Math.Min(1, songNames.Length - 1);
                SongGroup2_Song1_ComboBox.SelectedIndex = 0;
                SongGroup2_Song2_ComboBox.SelectedIndex = Math.Min(1, songNames.Length - 1);
            }
        }

        #region "CHECK IF THE USER HAS AN ABILITY AND IT'S RECAST TIMER"

        public int AbilityRecast(string checked_abilityName)
        {
            int id = _api.Resources.GetAbility(checked_abilityName, 0).TimerID;
            List<int> IDs = _api.Recast.GetAbilityIds();
            for (int x = 0; x < IDs.Count; x++)
            {
                if (IDs[x] == id)
                {
                    return _api.Recast.GetAbilityRecast(x);
                }
            }
            return 0;
        }

        public static bool HasAbility(string checked_abilityName)
        {

            uint AbilityID = _api.Resources.GetAbility(checked_abilityName, 0).ID;


            if (_api.Player.HasAbility(AbilityID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        #endregion

        private void DEBUG_Click(object sender, EventArgs e)
        {
            string Debug_MSG = string.Empty;

            // Updated to show Member_List_Group1 for debugging
            if (Member_List_Group1 != null && Member_List_Group1.Count() > 0)
            {
                foreach (PartyRequirements CharacterD in Member_List_Group1)
                {
                    Debug_MSG = Debug_MSG + "G1: " + CharacterD.CharacterName + "\n";
                }
            }
            if (Member_List_Group2 != null && Member_List_Group2.Count() > 0)
            {
                foreach (PartyRequirements CharacterD in Member_List_Group2)
                {
                    Debug_MSG = Debug_MSG + "G2: " + CharacterD.CharacterName + "\n";
                }
            }

            MessageBox.Show(Debug_MSG);

        }

        private void PartyMembersGroup1_ListBox_SelectedValueChanged(object sender, EventArgs e) // Renamed method
        {
            Member_List_Group1.Clear(); // Updated list name

            int count = PartyMembersGroup1_ListBox.Items.Count; // Updated control name

            foreach (object selecteditem in PartyMembersGroup1_ListBox.SelectedItems) // Updated control name
            {
                string strItem = selecteditem as string;
                Member_List_Group1.Add(new PartyRequirements { Checked = true, CharacterName = strItem }); // Updated list name
            }
        }

        private void ReloadParty_Click(object sender, EventArgs e)
        {
            GrabParty();
        }

        private void PartyMembersGroup2_ListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            Member_List_Group2.Clear();
            foreach (object selecteditem in PartyMembersGroup2_ListBox.SelectedItems)
            {
                string strItem = selecteditem as string;
                Member_List_Group2.Add(new PartyRequirements { Checked = true, CharacterName = strItem });
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            FollowerTarget.Text = string.Empty;
        }

        private void PauseTimersChecks_Tick(object sender, EventArgs e)
        {
            if (_api != null)
            {
                if (_api.Player.LoginStatus == (int)LoginStatus.Loading || _api.Player.LoginStatus == (int)LoginStatus.Loading)
                {
                    if (PauseOnZone_Switch.Checked == true)
                    {
                        if (ActivityButton.InvokeRequired)
                        {
                            ActivityButton.Invoke(new MethodInvoker(delegate () { ActivityButton.BackColor = Color.Red; ActivityButton.Text = "ZONED!"; }));
                        }
                        else
                        {
                            ActivityButton.BackColor = Color.Red; ActivityButton.Text = "ZONED!";
                        }

                        botRunning = false;
                    }

                }
            }
        }
    }
}
