﻿namespace PacmanGame_WinForms_
{
    partial class Menu
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
            this.label1 = new System.Windows.Forms.Label();
            this.startGame = new System.Windows.Forms.Button();
            this.help = new System.Windows.Forms.Button();
            this.settings = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.resultBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Showcard Gothic", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(264, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(292, 66);
            this.label1.TabIndex = 0;
            this.label1.Text = "MAIN MENU";
            // 
            // startGame
            // 
            this.startGame.BackColor = System.Drawing.Color.Lime;
            this.startGame.Cursor = System.Windows.Forms.Cursors.Hand;
            this.startGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startGame.ForeColor = System.Drawing.SystemColors.ControlText;
            this.startGame.Location = new System.Drawing.Point(306, 112);
            this.startGame.Name = "startGame";
            this.startGame.Size = new System.Drawing.Size(192, 44);
            this.startGame.TabIndex = 1;
            this.startGame.Text = "Start Game";
            this.startGame.UseVisualStyleBackColor = false;
            this.startGame.MouseUp += new System.Windows.Forms.MouseEventHandler(this.startGame_MouseUp);
            // 
            // help
            // 
            this.help.BackColor = System.Drawing.Color.Lime;
            this.help.Cursor = System.Windows.Forms.Cursors.Hand;
            this.help.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.help.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.help.ForeColor = System.Drawing.SystemColors.ControlText;
            this.help.Location = new System.Drawing.Point(306, 177);
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(192, 48);
            this.help.TabIndex = 2;
            this.help.Text = "Help\r\n";
            this.help.UseVisualStyleBackColor = false;
            this.help.MouseUp += new System.Windows.Forms.MouseEventHandler(this.help_MouseUp);
            // 
            // settings
            // 
            this.settings.BackColor = System.Drawing.Color.Lime;
            this.settings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.settings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settings.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.settings.ForeColor = System.Drawing.SystemColors.ControlText;
            this.settings.Location = new System.Drawing.Point(306, 244);
            this.settings.Name = "settings";
            this.settings.Size = new System.Drawing.Size(192, 51);
            this.settings.TabIndex = 3;
            this.settings.Text = "Settings\r\n";
            this.settings.UseVisualStyleBackColor = false;
            this.settings.MouseUp += new System.Windows.Forms.MouseEventHandler(this.settings_MouseUp);
            // 
            // exit
            // 
            this.exit.BackColor = System.Drawing.Color.Lime;
            this.exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.exit.Location = new System.Drawing.Point(306, 387);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(192, 51);
            this.exit.TabIndex = 4;
            this.exit.Text = "Exit";
            this.exit.UseVisualStyleBackColor = false;
            this.exit.MouseUp += new System.Windows.Forms.MouseEventHandler(this.exit_MouseUp);
            // 
            // resultBtn
            // 
            this.resultBtn.BackColor = System.Drawing.Color.Lime;
            this.resultBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.resultBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resultBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resultBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.resultBtn.Location = new System.Drawing.Point(306, 316);
            this.resultBtn.Name = "resultBtn";
            this.resultBtn.Size = new System.Drawing.Size(192, 51);
            this.resultBtn.TabIndex = 5;
            this.resultBtn.Text = "Results";
            this.resultBtn.UseVisualStyleBackColor = false;
            this.resultBtn.Click += new System.EventHandler(this.resultBtn_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.resultBtn);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.settings);
            this.Controls.Add(this.help);
            this.Controls.Add(this.startGame);
            this.Controls.Add(this.label1);
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pac-Man";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button startGame;
        public System.Windows.Forms.Button help;
        public System.Windows.Forms.Button settings;
        private System.Windows.Forms.Button exit;
        public System.Windows.Forms.Button resultBtn;
    }
}