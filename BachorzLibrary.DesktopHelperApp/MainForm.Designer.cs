
namespace BachorzLibrary.DesktopHelperApp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonNugetPacker = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonNugetPacker
            // 
            this.buttonNugetPacker.Location = new System.Drawing.Point(83, 37);
            this.buttonNugetPacker.Name = "buttonNugetPacker";
            this.buttonNugetPacker.Size = new System.Drawing.Size(96, 23);
            this.buttonNugetPacker.TabIndex = 0;
            this.buttonNugetPacker.Text = "Nuget Packer";
            this.buttonNugetPacker.UseVisualStyleBackColor = true;
            this.buttonNugetPacker.Click += new System.EventHandler(this.buttonNugetPacker_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 114);
            this.Controls.Add(this.buttonNugetPacker);
            this.Name = "MainForm";
            this.Text = "Desktop Helper App";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonNugetPacker;
    }
}

