
namespace CaixeiroViajante
{
    partial class Main
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
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxCountPoints = new System.Windows.Forms.TextBox();
            this.textBoxPathReport = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ButtonChangedPath = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(432, 180);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Gerar Relatório";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // textBoxCountPoints
            // 
            this.textBoxCountPoints.Location = new System.Drawing.Point(212, 99);
            this.textBoxCountPoints.Name = "textBoxCountPoints";
            this.textBoxCountPoints.Size = new System.Drawing.Size(204, 23);
            this.textBoxCountPoints.TabIndex = 1;
            this.textBoxCountPoints.Text = "5";
            // 
            // textBoxPathReport
            // 
            this.textBoxPathReport.Location = new System.Drawing.Point(212, 60);
            this.textBoxPathReport.Name = "textBoxPathReport";
            this.textBoxPathReport.Size = new System.Drawing.Size(204, 23);
            this.textBoxPathReport.TabIndex = 2;
            this.textBoxPathReport.Text = "C:\\gurobi";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Quantidade Pontos:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(74, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Pasta do Relatório:";
            // 
            // ButtonChangedPath
            // 
            this.ButtonChangedPath.Location = new System.Drawing.Point(422, 59);
            this.ButtonChangedPath.Name = "ButtonChangedPath";
            this.ButtonChangedPath.Size = new System.Drawing.Size(109, 23);
            this.ButtonChangedPath.TabIndex = 5;
            this.ButtonChangedPath.Text = "Alterar Destino";
            this.ButtonChangedPath.UseVisualStyleBackColor = true;
            this.ButtonChangedPath.Click += new System.EventHandler(this.ButtonChangedPath_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 243);
            this.Controls.Add(this.ButtonChangedPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxPathReport);
            this.Controls.Add(this.textBoxCountPoints);
            this.Controls.Add(this.button1);
            this.Name = "Main";
            this.Text = "Main";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxCountPoints;
        private System.Windows.Forms.TextBox textBoxPathReport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ButtonChangedPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}

