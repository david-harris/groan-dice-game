using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PhilipDujinAssgt
{

    public partial class HomeFrm : Form

    {

        public HomeFrm()
        {
            InitializeComponent();          
        }

        private void PlayBtn_Click(object sender, EventArgs e)
        {
            int iTest;
            //This closes the mainscreen and starts the game in centred position      
            try
            {
                iTest = Convert.ToInt32(ScoreTxtbx.Text);
                GroanFrm Groanfrm = new GroanFrm(Convert.ToInt32(ScoreTxtbx.Text), PlayerVPlayerRdoBtn, PlayerVComputerRdoBtn);
                Groanfrm.StartPosition = FormStartPosition.CenterScreen;
                Groanfrm.Show();
                this.Hide();
            }
            catch (FormatException executionObject)
            {
                MessageBox.Show("Please enter a valid number", "Error");
            }

                
                
        }
        
        private void InstructionsBtn_Click(object sender, EventArgs e)
        {
            // Displays the instuctions once the Instructions button is clicked
            InstructionsTxtbx.Visible = true;
            InstructionsTxtbx.Text = "There are two players, each of whom is trying to reach an agreed total with a pair of dice. Each player has a ‘cumulative score’, and there is a single ‘running score’ which is used in turn by whichever player is currently active. The active player rolls the dice as many times as (s)he likes, and the numbers that show on them are added to the running score. The alternative to rolling the dice is to pass them to the opponent; when a player does this, the running score is added to the player’s cumulative score. If either of the dice rolls a one, the running score is lost, and the dice automatically pass to the opponent. If you throw a double one (also known as ‘snake’s eyes’), you lose not only the running score but also your cumulative score. The first player to reach the total wins.";
        
        }   
 
      
        

        
    }
}
