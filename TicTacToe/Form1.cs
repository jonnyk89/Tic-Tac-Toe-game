using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Media;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        bool turn = true; // true = X turn; false = Y turn
        int turn_count = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("TicTacToe game by Kokoshinka", "About");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // once a button is clicked from the X-O buttons
        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
            {
                b.Text = "X";
            }
            else
            {
                b.Text = "O";
            }
            turn = !turn;
            b.Enabled = false;
            turn_count++;

            PlayClickSound();
            checkForWinner();
        }

        // checks if there is a winner
        private void checkForWinner()
        {
            bool there_is_a_winner = false;

            // horizontal checks
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
            {
                there_is_a_winner = true;
            }
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
            {
                there_is_a_winner = true;
            }
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
            {
                there_is_a_winner = true;
            }

            // vertical checks
            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
            {
                there_is_a_winner = true;
            }
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
            {
                there_is_a_winner = true;
            }
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
            {
                there_is_a_winner = true;
            }

            // diagonal checks
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
            {
                there_is_a_winner = true;
            }
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!C1.Enabled))
            {
                there_is_a_winner = true;
            }

            if (there_is_a_winner)
            {
                disableButtons();

                string winner = "";
                if (turn)
                {
                    winner = "O";
                }
                else
                {
                    winner = "X";
                }
                PlayCheerSound();
                MessageBox.Show(winner + " wins!", "Victory!");
            }
            else    //draw
            {
                if (turn_count == 9)
                {
                    PlayDisappointSound();
                    MessageBox.Show("Draw!", "Stalemate!");
                }
            }
        }

        // disable buttons when there is a winner and when a button is clicked
        private void disableButtons()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }
            catch (Exception)
            {
            }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turn_count = 0;

            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }
            }
            catch (Exception)
            {
            }
        }

        // Sound
        public static void PlayClickSound()
        {
            string soundPath = Directory.GetCurrentDirectory() + "\\Sounds" + "\\click.wav";

            SoundPlayer victorySound = new SoundPlayer(soundPath);
            victorySound.Play();
        }

        public static void PlayCheerSound()
        {
            string soundPath = Directory.GetCurrentDirectory() + "\\Sounds" + "\\cheer.wav";

            SoundPlayer victorySound = new SoundPlayer(soundPath);
            victorySound.Play();
        }

        public static void PlayDisappointSound()
        {
            string soundPath = Directory.GetCurrentDirectory() + "\\Sounds" + "\\disappointment.wav";

            SoundPlayer victorySound = new SoundPlayer(soundPath);
            victorySound.Play();
        }

    }
}
