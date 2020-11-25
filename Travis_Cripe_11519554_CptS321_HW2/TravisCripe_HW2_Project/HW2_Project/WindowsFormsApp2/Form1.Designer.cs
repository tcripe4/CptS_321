namespace WindowsFormsApp2
{
    using System;
    using System.Windows.Forms;
    using Text_File;
    /// <summary>
    /// The main class for the design of the form
    /// </summary>
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

        /// <summary>
        /// Creates the textbox to be multiline
        /// </summary>
        public void CreateMyMultilineTextBox()
        {
            // Create an instance of a TextBox control.
            TextBox textBox1 = new TextBox();

            // Set the Multiline property to true.
            textBox1.Multiline = true;

            // Add vertical scroll bars to the TextBox control.
            textBox1.ScrollBars = ScrollBars.Vertical;

            // Allow the RETURN key to be entered in the TextBox control.
            textBox1.AcceptsReturn = true;

            // Allow the TAB key to be entered in the TextBox control.
            textBox1.AcceptsTab = true;

            // Set WordWrap to true to allow text to wrap to the next line.
            textBox1.WordWrap = true;

            // Set the default text of the control.
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(2, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(799, 445);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Travis Cripe 11519554";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textBox1;
    }
}

