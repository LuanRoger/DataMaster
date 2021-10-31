
namespace DataMaster.UI
{
    partial class Home
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuConexao = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCreateDb = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLaodModel = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuScript = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCreateScript = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLoadScript = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuConfiguration = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblTempo = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblConnString = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ACriarScript = new System.Windows.Forms.ToolStripButton();
            this.ACreateDb = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuConexao,
            this.mnuDatabase,
            this.mnuScript,
            this.mnuConfiguration,
            this.mnuAbout});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(404, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuConexao
            // 
            this.mnuConexao.Name = "mnuConexao";
            this.mnuConexao.Size = new System.Drawing.Size(67, 20);
            this.mnuConexao.Text = "Conectar";
            // 
            // mnuDatabase
            // 
            this.mnuDatabase.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCreateDb,
            this.mnuLaodModel});
            this.mnuDatabase.Name = "mnuDatabase";
            this.mnuDatabase.Size = new System.Drawing.Size(103, 20);
            this.mnuDatabase.Text = "Banco de dados";
            // 
            // mnuCreateDb
            // 
            this.mnuCreateDb.Name = "mnuCreateDb";
            this.mnuCreateDb.Size = new System.Drawing.Size(172, 22);
            this.mnuCreateDb.Text = "Criar novo banco";
            // 
            // mnuCarregarModelo
            // 
            this.mnuLaodModel.Name = "mnuLaodModel";
            this.mnuLaodModel.Size = new System.Drawing.Size(172, 22);
            this.mnuLaodModel.Text = "Carregar modelo...";
            // 
            // mnuScript
            // 
            this.mnuScript.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCreateScript,
            this.mnuLoadScript});
            this.mnuScript.Name = "mnuScript";
            this.mnuScript.Size = new System.Drawing.Size(49, 20);
            this.mnuScript.Text = "Script";
            // 
            // mnuCriarScript
            // 
            this.mnuCreateScript.Name = "mnuCreateScript";
            this.mnuCreateScript.Size = new System.Drawing.Size(161, 22);
            this.mnuCreateScript.Text = "Criar novo script";
            // 
            // mnuCarregarScript
            // 
            this.mnuLoadScript.Name = "mnuLoadScript";
            this.mnuLoadScript.Size = new System.Drawing.Size(161, 22);
            this.mnuLoadScript.Text = "Carregar script...";
            // 
            // mnuConfiguration
            // 
            this.mnuConfiguration.Name = "mnuConfiguration";
            this.mnuConfiguration.Size = new System.Drawing.Size(96, 20);
            this.mnuConfiguration.Text = "Configurações";
            // 
            // mnuAbout
            // 
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.Size = new System.Drawing.Size(49, 20);
            this.mnuAbout.Text = "Sobre";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblTempo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(404, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblTempo
            // 
            this.lblTempo.Name = "lblTempo";
            this.lblTempo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTempo.Size = new System.Drawing.Size(389, 17);
            this.lblTempo.Spring = true;
            this.lblTempo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblConnString
            // 
            this.lblConnString.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblConnString.AutoSize = true;
            this.lblConnString.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblConnString.Location = new System.Drawing.Point(3, 389);
            this.lblConnString.Name = "lblConnString";
            this.lblConnString.Size = new System.Drawing.Size(133, 15);
            this.lblConnString.TabIndex = 4;
            this.lblConnString.Text = "connStringPlaceholder";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackgroundImage = global::DataMaster.Properties.Resources.InicioBackground;
            this.tableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lblConnString, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(404, 404);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ACriarScript,
            this.ACreateDb});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(404, 25);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // ACriarScript
            // 
            this.ACriarScript.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ACriarScript.Image = global::DataMaster.Properties.Resources.script_add;
            this.ACriarScript.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ACriarScript.Name = "ACriarScript";
            this.ACriarScript.Size = new System.Drawing.Size(23, 22);
            this.ACriarScript.Text = "Novo script";
            // 
            // ACreateDb
            // 
            this.ACreateDb.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ACreateDb.Image = global::DataMaster.Properties.Resources.database_add;
            this.ACreateDb.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ACreateDb.Name = "ACreateDb";
            this.ACreateDb.Size = new System.Drawing.Size(23, 22);
            this.ACreateDb.Text = "ACreateDb";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 450);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data Master";
            this.Activated += new System.EventHandler(this.Home_Activated);
            this.Load += new System.EventHandler(this.Home_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout;
        private System.Windows.Forms.ToolStripMenuItem mnuDatabase;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblTempo;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem mnuCreateDb;
        private System.Windows.Forms.ToolStripMenuItem mnuLaodModel;
        private System.Windows.Forms.ToolStripMenuItem mnuConexao;
        private System.Windows.Forms.Label lblConnString;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStripMenuItem mnuScript;
        private System.Windows.Forms.ToolStripMenuItem mnuCreateScript;
        private System.Windows.Forms.ToolStripMenuItem mnuLoadScript;
        private System.Windows.Forms.ToolStripMenuItem mnuConfiguration;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton ACriarScript;
        private System.Windows.Forms.ToolStripButton ACreateDb;
    }
}

