namespace TauriTSMAppDataFetcher
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
            this.serverSelectorCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timerCheckPrices
            // 
            this.timerCheckPrices.Enabled = true;
            this.timerCheckPrices.Interval = 300000;
            this.timerCheckPrices.Tick += new System.EventHandler(this.timerCheckPrices_Tick);
            // 
            // serverSelectorCombo
            // 
            this.serverSelectorCombo.DropDownHeight = 150;
            this.serverSelectorCombo.DropDownWidth = 200;
            this.serverSelectorCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverSelectorCombo.FormattingEnabled = true;
            this.serverSelectorCombo.IntegralHeight = false;
            this.serverSelectorCombo.Location = new System.Drawing.Point(116, 92);
            this.serverSelectorCombo.Name = "serverSelectorCombo";
            this.serverSelectorCombo.Size = new System.Drawing.Size(121, 24);
            this.serverSelectorCombo.TabIndex = 2;
            this.serverSelectorCombo.SelectedIndexChanged += new System.EventHandler(this.serverSelectorCombo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(115, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select Server";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 298);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.serverSelectorCombo);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tauri - TSM AppData Fetcher";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timerFetch;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timerCheckPrices;
        private System.Windows.Forms.ComboBox serverSelectorCombo;
        private System.Windows.Forms.Label label1;
    }
}

