using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utilities;
using Soundboard;
using Soundboard.Configuration;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using NAudio.Wave;

namespace Soundboard
{
    public partial class Form1 : Form
    {
        GlobalKeyHook keyHook = new GlobalKeyHook();
        SoundQueue _soundQueue = new SoundQueue();
        List<ButtonPanel> buttonPanels = new List<ButtonPanel>();
        Keys stopAllHotkey;
        public static double MasterVolume = 1;
        public static List<int> PlayBackDevices = new List<int>();

        public Form1()
        {
            InitializeComponent();
            CreateNewTab();
            keyHook.KeyDown += new KeyEventHandler(gkh_KeyDown);
            keyHook.KeyUp += new KeyEventHandler(gkh_KeyUp);
            tabControl.MouseDown += TabClick;
            hotKeyModifierDropDown.DataSource = Enum.GetValues(typeof(ModifierKeys));
            saveFileDialog1.Filter = "xml | *.xml";
            openFileDialog1.Filter = "xml | *.xml";

            InitializePlaybackDevices();
            _soundQueue.SetMasterVolume(MasterVolume);

        }

        private void InitializePlaybackDevices()
        {
            for (int deviceId = 0; deviceId < WaveOut.DeviceCount; deviceId++)
            {
                var capabilities = WaveOut.GetCapabilities(deviceId);
                string name = capabilities.ProductName;
                playbackDeviceList.Items.Add(name);
            }

            playbackDeviceList.SetItemChecked(0, true);
            //PlayBackDevices.Add(0);
        }


        private void saveButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NewTab_Click(object sender, EventArgs e)
        {
            CreateNewTab();
        }

