namespace Soundboard
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
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.label1 = new System.Windows.Forms.Label();
            this.transparencySlider = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.masterVolume = new System.Windows.Forms.TrackBar();
            this.hotKeyModifierDropDown = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.stopHotKeyText = new System.Windows.Forms.TextBox();
            this.setStopHotkey = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.saveConfigButton = new System.Windows.Forms.Button();
            this.loadConfigButton = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.playbackDeviceList = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.playCurrentTabCheck = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.transparencySlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterVolume)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(486, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "New Tab";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.NewTab_Click);
            // 
            // tabControl
            // 
            this.tabControl.AllowDrop = true;
            this.tabControl.Location = new System.Drawing.Point(1, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(479, 389);
            this.tabControl.TabIndex = 0;
            this.tabControl.DragOver += new System.Windows.Forms.DragEventHandler(this.tc_DragOver);
            this.tabControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tc_MouseDown);
            this.tabControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tc_MouseMove);
            this.tabControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tc_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(487, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Transparency";
            // 
            // transparencySlider
            // 
            this.transparencySlider.Location = new System.Drawing.Point(490, 69);
            this.transparencySlider.Name = "transparencySlider";
            this.transparencySlider.Size = new System.Drawing.Size(197, 45);
            this.transparencySlider.TabIndex = 3;
            this.transparencySlider.Value = 10;
            this.transparencySlider.Scroll += new System.EventHandler(this.transparencySlider_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(489, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Master Volume";
            // 
            // masterVolume
            // 
            this.masterVolume.LargeChange = 1;
            this.masterVolume.Location = new System.Drawing.Point(490, 120);
            this.masterVolume.Name = "masterVolume";
            this.masterVolume.Size = new System.Drawing.Size(197, 45);
            this.masterVolume.TabIndex = 5;
            this.masterVolume.Value = 10;
            this.masterVolume.Scroll += new System.EventHandler(this.masterVolume_Scroll);
            // 
            // hotKeyModifierDropDown
            // 
            this.hotKeyModifierDropDown.FormattingEnabled = true;
            this.hotKeyModifierDropDown.Location = new System.Drawing.Point(561, 217);
            this.hotKeyModifierDropDown.Name = "hotKeyModifierDropDown";
            this.hotKeyModifierDropDown.Size = new System.Drawing.Size(58, 21);
            this.hotKeyModifierDropDown.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(490, 220);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Modifier Key";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(490, 194);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Hot Key";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 73);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "Stop All";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // stopHotKeyText
            // 
            this.stopHotKeyText.AllowDrop = true;
            this.stopHotKeyText.Enabled = false;
            this.stopHotKeyText.Location = new System.Drawing.Point(561, 191);
            this.stopHotKeyText.Name = "stopHotKeyText";
            this.stopHotKeyText.Size = new System.Drawing.Size(58, 20);
            this.stopHotKeyText.TabIndex = 16;
            // 
            // setStopHotkey
            // 
            this.setStopHotkey.Location = new System.Drawing.Point(139, 18);
            this.setStopHotkey.Name = "setStopHotkey";
            this.setStopHotkey.Size = new System.Drawing.Size(52, 23);
            this.setStopHotkey.TabIndex = 17;
            this.setStopHotkey.Text = "Set";
            this.setStopHotkey.UseVisualStyleBackColor = true;
            this.setStopHotkey.Click += new System.EventHandler(this.setStopHotkey_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.setStopHotkey);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Location = new System.Drawing.Point(486, 171);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(201, 106);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Master Stop All";
            // 
            // saveConfigButton
            // 
            this.saveConfigButton.Location = new System.Drawing.Point(531, 355);
            this.saveConfigButton.Name = "saveConfigButton";
            this.saveConfigButton.Size = new System.Drawing.Size(75, 23);
            this.saveConfigButton.TabIndex = 19;
            this.saveConfigButton.Text = "Save";
            this.saveConfigButton.UseVisualStyleBackColor = true;
            this.saveConfigButton.Click += new System.EventHandler(this.saveConfigButton_Click);
            // 
            // loadConfigButton
            // 
            this.loadConfigButton.Location = new System.Drawing.Point(612, 355);
            this.loadConfigButton.Name = "loadConfigButton";
            this.loadConfigButton.Size = new System.Drawing.Size(75, 23);
            this.loadConfigButton.TabIndex = 20;
            this.loadConfigButton.Text = "Load ";
            this.loadConfigButton.UseVisualStyleBackColor = true;
            this.loadConfigButton.Click += new System.EventHandler(this.loadConfigButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // playbackDeviceList
            // 
            this.playbackDeviceList.FormattingEnabled = true;
            this.playbackDeviceList.Location = new System.Drawing.Point(486, 299);
            this.playbackDeviceList.Name = "playbackDeviceList";
            this.playbackDeviceList.Size = new System.Drawing.Size(201, 49);
            this.playbackDeviceList.TabIndex = 21;
            this.playbackDeviceList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox1_ItemCheck);
            this.playbackDeviceList.SelectedIndexChanged += new System.EventHandler(this.playbackDeviceList_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(483, 283);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Playback Devices:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // playCurrentTabCheck
            // 
            this.playCurrentTabCheck.AutoSize = true;
            this.playCurrentTabCheck.Checked = true;
            this.playCurrentTabCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.playCurrentTabCheck.Location = new System.Drawing.Point(567, 26);
            this.playCurrentTabCheck.Name = "playCurrentTabCheck";
            this.playCurrentTabCheck.Size = new System.Drawing.Size(129, 17);
            this.playCurrentTabCheck.TabIndex = 23;
            this.playCurrentTabCheck.Text = "Play Current Tab Only";
            this.playCurrentTabCheck.UseVisualStyleBackColor = true;
            this.playCurrentTabCheck.CheckedChanged += new System.EventHandler(this.playCurrentTabCheck_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 390);
            this.Controls.Add(this.playCurrentTabCheck);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.playbackDeviceList);
            this.Controls.Add(this.loadConfigButton);
            this.Controls.Add(this.saveConfigButton);
            this.Controls.Add(this.stopHotKeyText);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.hotKeyModifierDropDown);
            this.Controls.Add(this.masterVolume);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.transparencySlider);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "VG Soundboard";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.transparencySlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterVolume)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar transparencySlider;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar masterVolume;
        private System.Windows.Forms.ComboBox hotKeyModifierDropDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox stopHotKeyText;
        private System.Windows.Forms.Button setStopHotkey;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button saveConfigButton;
        private System.Windows.Forms.Button loadConfigButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.CheckedListBox playbackDeviceList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox playCurrentTabCheck;

    }
}

