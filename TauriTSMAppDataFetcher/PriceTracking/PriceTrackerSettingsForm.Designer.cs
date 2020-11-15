namespace TauriTSMAppDataFetcher
{
    partial class PriceTrackerSettingsForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gridPrices = new System.Windows.Forms.DataGridView();
            this.priceTrackerDSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.priceTrackerDS = new TauriTSMAppDataFetcher.PriceTracking.PriceTrackerDS();
            this.itemIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceCooperDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Faction = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.commentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remove = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridPrices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceTrackerDSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceTrackerDS)).BeginInit();
            this.SuspendLayout();
            // 
            // gridPrices
            // 
            this.gridPrices.AutoGenerateColumns = false;
            this.gridPrices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPrices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemIDDataGridViewTextBoxColumn,
            this.priceCooperDataGridViewTextBoxColumn,
            this.Faction,
            this.commentDataGridViewTextBoxColumn,
            this.remove});
            this.gridPrices.DataMember = "PriceTracker";
            this.gridPrices.DataSource = this.priceTrackerDSBindingSource;
            this.gridPrices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPrices.Location = new System.Drawing.Point(0, 0);
            this.gridPrices.Name = "gridPrices";
            this.gridPrices.Size = new System.Drawing.Size(484, 461);
            this.gridPrices.TabIndex = 1;
            this.gridPrices.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridPrices_CellContentClick);
            this.gridPrices.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.gridPrices_CellValidating);
            // 
            // priceTrackerDSBindingSource
            // 
            this.priceTrackerDSBindingSource.DataSource = this.priceTrackerDS;
            this.priceTrackerDSBindingSource.Position = 0;
            // 
            // priceTrackerDS
            // 
            this.priceTrackerDS.DataSetName = "PriceTrackerDS";
            this.priceTrackerDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // itemIDDataGridViewTextBoxColumn
            // 
            this.itemIDDataGridViewTextBoxColumn.DataPropertyName = "ItemID";
            this.itemIDDataGridViewTextBoxColumn.HeaderText = "Item ID";
            this.itemIDDataGridViewTextBoxColumn.MaxInputLength = 7;
            this.itemIDDataGridViewTextBoxColumn.MinimumWidth = 75;
            this.itemIDDataGridViewTextBoxColumn.Name = "itemIDDataGridViewTextBoxColumn";
            this.itemIDDataGridViewTextBoxColumn.Width = 75;
            // 
            // priceCooperDataGridViewTextBoxColumn
            // 
            this.priceCooperDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.priceCooperDataGridViewTextBoxColumn.DataPropertyName = "PriceCooper";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.priceCooperDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.priceCooperDataGridViewTextBoxColumn.HeaderText = "Max. price per item";
            this.priceCooperDataGridViewTextBoxColumn.MaxInputLength = 14;
            this.priceCooperDataGridViewTextBoxColumn.MinimumWidth = 80;
            this.priceCooperDataGridViewTextBoxColumn.Name = "priceCooperDataGridViewTextBoxColumn";
            this.priceCooperDataGridViewTextBoxColumn.ToolTipText = "In cooper (1g - 10000c)";
            this.priceCooperDataGridViewTextBoxColumn.Width = 94;
            // 
            // Faction
            // 
            this.Faction.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Faction.DataPropertyName = "Faction";
            this.Faction.HeaderText = "Faction";
            this.Faction.Items.AddRange(new object[] {
            "ALLY",
            "HORDE",
            "BOTH"});
            this.Faction.MinimumWidth = 75;
            this.Faction.Name = "Faction";
            this.Faction.Width = 75;
            // 
            // commentDataGridViewTextBoxColumn
            // 
            this.commentDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.commentDataGridViewTextBoxColumn.DataPropertyName = "Comment";
            this.commentDataGridViewTextBoxColumn.HeaderText = "Comment";
            this.commentDataGridViewTextBoxColumn.Name = "commentDataGridViewTextBoxColumn";
            // 
            // remove
            // 
            this.remove.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.remove.HeaderText = "Remove";
            this.remove.Name = "remove";
            this.remove.Text = "";
            this.remove.UseColumnTextForButtonValue = true;
            this.remove.Width = 53;
            // 
            // PriceTrackerSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.gridPrices);
            this.Name = "PriceTrackerSettingsForm";
            this.Text = "Setup price tracking";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PriceTrackerSettingsForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.gridPrices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceTrackerDSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceTrackerDS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridPrices;
        private System.Windows.Forms.BindingSource priceTrackerDSBindingSource;
        private PriceTracking.PriceTrackerDS priceTrackerDS;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceCooperDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn Faction;
        private System.Windows.Forms.DataGridViewTextBoxColumn commentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn remove;
    }
}