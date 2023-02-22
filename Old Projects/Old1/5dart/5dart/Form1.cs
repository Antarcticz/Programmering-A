using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _5dart
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBoxResult_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonAim_Click(object sender, EventArgs e)
        {
            bool aim_good = Game.Aim_Result();
            if (aim_good == false)
            {
                textBoxAimResult.Text = "Bad Aiming";
            }
            else
            {
                textBoxAimResult.Text = "Good Aiming";
            }
        }

        private void buttonShoot_Click(object sender, EventArgs e)
        {

        }

        private void textBoxPlayers_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            char[] radbrytning = new char[] { '\r', '\n' };
            string[] name_vektor = textBoxPlayers.Text.Split(radbrytning, StringSplitOptions.RemoveEmptyEntries);
            //string result = "";
            for (int i = 1; i < name_vektor.Length; i++)
            {
                //result += name_vektor[i];
                
                Game.AddPlayer(name_vektor[i]);
            }
            //textBoxResult.Text = namn_vektor[i];
        }

        private void textBoxAimResult_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
