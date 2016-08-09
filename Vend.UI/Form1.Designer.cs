namespace Vend.UI
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
            this.colaButton = new System.Windows.Forms.Button();
            this.chipsButton = new System.Windows.Forms.Button();
            this.candyButton = new System.Windows.Forms.Button();
            this.currentMoneyLabel = new System.Windows.Forms.Label();
            this.oneCentButton = new System.Windows.Forms.Button();
            this.fiveCentButton = new System.Windows.Forms.Button();
            this.tenCentButton = new System.Windows.Forms.Button();
            this.twentyFiveCentButton = new System.Windows.Forms.Button();
            this.fiftyCentButton = new System.Windows.Forms.Button();
            this.oneDollarButton = new System.Windows.Forms.Button();
            this.infoLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // colaButton
            // 
            this.colaButton.BackColor = System.Drawing.SystemColors.Control;
            this.colaButton.Location = new System.Drawing.Point(47, 31);
            this.colaButton.Name = "colaButton";
            this.colaButton.Size = new System.Drawing.Size(119, 60);
            this.colaButton.TabIndex = 0;
            this.colaButton.Text = "Cola $1.00";
            this.colaButton.UseVisualStyleBackColor = false;
            this.colaButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // chipsButton
            // 
            this.chipsButton.Location = new System.Drawing.Point(205, 31);
            this.chipsButton.Name = "chipsButton";
            this.chipsButton.Size = new System.Drawing.Size(117, 60);
            this.chipsButton.TabIndex = 1;
            this.chipsButton.Text = "Chips $0.50";
            this.chipsButton.UseVisualStyleBackColor = true;
            this.chipsButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // candyButton
            // 
            this.candyButton.Location = new System.Drawing.Point(369, 31);
            this.candyButton.Name = "candyButton";
            this.candyButton.Size = new System.Drawing.Size(126, 60);
            this.candyButton.TabIndex = 2;
            this.candyButton.Text = "Candy $0.65";
            this.candyButton.UseVisualStyleBackColor = true;
            this.candyButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // currentMoneyLabel
            // 
            this.currentMoneyLabel.AutoSize = true;
            this.currentMoneyLabel.Location = new System.Drawing.Point(66, 279);
            this.currentMoneyLabel.Name = "currentMoneyLabel";
            this.currentMoneyLabel.Size = new System.Drawing.Size(34, 13);
            this.currentMoneyLabel.TabIndex = 4;
            this.currentMoneyLabel.Text = "$0.00";
            // 
            // oneCentButton
            // 
            this.oneCentButton.Location = new System.Drawing.Point(47, 457);
            this.oneCentButton.Name = "oneCentButton";
            this.oneCentButton.Size = new System.Drawing.Size(75, 23);
            this.oneCentButton.TabIndex = 5;
            this.oneCentButton.Text = "1 cent";
            this.oneCentButton.UseVisualStyleBackColor = true;
            this.oneCentButton.Click += new System.EventHandler(this.oneCentButton_Click);
            // 
            // fiveCentButton
            // 
            this.fiveCentButton.Location = new System.Drawing.Point(142, 457);
            this.fiveCentButton.Name = "fiveCentButton";
            this.fiveCentButton.Size = new System.Drawing.Size(75, 23);
            this.fiveCentButton.TabIndex = 6;
            this.fiveCentButton.Text = "5 cent";
            this.fiveCentButton.UseVisualStyleBackColor = true;
            this.fiveCentButton.Click += new System.EventHandler(this.fiveCentButton_Click);
            // 
            // tenCentButton
            // 
            this.tenCentButton.Location = new System.Drawing.Point(244, 457);
            this.tenCentButton.Name = "tenCentButton";
            this.tenCentButton.Size = new System.Drawing.Size(75, 23);
            this.tenCentButton.TabIndex = 7;
            this.tenCentButton.Text = "10 cent";
            this.tenCentButton.UseVisualStyleBackColor = true;
            this.tenCentButton.Click += new System.EventHandler(this.tenCentButton_Click);
            // 
            // twentyFiveCentButton
            // 
            this.twentyFiveCentButton.Location = new System.Drawing.Point(355, 457);
            this.twentyFiveCentButton.Name = "twentyFiveCentButton";
            this.twentyFiveCentButton.Size = new System.Drawing.Size(75, 23);
            this.twentyFiveCentButton.TabIndex = 8;
            this.twentyFiveCentButton.Text = "25 cent";
            this.twentyFiveCentButton.UseVisualStyleBackColor = true;
            this.twentyFiveCentButton.Click += new System.EventHandler(this.twentyFiveCentButton_Click);
            // 
            // fiftyCentButton
            // 
            this.fiftyCentButton.Location = new System.Drawing.Point(489, 457);
            this.fiftyCentButton.Name = "fiftyCentButton";
            this.fiftyCentButton.Size = new System.Drawing.Size(75, 23);
            this.fiftyCentButton.TabIndex = 9;
            this.fiftyCentButton.Text = "50 cent";
            this.fiftyCentButton.UseVisualStyleBackColor = true;
            this.fiftyCentButton.Click += new System.EventHandler(this.fiftyCentButton_Click);
            // 
            // oneDollarButton
            // 
            this.oneDollarButton.Location = new System.Drawing.Point(603, 457);
            this.oneDollarButton.Name = "oneDollarButton";
            this.oneDollarButton.Size = new System.Drawing.Size(75, 23);
            this.oneDollarButton.TabIndex = 10;
            this.oneDollarButton.Text = "$1";
            this.oneDollarButton.UseVisualStyleBackColor = true;
            this.oneDollarButton.Click += new System.EventHandler(this.oneDollarButton_Click);
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Location = new System.Drawing.Point(47, 130);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(57, 13);
            this.infoLabel.TabIndex = 11;
            this.infoLabel.Text = "Insert Coin";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(354, 201);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 50);
            this.button1.TabIndex = 12;
            this.button1.Text = "Return Change";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 517);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.oneDollarButton);
            this.Controls.Add(this.fiftyCentButton);
            this.Controls.Add(this.twentyFiveCentButton);
            this.Controls.Add(this.tenCentButton);
            this.Controls.Add(this.fiveCentButton);
            this.Controls.Add(this.oneCentButton);
            this.Controls.Add(this.currentMoneyLabel);
            this.Controls.Add(this.candyButton);
            this.Controls.Add(this.chipsButton);
            this.Controls.Add(this.colaButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button colaButton;
        private System.Windows.Forms.Button chipsButton;
        private System.Windows.Forms.Button candyButton;
        private System.Windows.Forms.Label currentMoneyLabel;
        private System.Windows.Forms.Button oneCentButton;
        private System.Windows.Forms.Button fiveCentButton;
        private System.Windows.Forms.Button tenCentButton;
        private System.Windows.Forms.Button twentyFiveCentButton;
        private System.Windows.Forms.Button fiftyCentButton;
        private System.Windows.Forms.Button oneDollarButton;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.Button button1;
    }
}

