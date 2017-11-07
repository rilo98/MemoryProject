﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestMDi3
{
    public partial class MultiNameninvoeren : Form
    {
        public static string multispeler1, multispeler2;
        public static int length, width;
        public static bool spelmultiplayer;

        public MultiNameninvoeren()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);

            Lengte.Value = 4;
            Lengte.Maximum = 8;
            Lengte.Minimum = 4;


            Breedte.Value = 4;
            Breedte.Maximum = 8;
            Breedte.Minimum = 4;

            if (Spel.taalEngels == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                {
                    if (button.Text == "Terug")
                    {
                        button.Text = "Back";
                    }
                    if (button.Text == "Volgende")
                    {
                        button.Text = "Next";
                    }
                }
                foreach (Label label in this.Controls.OfType<Label>())
                {
                    if (label.Text == "Speler 1:")
                    {
                        label.Text = "Player 1:";
                    }
                    if (label.Text == "Speler 2")
                    {
                        label.Text = "Player 2";
                    }
                    if (label.Text == "Formaat speelveld <4-8>")
                    {
                        label.Text = "Size game board <4-8>";
                    }
                    if (label.Text == "Lengte:")
                    {
                        label.Text = "Length:";
                    }
                    if (label.Text == "Breedte:")
                    {
                        label.Text = "Width:";
                    }
                }
            }
        }

        private void Lengte_TextChanged(object sender, EventArgs e)
        {

        }

        private void Terug_Click(object sender, EventArgs e)
        {
            Spelers f3 = new Spelers();
            f3.MdiParent = this.ParentForm;
            f3.Show();
            Close();
        }

        private void Volgende_Click(object sender, EventArgs e)
        {
            if (Breedte.Text == "" || Lengte.Text == "" || (Convert.ToInt32(Lengte.Text) > 8 || Convert.ToInt32(Lengte.Text) < 4) || (Convert.ToInt32(Breedte.Text) > 8 || Convert.ToInt32(Breedte.Text) < 4))
            {
                if (Spel.taalEngels != true)
                {
                    status.Text = "Voer een getal tussen de 4 en de 8 in.";
                    status.ForeColor = Color.Red;
                }
                if (Spel.taalEngels == true)
                {
                    if(Spel.taalEngels == true)
                    status.Text = "Enter a number between 4 and 8.";
                    status.ForeColor = Color.Red;
                }
                return;
            }
            else if ((Convert.ToInt32(Lengte.Text) == 7 && Convert.ToInt32(Breedte.Text) == 7) || (Convert.ToInt32(Lengte.Text) == 5 && Convert.ToInt32(Breedte.Text) == 5) || (Convert.ToInt32(Lengte.Text) == 7 && Convert.ToInt32(Breedte.Text) == 5) || (Convert.ToInt32(Lengte.Text) == 5 && Convert.ToInt32(Breedte.Text) == 7))
            {
                if(Spel.taalEngels != true)
                {
                    status.Text = "Voer 2 even getallen, of een even en oneven getal.";
                    status.ForeColor = Color.Red;
                }
               if(Spel.taalEngels == true)
                {
                    status.Text = "Enter 2 odd numbers, or an even and odd number.";
                    status.ForeColor = Color.Red;
                }
                return;
            }

            else
            {
                if (speler1.Text == "" || speler2.Text == "")
                {
                    if(Spel.taalEngels != true)
                    {
                        errornaam.Text = "Vul een naam in.";
                        errornaam.ForeColor = Color.Red;
                    }
                 if(Spel.taalEngels == true)
                    {
                        errornaam.Text = "Enter a name.";
                        errornaam.ForeColor = Color.Red;
                    }
                    return;
                }

                else
                {
                    Spel.length = Convert.ToInt32(Lengte.Text);
                    Spel.width = Convert.ToInt32(Breedte.Text);
                    Spel.multinaam1 = speler1.Text;
                    Spel.multinaam2 = speler2.Text;
                    Spel.multiplayer = true;
                    Dobbelsteen f6 = new Dobbelsteen();
                    f6.MdiParent = this.ParentForm;
                    f6.Show();
                    Close();
                }
            }
        }
    }
}
