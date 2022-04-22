namespace DataMaster.UI
{
    partial class ConnectDb
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
            this.btnConnectDb = new System.Windows.Forms.Button();
            this.cmbServerNameSqlServer = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbAuthTypeSqlServer = new System.Windows.Forms.ComboBox();
            this.gpbInfoUser = new System.Windows.Forms.GroupBox();
            this.txtPasswordSqlServer = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUsernameSqlServer = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDbNameSqlServer = new System.Windows.Forms.TextBox();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.tbcProviderConnection = new System.Windows.Forms.TabControl();
            this.tabSqlServer = new System.Windows.Forms.TabPage();
            this.tabSqlite = new System.Windows.Forms.TabPage();
            this.chbReadOnlySqlite = new System.Windows.Forms.CheckBox();
            this.txtPasswordSqlite = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbVersionSqlite = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDataSourceSqlite = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.gpbInfoUser.SuspendLayout();
            this.tbcProviderConnection.SuspendLayout();
            this.tabSqlServer.SuspendLayout();
            this.tabSqlite.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome do servidor:";
            // 
            // btnConnectDb
            // 
            this.btnConnectDb.Image = global::DataMaster.Properties.Resources.disk;
            this.btnConnectDb.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConnectDb.Location = new System.Drawing.Point(305, 292);
            this.btnConnectDb.Name = "btnConnectDb";
            this.btnConnectDb.Size = new System.Drawing.Size(64, 23);
            this.btnConnectDb.TabIndex = 1;
            this.btnConnectDb.Text = "Salvar";
            this.btnConnectDb.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConnectDb.UseVisualStyleBackColor = true;
            this.btnConnectDb.Click += new System.EventHandler(this.btnConnectDb_Click);
            // 
            // cmbServerNameSqlServer
            // 
            this.cmbServerNameSqlServer.FormattingEnabled = true;
            this.cmbServerNameSqlServer.Location = new System.Drawing.Point(6, 21);
            this.cmbServerNameSqlServer.Name = "cmbServerNameSqlServer";
            this.cmbServerNameSqlServer.Size = new System.Drawing.Size(341, 23);
            this.cmbServerNameSqlServer.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Autenticação:";
            // 
            // cmbAuthTypeSqlServer
            // 
            this.cmbAuthTypeSqlServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAuthTypeSqlServer.FormattingEnabled = true;
            this.cmbAuthTypeSqlServer.Location = new System.Drawing.Point(6, 113);
            this.cmbAuthTypeSqlServer.Name = "cmbAuthTypeSqlServer";
            this.cmbAuthTypeSqlServer.Size = new System.Drawing.Size(341, 23);
            this.cmbAuthTypeSqlServer.TabIndex = 4;
            this.cmbAuthTypeSqlServer.SelectedIndexChanged += new System.EventHandler(this.cmbServerType_SelectedIndexChanged);
            // 
            // gpbInfoUser
            // 
            this.gpbInfoUser.Controls.Add(this.txtPasswordSqlServer);
            this.gpbInfoUser.Controls.Add(this.label4);
            this.gpbInfoUser.Controls.Add(this.txtUsernameSqlServer);
            this.gpbInfoUser.Controls.Add(this.label3);
            this.gpbInfoUser.Enabled = false;
            this.gpbInfoUser.Location = new System.Drawing.Point(6, 142);
            this.gpbInfoUser.Name = "gpbInfoUser";
            this.gpbInfoUser.Size = new System.Drawing.Size(340, 97);
            this.gpbInfoUser.TabIndex = 5;
            this.gpbInfoUser.TabStop = false;
            this.gpbInfoUser.Text = "Informações de autenticação";
            // 
            // txtPasswordSqlServer
            // 
            this.txtPasswordSqlServer.Location = new System.Drawing.Point(116, 57);
            this.txtPasswordSqlServer.Name = "txtPasswordSqlServer";
            this.txtPasswordSqlServer.Size = new System.Drawing.Size(218, 23);
            this.txtPasswordSqlServer.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Senha:";
            // 
            // txtUsernameSqlServer
            // 
            this.txtUsernameSqlServer.Location = new System.Drawing.Point(116, 23);
            this.txtUsernameSqlServer.Name = "txtUsernameSqlServer";
            this.txtUsernameSqlServer.Size = new System.Drawing.Size(218, 23);
            this.txtUsernameSqlServer.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Nome de Usuário:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "Nome do banco de dados:";
            // 
            // txtDbNameSqlServer
            // 
            this.txtDbNameSqlServer.Location = new System.Drawing.Point(6, 69);
            this.txtDbNameSqlServer.Name = "txtDbNameSqlServer";
            this.txtDbNameSqlServer.Size = new System.Drawing.Size(341, 23);
            this.txtDbNameSqlServer.TabIndex = 7;
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Image = global::DataMaster.Properties.Resources.database_lightning;
            this.btnTestConnection.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTestConnection.Location = new System.Drawing.Point(12, 292);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(109, 23);
            this.btnTestConnection.TabIndex = 8;
            this.btnTestConnection.Text = "Testar conexão";
            this.btnTestConnection.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // tbcProviderConnection
            // 
            this.tbcProviderConnection.Controls.Add(this.tabSqlServer);
            this.tbcProviderConnection.Controls.Add(this.tabSqlite);
            this.tbcProviderConnection.Location = new System.Drawing.Point(12, 12);
            this.tbcProviderConnection.Name = "tbcProviderConnection";
            this.tbcProviderConnection.SelectedIndex = 0;
            this.tbcProviderConnection.Size = new System.Drawing.Size(361, 274);
            this.tbcProviderConnection.TabIndex = 9;
            // 
            // tabSqlServer
            // 
            this.tabSqlServer.Controls.Add(this.gpbInfoUser);
            this.tabSqlServer.Controls.Add(this.label1);
            this.tabSqlServer.Controls.Add(this.txtDbNameSqlServer);
            this.tabSqlServer.Controls.Add(this.cmbServerNameSqlServer);
            this.tabSqlServer.Controls.Add(this.label5);
            this.tabSqlServer.Controls.Add(this.label2);
            this.tabSqlServer.Controls.Add(this.cmbAuthTypeSqlServer);
            this.tabSqlServer.Location = new System.Drawing.Point(4, 24);
            this.tabSqlServer.Name = "tabSqlServer";
            this.tabSqlServer.Padding = new System.Windows.Forms.Padding(3);
            this.tabSqlServer.Size = new System.Drawing.Size(353, 246);
            this.tabSqlServer.TabIndex = 0;
            this.tabSqlServer.Text = "SQL Server";
            this.tabSqlServer.UseVisualStyleBackColor = true;
            // 
            // tabSqlite
            // 
            this.tabSqlite.Controls.Add(this.chbReadOnlySqlite);
            this.tabSqlite.Controls.Add(this.txtPasswordSqlite);
            this.tabSqlite.Controls.Add(this.label8);
            this.tabSqlite.Controls.Add(this.cmbVersionSqlite);
            this.tabSqlite.Controls.Add(this.label7);
            this.tabSqlite.Controls.Add(this.txtDataSourceSqlite);
            this.tabSqlite.Controls.Add(this.label6);
            this.tabSqlite.Location = new System.Drawing.Point(4, 24);
            this.tabSqlite.Name = "tabSqlite";
            this.tabSqlite.Padding = new System.Windows.Forms.Padding(3);
            this.tabSqlite.Size = new System.Drawing.Size(353, 246);
            this.tabSqlite.TabIndex = 1;
            this.tabSqlite.Text = "SQLite";
            this.tabSqlite.UseVisualStyleBackColor = true;
            // 
            // chbReadOnlySqlite
            // 
            this.chbReadOnlySqlite.AutoSize = true;
            this.chbReadOnlySqlite.Location = new System.Drawing.Point(108, 111);
            this.chbReadOnlySqlite.Name = "chbReadOnlySqlite";
            this.chbReadOnlySqlite.Size = new System.Drawing.Size(101, 19);
            this.chbReadOnlySqlite.TabIndex = 6;
            this.chbReadOnlySqlite.Text = "Apenas leitura";
            this.chbReadOnlySqlite.UseVisualStyleBackColor = true;
            // 
            // txtPasswordSqlite
            // 
            this.txtPasswordSqlite.Location = new System.Drawing.Point(6, 65);
            this.txtPasswordSqlite.Name = "txtPasswordSqlite";
            this.txtPasswordSqlite.Size = new System.Drawing.Size(341, 23);
            this.txtPasswordSqlite.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 15);
            this.label8.TabIndex = 4;
            this.label8.Text = "Senha (opcional):";
            // 
            // cmbVersionSqlite
            // 
            this.cmbVersionSqlite.FormattingEnabled = true;
            this.cmbVersionSqlite.Items.AddRange(new object[] {
            "3"});
            this.cmbVersionSqlite.Location = new System.Drawing.Point(6, 109);
            this.cmbVersionSqlite.Name = "cmbVersionSqlite";
            this.cmbVersionSqlite.Size = new System.Drawing.Size(96, 23);
            this.cmbVersionSqlite.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 15);
            this.label7.TabIndex = 2;
            this.label7.Text = "Versão:";
            // 
            // txtDataSourceSqlite
            // 
            this.txtDataSourceSqlite.Location = new System.Drawing.Point(6, 21);
            this.txtDataSourceSqlite.Name = "txtDataSourceSqlite";
            this.txtDataSourceSqlite.Size = new System.Drawing.Size(341, 23);
            this.txtDataSourceSqlite.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "Fonte de dados:";
            // 
            // ConnectDb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 323);
            this.Controls.Add(this.tbcProviderConnection);
            this.Controls.Add(this.btnTestConnection);
            this.Controls.Add(this.btnConnectDb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ConnectDb";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Conectar";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ConnectDb_FormClosed);
            this.Load += new System.EventHandler(this.ConnectDb_Load);
            this.gpbInfoUser.ResumeLayout(false);
            this.gpbInfoUser.PerformLayout();
            this.tbcProviderConnection.ResumeLayout(false);
            this.tabSqlServer.ResumeLayout(false);
            this.tabSqlServer.PerformLayout();
            this.tabSqlite.ResumeLayout(false);
            this.tabSqlite.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConnectDb;
        private System.Windows.Forms.ComboBox cmbServerNameSqlServer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbAuthTypeSqlServer;
        private System.Windows.Forms.GroupBox gpbInfoUser;
        private System.Windows.Forms.TextBox txtPasswordSqlServer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUsernameSqlServer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDbNameSqlServer;
        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.TabControl tbcProviderConnection;
        private System.Windows.Forms.TabPage tabSqlServer;
        private System.Windows.Forms.TabPage tabSqlite;
        private System.Windows.Forms.ComboBox cmbVersionSqlite;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDataSourceSqlite;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chbReadOnlySqlite;
        private System.Windows.Forms.TextBox txtPasswordSqlite;
        private System.Windows.Forms.Label label8;
    }
}