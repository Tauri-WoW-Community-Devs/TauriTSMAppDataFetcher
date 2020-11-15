namespace TauriTSMAppDataFetcher
{
    partial class PriceTrackerListingForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gridAuctions = new System.Windows.Forms.DataGridView();
            this.ItemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PricePerItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeLeft = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StackCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridAuctions)).BeginInit();
            this.SuspendLayout();
            // 
            // gridAuctions
            // 
            this.gridAuctions.AllowUserToAddRows = false;
            this.gridAuctions.AllowUserToDeleteRows = false;
            this.gridAuctions.AllowUserToResizeRows = false;
            this.gridAuctions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAuctions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemId,
            this.ItemName,
            this.PricePerItem,
            this.TimeLeft,
            this.StackCount});
            this.gridAuctions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAuctions.Location = new System.Drawing.Point(0, 0);
            this.gridAuctions.MultiSelect = false;
            this.gridAuctions.Name = "gridAuctions";
            this.gridAuctions.ReadOnly = true;
            this.gridAuctions.ShowEditingIcon = false;
            this.gridAuctions.Size = new System.Drawing.Size(484, 461);
            this.gridAuctions.TabIndex = 1;
            this.gridAuctions.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gridAuctions_CellFormatting);
            // 
            // ItemId
            // 
            this.ItemId.DataPropertyName = "ItemId";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ItemId.DefaultCellStyle = dataGridViewCellStyle5;
            this.ItemId.HeaderText = "ID";
            this.ItemId.MinimumWidth = 75;
            this.ItemId.Name = "ItemId";
            this.ItemId.ReadOnly = true;
            this.ItemId.Width = 75;
            // 
            // ItemName
            // 
            this.ItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ItemName.DataPropertyName = "ItemName";
            this.ItemName.HeaderText = "Name";
            this.ItemName.Name = "ItemName";
            this.ItemName.ReadOnly = true;
            // 
            // PricePerItem
            // 
            this.PricePerItem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PricePerItem.DataPropertyName = "PricePerItem";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.PricePerItem.DefaultCellStyle = dataGridViewCellStyle6;
            this.PricePerItem.HeaderText = "Price per item";
            this.PricePerItem.MinimumWidth = 90;
            this.PricePerItem.Name = "PricePerItem";
            this.PricePerItem.ReadOnly = true;
            this.PricePerItem.ToolTipText = "Buyout divider by stack count";
            this.PricePerItem.Width = 96;
            // 
            // TimeLeft
            // 
            this.TimeLeft.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TimeLeft.DataPropertyName = "TimeLeft";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.TimeLeft.DefaultCellStyle = dataGridViewCellStyle7;
            this.TimeLeft.HeaderText = "Time left";
            this.TimeLeft.Name = "TimeLeft";
            this.TimeLeft.ReadOnly = true;
            this.TimeLeft.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TimeLeft.Width = 72;
            // 
            // StackCount
            // 
            this.StackCount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.StackCount.DataPropertyName = "StackCount";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.StackCount.DefaultCellStyle = dataGridViewCellStyle8;
            this.StackCount.HeaderText = "Stack count";
            this.StackCount.Name = "StackCount";
            this.StackCount.ReadOnly = true;
            this.StackCount.Width = 90;
            // 
            // PriceTrackerListingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.gridAuctions);
            this.Name = "PriceTrackerListingForm";
            this.Text = "Tracked auctions";
            ((System.ComponentModel.ISupportInitialize)(this.gridAuctions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridAuctions;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PricePerItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeLeft;
        private System.Windows.Forms.DataGridViewTextBoxColumn StackCount;
    }
}