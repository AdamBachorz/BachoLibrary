
namespace BachorzLibrary.DesktopHelperApp.OtherForms
{
    partial class PoligonForm
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
            this.buttonLocate = new System.Windows.Forms.Button();
            this.buttonGenerateDoc = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonLocate
            // 
            this.buttonLocate.Location = new System.Drawing.Point(34, 29);
            this.buttonLocate.Name = "buttonLocate";
            this.buttonLocate.Size = new System.Drawing.Size(131, 23);
            this.buttonLocate.TabIndex = 0;
            this.buttonLocate.Text = "Wybierz lokalizacje";
            this.buttonLocate.UseVisualStyleBackColor = true;
            this.buttonLocate.Click += new System.EventHandler(this.buttonLocate_Click);
            // 
            // buttonGenerateDoc
            // 
            this.buttonGenerateDoc.Location = new System.Drawing.Point(34, 58);
            this.buttonGenerateDoc.Name = "buttonGenerateDoc";
            this.buttonGenerateDoc.Size = new System.Drawing.Size(131, 23);
            this.buttonGenerateDoc.TabIndex = 1;
            this.buttonGenerateDoc.Text = "Generuj dokument";
            this.buttonGenerateDoc.UseVisualStyleBackColor = true;
            this.buttonGenerateDoc.Click += new System.EventHandler(this.buttonGenerateDoc_Click);
            // 
            // PoligonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 450);
            this.Controls.Add(this.buttonGenerateDoc);
            this.Controls.Add(this.buttonLocate);
            this.Name = "PoligonForm";
            this.Text = "PoligonForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonLocate;
        private System.Windows.Forms.Button buttonGenerateDoc;
    }
}