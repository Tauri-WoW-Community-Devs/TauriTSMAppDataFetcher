﻿namespace TauriTSMAppDataFetcher
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.timerFetch = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.timerCheckPrices = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timerFetch
            // 
            this.timerFetch.Enabled = true;
            this.timerFetch.Interval = 300000;
            this.timerFetch.Tick += new System.EventHandler(this.timerFetch_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(94, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Item Price Alerts";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // timerCheckPrices
            // 
            this.timerCheckPrices.Enabled = true;
            this.timerCheckPrices.Interval = 300000;
            this.timerCheckPrices.Tick += new System.EventHandler(this.timerCheckPrices_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 298);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tauri - TSM AppData Fetcher";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerFetch;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timerCheckPrices;
    }
}

