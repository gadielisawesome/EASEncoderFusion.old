using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Speech.Synthesis;
using System.Windows.Forms;
using EASEncoder.Models;
using EASEncoder.Models.SAME;
using EASEncoder_UI.Properties;
using NAudio.Wave;

namespace EASEncoder_UI
{
    public partial class MainForm : Form
    {
        private readonly List<SAMERegion> Regions = new List<SAMERegion>();
        private string _length;
        private SAMEMessageAlertCode _selectedAlertCode;
        private SAMECounty _selectedCounty;
        private SAMEMessageOriginator _selectedOriginator;
        private SAMEState _selectedState;
        //private SAMESubdivision _selectedSubdivision;
        // Subdivision unused for now. Not sure why it's here though. This is a forked project.
        private string _senderId;
        private DateTime _start;
        private WaveOutEvent player;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Screen.PrimaryScreen.Bounds.Width < 1280 || Screen.PrimaryScreen.Bounds.Height < 720)
            {
                this.MaximizeBox = false;
                this.WindowState = FormWindowState.Maximized;
            }
            SpeechSynthesizer synthesizer = new SpeechSynthesizer();
            lblOutputDirectory.Text = Environment.CurrentDirectory;
            var bindingList = new BindingList<SAMERegion>(Regions);
            var source = new BindingSource(bindingList, null);
            datagridRegions.DataSource = source;
            
            dateStart.ShowUpDown = true;
            dateStart.CustomFormat = "MM/dd/yyyy hh:mm tt";
            dateStart.Format = DateTimePickerFormat.Custom;

            comboState.Items.AddRange(MessageRegions.States.OrderBy(x => x.Name).Select(x => x.Name).ToArray());
            comboCode.Items.AddRange(MessageTypes.AlertCodes.OrderBy(x => x.Name).Select(x => x.Name).ToArray());
            comboOriginator.Items.AddRange(MessageTypes.Originators.OrderBy(x => x.Name).Select(x => x.Name).ToArray());


            for (int x = 0; x <= 99; x++)
            {
                if (x <= 60)
                {
                    comboLengthMinutes.Items.Add(x.ToString());
                }
                comboLengthHour.Items.Add(x.ToString());
            }

