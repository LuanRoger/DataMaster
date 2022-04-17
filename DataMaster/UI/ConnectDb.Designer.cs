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
            this.cmbServerName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbServerType = new System.Windows.Forms.ComboBox();
            this.gpbInfoUser = new System.Windows.Forms.GroupBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNameDb = new System.Windows.Forms.TextBox();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.tbcProviderConnection = new System.Windows.Forms.TabControl();
            this.tabSqlServer = new System.Windows.Forms.TabPage();
            this.tabSqlite = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
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
            // cmbServerName
            // 
            this.cmbServerName.FormattingEnabled = true;
            this.cmbServerName.Location = new System.Drawing.Point(6, 21);
            this.cmbServerName.Name = "cmbServerName";
            this.cmbServerName.Size = new System.Drawing.Size(341, 23);
            this.cmbServerName.TabIndex = 2;
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
            // cmbServerType
            // 
            this.cmbServerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbServerType.FormattingEnabled = true;
            this.cmbServerType.Location = new System.Drawing.Point(6, 113);
            this.cmbServerType.Name = "cmbServerType";
            this.cmbServerType.Size = new System.Drawing.Size(341, 23);
            this.cmbServerType.TabIndex = 4;
            this.cmbServerType.SelectedIndexChanged += new System.EventHandler(this.cmbServerType_SelectedIndexChanged);
            // 
            // gpbInfoUser
            // 
            this.gpbInfoUser.Controls.Add(this.txtPassword);
            this.gpbInfoUser.Controls.Add(this.label4);
            this.gpbInfoUser.Controls.Add(this.txtUserName);
            this.gpbInfoUser.Controls.Add(this.label3);
            this.gpbInfoUser.Enabled = false;
            this.gpbInfoUser.Location = new System.Drawing.Point(6, 142);
            this.gpbInfoUser.Name = "gpbInfoUser";
            this.gpbInfoUser.Size = new System.Drawing.Size(340, 97);
            this.gpbInfoUser.TabIndex = 5;
            this.gpbInfoUser.TabStop = false;
            this.gpbInfoUser.Text = "Informações de autenticação";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(116, 57);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(218, 23);
            this.txtPassword.TabIndex = 3;
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
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(116, 23);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(218, 23);
            this.txtUserName.TabIndex = 1;
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
            // txtNameDb
            // 
            this.txtNameDb.Location = new System.Drawing.Point(6, 69);
            this.txtNameDb.Name = "txtNameDb";
            this.txtNameDb.Size = new System.Drawing.Size(341, 23);
            this.txtNameDb.TabIndex = 7;
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
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestarConexao_Click);
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
            this.tabSqlServer.Controls.Add(this.txtNameDb);
            this.tabSqlServer.Controls.Add(this.cmbServerName);
            this.tabSqlServer.Controls.Add(this.label5);
            this.tabSqlServer.Controls.Add(this.label2);
            this.tabSqlServer.Controls.Add(this.cmbServerType);
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
            this.tabSqlite.Controls.Add(this.checkBox1);
            this.tabSqlite.Controls.Add(this.textBox2);
            this.tabSqlite.Controls.Add(this.label8);
            this.tabSqlite.Controls.Add(this.comboBox1);
            this.tabSqlite.Controls.Add(this.label7);
            this.tabSqlite.Controls.Add(this.textBox1);
            this.tabSqlite.Controls.Add(this.label6);
            this.tabSqlite.Location = new System.Drawing.Point(4, 24);
            this.tabSqlite.Name = "tabSqlite";
            this.tabSqlite.Padding = new System.Windows.Forms.Padding(3);
            this.tabSqlite.Size = new System.Drawing.Size(353, 246);
            this.tabSqlite.TabIndex = 1;
            this.tabSqlite.Text = "SQLite";
            this.tabSqlite.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "Nome do banco:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 21);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(341, 23);
            this.textBox1.TabIndex = 1;
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
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "3"});
            this.comboBox1.Location = new System.Drawing.Point(6, 109);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(96, 23);
            this.comboBox1.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(152, 15);
            this.label8.TabIndex = 4;
            this.label8.Text = "Senha (vazio se não quiser):";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(6, 65);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(341, 23);
            this.textBox2.TabIndex = 5;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(108, 111);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(101, 19);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "Apenas leitura";
            this.checkBox1.UseVisualStyleBackColor = true;
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
        private System.Windows.Forms.ComboBox cmbServerName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbServerType;
        private System.Windows.Forms.GroupBox gpbInfoUser;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNameDb;
        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.TabControl tbcProviderConnection;
        private System.Windows.Forms.TabPage tabSqlServer;
        private System.Windows.Forms.TabPage tabSqlite;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label8;
    }
}