using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace _5dart
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Game dartspel = new Game();

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBoxResult_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonAim_Click(object sender, EventArgs e)    //2) Writes information that the game is on going
        {
            textBoxAimResult.Text = "The players throw 3 darts per turn. The game is over when at least one player reach total score 301+.";
            buttonShoot.Enabled = true;
        }

        private void buttonShoot_Click(object sender, EventArgs e)  //3) Total Shoot result is shown in textBoxResult
        {
            textBoxResult.Text = dartspel.ToString();
            buttonPrint.Enabled = true;
        }

        private void textBoxPlayers_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonStart_Click(object sender, EventArgs e)  //1) Read player names, put each name in a vektor and add players
        {                                                           // and starts game
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

        private void buttonPrint_Click(object sender, EventArgs e)  //4) Prints result to textfile and give this information in texBox
        {
            dartspel.ToFile();
            textBoxPrint.Text = "Results are now printed to textfil";
        }

        private void textBoxPrint_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
