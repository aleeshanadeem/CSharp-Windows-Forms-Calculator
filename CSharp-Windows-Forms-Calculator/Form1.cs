using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharp_Windows_Forms_Calculator
{
    public partial class Form1 : Form
    {
        // Calculator ki memory ke liye variables
        Double resultValue = 0;
        String operationPerformed = "";
        bool isOperationPerformed = false;

        public Form1()
        {
            InitializeComponent();
        }

        // 1. Form Load Event
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "0"; // Shuru mein display par 0
        }

        // 2. Number Buttons (0-9) aur Decimal (.) ka code
        private void button_Number_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "0") || (isOperationPerformed))
                textBox1.Clear();

            isOperationPerformed = false;
            Button button = (Button)sender;

            if (button.Text == ".")
            {
                if (!textBox1.Text.Contains("."))
                {
                    textBox1.Text = textBox1.Text + button.Text;
                }
            }
            else
            {
                textBox1.Text = textBox1.Text + button.Text;
            }
        }

        // 3. Operator Buttons (+ - * / %) ka code
        private void button_Operator_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (textBox1.Text != "")
            {
                resultValue = Double.Parse(textBox1.Text);
                operationPerformed = button.Text;
                isOperationPerformed = true;
            }
        }

        // 4. Equal Button (=) ka code
        private void button_Equal_Click(object sender, EventArgs e)
        {
            Double secondNum;
            if (Double.TryParse(textBox1.Text, out secondNum))
            {
                switch (operationPerformed)
                {
                    case "+":
                        textBox1.Text = (resultValue + secondNum).ToString();
                        break;
                    case "-":
                        textBox1.Text = (resultValue - secondNum).ToString();
                        break;
                    case "*":
                        textBox1.Text = (resultValue * secondNum).ToString();
                        break;
                    case "/":
                        if (secondNum == 0)
                            textBox1.Text = "Error"; // 0 se divide nahi hota
                        else
                            textBox1.Text = (resultValue / secondNum).ToString();
                        break;
                    case "%":
                        textBox1.Text = (resultValue % secondNum).ToString();
                        break;
                }
                resultValue = Double.Parse(textBox1.Text);
                operationPerformed = "";
            }
        }

        // 5. AC (Clear) Button ka code
        private void button_AC_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            resultValue = 0;
            operationPerformed = "";
        }

        // 6. Backspace (X) Button ka code
        private void button_Backspace_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
            }
            if (textBox1.Text == "")
            {
                textBox1.Text = "0";
            }
        }

        // Jo purane events aapke paas thay, unhe khali chhor dein (error se bachne ke liye)
        private void textBox2_TextChanged(object sender, EventArgs e) { }
    }
}