        private void CreateNewTab()
        {

            TabPage tab = new TabPage("Tab " + (tabControl.TabPages.Count + 1));
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    ButtonPanel b = new ButtonPanel(_soundQueue);
                    buttonPanels.Add(b);
                    b.Parent = tab;
                    b.Location = new Point(i * b.Width, j * b.Height);
                }
            }
            tabControl.TabPages.Add(tab);
        }

        private void TabClick(object sender, MouseEventArgs e)
        {
            TabPage tab = null;
            if (e.Button == MouseButtons.Right)
            {
                // iterate through all the tab pages
                for (int i = 0; i < tabControl.TabCount; i++)
                {
                    // get their rectangle area and check if it contains the mouse cursor
                    Rectangle r = tabControl.GetTabRect(i);
                    if (r.Contains(e.Location))
                    {
                        tab = tabControl.TabPages[i];
                        TabControlPopup popup = new TabControlPopup(tabControl.TabPages[i].Text);
                        popup.ShowDialog();

                        if (popup.RemoveTab)
                        {
                            tabControl.TabPages.RemoveAt(i);
                        }
                        else
                        {
                            tabControl.TabPages[i].Text = popup.TabName;
                        }
                    }
                }
            }
        }

        private void transparencySlider_Scroll(object sender, EventArgs e)
        {   
            Opacity = ((float)transparencySlider.Value / 20) + .5; 
        }

        void gkh_KeyUp(object sender, KeyEventArgs e)
        {

        }

        //key down handle for global keys
        void gkh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == stopAllHotkey
                 && ConvertModifierKey(e.Modifiers) == (ModifierKeys)hotKeyModifierDropDown.SelectedIndex)
            {
                _soundQueue.StopAll();
            }
            else
            {
                foreach (var button in buttonPanels)
                {

                    if (button.HotKey == e.KeyCode
                        && button.ModifierKey == ConvertModifierKey(e.Modifiers))
                    {
                        if (playCurrentTabCheck.Checked)
                        {
                            if (button.Parent == tabControl.SelectedTab)
                            {
                                button.HandleHotkey();
                            }
                        }
                        else
                        {
                            button.HandleHotkey();
                        }
                    }
                }

                e.Handled = true;
            }
        }

        private ModifierKeys ConvertModifierKey(Keys mod)
        {
            switch (mod)
            {
                case Keys.Alt:
                    return Soundboard.ModifierKeys.Alt;
                case Keys.Control:
                    return Soundboard.ModifierKeys.Control;
                case Keys.None:
                    return Soundboard.ModifierKeys.None;
                default :
                    return Soundboard.ModifierKeys.None;
            }
        }

        private void masterVolume_Scroll(object sender, EventArgs e)
        {
            MasterVolume = (double)masterVolume.Value / 10;
            _soundQueue.SetMasterVolume(MasterVolume);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _soundQueue.StopAll();
        }

        private void setStopHotkey_Click(object sender, EventArgs e)
        {
            SetHotkeyPopup childForm = new SetHotkeyPopup();
            childForm.ShowDialog();
            stopHotKeyText.Text = childForm.Key.ToString();
            stopAllHotkey = childForm.Key;
        }

        private void saveConfigButton_Click(object sender, EventArgs e)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(SoundBoardConfigurationData));
            var result = saveFileDialog1.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                SoundBoardConfigurationData data = new SoundBoardConfigurationData();
                data.MasterStopHotKey = stopAllHotkey;
                data.MasterStopModifier = (ModifierKeys)hotKeyModifierDropDown.SelectedIndex;
                data.MasterVolume = MasterVolume;
                data.Transparency = Opacity;
                data.Tabs = new List<TabConfiguration>();

                for (int i = 0; i < tabControl.TabCount; i++)
                {
                    TabConfiguration tabConfig = new TabConfiguration();
                    tabConfig.TabName = tabControl.TabPages[i].Text;
                    tabConfig.Buttons = new List<ButtonConfiguration>();
                    foreach (var control in tabControl.TabPages[i].Controls)
                    {
                        var buttonPanel = control as ButtonPanel;
                        if (buttonPanel != null)
                        {
                            ButtonConfiguration buttonConfig = new ButtonConfiguration()
                            {
                                ButtonText = buttonPanel.ButtonText,
                                HotKey = buttonPanel.HotKey,
                                Loop = buttonPanel.Loop,
                                ModifierKey = buttonPanel.ModifierKey,
                                SoundLocation = buttonPanel.SoundLocation,
                                Volume = buttonPanel.Volume
                            };
                            tabConfig.Buttons.Add(buttonConfig);

                        }
                    }

                    data.Tabs.Add(tabConfig);
                }

                TextWriter writer = new StreamWriter(saveFileDialog1.FileName);
                serializer.Serialize(writer, data);
                writer.Close();
            }
        }

        private void loadConfigButton_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {

                XmlSerializer serializer = new
                XmlSerializer(typeof(SoundBoardConfigurationData));
                FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open);
                XmlReader reader = XmlReader.Create(fs);

                SoundBoardConfigurationData data = (SoundBoardConfigurationData)serializer.Deserialize(reader);
                fs.Close();

                _soundQueue.StopAll();
                _soundQueue.ResetQueue();
                tabControl.TabPages.Clear();

                stopAllHotkey = data.MasterStopHotKey;
                stopHotKeyText.Text = stopAllHotkey.ToString();
                hotKeyModifierDropDown.SelectedIndex = (int)data.MasterStopModifier;
                transparencySlider.Value = (int)(20  *(data.Transparency - .5));
                Opacity = data.Transparency;
                masterVolume.Value = (int)(10 * data.MasterVolume);
                _soundQueue.SetMasterVolume(data.MasterVolume);

                foreach (var tab in data.Tabs)
                {
                    TabPage tabPage = new TabPage(tab.TabName);
                    int i = 0;
                    int j = 0;
                    foreach (var button in tab.Buttons)
                    {
                        ButtonPanel buttonPanel = new ButtonPanel(_soundQueue)
                        {
                            Volume = button.Volume,
                            SoundLocation = button.SoundLocation,
                            ButtonText = button.ButtonText,
                            HotKey = button.HotKey,
                            ModifierKey = button.ModifierKey,
                            Loop = button.Loop,                       
                        };

                        buttonPanels.Add(buttonPanel);
                        buttonPanel.Parent = tabPage;
                        buttonPanel.Location = new Point(j * buttonPanel.Width, i * buttonPanel.Height);
                        i++;
                        if (i == 3)
                        {
                            i = 0;
                            j++;
                        }
                    }

                    tabControl.TabPages.Add(tabPage);
                }

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void playbackDeviceList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                if (!PlayBackDevices.Contains(e.Index))
                {
                    PlayBackDevices.Add(e.Index);
                }
            }
            else
            {
                if (PlayBackDevices.Contains(e.Index))
                {
                    PlayBackDevices.Remove(e.Index);
                }
            }
        }

        private void tc_MouseDown(object sender, MouseEventArgs e)
        {
            // store clicked tab
            TabControl tc = (TabControl)sender;
            int hover_index = this.getHoverTabIndex(tc);
            if (hover_index >= 0) { tc.Tag = tc.TabPages[hover_index]; }
        }
        private void tc_MouseUp(object sender, MouseEventArgs e)
        {
            // clear stored tab
            TabControl tc = (TabControl)sender;
            tc.Tag = null;
        }
        private void tc_MouseMove(object sender, MouseEventArgs e)
        {
            // mouse button down? tab was clicked?
            TabControl tc = (TabControl)sender;
            if ((e.Button != MouseButtons.Left) || (tc.Tag == null)) return;
            TabPage clickedTab = (TabPage)tc.Tag;
            int clicked_index = tc.TabPages.IndexOf(clickedTab);

            // start drag n drop
            tc.DoDragDrop(clickedTab, DragDropEffects.All);
        }
        private void tc_DragOver(object sender, DragEventArgs e)
        {
            TabControl tc = (TabControl)sender;

            // a tab is draged?
            if (e.Data.GetData(typeof(TabPage)) == null) return;
            TabPage dragTab = (TabPage)e.Data.GetData(typeof(TabPage));
            int dragTab_index = tc.TabPages.IndexOf(dragTab);

            // hover over a tab?
            int hoverTab_index = this.getHoverTabIndex(tc);
            if (hoverTab_index < 0) { e.Effect = DragDropEffects.None; return; }
            TabPage hoverTab = tc.TabPages[hoverTab_index];
            e.Effect = DragDropEffects.Move;

            // start of drag?
            if (dragTab == hoverTab) return;

            // swap dragTab & hoverTab - avoids toggeling
            Rectangle dragTabRect = tc.GetTabRect(dragTab_index);
            Rectangle hoverTabRect = tc.GetTabRect(hoverTab_index);

            if (dragTabRect.Width < hoverTabRect.Width)
            {
                Point tcLocation = tc.PointToScreen(tc.Location);

                if (dragTab_index < hoverTab_index)
                {
                    if ((e.X - tcLocation.X) > ((hoverTabRect.X + hoverTabRect.Width) - dragTabRect.Width))
                        this.swapTabPages(tc, dragTab, hoverTab);
                }
                else if (dragTab_index > hoverTab_index)
                {
                    if ((e.X - tcLocation.X) < (hoverTabRect.X + dragTabRect.Width))
                        this.swapTabPages(tc, dragTab, hoverTab);
                }
            }
            else this.swapTabPages(tc, dragTab, hoverTab);

            // select new pos of dragTab
            tc.SelectedIndex = tc.TabPages.IndexOf(dragTab);
        }

        private int getHoverTabIndex(TabControl tc)
        {
            for (int i = 0; i < tc.TabPages.Count; i++)
            {
                if (tc.GetTabRect(i).Contains(tc.PointToClient(Cursor.Position)))
                    return i;
            }

            return -1;
        }

        private void swapTabPages(TabControl tc, TabPage src, TabPage dst)
        {
            int index_src = tc.TabPages.IndexOf(src);
            int index_dst = tc.TabPages.IndexOf(dst);
            tc.TabPages[index_dst] = src;
            tc.TabPages[index_src] = dst;
            tc.Refresh();
        }

        private void playCurrentTabCheck_CheckedChanged(object sender, EventArgs e)
        {

        }

    }
}
