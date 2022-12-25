using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        int pipeSpeed = 8;
        int gravity = 15;
        int score = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappyBird.Top += gravity;
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            Scoretext.Text = "Score: " + score;

            if (pipeBottom.Right < 0)
            {
                pipeBottom.Left = 800;
                score++;
            }
            if (pipeTop.Right < 0)
            {
                pipeTop.Left = 950;
                score++;
            }
            if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) || 
                flappyBird.Bounds.IntersectsWith(pipeTop.Bounds)||
                flappyBird.Bounds.IntersectsWith(ground.Bounds) ||
                flappyBird.Top < -25
                )
            {
                endgame();

            }

            if (score == 5)
            {
                pipeSpeed= 10;
            }
            if (score == 10)
            {
                pipeSpeed = 15;
            }



        }

        private void gameKeyisDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -15;
                
            }


        }

        private void gameKeyisUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 15;
            }

        }

        private void endgame()
        {
            gameTimer.Stop();
            Scoretext.Text += " Game Over!!!";
          
        }

    }
}
