namespace spacerace
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
            this.components = new System.ComponentModel.Container();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.player1scoreLabel = new System.Windows.Forms.Label();
            this.player2scoreLabel = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Label();
            this.AILabel = new System.Windows.Forms.Label();
            this.tellplayerLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // player1scoreLabel
            // 
            this.player1scoreLabel.AutoSize = true;
            this.player1scoreLabel.Location = new System.Drawing.Point(174, 9);
            this.player1scoreLabel.Name = "player1scoreLabel";
            this.player1scoreLabel.Size = new System.Drawing.Size(35, 13);
            this.player1scoreLabel.TabIndex = 0;
            this.player1scoreLabel.Text = "label1";
            // 
            // player2scoreLabel
            // 
            this.player2scoreLabel.AutoSize = true;
            this.player2scoreLabel.Location = new System.Drawing.Point(396, 9);
            this.player2scoreLabel.Name = "player2scoreLabel";
            this.player2scoreLabel.Size = new System.Drawing.Size(35, 13);
            this.player2scoreLabel.TabIndex = 1;
            this.player2scoreLabel.Text = "label1";
            // 
            // startButton
            // 
            this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.Location = new System.Drawing.Point(212, 163);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(175, 34);
            this.startButton.TabIndex = 3;
            this.startButton.Text = "Start";
            this.startButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.startButton.Click += new System.EventHandler(this.startButton_Click_1);
            // 
            // AILabel
            // 
            this.AILabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AILabel.Location = new System.Drawing.Point(250, 283);
            this.AILabel.Name = "AILabel";
            this.AILabel.Size = new System.Drawing.Size(100, 34);
            this.AILabel.TabIndex = 4;
            this.AILabel.Text = "Vs AI";
            this.AILabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AILabel.Click += new System.EventHandler(this.AILabel_Click);
            // 
            // tellplayerLabel
            // 
            this.tellplayerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tellplayerLabel.Location = new System.Drawing.Point(81, 22);
            this.tellplayerLabel.Name = "tellplayerLabel";
            this.tellplayerLabel.Size = new System.Drawing.Size(434, 34);
            this.tellplayerLabel.TabIndex = 5;
            this.tellplayerLabel.Text = "Space Race";
            this.tellplayerLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(600, 600);
            this.Controls.Add(this.tellplayerLabel);
            this.Controls.Add(this.AILabel);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.player2scoreLabel);
            this.Controls.Add(this.player1scoreLabel);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label player1scoreLabel;
        private System.Windows.Forms.Label player2scoreLabel;
        private System.Windows.Forms.Label startButton;
        private System.Windows.Forms.Label AILabel;
        private System.Windows.Forms.Label tellplayerLabel;
    }
}

