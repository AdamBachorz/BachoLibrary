
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NugetPackerForm));
            this.buttonPack = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelUpcomingVersion = new System.Windows.Forms.Label();
            this.buttonOpenPackagesDirectory = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonPack
            // 
            this.buttonPack.Location = new System.Drawing.Point(12, 43);
            this.buttonPack.Name = "buttonPack";
            this.buttonPack.Size = new System.Drawing.Size(75, 23);
            this.buttonPack.TabIndex = 0;
            this.buttonPack.Text = "Pack";
            this.buttonPack.UseVisualStyleBackColor = true;
            this.buttonPack.Click += new System.EventHandler(this.buttonPack_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Upcoming version:";
            // 
            // labelUpcomingVersion
            // 
            this.labelUpcomingVersion.AutoSize = true;
            this.labelUpcomingVersion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelUpcomingVersion.Location = new System.Drawing.Point(125, 13);
            this.labelUpcomingVersion.Name = "labelUpcomingVersion";
            this.labelUpcomingVersion.Size = new System.Drawing.Size(34, 15);
            this.labelUpcomingVersion.TabIndex = 2;
            this.labelUpcomingVersion.Text = "0.0.0";
            // 
            // buttonOpenPackagesDirectory
            // 
            this.buttonOpenPackagesDirectory.Location = new System.Drawing.Point(93, 43);
            this.buttonOpenPackagesDirectory.Name = "buttonOpenPackagesDirectory";
            this.buttonOpenPackagesDirectory.Size = new System.Drawing.Size(155, 23);
            this.buttonOpenPackagesDirectory.TabIndex = 3;
            this.buttonOpenPackagesDirectory.Text = "Open Packages Directory";
            this.buttonOpenPackagesDirectory.UseVisualStyleBackColor = true;
            this.buttonOpenPackagesDirectory.Click += new System.EventHandler(this.buttonOpenPackagesDirectory_Click);
            // 
            // NugetPackerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 78);
            this.Controls.Add(this.buttonOpenPackagesDirectory);
            this.Controls.Add(this.labelUpcomingVersion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonPack);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NugetPackerForm";
            this.Text = "Nuget Packer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonPack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelUpcomingVersion;
        private System.Windows.Forms.Button buttonOpenPackagesDirectory;
    }
}