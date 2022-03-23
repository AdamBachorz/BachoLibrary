
namespace BachorzLibrary.DesktopHelperApp.OtherForms
{
    partial class NugetPackerForm
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
            this.buttonPack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonPack
            // 
            this.buttonPack.Location = new System.Drawing.Point(115, 11);
            this.buttonPack.Name = "buttonPack";
            this.buttonPack.Size = new System.Drawing.Size(75, 23);
            this.buttonPack.TabIndex = 0;
            this.buttonPack.Text = "Pack";
            this.buttonPack.UseVisualStyleBackColor = true;
            this.buttonPack.Click += new System.EventHandler(this.buttonPack_Click);
            // 
            // NugetPackerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 46);
            this.Controls.Add(this.buttonPack);
            this.Name = "NugetPackerForm";
            this.Text = "Nuget Packer";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonPack;
    }
}