
namespace DataMaster.UI
{
    partial class CreateDb
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
            this.tevDataVisualization = new System.Windows.Forms.TreeView();
            this.btnAdicionarDb = new System.Windows.Forms.Button();
            this.btnAddTable = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSaveModel = new System.Windows.Forms.Button();
            this.btnCreateDb = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.pgbAsyncTasks = new System.Windows.Forms.ToolStripProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblQuantTabela = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblQuantDb = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tevDataVisualization
            // 
            this.tevDataVisualization.LabelEdit = true;
            this.tevDataVisualization.Location = new System.Drawing.Point(12, 12);
            this.tevDataVisualization.Name = "tevDataVisualization";
            this.tevDataVisualization.Size = new System.Drawing.Size(466, 222);
            this.tevDataVisualization.TabIndex = 0;
            // 
            // btnAdicionarDb
            // 
            this.btnAdicionarDb.Image = global::DataMaster.Properties.Resources.database_add;
            this.btnAdicionarDb.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdicionarDb.Location = new System.Drawing.Point(12, 240);
            this.btnAdicionarDb.Name = "btnAdicionarDb";
            this.btnAdicionarDb.Size = new System.Drawing.Size(119, 23);
            this.btnAdicionarDb.TabIndex = 1;
            this.btnAdicionarDb.Text = "Adicionar banco";
            this.btnAdicionarDb.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdicionarDb.UseVisualStyleBackColor = true;
            this.btnAdicionarDb.Click += new System.EventHandler(this.btnAdicionarDb_Click);
            // 
            // btnAdicionarTabela
            // 
            this.btnAddTable.Image = global::DataMaster.Properties.Resources.table_add;
            this.btnAddTable.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddTable.Location = new System.Drawing.Point(12, 269);
            this.btnAddTable.Name = "btnAddTable";
            this.btnAddTable.Size = new System.Drawing.Size(119, 23);
            this.btnAddTable.TabIndex = 2;
            this.btnAddTable.Text = "Adicionar tabela";
            this.btnAddTable.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddTable.UseVisualStyleBackColor = true;
            this.btnAddTable.Click += new System.EventHandler(this.btnAdicionarTabela_Click);
            // 
            // btnExcluir
            // 
            this.btnDelete.Image = global::DataMaster.Properties.Resources.delete;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(12, 298);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(119, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Excluir elemento";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnSalvarModelo
            // 
            this.btnSaveModel.Image = global::DataMaster.Properties.Resources.database_save;
            this.btnSaveModel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveModel.Location = new System.Drawing.Point(277, 315);
            this.btnSaveModel.Name = "btnSaveModel";
            this.btnSaveModel.Size = new System.Drawing.Size(106, 23);
            this.btnSaveModel.TabIndex = 5;
            this.btnSaveModel.Text = "Salvar modelo";
            this.btnSaveModel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveModel.UseVisualStyleBackColor = true;
            this.btnSaveModel.Click += new System.EventHandler(this.btnSalvarModelo_Click);
            // 
            // btnCriarDb
            // 
            this.btnCreateDb.Image = global::DataMaster.Properties.Resources.go;
            this.btnCreateDb.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreateDb.Location = new System.Drawing.Point(389, 315);
            this.btnCreateDb.Name = "btnCreateDb";
            this.btnCreateDb.Size = new System.Drawing.Size(89, 23);
            this.btnCreateDb.TabIndex = 6;
            this.btnCreateDb.Text = "Criar banco";
            this.btnCreateDb.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCreateDb.UseVisualStyleBackColor = true;
            this.btnCreateDb.Click += new System.EventHandler(this.btnCriarDb_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pgbAsyncTasks});
            this.statusStrip1.Location = new System.Drawing.Point(0, 353);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(490, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // pgbAsyncTasks
            // 
            this.pgbAsyncTasks.Name = "pgbAsyncTasks";
            this.pgbAsyncTasks.Size = new System.Drawing.Size(100, 16);
            this.pgbAsyncTasks.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblQuantTabela);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblQuantDb);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(156, 240);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(322, 69);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informações";
            // 
            // lblQuantTabela
            // 
            this.lblQuantTabela.AutoSize = true;
            this.lblQuantTabela.Location = new System.Drawing.Point(192, 38);
            this.lblQuantTabela.Name = "lblQuantTabela";
            this.lblQuantTabela.Size = new System.Drawing.Size(13, 15);
            this.lblQuantTabela.TabIndex = 3;
            this.lblQuantTabela.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Quantidade de Tabelas:";
            // 
            // lblQuantDb
            // 
            this.lblQuantDb.AutoSize = true;
            this.lblQuantDb.Location = new System.Drawing.Point(192, 19);
            this.lblQuantDb.Name = "lblQuantDb";
            this.lblQuantDb.Size = new System.Drawing.Size(13, 15);
            this.lblQuantDb.TabIndex = 1;
            this.lblQuantDb.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quantidade de Bancos de dados:";
            // 
            // CreateDb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 375);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnCreateDb);
            this.Controls.Add(this.btnSaveModel);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAddTable);
            this.Controls.Add(this.btnAdicionarDb);
            this.Controls.Add(this.tevDataVisualization);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "CreateDb";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Criar Banco de Dados";
            this.Activated += new System.EventHandler(this.CreateDb_Activated);
            this.Load += new System.EventHandler(this.CreateDb_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tevDataVisualization;
        private System.Windows.Forms.Button btnAdicionarDb;
        private System.Windows.Forms.Button btnAddTable;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSaveModel;
        private System.Windows.Forms.Button btnCreateDb;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar pgbAsyncTasks;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblQuantTabela;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblQuantDb;
        private System.Windows.Forms.Label label1;
    }
}