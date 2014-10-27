using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Collections;
using System.IO;

namespace Soundboard
{
    public partial class PopupForm : Form
    {
        public string SoundLocation { get; set; }
        public string ButtonText { get; set; }
        public Keys HotKey { get; set; }
        public ModifierKeys ModifierKey { get; set; }
        public Color Color { get; set; }
        private Keys tempKey;

        public PopupForm(string buttonText, string soundLocation, Keys hotKey, ModifierKeys modifierKey, Color color)
        {
            InitializeComponent();
            
            //set text fields
            buttotTextTextBox.Text = buttonText;
            soundPathTextBox.Text = soundLocation;

            //populate drop downs
            //hotKeyDropDown.DataSource = Enum.GetValues(typeof(Keys));
            modifierDropDown.DataSource = Enum.GetValues(typeof(ModifierKeys));
            
            //color dropdown
            ArrayList ColorList = new ArrayList();
            Type colorType = typeof(System.Drawing.Color);
            PropertyInfo[] propInfoList = colorType.GetProperties(BindingFlags.Static |
                                          BindingFlags.DeclaredOnly | BindingFlags.Public);
            foreach (PropertyInfo c in propInfoList)
            {
                this.colorDropDown.Items.Add(c.Name);
            }
            colorDropDown.Items.Add(color.Name);
            colorDropDown.DrawMode = DrawMode.OwnerDrawFixed;
            colorDropDown.SelectedValue = color.Name;

            //set to current host keyValue
            //hotKeyDropDown.SelectedIndex = (int)hotKey;
            hotKeyText.Text = hotKey.ToString();
            tempKey = hotKey;

            modifierDropDown.SelectedIndex = (int)modifierKey;

            //set class level fields
            SoundLocation = soundLocation;
            ButtonText = buttonText;
            HotKey = hotKey;
            ModifierKey = modifierKey;

            //set file dialog filter
            openFileDialog1.Filter = "Sound Files (*.wav, *.mp3) | *.wav; *mp3";
            
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            ButtonText = buttotTextTextBox.Text;
            SoundLocation = soundPathTextBox.Text;
            HotKey = tempKey;
            ModifierKey =(ModifierKeys)modifierDropDown.SelectedIndex;
            Close();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            
            //if(openFileDialog1.CheckFileExists && openFileDialog1.
            soundPathTextBox.Text = openFileDialog1.FileName.ToString();
            buttotTextTextBox.Text = Path.GetFileNameWithoutExtension(openFileDialog1.FileName.ToString());

        }

        private void cmbboxClr_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = e.Bounds;
            if (e.Index >= 0)
            {
                string n = ((ComboBox)sender).Items[e.Index].ToString();
                Font f = new Font("Arial", 9, FontStyle.Regular);
                Color c = Color.FromName(n);
                Brush b = new SolidBrush(c);
                g.DrawString(n, f, Brushes.Black, rect.X, rect.Top);
                g.FillRectangle(b, rect.X + 110, rect.Y + 5,
                                rect.Width - 10, rect.Height - 10);
            }
        }

        private void setHotkey_Click(object sender, EventArgs e)
        {
            SetHotkeyPopup childForm = new SetHotkeyPopup();
            childForm.ShowDialog();
            tempKey = childForm.Key;
            hotKeyText.Text = tempKey.ToString();
        }
    }
}
