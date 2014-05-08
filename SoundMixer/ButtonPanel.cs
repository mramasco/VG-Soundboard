using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Soundboard
{
    public partial class ButtonPanel : UserControl
    {
        private string _soundLocation;
        public string SoundLocation 
        {
            get
            {
                return _soundLocation;
            }
            set
            {
                _soundLocation = value;
                RegisterSound();
            }
        }
        public Keys HotKey { get; set; }
        public ModifierKeys ModifierKey {get; set; }
        public Color ControlColor;
        public Color ButtonColor;
        private SoundQueue _soundQueue;
        private Guid id;

        public string ButtonText
        { 
            get { return PlayButton.Text; }
            set { PlayButton.Text = value; }
        }

        public bool Loop
        { 
            get { return loopCheckBox.Checked; }
            set { loopCheckBox.Checked = value;
           
            }
        }
        public double Volume
        { 
            get { return VolumeFromSlider(); }
            set { volumeSlider.Value = (int)(value * 10); }
        }

        public ButtonPanel(SoundQueue soundQueue)
        {
            InitializeComponent();
            _soundQueue = soundQueue;
            HotKey = Keys.None;
            ModifierKey = Soundboard.ModifierKeys.None;
            ControlColor = Color.FromArgb(255, 240, 240, 240);
            ButtonColor = ControlColor;
            var test = ButtonText;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            PlaySound();
        }

        private void RegisterSound()
        {
            if (!string.IsNullOrEmpty(SoundLocation))
            {

                if (id != null)
                {
                    _soundQueue.UnregisterSound(id);
                }

                id = _soundQueue.RegisterSound(SoundLocation, VolumeFromSlider(), loopCheckBox.Checked);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            RegisterSound();
        }

        private void ButtonRightClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                PopupForm childForm = new PopupForm(PlayButton.Text, SoundLocation, HotKey, ModifierKey, ButtonColor);
                childForm.ShowDialog();
                PlayButton.Text = childForm.ButtonText;
                SoundLocation = childForm.SoundLocation;
                HotKey = childForm.HotKey;
                ModifierKey = childForm.ModifierKey;
            }
        }

        public void HandleHotkey()
        {
        
            PlaySound();
        }

        private void PlaySound()
        {
            if (!String.IsNullOrEmpty(SoundLocation))
            {
                if (id != null)
                {
                    _soundQueue.PlaySound(id);
                }
            }
        }

        private double VolumeFromSlider()
        {
            var vol = ((double)volumeSlider.Value / 10);
            Console.WriteLine("slider: " + volumeSlider.Value + " vol: " + vol);

            //strange bug causing 1 to be lower than .9
            //if (vol == 1)
            //    return .99f;
             
            return vol;
        }

        private void volumeSlider_Scroll(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(SoundLocation))
            {
                if (id != null)
                {
                    _soundQueue.SetVolume(VolumeFromSlider(), id);
                }
            }
        }

    }
}
