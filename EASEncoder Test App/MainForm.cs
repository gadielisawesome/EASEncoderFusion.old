using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
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
            this.SuspendLayout();
            if (Settings.Default.LowRes)
            {
                this.MaximizeBox = false;
                //this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                //this.TopMost = false;
                //this.BringToFront();
                //MainFormLowRes mainFormLowRes = new MainFormLowRes();
                //mainFormLowRes.Show();
            }
            lblVersion.Text = this.Tag.ToString() + "\nBunnyTub on Discord";
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
            this.ResumeLayout();
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
                        //SoundPlayer player = new SoundPlayer("https://github.com/gadielisawesome/files/raw/master/boom.wav");
                        //player.Load();
                        //player.Play();
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

            if (string.IsNullOrEmpty(txtOutputFile.Text))
            {
                MessageBox.Show("You must enter a valid output file name for the EAS audio message.", "EASEncoder Fusion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var generatedData = EASEncoderFusion.EASEncoderFusion.CreateNewMessage(newMessage, chkEbsTones.Checked, chkNwsTone.Checked,
                FormatAnnouncement(txtAnnouncement.Text), chkBurstHeaders.Checked, txtOutputFile.Text);
            var generatedData2 = generatedData.Replace("\xab\xab\xab\xab\xab\xab\xab\xab\xab\xab\xab\xab\xab\xab\xab\xab", "[Preamble]");
            txtGeneratedData.Text = generatedData2;
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
                try { player = null; player?.Dispose(); } catch (Exception) { }
                EnableElementsWithTag.EnableControlsWithTag(this.Controls, "disable");
                this.ResumeLayout();
                btnGeneratePlay.Text = "PLAY";
                if (Settings.Default.QuitOnFinish) this.Close();
            };

            player.Init(volumeStream);

            if (Settings.Default.UseCountdown)
            {
                btnGeneratePlay.Enabled = false;
                PlayCountdown.Start();
                return;
            }

            //new DisplayForm().Show();
            player.Play();
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
                MessageBox.Show("You must select and add at least 1 location (state/county).", "EASEncoder Fusion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
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
            this.Hide();
            aboutDialog.ShowDialog();
            this.Show();
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
            this.Hide();
            if (customEncode.ShowDialog(this) == DialogResult.OK)
            {
                EASEncoderFusion.EASEncoderFusion.CreateNewMessageFromRawData(message: customEncode.txtCustomData.Text, ebsTone: customEncode.checkBoxEBS.Checked, nwsTone: customEncode.checkBoxNWR.Checked, announcement: FormatAnnouncement(customEncode.txtAnnouncement.Text));
            }
            else
            {
            }
            customEncode.Dispose();
            this.Show();
        }

        private void BtnTTSSettings_Click(object sender, EventArgs e)
        {
            MessageBox.Show("SAPI voices are currently incompatible. This will be fixed in the next update.", "EASEncoder Fusion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            if (chkBurstHeaders.Checked) MessageBox.Show("This feature is experimental.", "EASEncoder Fusion", MessageBoxButtons.OK);
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
                //new DisplayForm().Show();
                player.Play();
            }
        }

        private void txtSender_TextChanged(object sender, EventArgs e)
        {
            txtSender.Text.Trim();
        }

        int GridIndexRow = -1;
        //int GridIndexColumn = -1;

        private void datagridRegions_CellClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (e.Button == MouseButtons.Right)
                {
                    GridIndexRow = e.RowIndex;
                    //GridIndexColumn = e.ColumnIndex;
                    LocationContextMenu.Show(MousePosition.X, MousePosition.Y);
                }
            }
        }

        private void deleteLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SuspendLayout();
            try { datagridRegions.Rows.RemoveAt(GridIndexRow); } catch (Exception) { }
            this.ResumeLayout();
        }

        private void btnAddAllRegions_Click(object sender, EventArgs e)
        {
            
        }

        private void label14_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to forcefully redraw all elements?", "EASEncoder Fusion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) this.Invalidate();
        }

        private void btnCopyHeader_Click(object sender, EventArgs e)
        {
            txtGeneratedData.SelectAll();
            txtGeneratedData.Copy();
            string temp = txtGeneratedData.Text;
            txtGeneratedData.Clear();
            txtGeneratedData.Text = temp;
        }

        private readonly Random rnd = new Random(DateTime.Now.Millisecond);

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                if (MessageBox.Show("This will start testing now. It may take a few minutes to fully complete due to the hardcore nature of this test. Your computer may become unresponsive for a few minutes while processing the headers.\n\nDo you want to continue?", "EASEncoder Fusion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    DisableElementsWithTag.DisableControlsWithTag(this.Controls, "disable");
                    comboOriginator.SelectedIndex = rnd.Next(1, 3);
                    txtSender.Text = "TESTDEMO";
                    comboCode.SelectedIndex = rnd.Next(1, 20);
                    comboLengthHour.SelectedIndex = rnd.Next(1, 99);
                    comboLengthMinutes.SelectedIndex = rnd.Next(1, 60);
                    for (int i = 0; i < 1000; i++)
                    {
                        try
                        {
                            comboState.SelectedIndex = rnd.Next(1, 40);
                            comboCounty.SelectedIndex = rnd.Next(1, 5);
                            Regions.Add(new SAMERegion(_selectedState, _selectedCounty));
                        }
                        catch (Exception) { }
                    }

                    try
                    {
                        datagridRegions.DataSource = new BindingSource(new BindingList<SAMERegion>(Regions), null);
                    }
                    catch (Exception) { }

                    if (rnd.Next(1, 2) == 1) chkEbsTones.Checked = true;
                    else chkEbsTones.Checked = false;

                    if (rnd.Next(1, 2) == 1) chkNwsTone.Checked = true;
                    else chkNwsTone.Checked = false;

                    chkBurstHeaders.Checked = false;

                    txtAnnouncement.Text = "Rainbow meadow dances, tranquil breeze painting whimsical symphony. Serendipitous whispers caress ethereal whispers, blooming moonbeams caressing starlit whispers. Enchanted twilight waltzes, mystic lullabies enchant celestial fireflies. Velvet petals float, embracing whispers of serenity, twilight's embrace cascading gently. Ethereal echoes shimmer, whispering dreamsong amidst enchanted meadows. Luminous whispers guide ethereal wanderers, weaving ephemeral tapestries of infinite wonder. Spiraling stardust illuminates nocturnal whispers, entwining galaxies with ethereal lullabies. Midnight symphony dances, cosmic whispers enthralling the universe. Celestial rivers flow, whispering secrets in celestial languages. Enigmatic whispers echo through enchanted realms, beckoning ethereal voyagers.";

                    _start = dateStart.Value.ToUniversalTime();
                    _senderId = txtSender.Text;
                    _length = ZeroPad(comboLengthHour.Text, 2) + ZeroPad(comboLengthMinutes.Text, 2);

                    var newMessage = new EASMessage(_selectedOriginator.Id, _selectedAlertCode.Id,
                        Regions, _length, _start, _senderId);


                    var messageStream = EASEncoderFusion.EASEncoderFusion.GetMemoryStreamFromNewMessage(newMessage, chkEbsTones.Checked,
                        chkNwsTone.Checked, FormatAnnouncement(txtAnnouncement.Text), chkBurstHeaders.Checked);

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
                        try { player = null; player?.Dispose(); } catch (Exception) { }
                        EnableElementsWithTag.EnableControlsWithTag(this.Controls, "disable");
                        this.ResumeLayout();
                        btnGeneratePlay.Text = "PLAY";
                        this.Hide();
                        MessageBox.Show("Processed 500 areas.");
                        this.Close();
                        checkBox1.Checked = false;
                    };

                    player.Init(volumeStream);

                    player.Play();
                }
                else checkBox1.Checked = false;
            }
            else
            {
                EnableElementsWithTag.EnableControlsWithTag(this.Controls, "disable");
            }
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            
        }

        private void txtAnnouncement_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        private void EditContextMenu_Opening(object sender, CancelEventArgs e)
        {
            toolCut.Enabled = false;
            toolCopy.Enabled = false;
            toolDelete.Enabled = false;
            toolPaste.Enabled = false;
            toolUndoRedo.Enabled = false;

            if (txtAnnouncement.SelectedText != "")
            {
                toolCut.Enabled = true;
                toolCopy.Enabled = true;
                toolDelete.Enabled = true;
            }
            if (Clipboard.ContainsText())
            {
                toolPaste.Enabled = true;
            }
            if (txtAnnouncement.CanUndo)
            {
                toolUndoRedo.Enabled = true;
            }
        }

        private void toolUndoRedo_Click(object sender, EventArgs e)
        {
            if (txtAnnouncement.CanUndo) txtAnnouncement.Undo();
        }

        private void toolCut_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtAnnouncement.SelectedText))
            {
                Clipboard.SetText(txtAnnouncement.SelectedText);
                txtAnnouncement.Text = txtAnnouncement.Text.Remove(txtAnnouncement.SelectionStart, txtAnnouncement.SelectionLength);
            }
        }


        private void toolCopy_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtAnnouncement.SelectedText))
            {
                Clipboard.SetText(txtAnnouncement.SelectedText);
            }
        }

        private void toolDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtAnnouncement.SelectedText))
            {
                txtAnnouncement.Text = txtAnnouncement.Text.Remove(txtAnnouncement.SelectionStart, txtAnnouncement.SelectionLength);
            }
        }

        private void toolPaste_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                string clipboardText = Clipboard.GetText();
                int caretPosition = txtAnnouncement.SelectionStart;
                txtAnnouncement.Text = txtAnnouncement.Text.Insert(caretPosition, clipboardText);
                txtAnnouncement.SelectionStart = caretPosition + clipboardText.Length;
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