
namespace DataMaster.UI
{
    partial class UpdateDb
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
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.pgbAsyncTasks = new System.Windows.Forms.ToolStripProgressBar();
            this.btnCriarTabela = new System.Windows.Forms.Button();
            this.btnExcluirTabela = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSalvarArquivo = new System.Windows.Forms.Button();
            this.btnEditarTabela = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tevDataVisualization
            // 
            this.tevDataVisualization.LabelEdit = true;
            this.tevDataVisualization.Location = new System.Drawing.Point(12, 12);
            this.tevDataVisualization.Name = "tevDataVisualization";
            this.tevDataVisualization.Size = new System.Drawing.Size(466, 222);
            this.tevDataVisualization.TabIndex = 1;
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Location = new System.Drawing.Point(403, 324);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(75, 23);
            this.btnAtualizar.TabIndex = 2;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pgbAsyncTasks});
            this.statusStrip1.Location = new System.Drawing.Point(0, 351);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(490, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // pgbAsyncTasks
            // 
            this.pgbAsyncTasks.Name = "pgbAsyncTasks";
            this.pgbAsyncTasks.Size = new System.Drawing.Size(100, 16);
            this.pgbAsyncTasks.Visible = false;
            // 
            // btnCriarTabela
            // 
            this.btnCriarTabela.Location = new System.Drawing.Point(12, 240);
            this.btnCriarTabela.Name = "btnCriarTabela";
            this.btnCriarTabela.Size = new System.Drawing.Size(87, 23);
            this.btnCriarTabela.TabIndex = 9;
            this.btnCriarTabela.Text = "Criar tabela";
            this.btnCriarTabela.UseVisualStyleBackColor = true;
            this.btnCriarTabela.Click += new System.EventHandler(this.btnCriarTabela_Click);
            // 
            // btnExcluirTabela
            // 
            this.btnExcluirTabela.Location = new System.Drawing.Point(12, 269);
            this.btnExcluirTabela.Name = "btnExcluirTabela";
            this.btnExcluirTabela.Size = new System.Drawing.Size(87, 23);
            this.btnExcluirTabela.TabIndex = 10;
            this.btnExcluirTabela.Text = "Excluir tabela";
            this.btnExcluirTabela.UseVisualStyleBackColor = true;
            this.btnExcluirTabela.Click += new System.EventHandler(this.btnExcluirTabela_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(105, 240);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(373, 81);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informações";
            // 
            // btnSalvarArquivo
            // 
            this.btnSalvarArquivo.Location = new System.Drawing.Point(221, 324);
            this.btnSalvarArquivo.Name = "btnSalvarArquivo";
            this.btnSalvarArquivo.Size = new System.Drawing.Size(176, 23);
            this.btnSalvarArquivo.TabIndex = 12;
            this.btnSalvarArquivo.Text = "Salvar arquivo de atualização";
            this.btnSalvarArquivo.UseVisualStyleBackColor = true;
            this.btnSalvarArquivo.Click += new System.EventHandler(this.btnSalvarArquivo_Click);
            // 
            // btnEditarTabela
            // 
            this.btnEditarTabela.Location = new System.Drawing.Point(12, 298);
            this.btnEditarTabela.Name = "btnEditarTabela";
            this.btnEditarTabela.Size = new System.Drawing.Size(87, 23);
            this.btnEditarTabela.TabIndex = 13;
            this.btnEditarTabela.Text = "Editar tabela";
            this.btnEditarTabela.UseVisualStyleBackColor = true;
            this.btnEditarTabela.Click += new System.EventHandler(this.btnEditarTabela_Click);
            // 
            // UpdateDb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 373);
            this.Controls.Add(this.btnEditarTabela);
            this.Controls.Add(this.btnSalvarArquivo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnExcluirTabela);
            this.Controls.Add(this.btnCriarTabela);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.tevDataVisualization);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateDb";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Atualizar Banco de Dados";
            this.Load += new System.EventHandler(this.UpdateDb_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tevDataVisualization;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar pgbAsyncTasks;
        private System.Windows.Forms.Button btnCriarTabela;
        private System.Windows.Forms.Button btnExcluirTabela;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSalvarArquivo;
        private System.Windows.Forms.Button btnEditarTabela;
    }
}