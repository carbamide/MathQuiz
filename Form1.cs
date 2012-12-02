using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Math_Quiz
{
    public partial class Form1 : Form
    {
        Random randomizer = new Random();

        int addend1;
        int addend2;
        int minuend;
        int subtrahend;
        int multiplicand;
        int multiplier;
        int dividend;
        int divisor;
        int timeLeft;

        bool winningCondition;

        public Form1()
        {
            InitializeComponent();
        }

        public void StartTheQuiz()
        {
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();
            sum.Value = 0;

            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            difference.Value = 0;

            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            product.Value = 0;

            divisor = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            quotient.Value = 0;

            timeLeft = 30;

            timeLabel.Text = "30 seconds";
            timer1.Start();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (winningCondition)
            {
                sum.Value = 0;
                difference.Value = 0;
                product.Value = 0;
                quotient.Value = 0;

                sum.BackColor = Color.White;
                difference.BackColor = Color.White;
                product.BackColor = Color.White;
                quotient.BackColor = Color.White;

                startButton.Text = "Start the Quiz";

                timeLeft = 30;

                timeLabel.Text = null;

                winningCondition = false;
            }
            else
            {
                StartTheQuiz();

                startButton.Enabled = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                timer1.Stop();

                MessageBox.Show("You got all the answers right!", "Congratulations!");

                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                timeLeft--;

                timeLabel.Text = timeLeft + " seconds";
            }
            else
            {
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time!", "Sorry");
                sum.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                startButton.Enabled = true;
            }

            if (timeLeft < 5)
            {
                timeLabel.BackColor = Color.Red;
            }
        }

        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == sum.Value)
                && (minuend - subtrahend == difference.Value)
                && (multiplicand * multiplier == product.Value)
                && (dividend / divisor == quotient.Value))
            {
                winningCondition = true;

                startButton.Text = "Reset";

                return true;
            }
            else
            {
                return false;
            }
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }

        private void additionValueChanged(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;

            if (addend1 + addend2 == sum.Value)
            {
                Yep(answerBox);
            }
            else
            {
                Nope(answerBox);
            }
        }

        private void subtractionValueChanged(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;

            if (minuend - subtrahend == difference.Value)
            {
                Yep(answerBox);
            }
            else
            {
                Nope(answerBox);
            }
        }

        private void multiplicationValueChanged(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;

            if (multiplicand * multiplier == product.Value)
            {
                Yep(answerBox);
            }
            else
            {
                Nope(answerBox);
            }
        }

        private void dividingValueChanged(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;

            if (dividend / divisor == quotient.Value)
            {
                Yep(answerBox);
            }
            else
            {
                Nope(answerBox);
            }
        }

        private void Yep(NumericUpDown sender)
        {
            //System.Media.SystemSounds.Exclamation.Play();

            sender.BackColor = Color.Green;
        }

        private void Nope(NumericUpDown sender)
        {
            //System.Media.SystemSounds.Beep.Play();

            sender.BackColor = Color.Red;
        }
    }
}
