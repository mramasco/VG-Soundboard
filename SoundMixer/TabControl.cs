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
    public partial class TabControlPopup : Form
    {
        public bool RemoveTab { get; set; }
        public string TabName { get; set; }

        public TabControlPopup(string tabName)
        {
            InitializeComponent();
            tabNameTextBox.Text = tabName;
            TabName = tabName;
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Really delete?", "Confirm delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                RemoveTab = true;
                Close();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            TabName = tabNameTextBox.Text;
            Close();
        }
    }
}
