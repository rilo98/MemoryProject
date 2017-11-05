﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace TestMDi3
{
    public partial class Opties : Form
    {
        public bool mute = false;

        bool applied = true;
        int standaartcount;
        public Opties()
        {
            InitializeComponent();
            //load all themes
            if (!Directory.Exists(@"Themes\" + themename.Text))
            {
                Directory.CreateDirectory(@"Themes\");
                string[] files = Directory.GetDirectories(@"Themes\");
                dropdown.Items.AddRange(files);
                dropdown.Items.Add("Standaart");
                dropdown.SelectedItem = "Standaart";
                StartPosition = FormStartPosition.Manual;
                Location = new Point(0, 0);
            }

            else
            {
                string[] files = Directory.GetDirectories(@"Themes\");
                dropdown.Items.AddRange(files);
                dropdown.Items.Add("Standaart");
                dropdown.SelectedItem = "Standaart";
                StartPosition = FormStartPosition.Manual;
                Location = new Point(0, 0);
            }

            Volume.BackgroundImage = Properties.Resources.Volume_max;
            Volume.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void upload_Click(object sender, EventArgs e)
        {
            //upload een folder voor de themes 
            string targetPath = @"Themes\" + themename.Text;
            string source = "";
            try
            {
                FolderBrowserDialog dialog = new FolderBrowserDialog();

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    source = dialog.SelectedPath;
                    DirectoryCopy(source, targetPath);
                    string[] files = Directory.GetDirectories(@"Themes\");
                    dropdown.Items.AddRange(files);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An error occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private static void DirectoryCopy(string sourceDirName, string destDirName)
        {
            // Haalt de mapjes op.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException("De geselecteerde map kon niet worden gevonden: " + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, false);
            }
        }


        public void applysettings()
        {
            applied = true;
            Spel.selectedtheme = dropdown.Text;
        }


        //buttons

        private void Apply_Click(object sender, EventArgs e)
        {
            applysettings();
        }

        private void Terug_Click(object sender, EventArgs e)
        {
            if (applied == false)
            {
                DialogResult dialogResult = MessageBox.Show("U heeft nog niet opgeslagen; Wilt u opslaan?", "Opslaan", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    applysettings();
                    MessageBox.Show("Instellingen zijn opsgeslagen", "Opgeslagen");
                    Hoofdmenu f2 = new Hoofdmenu();
                    f2.MdiParent = this.ParentForm;
                    f2.Show();
                    Close();
                }
                else if (dialogResult == DialogResult.No)
                {
                    Hoofdmenu f2 = new Hoofdmenu();
                    f2.MdiParent = this.ParentForm;
                    f2.Show();
                    Close();
                }
            }
            else
            {
                Hoofdmenu f2 = new Hoofdmenu();
                f2.MdiParent = this.ParentForm;
                f2.Show();
                Close();
            }
        }

        private void dropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            applied = false;

            if (dropdown.Text == "Standaart" && standaartcount == 0)
            {
                standaartcount++;
                return;
            }
            else
            {
                MessageBox.Show(dropdown.Text + " is geselecteerd!");
            }
        }

        private void Volume_Click(object sender, EventArgs e)
        {
            if (mute == false)
            {
                Volume.BackgroundImage = Properties.Resources.Volume_Mute;
                Volume.BackgroundImageLayout = ImageLayout.Stretch;
                mute = true;
            }

            if (mute == true)
            {
                Volume.BackgroundImage = Properties.Resources.Volume_max;
                Volume.BackgroundImageLayout = ImageLayout.Stretch;
                mute = false;
            }
        }
    }
}
