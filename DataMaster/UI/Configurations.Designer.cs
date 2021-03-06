
namespace DataMaster.UI
{
    partial class Configurations
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
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtConnectionString = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClearConnectionString = new System.Windows.Forms.Button();
            this.btnDeleteConnectionHistoric = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnChangeHighlight = new System.Windows.Forms.Button();
            this.txtHighlightColor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbLanguages = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Image = global::DataMaster.Properties.Resources.disk;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(313, 215);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(63, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Salvar";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtConnectionString);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnClearConnectionString);
            this.groupBox1.Controls.Add(this.btnDeleteConnectionHistoric);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(366, 103);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Conexão";
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.Location = new System.Drawing.Point(7, 41);
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.Size = new System.Drawing.Size(353, 23);
            this.txtConnectionString.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "String de conexão:";
            // 
            // btnClearConnectionString
            // 
            this.btnClearConnectionString.Location = new System.Drawing.Point(6, 70);
            this.btnClearConnectionString.Name = "btnClearConnectionString";
            this.btnClearConnectionString.Size = new System.Drawing.Size(173, 23);
            this.btnClearConnectionString.TabIndex = 1;
            this.btnClearConnectionString.Text = "Limpar string de conexão";
            this.btnClearConnectionString.UseVisualStyleBackColor = true;
            this.btnClearConnectionString.Click += new System.EventHandler(this.btnClearConnectionString_Click);
            // 
            // btnDeleteConnectionHistoric
            // 
            this.btnDeleteConnectionHistoric.Location = new System.Drawing.Point(187, 70);
            this.btnDeleteConnectionHistoric.Name = "btnDeleteConnectionHistoric";
            this.btnDeleteConnectionHistoric.Size = new System.Drawing.Size(173, 23);
            this.btnDeleteConnectionHistoric.TabIndex = 0;
            this.btnDeleteConnectionHistoric.Text = "Excluir histórico de conexão";
            this.btnDeleteConnectionHistoric.UseVisualStyleBackColor = true;
            this.btnDeleteConnectionHistoric.Click += new System.EventHandler(this.btnDeleteConnectionHistoric_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnChangeHighlight);
            this.groupBox2.Controls.Add(this.txtHighlightColor);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 121);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(194, 83);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Personalização";
            // 
            // btnChangeHighlight
            // 
            this.btnChangeHighlight.Location = new System.Drawing.Point(160, 41);
            this.btnChangeHighlight.Name = "btnChangeHighlight";
            this.btnChangeHighlight.Size = new System.Drawing.Size(26, 23);
            this.btnChangeHighlight.TabIndex = 2;
            this.btnChangeHighlight.Text = "...";
            this.btnChangeHighlight.UseVisualStyleBackColor = true;
            this.btnChangeHighlight.Click += new System.EventHandler(this.btnChangeHighlight_Click);
            // 
            // txtHighlightColor
            // 
            this.txtHighlightColor.Location = new System.Drawing.Point(7, 41);
            this.txtHighlightColor.Name = "txtHighlightColor";
            this.txtHighlightColor.ReadOnly = true;
            this.txtHighlightColor.Size = new System.Drawing.Size(147, 23);
            this.txtHighlightColor.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Cor de destaque do editor:";
            // 
            // cmbLanguages
            // 
            this.cmbLanguages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLanguages.FormattingEnabled = true;
            this.cmbLanguages.Location = new System.Drawing.Point(212, 150);
            this.cmbLanguages.Name = "cmbLanguages";
            this.cmbLanguages.Size = new System.Drawing.Size(166, 23);
            this.cmbLanguages.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(212, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Idioma:";
            // 
            // Configurations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 250);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbLanguages);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Configurations";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configurações";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Configurations_FormClosed);
            this.Load += new System.EventHandler(this.Configurations_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtConnectionString;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClearConnectionString;
        private System.Windows.Forms.Button btnDeleteConnectionHistoric;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnChangeHighlight;
        private System.Windows.Forms.TextBox txtHighlightColor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbLanguages;
        private System.Windows.Forms.Label label3;
    }
}