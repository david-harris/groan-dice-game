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
    // David Harris (3166241) and Philip Dujin (3163350)
    public partial class GroanFrm : Form
    {
        private bool bPlayer1Turn;
        private int iPlayer1RunningScore = 0;
        private int iPlayer2RunningScore = 0;
        private int iPlayer1CumulativeScore = 0;
        private int iPlayer2CumulativeScore = 0;
        private int iWinningPoints = 0;
        private RadioButton rPlayerVsPlayer;
        private RadioButton rPlayerVsComputer;


        // Creates a random number generator
        private Random rRoll = new Random();
       
        public GroanFrm()
        {
            InitializeComponent();  
        }

        public GroanFrm(int iWinPoints, RadioButton PlayerVPlayerRdoBtn, RadioButton PlayerVComputerRdoBtn)
        {
            InitializeComponent();
            iWinningPoints = iWinPoints;
            WinningScoreTxtbx.Text = "Score to win: " + Convert.ToString(iWinningPoints);
            rPlayerVsPlayer = PlayerVPlayerRdoBtn;
            rPlayerVsComputer = PlayerVComputerRdoBtn;
        }

        private void GroanFrm_Load(object sender, EventArgs e)
        {
            // Calls two functions which randomly choose which player/computer plays first
          Start();  
          CheckComputerTurn();
        }

        private void Start()
        {
            //Generates a random number between 1 and 2
            int iStart = rRoll.Next(1, 3);

            // decides on who places first
            if (iStart == 1)
            {
                bPlayer1Turn = true;
                MessageBox.Show("Player 1 Starts", "Startup");
            }

            else //(iStart == 2)
            {
                if (rPlayerVsPlayer.Checked)
                {
                    bPlayer1Turn = false;
                    MessageBox.Show("Player 2 Starts", "Startup");
                }

                else if (rPlayerVsComputer.Checked)
                {
                    bPlayer1Turn = false;
                    MessageBox.Show("Computer Starts", "Startup");
                }

            }

             

        }

        private void RollBtn_Click(object sender, EventArgs e)
        {     
            // Generates random numbers for each dice everytime the roll button is clicked
            int iRandomNumber1 = rRoll.Next(1, 7);
            int iRandomNumber2 = rRoll.Next(1, 7);

            //Displays the corressponding picture to the number rolled
            DicePictures(iRandomNumber1, iRandomNumber2);

            //Adds dice number rolled to running total and checks if any 1's where rolled
            DiceOneCheck(iRandomNumber1, iRandomNumber2);

            //Checks if the running total + Cumulative score is equal to the game score total 
            CheckWin(iPlayer1RunningScore, iPlayer2RunningScore, iPlayer1CumulativeScore, iPlayer2CumulativeScore);
            

            //Displays the numbers just rolled
            ActionsLbl.Text = Convert.ToString(iRandomNumber1) + " and " + Convert.ToString(iRandomNumber2) + " is rolled.";

            // Displays the numbers vertically in Rich text box
            DisplayVerticalNumbers();            
        }

        private void PassBtn_Click(object sender, EventArgs e)
        {

            // When the pass button is clicked the program will check whos go it was and add score to cumulative score, clear appropriate textboxes, and change to next player
            if (bPlayer1Turn)
            {        
                bPlayer1Turn = false;
                iPlayer1CumulativeScore = iPlayer1CumulativeScore + iPlayer1RunningScore;
                iPlayer1RunningScore = 0;
                Player1RunningTxtbx.Clear();
                MessageBox.Show("Player one passes", "Pass");
                CheckComputerTurn();
            }
            else                          
                {                    
                    bPlayer1Turn = true;
                    iPlayer2CumulativeScore = iPlayer2CumulativeScore + iPlayer2RunningScore;
                    iPlayer2RunningScore = 0;
                    Player2RunningTxtbx.Clear();
                    MessageBox.Show("Player two passes", "Pass");
                    CheckPlayer1Turn();
                }

               
            //Displays the cumulative score in rich text boxes
            Player1CumulativeTxtBx.Text = Convert.ToString(iPlayer1CumulativeScore);
            Player2CumulativeTxtBx.Text = Convert.ToString(iPlayer2CumulativeScore);
        }

        private void ComputerStrategy()
        {
            //This creates an computer to a player to play against. There is a number of different strategys which are choosen at random.

            //Generates a number to choose the strategy.
            int iRandomStrategy = rRoll.Next(1, 6);
            

            while (!bPlayer1Turn)
            {
                if (iRandomStrategy == 1)
                {
                    do
                    {
                        //Generates 2 random dice numbers
                        int iRandomNumber1 = rRoll.Next(1, 7);
                        int iRandomNumber2 = rRoll.Next(1, 7);


                        //Displays the numbers just rolled
                        ActionsLbl.Text = Convert.ToString(iRandomNumber1) + " and " + Convert.ToString(iRandomNumber2) + " is rolled.";

                        //Calls all the functions to check/add/display correctly
                        DisplayVerticalNumbers();
                        DicePictures(iRandomNumber1, iRandomNumber2);
                        DiceOneCheck(iRandomNumber1, iRandomNumber2);
                        CheckWin(iPlayer1RunningScore, iPlayer2RunningScore, iPlayer1CumulativeScore, iPlayer2CumulativeScore);

                        bPlayer1Turn = false;

                        //Delays the computer so player can see whats happening
                        Application.DoEvents();
                        System.Threading.Thread.Sleep(1250);

                    }
                    while (iPlayer2RunningScore >= 16);                
                    }


                else if (iRandomStrategy == 2)
                {
                    do
                    {
                        //Generates 2 random dice numbers
                        int iRandomNumber1 = rRoll.Next(1, 7);
                        int iRandomNumber2 = rRoll.Next(1, 7);                       

                        //Displays the numbers just rolled
                        ActionsLbl.Text = Convert.ToString(iRandomNumber1) + " and " + Convert.ToString(iRandomNumber2) + " is rolled.";

                        //Calls all the functions to check/add/display correctly
                        DisplayVerticalNumbers();
                        DicePictures(iRandomNumber1, iRandomNumber2);
                        DiceOneCheck(iRandomNumber1, iRandomNumber2);
                        CheckWin(iPlayer1RunningScore, iPlayer2RunningScore, iPlayer1CumulativeScore, iPlayer2CumulativeScore);

                        bPlayer1Turn = false;

                        //Delays the computer so player can see whats happening
                        Application.DoEvents();
                        System.Threading.Thread.Sleep(1250);
                    
                    }
                    while (iPlayer2RunningScore >= 9);             
                }


                else if (iRandomStrategy == 3)
                {
                    do
                    {
                        //Generates 2 random dice numbers
                        int iRandomNumber1 = rRoll.Next(1, 7);
                        int iRandomNumber2 = rRoll.Next(1, 7);
                        
                        //Displays the numbers just rolled
                        ActionsLbl.Text = Convert.ToString(iRandomNumber1) + " and " + Convert.ToString(iRandomNumber2) + " is rolled.";

                        //Calls all the functions to check/add/display correctly
                        DisplayVerticalNumbers(); 
                        DicePictures(iRandomNumber1, iRandomNumber2);
                        DiceOneCheck(iRandomNumber1, iRandomNumber2);
                        CheckWin(iPlayer1RunningScore, iPlayer2RunningScore, iPlayer1CumulativeScore, iPlayer2CumulativeScore);

                        bPlayer1Turn = false;

                        //Delays the computer so player can see whats happening
                        Application.DoEvents();
                        System.Threading.Thread.Sleep(1250);

                    }
                    while (iPlayer2RunningScore >= 10);                   
                }


                else if (iRandomStrategy == 4)
                {
                    do
                    {
                        //Generates 2 random dice numbers
                        int iRandomNumber1 = rRoll.Next(1, 7);
                        int iRandomNumber2 = rRoll.Next(1, 7);                        

                        //Displays the numbers just rolled
                        ActionsLbl.Text = Convert.ToString(iRandomNumber1) + " and " + Convert.ToString(iRandomNumber2) + " is rolled.";

                        //Calls all the functions to check/add/display correctly
                        DisplayVerticalNumbers() ;
                        DicePictures(iRandomNumber1, iRandomNumber2);
                        DiceOneCheck(iRandomNumber1, iRandomNumber2);
                        CheckWin(iPlayer1RunningScore, iPlayer2RunningScore, iPlayer1CumulativeScore, iPlayer2CumulativeScore);

                        bPlayer1Turn = false;

                        //Delays the computer so player can see whats happening
                        Application.DoEvents();
                        System.Threading.Thread.Sleep(1250);

                    }
                    while (iPlayer2RunningScore >= 25);                 
                }


                else
                {
                    do
                    {
                        //Generates 2 random dice numbers
                        int iRandomNumber1 = rRoll.Next(1, 7);
                        int iRandomNumber2 = rRoll.Next(1, 7);                        

                        //Displays the numbers just rolled
                        ActionsLbl.Text = Convert.ToString(iRandomNumber1) + " and " + Convert.ToString(iRandomNumber2) + " is rolled.";

                        //Calls all the functions to check/add/display correctly
                        DisplayVerticalNumbers();
                        DicePictures(iRandomNumber1, iRandomNumber2);
                        DiceOneCheck(iRandomNumber1, iRandomNumber2);
                        CheckWin(iPlayer1RunningScore, iPlayer2RunningScore, iPlayer1CumulativeScore, iPlayer2CumulativeScore);

                        bPlayer1Turn = false;

                        //Delays the computer so player can see whats happening
                        Application.DoEvents();
                        System.Threading.Thread.Sleep(1250);

                    }
                    while (iPlayer2RunningScore >= 7);                   
                }
                break;
            }
                       
            // adds running score to cumulative score
            if (iPlayer2RunningScore!=0)
            {
                AddtoCumulativeScore();
            }

            else 
            {
                bPlayer1Turn = true; 
            }
         }

        private void AddtoCumulativeScore()
        {
            //Adds running score to cumulative score, changes boolen values and displays message box
            bPlayer1Turn = true;
            iPlayer2CumulativeScore = iPlayer2CumulativeScore + iPlayer2RunningScore;
            iPlayer2RunningScore = 0;
            Player2RunningTxtbx.Clear();
            MessageBox.Show("Computer Passes", "Pass");
            Player2CumulativeTxtBx.Text = Convert.ToString(iPlayer2CumulativeScore);
            CheckPlayer1Turn();
        }

        private void DicePictures(int iRandomNumber1, int iRandomNumber2)
       // Checks to find the number rolled and displays the appropriate dice picture in the picture boxes
        {
            if (iRandomNumber1 == 1)
            {
                Dice1Picbx.Image = Properties.Resources.dice1;
            }

            else if (iRandomNumber1 == 2)
            {
                Dice1Picbx.Image = Properties.Resources.dice2;
            }

            else if (iRandomNumber1 == 3)
            {
                Dice1Picbx.Image = Properties.Resources.dice3;
            }

            else if (iRandomNumber1 == 4)
            {
                Dice1Picbx.Image = Properties.Resources.dice4;
            }

            else if (iRandomNumber1 == 5)
            {
                Dice1Picbx.Image = Properties.Resources.dice5;
            }

            else
            {
                Dice1Picbx.Image = Properties.Resources.dice6;
            }

            if (iRandomNumber2 == 1)
            {
                Dice2Picbx.Image = Properties.Resources.dice1;
            }

            else if (iRandomNumber2 == 2)
            {
                Dice2Picbx.Image = Properties.Resources.dice2;
            }

            else if (iRandomNumber2 == 3)
            {
                Dice2Picbx.Image = Properties.Resources.dice3;
            }

            else if (iRandomNumber2 == 4)
            {
                Dice2Picbx.Image = Properties.Resources.dice4;
            }

            else if (iRandomNumber2 == 5)
            {
                Dice2Picbx.Image = Properties.Resources.dice5;
            }

            else
            {
                Dice2Picbx.Image = Properties.Resources.dice6;
            }
        }

        private void DisplayVerticalNumbers()
            // Displays the numbers verticaly and clears running score
        {
            if (bPlayer1Turn)
            {
                Player2RunningTxtbx.Clear();
                Player1RunningTxtbx.Text = Convert.ToString(iPlayer1RunningScore) + "\n" + Player1RunningTxtbx.Text;
            }
            else
            {
                Player1RunningTxtbx.Clear();
                Player2RunningTxtbx.Text = Convert.ToString(iPlayer2RunningScore)  + "\n" + Player2RunningTxtbx.Text;   
            }
        }

        private void DiceOneCheck(int iRandomNumber1, int iRandomNumber2)
        {

            // adds dice number rolled to running total
            if (bPlayer1Turn)
            {
                iPlayer1RunningScore = iPlayer1RunningScore + iRandomNumber1 + iRandomNumber2;
              
            }
            else
            {
                iPlayer2RunningScore = iPlayer2RunningScore + iRandomNumber1 + iRandomNumber2;
               
            }

           
            // Tests for roll for one if true running score = 0, also tests to see what radio buttons where checked to display the correct message
            if (iRandomNumber1 == 1 || iRandomNumber2 == 1)
            {
                if (bPlayer1Turn)
                {
                    if (rPlayerVsPlayer.Checked)
                    {

                        if ((iRandomNumber1 == 1 && iRandomNumber2 == 1))
                        {
                            iPlayer1RunningScore = 0;
                            iPlayer1CumulativeScore = 0;
                            Player1RunningTxtbx.Clear();
                            Player1CumulativeTxtBx.Clear();
                            bPlayer1Turn = false;
                            MessageBox.Show("Player two's turn, Player one starts again", "Turn");
                            CheckComputerTurn();
                        }
                        else if ((iRandomNumber1 == 1 || iRandomNumber2 == 1))
                        {
                            iPlayer1RunningScore = 0;
                            Player1RunningTxtbx.Clear();
                            bPlayer1Turn = false;
                            MessageBox.Show("Player two's turn, Player one loses running score", "Turn");
                            CheckComputerTurn();
                        }
                    }

                    else if (rPlayerVsComputer.Checked)
                    {
                        if ((iRandomNumber1 == 1 && iRandomNumber2 == 1))
                        {
                            iPlayer1RunningScore = 0;
                            iPlayer1CumulativeScore = 0;
                            Player1RunningTxtbx.Clear();
                            Player1CumulativeTxtBx.Clear();
                            bPlayer1Turn = false;
                            CheckComputerTurn();

                            MessageBox.Show("Computer's turn, Player one starts again", "Turn");
                        }
                        else if ((iRandomNumber1 == 1 || iRandomNumber2 == 1))
                        {
                            iPlayer1RunningScore = 0;
                            Player1RunningTxtbx.Clear();
                            bPlayer1Turn = false;
                            MessageBox.Show("Computer's turn, Player one loses running score", "Turn");
                            CheckComputerTurn();
                        }
                    }
                }

                else
                {
                    if (rPlayerVsPlayer.Checked)
                    {
                        if ((iRandomNumber1 == 1 && iRandomNumber2 == 1))
                        {
                            iPlayer2RunningScore = 0;
                            iPlayer2CumulativeScore = 0;
                            Player2RunningTxtbx.Clear();
                            Player2CumulativeTxtBx.Clear();
                            bPlayer1Turn = true;
                            MessageBox.Show("Player one's turn, Player two starts again", "Turn");
                            CheckPlayer1Turn();
                        }
                        else if ((iRandomNumber1 == 1 || iRandomNumber2 == 1))
                        {
                            iPlayer2RunningScore = 0;
                            Player1RunningTxtbx.Clear();
                            bPlayer1Turn = true;
                            MessageBox.Show("Player one's turn, Player two loses running score ", "Turn");
                            CheckPlayer1Turn();
                        }
                    }

                    else if (rPlayerVsComputer.Checked)
                    {
                        if ((iRandomNumber1 == 1 && iRandomNumber2 == 1))
                        {
                            iPlayer2RunningScore = 0;
                            iPlayer2CumulativeScore = 0;
                            Player2RunningTxtbx.Clear();
                            Player2CumulativeTxtBx.Clear();
                            bPlayer1Turn = true;
                            MessageBox.Show("Player one's turn, Computer starts again", "Turn");
                            CheckPlayer1Turn();
                        }
                        else if ((iRandomNumber1 == 1 || iRandomNumber2 == 1))
                        {
                            iPlayer2RunningScore = 0;
                            Player2RunningTxtbx.Clear();
                            bPlayer1Turn = true;
                            MessageBox.Show("Player one's turn, Computer loses running score ", "Turn");
                            CheckPlayer1Turn();
                        }
                    }
                }
            }
        }

        private void CheckPlayer1Turn()
            //Enables buttons after computers turn
        {
            if (bPlayer1Turn)
            {
                PassBtn.Enabled = true;
                RollBtn.Enabled = true;
            }
        }

        private void CheckComputerTurn()
            //disables buttons while computers turn and calls the strategy
        {
            if (rPlayerVsComputer.Checked)
            {
                if (bPlayer1Turn == false)
                {
                    PassBtn.Enabled = false;
                    RollBtn.Enabled = false;

                    ComputerStrategy();
                }

            }


        }

        private void CheckWin(int iPlayer1RunningScore, int iPlayer2RunningScore, int iPlayer1CumulativeScore, int iPlayer2CumulativeScore)
            // Checks who one and displays the correct message, also exits the game.
        {
            if (bPlayer1Turn)
            {
                if (iPlayer1RunningScore + iPlayer1CumulativeScore >= iWinningPoints)
                {
                    MessageBox.Show("Player 1 Wins!", "End of game!");
                    Application.Exit(); 

                }
            }

            else
            {
                if (rPlayerVsPlayer.Checked)
                {
                    if (iPlayer2RunningScore + iPlayer2CumulativeScore >= iWinningPoints)
                    {
                        MessageBox.Show("Player 2 Wins!", "End of game!");
                        Application.Exit();
                    }
                }

                else if (rPlayerVsComputer.Checked)
                {
                    if (iPlayer2RunningScore + iPlayer2CumulativeScore >= iWinningPoints)
                    {
                        MessageBox.Show("Computer Wins!", "End of game!");
                        Application.Exit();
                    }
                }

            }
        }
    }
    }


