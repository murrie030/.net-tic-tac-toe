using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToe_Library;

namespace TicTacToe_Gui
{
    public partial class Form1 : Form
    {
        // Make an object of the TicTacToeEngine
        public TicTacToeEnginge engine;
        public Form1(TicTacToeEnginge engine)
        {
            this.engine = engine;
            InitializeComponent();
        }

        /* Initialise every button with the methods in the library
         * First choose the cell, then set the text of the player O or player X
         * Finally, update the text on the board
         */
        private void button1_Click(object sender, EventArgs e)
        {
            engine.ChooseCell(1);
            this.button1.Text = engine.cellNumbers1[0];
            SetResult(engine.Status);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            engine.ChooseCell(2);
            this.button2.Text = engine.cellNumbers1[1];
            SetResult(engine.Status);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            engine.ChooseCell(3);
            this.button3.Text = engine.cellNumbers1[2];
            SetResult(engine.Status);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            engine.ChooseCell(4);
            this.button4.Text = engine.cellNumbers1[3];
            SetResult(engine.Status);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            engine.ChooseCell(5);
            this.button5.Text = engine.cellNumbers1[4];
            SetResult(engine.Status);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            engine.ChooseCell(6);
            this.button6.Text = engine.cellNumbers1[5];
            SetResult(engine.Status);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            engine.ChooseCell(7);
            this.button7.Text = engine.cellNumbers1[6];
            SetResult(engine.Status);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            engine.ChooseCell(8);
            this.button8.Text = engine.cellNumbers1[7];
            SetResult(engine.Status);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            engine.ChooseCell(9);
            this.button9.Text = engine.cellNumbers1[8];
            SetResult(engine.Status);
        }
        private void resetButton_Click(object sender, EventArgs e)
        {
            engine.Reset();
            this.button1.Text = "";
            this.button2.Text = "";
            this.button3.Text = "";
            this.button4.Text = "";
            this.button5.Text = "";
            this.button6.Text = "";
            this.button7.Text = "";
            this.button8.Text = "";
            this.button9.Text = "";
            this.label2.Text = "Player O begin!";
        }

        /* This method sets the text of the results to the label
         */
        private void SetResult(TicTacToeEnginge.GameStatus status)
        {
            if (status == TicTacToeEnginge.GameStatus.PlayerOPlays)
            {
                this.label2.Text = "Player O, it's your turn!";
            } 
            else
            {
                this.label2.Text = "Player X, it's your turn!";
            }
            
            if (status == TicTacToeEnginge.GameStatus.PlayerOWins)
            {
                this.label2.Text = "Congratulations, player O won!";
                System.Windows.Forms.MessageBox.Show("Congratulations, player O won!");
            }
            else if (status == TicTacToeEnginge.GameStatus.PlayerXWins)
            {
                this.label2.Text = "Congratulations, player X won!";
                System.Windows.Forms.MessageBox.Show("Congratulations, player X won!");
            }
            else if (status == TicTacToeEnginge.GameStatus.Equal)
            {
                this.label2.Text = "Tie!";
                System.Windows.Forms.MessageBox.Show("Tie!");
            }
        }
    }
}
