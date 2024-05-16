
namespace PLD_Project
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtBox1 = new System.Windows.Forms.TextBox();
            this.lstBox1 = new System.Windows.Forms.ListBox();
            this.lstBox2 = new System.Windows.Forms.ListBox();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtBox1
            // 
            this.txtBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtBox1.Location = new System.Drawing.Point(12, 70);
            this.txtBox1.Multiline = true;
            this.txtBox1.Name = "txtBox1";
            this.txtBox1.Size = new System.Drawing.Size(288, 322);
            this.txtBox1.TabIndex = 0;
            this.txtBox1.TextChanged += new System.EventHandler(this.txtBox1_TextChanged);
            // 
            // lstBox1
            // 
            this.lstBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lstBox1.FormattingEnabled = true;
            this.lstBox1.ItemHeight = 25;
            this.lstBox1.Location = new System.Drawing.Point(330, 70);
            this.lstBox1.Name = "lstBox1";
            this.lstBox1.Size = new System.Drawing.Size(513, 79);
            this.lstBox1.TabIndex = 1;
            // 
            // lstBox2
            // 
            this.lstBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lstBox2.FormattingEnabled = true;
            this.lstBox2.ItemHeight = 25;
            this.lstBox2.Location = new System.Drawing.Point(330, 213);
            this.lstBox2.Name = "lstBox2";
            this.lstBox2.Size = new System.Drawing.Size(513, 179);
            this.lstBox2.TabIndex = 2;
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.BackColor = System.Drawing.Color.Transparent;
            this.lbl1.Font = new System.Drawing.Font("Comic Sans MS", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl1.Location = new System.Drawing.Point(12, 35);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(87, 32);
            this.lbl1.TabIndex = 3;
            this.lbl1.Text = "Code: ";
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.BackColor = System.Drawing.Color.Transparent;
            this.lbl2.Font = new System.Drawing.Font("Comic Sans MS", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl2.Location = new System.Drawing.Point(330, 35);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(193, 32);
            this.lbl2.TabIndex = 4;
            this.lbl2.Text = "Syntax Errors: ";
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.BackColor = System.Drawing.Color.Transparent;
            this.lbl3.Font = new System.Drawing.Font("Comic Sans MS", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl3.Location = new System.Drawing.Point(330, 178);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(218, 32);
            this.lbl3.TabIndex = 5;
            this.lbl3.Text = "Lexical Analyzer: ";
            // 
            // lbl4
            // 
            this.lbl4.AutoSize = true;
            this.lbl4.BackColor = System.Drawing.Color.Transparent;
            this.lbl4.Font = new System.Drawing.Font("Comic Sans MS", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl4.Location = new System.Drawing.Point(12, 411);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(365, 32);
            this.lbl4.TabIndex = 6;
            this.lbl4.Text = "By: Safyah Nashaat Ali (Sec4)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(855, 470);
            this.Controls.Add(this.lbl4);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.lstBox2);
            this.Controls.Add(this.lstBox1);
            this.Controls.Add(this.txtBox1);
            this.Name = "Form1";
            this.Text = "PLD_Project";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBox1;
        private System.Windows.Forms.ListBox lstBox1;
        private System.Windows.Forms.ListBox lstBox2;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label lbl4;
    }
}

