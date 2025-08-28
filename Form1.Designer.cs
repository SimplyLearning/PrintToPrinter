
using System.Drawing.Printing;

namespace PrintToPrinter
{
    partial class Form1
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
            Print = new Button();
            printDocument1 = new PrintDocument();
            SuspendLayout();
            // 
            // Print
            // 
            Print.BackColor = SystemColors.ActiveCaption;
            Print.BackgroundImage = Properties.Resources.icon;
            Print.Location = new Point(75, 325);
            Print.Name = "Print";
            Print.Size = new Size(629, 59);
            Print.TabIndex = 0;
            Print.Text = "Print To Printer";
            Print.UseVisualStyleBackColor = false;
            Print.Click += Print_Click;
            // 
            // printDocument1
            // 
            printDocument1.PrintPage += printDocument1_PrintPage;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Print);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button Print;
        private PrintDocument printDocument1;
    }
}
