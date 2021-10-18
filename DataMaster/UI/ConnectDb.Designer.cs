
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
            this.btnTestarConexao = new System.Windows.Forms.Button();
            this.gpbInfoUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome do servidor:";
            // 
            // btnConnectDb
            // 
            this.btnConnectDb.Image = global::DataMaster.Properties.Resources.disk;
            this.btnConnectDb.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConnectDb.Location = new System.Drawing.Point(289, 256);
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
            this.cmbServerName.Location = new System.Drawing.Point(12, 27);
            this.cmbServerName.Name = "cmbServerName";
            this.cmbServerName.Size = new System.Drawing.Size(341, 23);
            this.cmbServerName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Autenticação:";
            // 
            // cmbServerType
            // 
            this.cmbServerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbServerType.FormattingEnabled = true;
            this.cmbServerType.Items.AddRange(new object[] {
            "Autenticação do Windows",
            "Autenticação do SQL Server"});
            this.cmbServerType.Location = new System.Drawing.Point(12, 119);
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
            this.gpbInfoUser.Location = new System.Drawing.Point(12, 148);
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
            this.label4.Location = new System.Drawing.Point(7, 57);
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
            this.label5.Location = new System.Drawing.Point(12, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "Nome do banco de dados:";
            // 
            // txtNameDb
            // 
            this.txtNameDb.Location = new System.Drawing.Point(12, 75);
            this.txtNameDb.Name = "txtNameDb";
            this.txtNameDb.Size = new System.Drawing.Size(341, 23);
            this.txtNameDb.TabIndex = 7;
            // 
            // btnTestarConexao
            // 
            this.btnTestarConexao.Image = global::DataMaster.Properties.Resources.database_lightning;
            this.btnTestarConexao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTestarConexao.Location = new System.Drawing.Point(12, 256);
            this.btnTestarConexao.Name = "btnTestarConexao";
            this.btnTestarConexao.Size = new System.Drawing.Size(109, 23);
            this.btnTestarConexao.TabIndex = 8;
            this.btnTestarConexao.Text = "Testar conexão";
            this.btnTestarConexao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTestarConexao.UseVisualStyleBackColor = true;
            this.btnTestarConexao.Click += new System.EventHandler(this.btnTestarConexao_Click);
            // 
            // ConnectDb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 291);
            this.Controls.Add(this.btnTestarConexao);
            this.Controls.Add(this.txtNameDb);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.gpbInfoUser);
            this.Controls.Add(this.cmbServerType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbServerName);
            this.Controls.Add(this.btnConnectDb);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ConnectDb";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Conectar";
            this.Load += new System.EventHandler(this.ConnectDb_Load);
            this.gpbInfoUser.ResumeLayout(false);
            this.gpbInfoUser.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Button btnTestarConexao;
    }
}