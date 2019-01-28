using System;
using System.Linq;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
        }

        // Properties to keep track of user input and the state of the application.
        public double TermOne { get; set; }
        public double TermTwo { get; set; }
        public double PreviousTermTwo { get; set; }
        public double Answer { get; set; }
        public double PreviousAnswer { get; set; }
        public bool PreviousCalulations { get; set; }
        public char OperatorType { get; set; }
        public bool OperatorTypeChosen { get; set; }
        public bool LastInputWasOperator { get; set; }

        // Calculator_KeyPress: Checks for user input through KeyPresses and performs
        // the corresponding Click-event for the appropriate button.
        // Pre: -
        // Post: The KeyPress-event has been handled and, if there's a match, the appropriate
        // buttons Click-event has been fired.
        private void Calculator_KeyPress(object sender, KeyPressEventArgs e)
        {                
            switch(e.KeyChar)
            {
                case '1': oneButton.PerformClick(); break;
                case '2': twoButton.PerformClick(); break;
                case '3': threeButton.PerformClick(); break;
                case '4': fourButton.PerformClick(); break;
                case '5': fiveButton.PerformClick(); break;
                case '6': sixButton.PerformClick(); break;
                case '7': sevenButton.PerformClick(); break;
                case '8': eightButton.PerformClick(); break;
                case '9': nineButton.PerformClick(); break;
                case '0': zeroButton.PerformClick(); break;
                case '/': divideButton.PerformClick(); break;
                case '*': multiplyButton.PerformClick(); break;
                case '-': subtractButton.PerformClick(); break;
                case '+': addButton.PerformClick(); break;
                case ',': commaButton.PerformClick(); break;
                case 'C': clearButton.PerformClick(); break;
                case 'c': clearButton.PerformClick(); break;
            }
            e.Handled = true;
        }

        // EqualsButton_Click: Checks for the state of the users input and if it's in a valid state, performs an equation,
        // saves the input for later use if desired and prints the result to the form.
        // Pre: -
        // Post: The result of the equation is shown in the TextBox inputTextBox. The numbers and numeric operator used in 
        // the equation is shown in the TextBox previousInputTextBox and saved to be reused if the user continues to press the
        // Equals-button without making any other alterations to their input. In case of either a division by zero or an equation
        // leading to the number being represented by ∞, a warning is shown and the calculator is reset.
        private void EqualsButton_Click(object sender, EventArgs e)
        {
            if (LastInputWasOperator || inputTextBox.Text.Last() == ',' || (!OperatorTypeChosen && !PreviousCalulations))
                return;

            if (OperatorTypeChosen)
            {
                TermTwo = Convert.ToDouble(inputTextBox.Text.Split(OperatorType).Last());
                PreviousTermTwo = TermTwo;
                previousInputTextBox.Text = inputTextBox.Text;
            }
            else if (!OperatorTypeChosen && PreviousCalulations)
            {
                TermOne = Answer;
                TermTwo = PreviousTermTwo;
                previousInputTextBox.Text = PreviousAnswer.ToString() + OperatorType + PreviousTermTwo;
            }

            CalculateEquation();
            if (DivisionByZero() || AnswerIsInfinity())
                return;

            inputTextBox.Text = Answer.ToString();
            OperatorTypeChosen = false;
            PreviousAnswer = Answer;
            PreviousCalulations = true;
        }

        // CalculateEquation: Performs the desired calculation.
        // Pre: OperatorType is either /, *, - or +. 
        // Post: The answer of the equation has been saved to the Answer property.
        private void CalculateEquation()
        {
            switch (OperatorType)
            {
                case '*': Answer = TermOne * TermTwo; break;
                case '/': Answer = TermOne / TermTwo; break;
                case '-': Answer = TermOne - TermTwo; break;
                case '+': Answer = TermOne + TermTwo; break;
            }
        }

        // DivisionByZero: Determines if the user attempted a division by zero.
        // Pre: -
        // Post: If the user attempted a division by zero, a warning is shown and the calculator is reset.
        private bool DivisionByZero()
        {
            if (TermTwo == 0 && OperatorType == '/')
            {
                clearButton.PerformClick();
                MessageBox.Show("Division med noll kan ej genomföras. Miniräknaren nollställs.");
                return true;
            }
            return false;
        }

        // AnswerIsInfinity: Determines if the equation resulted in an answer being represented by ∞.
        // Pre: -
        // Post: If the result is represented by ∞, a warning is shown and the calculator is reset.
        private bool AnswerIsInfinity()
        {
            if (double.IsInfinity(Answer))
            {
                clearButton.PerformClick();
                MessageBox.Show("Uträkningen resulterade i att svaret endast kan representeras som oändligt. Miniräknaren nollställs.");
                return true;
            }
            return false;
        }

        // NumberButton_Click: Checks for the state of the users input and attempts to add the users chosen value to the input field.
        // Pre: -
        // Post: Unless the user has performed a previous calculation but has yet to choose a type of operator, the chosen
        // buttons value is added to the TextBox inputTextBox.
        private void NumberButton_Click(object sender, EventArgs e)
        {
            if (PreviousCalulations && !OperatorTypeChosen)
                return;

            Button button = sender as Button;
            if (inputTextBox.Text == "0")
                inputTextBox.Text = button.Text;
            else
                inputTextBox.Text += button.Text;

            LastInputWasOperator = false;
        }

        // NumberButton_Click: Checks for the state of the users input and attempts to add a comma to the input field.
        // Pre: -
        // Post: Unless the user has performed a previous calculation but has yet to choose a type of operator, a comma
        // is added to the TextBox inputTextBox. Each number, both before and after the numeric operator, will only contain
        // a single comma.
        private void CommaButton_Click(object sender, EventArgs e)
        {
            if (PreviousCalulations && !OperatorTypeChosen)
                return;

            if (!OperatorTypeChosen && !inputTextBox.Text.Contains(","))
                inputTextBox.Text += ",";
            else if (OperatorTypeChosen && !inputTextBox.Text.Split(OperatorType).Last().Contains(","))
                inputTextBox.Text += ",";

            LastInputWasOperator = false;
        }

        // OperatorButton_Click: Allows the user to select the numeric operator for their desired equation. Only one choice
        // can ever be active at a time.
        // Pre: -
        // Post: If no operator has been chosen prior, it's now saved in the OperatorType property, along with TermOne property
        // being selected from the users prior input. The OperatorType may be changed if this was the last input made by the user.
        // The chosen operator is shown in the TextBox inputTextBox.
        private void OperatorButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (LastInputWasOperator)
            {
                OperatorType = Convert.ToChar(button.Text);
                inputTextBox.Text = inputTextBox.Text.Substring(0, inputTextBox.Text.Length - 1) + OperatorType;
            }
            else if (!OperatorTypeChosen)
            {
                OperatorType = Convert.ToChar(button.Text);
                TermOne = Convert.ToDouble(inputTextBox.Text);
                inputTextBox.Text += OperatorType;
                OperatorTypeChosen = true;
                LastInputWasOperator = true;
            }
        }

        // ClearButton_Click: Resets the calculator.
        // Pre: -
        // Post: TextBoxes and all properties representing the state of the application has been reset to their default values.
        private void ClearButton_Click(object sender, EventArgs e)
        {
            inputTextBox.Text = "0";
            previousInputTextBox.Text = "";
            TermOne = 0;
            TermTwo = 0;
            PreviousTermTwo = 0;
            Answer = 0;
            PreviousAnswer = 0;
            PreviousCalulations = false;
            OperatorType = '.';
            OperatorTypeChosen = false;
            LastInputWasOperator = false;
        }
    }
}