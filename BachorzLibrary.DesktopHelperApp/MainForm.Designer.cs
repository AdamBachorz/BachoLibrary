
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.buttonNugetPacker = new System.Windows.Forms.Button();
            this.buttonPoligon = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonNugetPacker
            // 
            this.buttonNugetPacker.Location = new System.Drawing.Point(71, 10);
            this.buttonNugetPacker.Name = "buttonNugetPacker";
            this.buttonNugetPacker.Size = new System.Drawing.Size(96, 23);
            this.buttonNugetPacker.TabIndex = 0;
            this.buttonNugetPacker.Text = "Nuget Packer";
            this.buttonNugetPacker.UseVisualStyleBackColor = true;
            this.buttonNugetPacker.Click += new System.EventHandler(this.buttonNugetPacker_Click);
            // 
            // buttonPoligon
            // 
            this.buttonPoligon.Location = new System.Drawing.Point(71, 39);
            this.buttonPoligon.Name = "buttonPoligon";
            this.buttonPoligon.Size = new System.Drawing.Size(96, 23);
            this.buttonPoligon.TabIndex = 1;
            this.buttonPoligon.Text = "Poligon";
            this.buttonPoligon.UseVisualStyleBackColor = true;
            this.buttonPoligon.Click += new System.EventHandler(this.buttonPoligon_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 74);
            this.Controls.Add(this.buttonPoligon);
            this.Controls.Add(this.buttonNugetPacker);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Desktop Helper App";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonNugetPacker;
        private System.Windows.Forms.Button buttonPoligon;
    }
}

