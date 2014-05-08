using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Soundboard
{
    public partial class SetHotkeyPopup : Form
    {
        public Keys Key { get; set; }

        public SetHotkeyPopup()
        {
            InitializeComponent();
        }

        private void HandleKeyInput(object sender, KeyEventArgs e)
        {
            Key = e.KeyCode;
            Console.WriteLine(Key);
            Close();
        }

    }
}
