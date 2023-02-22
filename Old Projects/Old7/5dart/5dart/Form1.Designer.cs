namespace _5dart
{
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonAim = new System.Windows.Forms.Button();
            this.textBoxResult = new System.Windows.Forms.TextBox();
            this.buttonShoot = new System.Windows.Forms.Button();
            this.textBoxPlayers = new System.Windows.Forms.TextBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.textBoxAimResult = new System.Windows.Forms.TextBox();
            this.textBoxPrint = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonAim
            // 
            this.buttonAim.BackColor = System.Drawing.Color.Silver;
            this.buttonAim.Enabled = false;
            this.buttonAim.Font = new System.Drawing.Font("Milano LET", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAim.ForeColor = System.Drawing.SystemColors.WindowText;
            this.buttonAim.Location = new System.Drawing.Point(514, 80);
            this.buttonAim.Name = "buttonAim";
            this.buttonAim.Size = new System.Drawing.Size(343, 49);
            this.buttonAim.TabIndex = 0;
            this.buttonAim.Text = "Throw Darts";
            this.buttonAim.UseVisualStyleBackColor = false;
            this.buttonAim.Click += new System.EventHandler(this.buttonAim_Click);
            // 
            // textBoxResult
            // 
            this.textBoxResult.BackColor = System.Drawing.Color.SeaGreen;
            this.textBoxResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxResult.ForeColor = System.Drawing.Color.White;
            this.textBoxResult.Location = new System.Drawing.Point(1054, 224);
            this.textBoxResult.Multiline = true;
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.Size = new System.Drawing.Size(251, 146);
            this.textBoxResult.TabIndex = 2;
            this.textBoxResult.TextChanged += new System.EventHandler(this.textBoxResult_TextChanged);
            // 
            // buttonShoot
            // 
            this.buttonShoot.BackColor = System.Drawing.Color.Silver;
            this.buttonShoot.Enabled = false;
            this.buttonShoot.Font = new System.Drawing.Font("Milano LET", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonShoot.ForeColor = System.Drawing.SystemColors.WindowText;
            this.buttonShoot.Location = new System.Drawing.Point(1054, 376);
            this.buttonShoot.Name = "buttonShoot";
            this.buttonShoot.Size = new System.Drawing.Size(251, 49);
            this.buttonShoot.TabIndex = 3;
            this.buttonShoot.Text = "Get Result";
            this.buttonShoot.UseVisualStyleBackColor = false;
            this.buttonShoot.Click += new System.EventHandler(this.buttonShoot_Click);
            // 
            // textBoxPlayers
            // 
            this.textBoxPlayers.BackColor = System.Drawing.Color.SeaGreen;
            this.textBoxPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPlayers.ForeColor = System.Drawing.Color.White;
            this.textBoxPlayers.Location = new System.Drawing.Point(62, 224);
            this.textBoxPlayers.Multiline = true;
            this.textBoxPlayers.Name = "textBoxPlayers";
            this.textBoxPlayers.Size = new System.Drawing.Size(245, 146);
            this.textBoxPlayers.TabIndex = 4;
            this.textBoxPlayers.TextChanged += new System.EventHandler(this.textBoxPlayers_TextChanged);
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.Color.Silver;
            this.buttonStart.Font = new System.Drawing.Font("Milano LET", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStart.ForeColor = System.Drawing.SystemColors.WindowText;
            this.buttonStart.Location = new System.Drawing.Point(62, 376);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(245, 43);
            this.buttonStart.TabIndex = 5;
            this.buttonStart.Text = "Start Game";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.WindowText;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox1.Location = new System.Drawing.Point(12, 2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(1344, 72);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = "1. Enter the players names (one per row) in the box to the left and press [Start " +
    "Game].\r\n2. Press [Throw Darts] then press [Get Result].\r\n3. Press [Print] to wri" +
    "te result details to textfile.";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonPrint
            // 
            this.buttonPrint.BackColor = System.Drawing.Color.Silver;
            this.buttonPrint.Enabled = false;
            this.buttonPrint.Font = new System.Drawing.Font("Milano LET", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPrint.ForeColor = System.Drawing.SystemColors.WindowText;
            this.buttonPrint.Location = new System.Drawing.Point(1054, 487);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(251, 43);
            this.buttonPrint.TabIndex = 7;
            this.buttonPrint.Text = "Print";
            this.buttonPrint.UseVisualStyleBackColor = false;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // textBoxAimResult
            // 
            this.textBoxAimResult.BackColor = System.Drawing.Color.Tan;
            this.textBoxAimResult.Location = new System.Drawing.Point(517, 144);
            this.textBoxAimResult.Multiline = true;
            this.textBoxAimResult.Name = "textBoxAimResult";
            this.textBoxAimResult.Size = new System.Drawing.Size(340, 41);
            this.textBoxAimResult.TabIndex = 8;
            this.textBoxAimResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxAimResult.TextChanged += new System.EventHandler(this.textBoxAimResult_TextChanged);
            // 
            // textBoxPrint
            // 
            this.textBoxPrint.BackColor = System.Drawing.Color.SeaGreen;
            this.textBoxPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPrint.ForeColor = System.Drawing.Color.White;
            this.textBoxPrint.Location = new System.Drawing.Point(1054, 536);
            this.textBoxPrint.Multiline = true;
            this.textBoxPrint.Name = "textBoxPrint";
            this.textBoxPrint.Size = new System.Drawing.Size(251, 43);
            this.textBoxPrint.TabIndex = 9;
            this.textBoxPrint.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxPrint.TextChanged += new System.EventHandler(this.textBoxPrint_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1368, 792);
            this.Controls.Add(this.textBoxPrint);
            this.Controls.Add(this.textBoxAimResult);
            this.Controls.Add(this.buttonPrint);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.textBoxPlayers);
            this.Controls.Add(this.buttonShoot);
            this.Controls.Add(this.textBoxResult);
            this.Controls.Add(this.buttonAim);
            this.ForeColor = System.Drawing.Color.MidnightBlue;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAim;
        private System.Windows.Forms.TextBox textBoxResult;
        private System.Windows.Forms.Button buttonShoot;
        private System.Windows.Forms.TextBox textBoxPlayers;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.TextBox textBoxAimResult;
        private System.Windows.Forms.TextBox textBoxPrint;
    }
}

