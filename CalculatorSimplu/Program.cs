using System;
using System.Drawing;
using System.Windows.Forms;

namespace CalculatorSimplu
{
    public class CalculatorForm : Form
    {
        // Declarații pentru controale
        private TextBox txtDisplay;
        private Button btn7, btn8, btn9, btnDiv;
        private Button btn4, btn5, btn6, btnMul;
        private Button btn1, btn2, btn3, btnSub;
        private Button btn0, btnClear, btnEqual, btnAdd;

        // Variabile pentru stocarea rezultatului și a operației
        private double result = 0;
        private string operation = "";
        private bool isOperationPerformed = false;

        public CalculatorForm()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            // Setări pentru formular
            this.Text = "Calculator Simplu";
            this.Size = new Size(320, 320);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Creare TextBox pentru afișaj
            txtDisplay = new TextBox();
            txtDisplay.ReadOnly = true;
            txtDisplay.TextAlign = HorizontalAlignment.Right;
            txtDisplay.Font = new Font("Arial", 16);
            txtDisplay.Location = new Point(10, 10);
            txtDisplay.Size = new Size(280, 30);
            txtDisplay.Text = "0";
            this.Controls.Add(txtDisplay);

            // Dimensiunile și pozițiile butoanelor
            int buttonWidth = 60;
            int buttonHeight = 40;
            int padding = 10;
            int startX = 10;
            int startY = 50;

            // Randul 1: 7, 8, 9, /
            btn7 = CreateButton("7", new Point(startX, startY));
            btn8 = CreateButton("8", new Point(startX + (buttonWidth + padding), startY));
            btn9 = CreateButton("9", new Point(startX + 2 * (buttonWidth + padding), startY));
            btnDiv = CreateButton("/", new Point(startX + 3 * (buttonWidth + padding), startY));

            // Randul 2: 4, 5, 6, *
            btn4 = CreateButton("4", new Point(startX, startY + (buttonHeight + padding)));
            btn5 = CreateButton("5", new Point(startX + (buttonWidth + padding), startY + (buttonHeight + padding)));
            btn6 = CreateButton("6", new Point(startX + 2 * (buttonWidth + padding), startY + (buttonHeight + padding)));
            btnMul = CreateButton("*", new Point(startX + 3 * (buttonWidth + padding), startY + (buttonHeight + padding)));

            // Randul 3: 1, 2, 3, -
            btn1 = CreateButton("1", new Point(startX, startY + 2 * (buttonHeight + padding)));
            btn2 = CreateButton("2", new Point(startX + (buttonWidth + padding), startY + 2 * (buttonHeight + padding)));
            btn3 = CreateButton("3", new Point(startX + 2 * (buttonWidth + padding), startY + 2 * (buttonHeight + padding)));
            btnSub = CreateButton("-", new Point(startX + 3 * (buttonWidth + padding), startY + 2 * (buttonHeight + padding)));

            // Randul 4: 0, C, =, +
            btn0 = CreateButton("0", new Point(startX, startY + 3 * (buttonHeight + padding)));
            btnClear = CreateButton("C", new Point(startX + (buttonWidth + padding), startY + 3 * (buttonHeight + padding)));
            btnEqual = CreateButton("=", new Point(startX + 2 * (buttonWidth + padding), startY + 3 * (buttonHeight + padding)));
            btnAdd = CreateButton("+", new Point(startX + 3 * (buttonWidth + padding), startY + 3 * (buttonHeight + padding)));

            // Asociere evenimente
            // Butoane pentru cifre
            btn0.Click += DigitButton_Click;
            btn1.Click += DigitButton_Click;
            btn2.Click += DigitButton_Click;
            btn3.Click += DigitButton_Click;
            btn4.Click += DigitButton_Click;
            btn5.Click += DigitButton_Click;
            btn6.Click += DigitButton_Click;
            btn7.Click += DigitButton_Click;
            btn8.Click += DigitButton_Click;
            btn9.Click += DigitButton_Click;

            // Butoane pentru operații
            btnAdd.Click += OperatorButton_Click;
            btnSub.Click += OperatorButton_Click;
            btnMul.Click += OperatorButton_Click;
            btnDiv.Click += OperatorButton_Click;

            // Butonul egal
            btnEqual.Click += EqualButton_Click;

            // Butonul clear
            btnClear.Click += ClearButton_Click;
        }

        // Metodă auxiliară pentru creare butoane
        private Button CreateButton(string text, Point location)
        {
            Button btn = new Button();
            btn.Text = text;
            btn.Font = new Font("Arial", 14);
            btn.Size = new Size(60, 40);
            btn.Location = location;
            this.Controls.Add(btn);
            return btn;
        }

        // Eveniment pentru butoanele cu cifre
        private void DigitButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (txtDisplay.Text == "0" || isOperationPerformed)
            {
                txtDisplay.Text = btn.Text;
                isOperationPerformed = false;
            }
            else
            {
                txtDisplay.Text += btn.Text;
            }
        }

        // Eveniment pentru butoanele de operații
        private void OperatorButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            result = double.Parse(txtDisplay.Text);
            operation = btn.Text;
            isOperationPerformed = true;
        }

        // Eveniment pentru butonul egal
        private void EqualButton_Click(object sender, EventArgs e)
        {
            double secondOperand = double.Parse(txtDisplay.Text);
            double calculationResult = 0;

            switch (operation)
            {
                case "+":
                    calculationResult = result + secondOperand;
                    break;
                case "-":
                    calculationResult = result - secondOperand;
                    break;
                case "*":
                    calculationResult = result * secondOperand;
                    break;
                case "/":
                    if (secondOperand != 0)
                        calculationResult = result / secondOperand;
                    else
                    {
                        MessageBox.Show("Împărțirea la zero nu este permisă!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        calculationResult = 0;
                    }
                    break;
                default:
                    break;
            }
            txtDisplay.Text = calculationResult.ToString();
        }

        // Eveniment pentru butonul clear
        private void ClearButton_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
            result = 0;
            operation = "";
        }
    }

    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CalculatorForm());
        }
    }
}
