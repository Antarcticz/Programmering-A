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

        Game dartspel = new Game();
        //int TurnCount = 0;
        int PlayerCount = 0;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBoxResult_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonAim_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < dartspel.player_list[PlayerCount].turn_list.Count-1; i++)
            {
                bool _aim_good = dartspel.player_list[PlayerCount].turn_list[i].Get_Aim_Result();
                if (_aim_good == false)
                {
                    textBoxAimResult.Text += "Bad Aiming";
                    textBoxAimResult.AppendText(Environment.NewLine);
                }
                else
                {
                    textBoxAimResult.Text += "Good Aiming";
                    textBoxAimResult.AppendText(Environment.NewLine);
                }

                //dartspel.printDetails2(clicked);

                
            }
            PlayerCount++;

            buttonShoot.Enabled = true;
 
        }

        private void buttonShoot_Click(object sender, EventArgs e)
        {
            textBoxResult.Text = dartspel.ToString();
            //dartspel.player_list[PlayerCount].ToString();  
        }

        private void textBoxPlayers_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            char[] radbrytning = new char[] { '\r', '\n' };
            string[] name_vektor = textBoxPlayers.Text.Split(radbrytning, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < name_vektor.Length; i++)
            { 
                dartspel.AddPlayer(name_vektor[i]);  
            }
            dartspel.Play_Game();
            buttonAim.Enabled = true;
            
        }

        private void textBoxAimResult_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
