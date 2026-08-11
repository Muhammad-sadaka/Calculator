using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Calculator
{
    public partial class Form1 : Form
    {
        double FirstNumber =0,SecondNumber=0;
        string CurrentOperat = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tBMain.Text = "0";
            FirstNumber = 0;
            SecondNumber = 0;
            CurrentOperat = null;
        }

        void ButtonClick(Button button)
        {
            if (tBMain.Text == "0")
                tBMain.Text = button.Text;
            else
                tBMain.Text += button.Text;
        }

        private void btnNum_Click(object sender, EventArgs e)
        {
            ButtonClick((Button)sender);
        }

        private void btnOperation_Click(object sender, EventArgs e)
        {
            ButtonClickOperation((Button)sender);
        }

        void ButtonClickOperation(Button button)
        {
            ClickOperation(button.Text);
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            if (tBMain.Text != "0")
                tBMain.Text += "0";
        }

        private void btnPoint_Click(object sender, EventArgs e)
        {
             tBMain.Text += ".";
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (CurrentOperat != null || tBMain.Text != "0")
            {
                string s = tBMain.Text.Remove(0, tBMain.Text.IndexOf(CurrentOperat) + 1);
                if (s.Length > 0)
                {
                    SecondNumber = Convert.ToSingle(s);
                    tBMain.Text = DoOperation();
                    FirstNumber = Convert.ToSingle(tBMain.Text);
                    SecondNumber = 0;
                }
                else
                {
                    s = tBMain.Text;
                    tBMain.Text = tBMain.Text.Remove(s.Length - 1);
                }
                CurrentOperat = null;
            }
        }

        private void btnDarkLigth_Click(object sender, EventArgs e)
        {
            if (this.BackColor == Color.Black)
            {
                this.BackColor = Color.Silver;
                tBMain.BackColor = Color.White;
                btn0.BackColor = Color.White;
                btn1.BackColor = Color.White;
                btn2.BackColor = Color.White;
                btn3.BackColor = Color.White;
                btn4.BackColor = Color.White;
                btn5.BackColor = Color.White;
                btn6.BackColor = Color.White;
                btn7.BackColor = Color.White;
                btn8.BackColor = Color.White;
                btn9.BackColor = Color.White;

                btnPower.BackColor = Color.White;
                btnPercent.BackColor = Color.White;
                btnClear.BackColor = Color.White;
                btnDiv.BackColor = Color.White;
                btnMul.BackColor = Color.White;
                btnMin.BackColor = Color.White;
                btnAdd.BackColor = Color.White;
                btnEqual.BackColor = Color.White;
                btnPoint.BackColor = Color.White;
            }
            else
            {
                this.BackColor = Color.Black;
                tBMain.BackColor = Color.DarkGray;
                btn0.BackColor = Color.DarkGray;
                btn1.BackColor = Color.DarkGray;
                btn2.BackColor = Color.DarkGray;
                btn3.BackColor = Color.DarkGray;
                btn4.BackColor = Color.DarkGray;
                btn5.BackColor = Color.DarkGray;
                btn6.BackColor = Color.DarkGray;
                btn7.BackColor = Color.DarkGray;
                btn8.BackColor = Color.DarkGray;
                btn9.BackColor = Color.DarkGray;

                btnPower.BackColor = Color.DarkGray;
                btnPercent.BackColor = Color.DarkGray;
                btnClear.BackColor = Color.DarkGray;
                btnDiv.BackColor = Color.DarkGray;
                btnMul.BackColor = Color.DarkGray;
                btnMin.BackColor = Color.DarkGray;
                btnAdd.BackColor = Color.DarkGray;
                btnEqual.BackColor = Color.DarkGray;
                btnPoint.BackColor = Color.DarkGray;
            }
        }

        string DoOperation()
        {
            switch (CurrentOperat)
            {
                case "+":
                    return (FirstNumber + SecondNumber).ToString();
                case "/":
                    return (FirstNumber / SecondNumber).ToString();
                case "-":
                    return (FirstNumber - SecondNumber).ToString();
                case "*":
                    return (FirstNumber * SecondNumber).ToString();
                case "^":
                    return (Math.Pow(FirstNumber, SecondNumber)).ToString();
                case "%":
                    return (FirstNumber % SecondNumber).ToString();
                default:
                    MessageBox.Show("Error don't find the operation","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return null;
            }
        }

        void ClickOperation(string Operation)
        {
            //if (tBMain.Text == "-")
            //    return;
            if (tBMain.Text != "0")
            {
                if (CurrentOperat != null)
                {
                    string s = tBMain.Text;
                    if (CurrentOperat == Operation)
                    {
                        s = s.Remove(0, s.IndexOf(CurrentOperat) + 1);
                        if (s.Length > 0)
                        {
                            SecondNumber = Convert.ToSingle(s);    // if current operation - and the first number -n
                            tBMain.Text = DoOperation();
                            FirstNumber = Convert.ToSingle(tBMain.Text);
                            SecondNumber = 0;
                            tBMain.Text += Operation;
                        }
                    }
                    else
                    {
                        tBMain.Text = s.Remove(s.Length-1);
                        tBMain.Text += Operation;
                        CurrentOperat = Operation;
                    }
                   
                }
                else
                {
                    FirstNumber = Convert.ToSingle(tBMain.Text);
                    tBMain.Text += Operation;
                    CurrentOperat = Operation;
                }
            }
            //else if (Operation == "-")
            //    tBMain.Text = Operation;
        }

    }
}
