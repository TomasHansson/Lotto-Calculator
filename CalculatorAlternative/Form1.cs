using System;
using System.Windows.Forms;

namespace CalculatorAlternative
{
    public partial class Calculator : Form
    {
        // Properties to keep track of user input and the state of the application.
        public double Result { get; set; }
        public double Input { get; set; }
        public string Operator { get; set; }
        public bool LastClickWasOperator { get; set; }
        public bool LastClickWasEquals { get; set; }

        public Calculator()
        {
            InitializeComponent();
        }

        // Calculator_KeyPress: Checks for user input through KeyPresses and performs
        // the corresponding Click-event for the appropriate button.
        // Pre: -
        // Post: The KeyPress-event has been handled and, if there's a match, the appropriate
        // buttons Click-event has been fired.
        private void Calculator_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '1': OneButton.PerformClick(); break;
                case '2': TwoButton.PerformClick(); break;
                case '3': ThreeButton.PerformClick(); break;
                case '4': FourButton.PerformClick(); break;
                case '5': FiveButton.PerformClick(); break;
                case '6': SixButton.PerformClick(); break;
                case '7': SevenButton.PerformClick(); break;
                case '8': EightButton.PerformClick(); break;
                case '9': NineButton.PerformClick(); break;
                case '0': ZeroButton.PerformClick(); break;
                case '/': DivideButton.PerformClick(); break;
                case '*': MultiplyButton.PerformClick(); break;
                case '-': SubtractButton.PerformClick(); break;
                case '+': AddButton.PerformClick(); break;
                case ',': CommaButton.PerformClick(); break;
                case 'C': ClearButton.PerformClick(); break;
                case 'c': ClearButton.PerformClick(); break;
            }
            e.Handled = true;
        }

        // NumberButton_Click: Checks for the state of the users input and attempts to add the users chosen value to the input field.
        // Pre: -
        // Post: If the input field only contained a zero (default value) or the last click was either an operator or equals, the input field has been replaced by the
        // clicked number. Otherwice, the clicked number has been added to the previously inserted value.
        private void NumberButton_Clicked(object sender, EventArgs e)
        {
            if (ResultTextBox.Text == "0" || LastClickWasOperator || LastClickWasEquals)
                ResultTextBox.Text = (sender as Button).Text;
            else 
                ResultTextBox.Text += (sender as Button).Text;
            LastClickWasOperator = false;
            LastClickWasEquals = false;
        }


        // OperatorButton_Clicked: Allows the player to choose the type of numeric operator to apply to their calculation. If previous calculations have been made,
        // the result of these are shown together with the users input.
        // Pre: -
        // Post: There are several possible outcomes:
        // - If the users last command was operator, the operator has been replaced by the users new choice.
        // - If the users last command was equals, a new calculation has begun, based on the result of the last equation and with the users chosen operator set.
        // - If this is the first operation the result and the operator have been set to the users inputs.
        // - If this is a continuing operation, operations up to this point has been calculated, the result of which have been set along with the users new input.
        // In the event of a division by zero or the number being represented by infinity, the calculator has been reset.
        private void OperatorButton_Clicked(object sender, EventArgs e)
        {
            if (LastClickWasOperator)
            {
                Operator = (sender as Button).Text;
                CurrentOperationLabel.Text = CurrentOperationLabel.Text.Substring(0, CurrentOperationLabel.Text.Length - 1) + Operator;
                LastClickWasEquals = false;
                return;
            }

            Input = Convert.ToDouble(ResultTextBox.Text);
            if (LastClickWasEquals)
            {
                Operator = (sender as Button).Text;
                CurrentOperationLabel.Text = Result + " " + Operator;
                LastClickWasOperator = true;
                LastClickWasEquals = false;
                return;
            }

            if (Operator == null)
            {
                Operator = (sender as Button).Text;
                Result = Input;
                CurrentOperationLabel.Text = Result + " " + Operator;
            }
            else
            {
                CurrentOperationLabel.Text += " " + Input + " ";
                PerformCalculation();
                if (DivisionByZero() || AnswerIsInfinity())
                    return;

                Operator = (sender as Button).Text;
                CurrentOperationLabel.Text += Operator;
                ResultTextBox.Text = Result.ToString();
            }
            LastClickWasOperator = true;
            LastClickWasEquals = false;
        }

        // CalculateEquation: Performs the desired calculation.
        // Pre: Operator is either /, *, - or +. 
        // Post: The result of the equation has been saved to the Result property.
        private void PerformCalculation()
        {
            switch (Operator)
            {
                case "+":
                    Result += Input;
                    break;
                case "-":
                    Result -= Input;
                    break;
                case "*":
                    Result *= Input;
                    break;
                case "/":
                    Result /= Input;
                    break;
            }
        }

        // DivisionByZero: Determines if the user attempted a division by zero.
        // Pre: -
        // Post: If the user attempted a division by zero, a warning is shown and the calculator is reset.
        private bool DivisionByZero()
        {
            if (Input == 0 && Operator == "/")
            {
                ClearButton.PerformClick();
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
            if (double.IsInfinity(Result))
            {
                ClearButton.PerformClick();
                MessageBox.Show("Uträkningen resulterade i att svaret endast kan representeras som oändligt. Miniräknaren nollställs.");
                return true;
            }
            return false;
        }

        // ClearButton_Click: Resets the calculator.
        // Pre: -
        // Post: The TextBox, Label and all properties representing the state of the application has been reset to their default values.
        private void ClearButton_Click(object sender, EventArgs e)
        {
            ResultTextBox.Text = "0";
            CurrentOperationLabel.Text = "";
            Result = 0;
            Input = 0;
            Operator = null;
            LastClickWasOperator = false;
            LastClickWasEquals = false;
        }

        // EqualsButton_Click: Checks for the state of the users input and if it's in a valid state, performs the appropriate equation.
        // Pre: -
        // Post: The result of the equation is shown in the ResultTextBox. Repeated click on equals have resulted in repeating
        // the last given equation, for example continuing to add 20 to the result if the latests inputs were + 20. 
        // In case of either a division by zero or an equation leading to the number being represented by ∞, a warning is shown and 
        // the calculator has been reset.
        private void EqualsButton_Click(object sender, EventArgs e)
        {
            if (Operator == null || LastClickWasOperator)
                return;

            if (LastClickWasEquals)
                PerformCalculation();
            else
            {
                Input = Convert.ToDouble(ResultTextBox.Text);
                PerformCalculation();
            }
            if (DivisionByZero() || AnswerIsInfinity())
                return;

            CurrentOperationLabel.Text = "";
            LastClickWasOperator = false;
            LastClickWasEquals = true;
            ResultTextBox.Text = Result.ToString();
        }

        // NumberButton_Click: Checks for the state of the users input and attempts to add a comma to the input field.
        // Pre: -
        // Post: Unless the user has performed a previous calculation but has yet to choose a type of operator, a comma
        // is added to the TextBox inputTextBox. Each number, both before and after the numeric operator, will only contain
        // a single comma.
        private void CommaButton_Click(object sender, EventArgs e)
        {
            if (ResultTextBox.Text.Contains(","))
                return;
            if (LastClickWasOperator)
                ResultTextBox.Text = "0,";
            else
                ResultTextBox.Text += ",";
            LastClickWasOperator = false;
            LastClickWasEquals = false;
        }
    }
}