            comboOriginator.DrawItem += ComboBox1_DrawItem;
            comboOriginator.MeasureItem += ComboBox1_MeasureItem;
        }

        private void ComboState_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedState = MessageRegions.States.FirstOrDefault(x => x.Name == comboState.Text);
            if (_selectedState != null)
            {
                comboCounty.Items.Clear();
                comboCounty.Text = "";
                _selectedCounty = null;
                foreach (
                    var thisCounty in
                        MessageRegions.Counties.Where(x => x.state.Id == _selectedState.Id).OrderBy(x => x.Name))
                {
                    comboCounty.Items.Add(thisCounty.Name);
                }
                if (comboState.SelectedItem.ToString() == "Ohio")
                {
                    try
                    {
                        SoundPlayer player = new SoundPlayer("https://github.com/gadielisawesome/files/raw/master/boom.wav");
                        player.Load();
                        player.Play();
                        //if (player != null && player.IsLoadCompleted)
                        //    player.Stop();
                    }
                    catch (Exception)
                    {
                        
                    }
                }
            }
        }

        private void ComboCounty_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedCounty =
                MessageRegions.Counties.FirstOrDefault(
                    x => x.state.Id == _selectedState.Id && x.Name == comboCounty.Text);
        }

        private void ComboCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedAlertCode = MessageTypes.AlertCodes.FirstOrDefault(y => y.Name == comboCode.Text);
        }

        private void ComboOriginator_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedOriginator = MessageTypes.Originators.FirstOrDefault(y => y.Name == comboOriginator.Text);
            if (comboOriginator.SelectedItem.ToString() == "Mock Alert")
            {
                MessageBox.Show("You have activated the Mock Alert. Select any other originator to disable. This is a feature that attempts to prevent activations of TVs and radios. It attempts to achieve this by modifying the S.A.M.E. preamble, and setting the originator to an unknown value (MCK). This will also disable using custom Sender IDs, and will generate a randomized one.\n\nIf the originator (MCK) becomes an actual originator, it will be changed in the next version.", "EASEncoder Fusion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSender.Text = new string(Enumerable.Range(65, 26).OrderBy(_ => Guid.NewGuid()).Take(8).Select(x => (char)x).ToArray());
                txtSender.ReadOnly = true;
            }
            else txtSender.ReadOnly = false;

            var selectedOriginator = MessageTypes.Originators.FirstOrDefault(x => x.Name == comboOriginator.SelectedItem.ToString());
            if (selectedOriginator != null && selectedOriginator.Broken)
            {
                MessageBox.Show("This originator may be erratic and unstable. Consider using a different originator.", "EASEncoder Fusion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ComboBox1_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            //e.ItemHeight = 20; // Set the desired item height
        }

        private void ComboBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            //// Check if the current item is the "Mock Alert" item
            //if (e.Index >= 0 && comboOriginator.Items[e.Index].ToString() == "Mock Alert")
            //{
            //    // Set the desired color for the "Mock Alert" item
            //    e.Graphics.DrawString(comboOriginator.Items[e.Index].ToString(), e.Font, Brushes.Red, e.Bounds);
            //}
            //else
            //{
            //    // Set the default color for other items
            //    e.DrawBackground();
            //    e.Graphics.DrawString(comboOriginator.Items[e.Index].ToString(), e.Font, Brushes.Black, e.Bounds);
            //}
        }


        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return;
            }
            _start = dateStart.Value.ToUniversalTime();
            _senderId = txtSender.Text;
            _length = ZeroPad(comboLengthHour.Text, 2) + ZeroPad(comboLengthMinutes.Text, 2);

            var newMessage = new EASMessage(_selectedOriginator.Id, _selectedAlertCode.Id,
                Regions, _length, _start, _senderId);

            if (String.IsNullOrEmpty(txtOutputFile.Text))
            {
                MessageBox.Show("You must enter a valid output file name for the EAS audio message.", "EASEncoder Fusion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var generatedData = EASEncoderFusion.EASEncoderFusion.CreateNewMessage(newMessage, chkEbsTones.Checked, chkNwsTone.Checked,
                FormatAnnouncement(txtAnnouncement.Text), chkBurstHeaders.Checked);
            var generatedData2 = generatedData.Replace("\xab\xab\xab\xab\xab\xab\xab\xab\xab\xab\xab\xab\xab\xab\xab\xab", "[Preamble]");
            txtGeneratedData.Text = generatedData2;
        }

        internal string ZeroPad(string String, int Length)
        {
            if (string.IsNullOrEmpty(String))
            {
                String = "0";
            }
            if (String.Length > Length)
            {
                return String;
            }

            while (String.Length < Length)
            {
                String = "0" + String;
            }

            return String;
        }

        private string FormatAnnouncement(string announcement)
        {
            return
                announcement.Replace("*", "")
                    .Replace("\r\n", " ")
                    .ToLower()
                    .Replace(" cdt", "central daylight time")
                    .Replace(" cst", "central standard time")
                    .Replace(" edt", "eastern daylight time")
                    .Replace(" est", "eastern standard time")
                    .Replace(" mdt", "mountain daylight time")
                    .Replace(" mst", "moutain standard time")
                    .Replace(" pdt", "pacific daylight time")
                    .Replace(" pst", "pacific standard time")
                    .Replace(" mph", "miles per hour")
                    .Replace(" winds", "whinds")
                    .Replace("  ", " ")
                    .Replace("...", ", ")
                    .Replace("precautionary/preparedness actions", "")
                    .ToLower();

        }

        private bool ValidateInput()
        {
            if (String.IsNullOrEmpty(txtSender.Text) || txtSender.TextLength != 8)
            {
                MessageBox.Show("You must enter a 'Sender' id.  Ensure it is 8 characters in length.", "EASEncoder Fusion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (String.IsNullOrEmpty(comboOriginator.Text))
            {
                MessageBox.Show("You must select an 'Originator' from the drop down menu.", "EASEncoder Fusion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (String.IsNullOrEmpty(comboCode.Text))
            {
                MessageBox.Show("You must select a 'Code' (event) from the drop down menu.", "EASEncoder Fusion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (String.IsNullOrEmpty(comboLengthHour.Text))
            {
                MessageBox.Show("You must select a 'Length Hour' from the drop down menu.", "EASEncoder Fusion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (String.IsNullOrEmpty(comboLengthMinutes.Text))
            {
                MessageBox.Show("You must select a 'Length Minute' from the drop down menu.", "EASEncoder Fusion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (Regions.Count < 1)
            {
                MessageBox.Show("You must add at least 1 location (state/county) to the locations list.", "EASEncoder Fusion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (player != null)
            {
                btnGeneratePlay.Enabled = false;
                DialogResult response = MessageBox.Show("Are you sure you want to end your message early?\n\nPress ABORT to abruptly stop the message.\nPress RETRY to stop the message with EOM.\nPress IGNORE to go back.", "EASEncoder Fusion", MessageBoxButtons.AbortRetryIgnore);
                if (response == DialogResult.Abort)
                {
                    player.Stop();
                    player = null;
                    EnableElementsWithTag.EnableControlsWithTag(this.Controls, "disable");
                    btnGeneratePlay.Enabled = true;
                    return;
                }
                else if (response == DialogResult.Retry)
                {
                    player.Stop();
                    player = null;
                    new SoundPlayer(Resources.EOM).PlaySync();
                    EnableElementsWithTag.EnableControlsWithTag(this.Controls, "disable");
                    btnGeneratePlay.Enabled = true;
                    return;
                }
                else if (response == DialogResult.Ignore)
                {
                    btnGeneratePlay.Enabled = true;
                    return;
                }
                btnGeneratePlay.Enabled = true;
                return;
            }

            if (!ValidateInput())
            {
                return;
            }

            _start = dateStart.Value.ToUniversalTime();
            _senderId = txtSender.Text;
            _length = ZeroPad(comboLengthHour.Text, 2) + ZeroPad(comboLengthMinutes.Text, 2);

            var newMessage = new EASMessage(_selectedOriginator.Id, _selectedAlertCode.Id,
                Regions, _length, _start, _senderId);


            var messageStream = EASEncoderFusion.EASEncoderFusion.GetMemoryStreamFromNewMessage(newMessage, chkEbsTones.Checked,
                chkNwsTone.Checked, FormatAnnouncement(txtAnnouncement.Text), chkBurstHeaders.Checked);

            //btnGeneratePlay.BackColor = Color.Red;
            DisableElementsWithTag.DisableControlsWithTag(this.Controls, "disable");
            btnGeneratePlay.Text = "STOP";

            WaveStream mainOutputStream = new RawSourceWaveStream(messageStream, new WaveFormat());
            var volumeStream = new WaveChannel32(mainOutputStream)
            {
                PadWithZeroes = false
            };

            player = new WaveOutEvent();
            player.PlaybackStopped += (o, args) =>
            {
                this.SuspendLayout();
                try { player = null; player?.Dispose();  } catch (Exception) { }
                EnableElementsWithTag.EnableControlsWithTag(this.Controls, "disable");
                this.ResumeLayout();
                btnGeneratePlay.Text = "PLAY";
            };

            player.Init(volumeStream);

            if (Settings.Default.UseCountdown)
            {
                btnGeneratePlay.Enabled = false;
                PlayCountdown.Start();
                return;
            }

            player.Play();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            btnGeneratePlay.BackColor = (btnGeneratePlay.BackColor == Color.Red) ? Color.White : Color.Red;
            //btnGeneratePlay.ForeColor = (btnGeneratePlay.BackColor == Color.White) ? Color.Red : Color.White;
        }

        private void BtnAddRegion_Click(object sender, EventArgs e)
        {
            if (comboState.SelectedIndex >= 0 && comboCounty.SelectedIndex >= 0 && !Regions.Exists(x => x.County.Id == _selectedCounty.Id && x.State.Id == _selectedState.Id))
            {
                Regions.Add(new SAMERegion(_selectedState, _selectedCounty));
                var bindingList = new BindingList<SAMERegion>(Regions);
                var source = new BindingSource(bindingList, null);
                datagridRegions.DataSource = source;

                comboCounty.SelectedIndex = -1;
                _selectedCounty = null;
            }
        }

        private void TxtAnnouncement_TextChanged(object sender, EventArgs e)
        {
            //parse vtec
            // (\/)(O)(.)(NEW|CON|EXT|EXA|EXB|UPG|CAN|EXP|COR|ROU)(.)([\w]{4})(.)([A-Z][A-Z])(.)([WAYSFON])(.)([0-9]{4})(.)([0-9]{6})(T)([0-9]{4})(Z)([-])([0-9]{6})([T])([0-9]{4})([Z])(\/)?
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            AboutForm aboutDialog = new AboutForm();
            aboutDialog.ShowDialog();
            //int frequency1 = 540; // Frequency of the first tone in Hz
            //int frequency2 = 420; // Frequency of the second tone in Hz

            //WaveOutEvent waveOut = new WaveOutEvent();
            //SignalGenerator toneGenerator = new SignalGenerator();

            //toneGenerator.Frequency = frequency1;
            //toneGenerator.Type = SignalGeneratorType.Sin;

            //waveOut.Init(toneGenerator);
            //waveOut.Play();

            //while (true)
            //{
            //    Thread.Sleep(1);
            //    toneGenerator.Frequency = (toneGenerator.Frequency == frequency1) ? frequency2 : frequency1;
            //}
        }

        private void Button1_Click_2(object sender, EventArgs e)
        {
                CustomGenForm customEncode = new CustomGenForm();
                if (customEncode.ShowDialog(this) == DialogResult.OK)
                {
                    EASEncoderFusion.EASEncoderFusion.CreateNewMessageFromRawData(message: customEncode.txtCustomData.Text, ebsTone: customEncode.checkBoxEBS.Checked, nwsTone: customEncode.checkBoxNWR.Checked, announcement: FormatAnnouncement(customEncode.txtAnnouncement.Text));
                }
                else
                {
                }
                customEncode.Dispose();
        }

        private void BtnTTSSettings_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Although you can change the default speech instrument, it may not reflect or change here.\nSome voices are incompatible.");
            //int b = 0;
            //_ = 1 / b;
            Process.Start("C:\\WINDOWS\\SYSWOW64\\SPEECH\\SPEECHUX\\SAPI.CPL");
            //var synthesizer = new SpeechSynthesizer();

            //// Get the installed voices
            //var installedVoices = synthesizer.GetInstalledVoices();

            //// Iterate over the installed voices and print their names
            //foreach (var installedVoice in installedVoices)
            //{
            //    var voiceInfo = installedVoice.VoiceInfo;
            //    MessageBox.Show(voiceInfo.Name);
            //}
        }

        private void TxtGeneratedData_TextChanged(object sender, EventArgs e)
        {

        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox1.Checked = false;
                throw new NotImplementedException();
            }
        }

        private void timer_Tick_1(object sender, EventArgs e)
        {

        }

        private void btnGenerateTTSOnly_Click(object sender, EventArgs e)
        {
            DisableElementsWithTag.DisableControlsWithTag(this.Controls, "disable");
            btnGeneratePlay.Enabled = false;
            try
            {
                var synthesizer = new SpeechSynthesizer
                {
                    Volume = 100
                };

                var audioStream = new MemoryStream();
                synthesizer.SetOutputToWaveStream(audioStream);

                synthesizer.Speak(txtAnnouncement.Text);

                synthesizer.SetOutputToDefaultAudioDevice();

                audioStream.Position = 0;
                using (var audioPlayer = new SoundPlayer(audioStream))
                {
                    audioPlayer.PlaySync();
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                EnableElementsWithTag.EnableControlsWithTag(this.Controls, "disable");
                btnGeneratePlay.Enabled = true;
            }
        }

        private void chkBurstHeaders_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBurstHeaders.Checked) MessageBox.Show("This feature is experimental and should not be used in production environments.", "EASEncoder Fusion", MessageBoxButtons.OK);
        }

        int i = 15;

        private void PlayCountdown_Tick(object sender, EventArgs e)
        {
            if (PlayCountdown.Interval < 1000) PlayCountdown.Interval = 1000;
            btnGeneratePlay.Text = i.ToString();
            if (i != 0) i--;
            else
            {
                PlayCountdown.Stop();
                i = 15;
                btnGeneratePlay.Enabled = true;
                btnGeneratePlay.Text = "STOP";
                player.Play();
            }
        }
    }
    public static class DisableElementsWithTag
    {
        public static void DisableControlsWithTag(Control.ControlCollection controls, string tag)
        {
            foreach (Control control in controls)
            {
                if (control.Tag != null && control.Tag.ToString() == tag)
                {
                    control.Enabled = false;
                }

                if (control.HasChildren)
                {
                    DisableControlsWithTag(control.Controls, tag);
                }
            }
        }
    }

    public static class EnableElementsWithTag
    {
        public static void EnableControlsWithTag(Control.ControlCollection controls, string tag)
        {
            foreach (Control control in controls)
            {
                if (control.Tag != null && control.Tag.ToString() == tag)
                {
                    control.Enabled = true;
                }

                if (control.HasChildren)
                {
                    EnableControlsWithTag(control.Controls, tag);
                }
            }
        }
    }
}