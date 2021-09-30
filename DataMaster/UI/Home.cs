﻿using Baser.GUI;
using DataMaster.UI;
using System;
using System.Windows.Forms;
using DataMaster.Managers;
using DataMaster.Managers.Configuration;

namespace DataMaster
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            SetMenuClick();
        }

        private void SetMenuClick()
        {
            mnuConexao.Click += (_, _) =>
            {
                ConnectDb connectDb = new();
                connectDb.Show();
            };

            mnuCreateDb.Click += (_, _) =>
            {
                CreateDb createDb = new();
                createDb.Show();
            };
            mnuCreateMigration.Click += (_, _) =>
            {
                if(string.IsNullOrEmpty(DbConnectionManager.GetConnectedDatabase()))
                {
                    MessageBox.Show("Conecte-se a um banco de dados antes de continuar", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try
                {
                    UpdateDb updateDb = new();
                    updateDb.Show();   
                }
                catch(Exception exception)
                {
                    MessageBox.Show("Ocorreu um error: " + exception.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            mnuCarregarModelo.Click += (_, _) => 
            {
                OpenFileDialog openFileDialog = new()
                {
                    Filter = Consts.FILTER_DSM
                };

                DialogResult dialogResult = openFileDialog.ShowDialog();

                if(dialogResult != DialogResult.OK) return;

                CreateDb createDb = new(openFileDialog.FileName);
                createDb.Show();
            };

            mnuAbout.Click += (_, _) =>
            {
                Sobre sobre = new();
                sobre.Show();
            };
        }

        private void Home_Load(object sender, EventArgs e)
        {
            ShowInTaskbar = false;
            Opacity = 0;

            SplashScreen splashScreen = new();
            splashScreen.Show();
            splashScreen.FormClosed += (_, _) => {
                ShowInTaskbar = true;
                Opacity = 100;
                BringToFront();
            };
        }

        private void timer1_Tick(object sender, EventArgs e) => lblTempo.Text = DateTime.Now.ToString();

        private void Home_Activated(object sender, EventArgs e)
        {
            lblConnString.Text = string.IsNullOrEmpty(AppConfigurationManager.configuration.database.ConnectionString) ? 
                "Nenhuma string de conexão definida" :
                AppConfigurationManager.configuration.database.ConnectionString;
        }
    }
}