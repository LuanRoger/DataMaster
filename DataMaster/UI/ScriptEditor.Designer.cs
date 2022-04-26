namespace DataMaster.UI
{
    partial class ScriptEditor
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnExecuteCommand = new System.Windows.Forms.ToolStripButton();
            this.btnSaveScript = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblScriptLang = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblRowsAffectedLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblRowsAffected = new System.Windows.Forms.ToolStripStatusLabel();
            this.pgbAsyncTask = new System.Windows.Forms.ToolStripProgressBar();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbpScript = new System.Windows.Forms.TabPage();
            this.tbpQuery = new System.Windows.Forms.TabPage();
            this.dgvQuery = new System.Windows.Forms.DataGridView();
            this.txtScriptCommand = new DataMasterComponents.RichTextBox.RichTextBoxScriptingHighlights(DataMasterComponents.RichTextBox.LanguageHighlight.SQL, System.Drawing.Color.FromArgb(DataMaster.Managers.Configuration.AppConfigurationManager.configuration.customizationConfigModel.highlightColor));
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tbpScript.SuspendLayout();
            this.tbpQuery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuery)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.statusStrip1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(641, 316);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExecuteCommand,
            this.btnSaveScript});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(641, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnExecuteCommand
            // 
            this.btnExecuteCommand.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExecuteCommand.Image = global::DataMaster.Properties.Resources.script_go;
            this.btnExecuteCommand.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExecuteCommand.Name = "btnExecuteCommand";
            this.btnExecuteCommand.Size = new System.Drawing.Size(23, 22);
            this.btnExecuteCommand.Text = "Executar";
            // 
            // btnSaveScript
            // 
            this.btnSaveScript.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSaveScript.Image = global::DataMaster.Properties.Resources.disk;
            this.btnSaveScript.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveScript.Name = "btnSaveScript";
            this.btnSaveScript.Size = new System.Drawing.Size(23, 22);
            this.btnSaveScript.Text = "Salvar";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblScriptLang,
            this.lblRowsAffectedLabel,
            this.lblRowsAffected,
            this.pgbAsyncTask});
            this.statusStrip1.Location = new System.Drawing.Point(0, 292);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(641, 24);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblScriptLang
            // 
            this.lblScriptLang.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblScriptLang.Name = "lblScriptLang";
            this.lblScriptLang.Size = new System.Drawing.Size(36, 19);
            this.lblScriptLang.Text = "NoN";
            // 
            // lblRowsAffectedLabel
            // 
            this.lblRowsAffectedLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblRowsAffectedLabel.Name = "lblRowsAffectedLabel";
            this.lblRowsAffectedLabel.Size = new System.Drawing.Size(95, 19);
            this.lblRowsAffectedLabel.Text = "Linhas afetadas:";
            this.lblRowsAffectedLabel.Visible = false;
            // 
            // lblRowsAffected
            // 
            this.lblRowsAffected.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Top | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblRowsAffected.Margin = new System.Windows.Forms.Padding(-2, 3, 0, 2);
            this.lblRowsAffected.Name = "lblRowsAffected";
            this.lblRowsAffected.Size = new System.Drawing.Size(17, 19);
            this.lblRowsAffected.Text = "0";
            this.lblRowsAffected.Visible = false;
            // 
            // pgbAsyncTask
            // 
            this.pgbAsyncTask.Name = "pgbAsyncTask";
            this.pgbAsyncTask.Size = new System.Drawing.Size(100, 18);
            this.pgbAsyncTask.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pgbAsyncTask.Visible = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbpScript);
            this.tabControl1.Controls.Add(this.tbpQuery);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(635, 261);
            this.tabControl1.TabIndex = 2;
            // 
            // tbpScript
            // 
            this.tbpScript.Controls.Add(this.txtScriptCommand);
            this.tbpScript.Location = new System.Drawing.Point(4, 24);
            this.tbpScript.Name = "tbpScript";
            this.tbpScript.Padding = new System.Windows.Forms.Padding(3);
            this.tbpScript.Size = new System.Drawing.Size(627, 233);
            this.tbpScript.TabIndex = 0;
            this.tbpScript.Text = "Script";
            this.tbpScript.UseVisualStyleBackColor = true;
            // 
            // txtScriptCommand
            // 
            this.txtScriptCommand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtScriptCommand.Location = new System.Drawing.Point(3, 3);
            this.txtScriptCommand.Name = "txtScriptCommand";
            this.txtScriptCommand.Size = new System.Drawing.Size(621, 227);
            this.txtScriptCommand.TabIndex = 0;
            this.txtScriptCommand.Text = "";
            // 
            // tbpQuery
            // 
            this.tbpQuery.Controls.Add(this.dgvQuery);
            this.tbpQuery.Location = new System.Drawing.Point(4, 24);
            this.tbpQuery.Name = "tbpQuery";
            this.tbpQuery.Padding = new System.Windows.Forms.Padding(3);
            this.tbpQuery.Size = new System.Drawing.Size(627, 233);
            this.tbpQuery.TabIndex = 1;
            this.tbpQuery.Text = "Query";
            this.tbpQuery.UseVisualStyleBackColor = true;
            // 
            // dgvQuery
            // 
            this.dgvQuery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvQuery.Location = new System.Drawing.Point(3, 3);
            this.dgvQuery.Name = "dgvQuery";
            this.dgvQuery.RowTemplate.Height = 25;
            this.dgvQuery.Size = new System.Drawing.Size(621, 227);
            this.dgvQuery.TabIndex = 0;
            // 
            // ScriptEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 316);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ScriptEditor";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Script editor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ScriptEditor_FormClosed);
            this.Load += new System.EventHandler(this.ScriptEditor_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tbpScript.ResumeLayout(false);
            this.tbpQuery.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuery)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnSaveScript;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbpScript;
        private System.Windows.Forms.TabPage tbpQuery;
        private System.Windows.Forms.ToolStripStatusLabel lblScriptLang;
        private System.Windows.Forms.ToolStripButton btnExecuteCommand;
        private DataMasterComponents.RichTextBox.RichTextBoxScriptingHighlights txtScriptCommand;
        private System.Windows.Forms.ToolStripStatusLabel lblRowsAffectedLabel;
        private System.Windows.Forms.ToolStripStatusLabel lblRowsAffected;
        private System.Windows.Forms.ToolStripProgressBar pgbAsyncTask;
        private System.Windows.Forms.DataGridView dgvQuery;
    }
}