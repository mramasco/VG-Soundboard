namespace Soundboard
{
    partial class PopupForm
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
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttotTextTextBox = new System.Windows.Forms.TextBox();
            this.soundPathTextBox = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.browseButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.modifierDropDown = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.colorDropDown = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.setHotkey = new System.Windows.Forms.Button();
            this.hotKeyText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(217, 122);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(298, 122);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Button Text";
            // 
            // buttotTextTextBox
            // 
            this.buttotTextTextBox.Location = new System.Drawing.Point(80, 9);
            this.buttotTextTextBox.Name = "buttotTextTextBox";
            this.buttotTextTextBox.Size = new System.Drawing.Size(212, 20);
            this.buttotTextTextBox.TabIndex = 3;
            // 
            // soundPathTextBox
            // 
            this.soundPathTextBox.Location = new System.Drawing.Point(80, 38);
            this.soundPathTextBox.Name = "soundPathTextBox";
            this.soundPathTextBox.Size = new System.Drawing.Size(212, 20);
            this.soundPathTextBox.TabIndex = 4;
            // 
            // browseButton
            // 
            this.browseButton.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.browseButton.Location = new System.Drawing.Point(298, 38);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 5;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "File Location";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(155, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Hot Key";
            // 
            // modifierDropDown
            // 
            this.modifierDropDown.FormattingEnabled = true;
            this.modifierDropDown.Location = new System.Drawing.Point(80, 64);
            this.modifierDropDown.Name = "modifierDropDown";
            this.modifierDropDown.Size = new System.Drawing.Size(69, 21);
            this.modifierDropDown.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Modifier";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // colorDropDown
            // 
            this.colorDropDown.FormattingEnabled = true;
            this.colorDropDown.Location = new System.Drawing.Point(80, 92);
            this.colorDropDown.Name = "colorDropDown";
            this.colorDropDown.Size = new System.Drawing.Size(212, 21);
            this.colorDropDown.TabIndex = 12;
            this.colorDropDown.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cmbboxClr_DrawItem);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Color";
            // 
            // setHotkey
            // 
            this.setHotkey.Location = new System.Drawing.Point(298, 62);
            this.setHotkey.Name = "setHotkey";
            this.setHotkey.Size = new System.Drawing.Size(75, 23);
            this.setHotkey.TabIndex = 14;
            this.setHotkey.Text = "Set";
            this.setHotkey.UseVisualStyleBackColor = true;
            this.setHotkey.Click += new System.EventHandler(this.setHotkey_Click);
            // 
            // hotKeyText
            // 
            this.hotKeyText.Enabled = false;
            this.hotKeyText.Location = new System.Drawing.Point(206, 64);
            this.hotKeyText.Name = "hotKeyText";
            this.hotKeyText.Size = new System.Drawing.Size(86, 20);
            this.hotKeyText.TabIndex = 15;
            // 
            // PopupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(387, 157);
            this.ControlBox = false;
            this.Controls.Add(this.hotKeyText);
            this.Controls.Add(this.setHotkey);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.colorDropDown);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.modifierDropDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.soundPathTextBox);
            this.Controls.Add(this.buttotTextTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PopupForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Button Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox buttotTextTextBox;
        private System.Windows.Forms.TextBox soundPathTextBox;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox modifierDropDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox colorDropDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button setHotkey;
        private System.Windows.Forms.TextBox hotKeyText;
    }
}