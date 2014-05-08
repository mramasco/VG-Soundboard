namespace Soundboard
{
    partial class ButtonPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PlayButton = new System.Windows.Forms.Button();
            this.loopCheckBox = new System.Windows.Forms.CheckBox();
            this.volumeSlider = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.volumeSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // PlayButton
            // 
            this.PlayButton.Location = new System.Drawing.Point(4, 4);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(66, 66);
            this.PlayButton.TabIndex = 1;
            this.PlayButton.Text = "Right Click To Set";
            this.PlayButton.UseVisualStyleBackColor = true;
            this.PlayButton.Click += new System.EventHandler(this.button1_Click);
            this.PlayButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonRightClick);
            // 
            // loopCheckBox
            // 
            this.loopCheckBox.AutoSize = true;
            this.loopCheckBox.Location = new System.Drawing.Point(76, 30);
            this.loopCheckBox.Name = "loopCheckBox";
            this.loopCheckBox.Size = new System.Drawing.Size(50, 17);
            this.loopCheckBox.TabIndex = 2;
            this.loopCheckBox.Text = "Loop";
            this.loopCheckBox.UseVisualStyleBackColor = true;
            this.loopCheckBox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // volumeSlider
            // 
            this.volumeSlider.Location = new System.Drawing.Point(4, 77);
            this.volumeSlider.Name = "volumeSlider";
            this.volumeSlider.Size = new System.Drawing.Size(150, 45);
            this.volumeSlider.TabIndex = 4;
            this.volumeSlider.Value = 10;
            this.volumeSlider.Scroll += new System.EventHandler(this.volumeSlider_Scroll);
            // 
            // ButtonPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.volumeSlider);
            this.Controls.Add(this.loopCheckBox);
            this.Controls.Add(this.PlayButton);
            this.Name = "ButtonPanel";
            this.Size = new System.Drawing.Size(154, 122);
            ((System.ComponentModel.ISupportInitialize)(this.volumeSlider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button PlayButton;
        private System.Windows.Forms.CheckBox loopCheckBox;
        private System.Windows.Forms.TrackBar volumeSlider;
    }
}
