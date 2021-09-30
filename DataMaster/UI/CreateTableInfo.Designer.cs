﻿
namespace DataMaster.UI
{
    partial class CreateTableInfo
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
            this.tevTableDesing = new System.Windows.Forms.TreeView();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNomeColuna = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTiposDados = new System.Windows.Forms.ComboBox();
            this.chbPermitirNull = new System.Windows.Forms.CheckBox();
            this.btnAcionarColuna = new System.Windows.Forms.Button();
            this.chbHasKey = new System.Windows.Forms.CheckBox();
            this.btnSubirColuna = new System.Windows.Forms.Button();
            this.btnDescerColuna = new System.Windows.Forms.Button();
            this.btnRemoverColuna = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tevTableDesing
            // 
            this.tevTableDesing.LabelEdit = true;
            this.tevTableDesing.Location = new System.Drawing.Point(12, 12);
            this.tevTableDesing.Name = "tevTableDesing";
            this.tevTableDesing.Size = new System.Drawing.Size(468, 164);
            this.tevTableDesing.TabIndex = 0;
            this.tevTableDesing.BeforeLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.tevTableDesing_BeforeLabelEdit);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(405, 281);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(324, 281);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nome da coluna:";
            // 
            // txtNomeColuna
            // 
            this.txtNomeColuna.Location = new System.Drawing.Point(12, 197);
            this.txtNomeColuna.Name = "txtNomeColuna";
            this.txtNomeColuna.Size = new System.Drawing.Size(143, 23);
            this.txtNomeColuna.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 223);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tipo de dados:";
            // 
            // txtTiposDados
            // 
            this.txtTiposDados.FormattingEnabled = true;
            this.txtTiposDados.Items.AddRange(new object[] {
            "bigint",
            "binary(50)",
            "bit",
            "char(10)",
            "date",
            "datetime",
            "datetime2(7)",
            "datetimeoffset(7)",
            "decimal(18, 0)",
            "float",
            "geography",
            "geometry",
            "hierarchyid",
            "image",
            "int",
            "money",
            "nchar(10)",
            "ntext",
            "numeric(18, 0)",
            "nvarchar(50)",
            "nvarchar(MAX)",
            "real",
            "smalldatetime",
            "smallint",
            "smallmoney",
            "sql_variant",
            "text",
            "time(7)",
            "timestamp",
            "tinyint",
            "uniqueidentifier",
            "varbinary(50)",
            "varbinary(MAX)",
            "varchar(50)",
            "varchar(MAX)",
            "xml"});
            this.txtTiposDados.Location = new System.Drawing.Point(12, 241);
            this.txtTiposDados.Name = "txtTiposDados";
            this.txtTiposDados.Size = new System.Drawing.Size(143, 23);
            this.txtTiposDados.TabIndex = 6;
            this.txtTiposDados.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTiposDados_KeyDown);
            // 
            // chbPermitirNull
            // 
            this.chbPermitirNull.AutoSize = true;
            this.chbPermitirNull.Location = new System.Drawing.Point(161, 197);
            this.chbPermitirNull.Name = "chbPermitirNull";
            this.chbPermitirNull.Size = new System.Drawing.Size(100, 19);
            this.chbPermitirNull.TabIndex = 7;
            this.chbPermitirNull.Text = "Permitir NULL";
            this.chbPermitirNull.UseVisualStyleBackColor = true;
            // 
            // btnAcionarColuna
            // 
            this.btnAcionarColuna.Location = new System.Drawing.Point(161, 241);
            this.btnAcionarColuna.Name = "btnAcionarColuna";
            this.btnAcionarColuna.Size = new System.Drawing.Size(75, 23);
            this.btnAcionarColuna.TabIndex = 8;
            this.btnAcionarColuna.Text = "Adicionar";
            this.btnAcionarColuna.UseVisualStyleBackColor = true;
            this.btnAcionarColuna.Click += new System.EventHandler(this.btnAcionarColuna_Click);
            // 
            // chbHasKey
            // 
            this.chbHasKey.AutoSize = true;
            this.chbHasKey.Location = new System.Drawing.Point(161, 219);
            this.chbHasKey.Name = "chbHasKey";
            this.chbHasKey.Size = new System.Drawing.Size(59, 19);
            this.chbHasKey.TabIndex = 9;
            this.chbHasKey.Text = "Chave";
            this.chbHasKey.UseVisualStyleBackColor = true;
            // 
            // btnSubirColuna
            // 
            this.btnSubirColuna.Image = global::DataMaster.Properties.Resources.arrow_up;
            this.btnSubirColuna.Location = new System.Drawing.Point(449, 194);
            this.btnSubirColuna.Name = "btnSubirColuna";
            this.btnSubirColuna.Size = new System.Drawing.Size(31, 23);
            this.btnSubirColuna.TabIndex = 10;
            this.btnSubirColuna.UseVisualStyleBackColor = true;
            this.btnSubirColuna.Click += new System.EventHandler(this.btnSubirColuna_Click);
            // 
            // btnDescerColuna
            // 
            this.btnDescerColuna.Image = global::DataMaster.Properties.Resources.arrow_down;
            this.btnDescerColuna.Location = new System.Drawing.Point(449, 223);
            this.btnDescerColuna.Name = "btnDescerColuna";
            this.btnDescerColuna.Size = new System.Drawing.Size(31, 23);
            this.btnDescerColuna.TabIndex = 11;
            this.btnDescerColuna.UseVisualStyleBackColor = true;
            this.btnDescerColuna.Click += new System.EventHandler(this.btnDescerColuna_Click);
            // 
            // btnRemoverColuna
            // 
            this.btnRemoverColuna.Location = new System.Drawing.Point(242, 241);
            this.btnRemoverColuna.Name = "btnRemoverColuna";
            this.btnRemoverColuna.Size = new System.Drawing.Size(75, 23);
            this.btnRemoverColuna.TabIndex = 13;
            this.btnRemoverColuna.Text = "Remover";
            this.btnRemoverColuna.UseVisualStyleBackColor = true;
            this.btnRemoverColuna.Click += new System.EventHandler(this.btnRemoverColuna_Click);
            // 
            // CreateTableInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 316);
            this.Controls.Add(this.btnRemoverColuna);
            this.Controls.Add(this.btnDescerColuna);
            this.Controls.Add(this.btnSubirColuna);
            this.Controls.Add(this.chbHasKey);
            this.Controls.Add(this.btnAcionarColuna);
            this.Controls.Add(this.chbPermitirNull);
            this.Controls.Add(this.txtTiposDados);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNomeColuna);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tevTableDesing);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateTableInfo";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Criar Tabela";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tevTableDesing;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNomeColuna;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox txtTiposDados;
        private System.Windows.Forms.CheckBox chbPermitirNull;
        private System.Windows.Forms.Button btnAcionarColuna;
        private System.Windows.Forms.CheckBox chbHasKey;
        private System.Windows.Forms.Button btnSubirColuna;
        private System.Windows.Forms.Button btnDescerColuna;
        private System.Windows.Forms.Button btnRemoverColuna;
    }
}