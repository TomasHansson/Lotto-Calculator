using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Lotto
{
    public partial class Lotto : Form
    {
        // Constants that sets the constraints of user input. 
        private const int numberOfLottoNumbers = 7;
        private const int lowerBound = 1;
        private const int lottoNumberUpperBound = 35;
        private const int numberOfDrawsUpperBound = 999999;

        public Lotto()
        {
            InitializeComponent();
        }

        // Input_TextChanged: Whenever the text of any of the applications TextBoxes is changed, the application will validate the users input.
        // Pre: -
        // Post: If the input isn't a number within the bounds given by the constants, a warning has been shown and the textbox has been reset. 
        // The upperBound is determined by whether it's a TextBox for the number of draws or for a lotto number.
        private void Input_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            string input = textBox.Text;

            if (input == "")
                return;

            int upperBound = textBox == numberOfDraws ? numberOfDrawsUpperBound : lottoNumberUpperBound;

            if (!InputIsANumber(input) || !InputIsWithinBounds(input, lowerBound, upperBound))
                textBox.Text = "";
        }

        // InputIsANumber: Determined whether the input is a number.
        // Pre: -
        // Post: If the input isn't a number, a warning has been shown.
        private bool InputIsANumber(string input)
        {
            if (!Int32.TryParse(input, out int n))
            {
                MessageBox.Show("Du måste ange ett nummer.");
                return false;
            }
            return true;
        }

        // InputIsWithinBounds: Determines wheter the input is within the bounds given by _lowerBound and _upperBound.
        // Pre: The string input is a string representation of a number. _lowerBound <= _upperBound.
        // Post: If the input isn't within the given bounds, a warning has been shown.
        private bool InputIsWithinBounds(string input, int _lowerBound, int _upperBound)
        {
            int number = Convert.ToInt32(input);
            if (number < _lowerBound || number > _upperBound)
            {
                MessageBox.Show(string.Format("Du måste ange ett nummer mellan {0} och {1}.", _lowerBound, _upperBound));
                return false;
            }
            return true;
        }

        // RunLotto: Creates a list of lotto numbers based on the user input in the respective textboxes and validates this list
        // as well as the input for number of draws. If both are valid, the lotto is run.
        // Pre: -
        // Post: If the users input is valid, the method to run the lotto has been executed, otherwice a warning has been shown.
        private void RunLotto_Click(object sender, EventArgs e)
        {
            CreateListOfLottoNumbers();

            if (!LottoNumbersAreValid() || !NumberOfDrawsIsValid())
                return;

            RunLotto();
        }

        // CreateListOfLottoNumbers: Empties the list inside the property LottoNumbers and then refills it with any valid input inside
        // the TextBoxes for lotto numbers.
        // Pre: -
        // Post: The list has been populated with all valid values as given by the user.
        public List<int> LottoNumbers { get; set; } = new List<int>();
        private void CreateListOfLottoNumbers()
        {
            LottoNumbers.Clear();
            if (Int32.TryParse(lottoNumber1.Text, out int input))
                LottoNumbers.Add(input);
            if (Int32.TryParse(lottoNumber2.Text, out input))
                LottoNumbers.Add(input);
            if (Int32.TryParse(lottoNumber3.Text, out input))
                LottoNumbers.Add(input);
            if (Int32.TryParse(lottoNumber4.Text, out input))
                LottoNumbers.Add(input);
            if (Int32.TryParse(lottoNumber5.Text, out input))
                LottoNumbers.Add(input);
            if (Int32.TryParse(lottoNumber6.Text, out input))
                LottoNumbers.Add(input);
            if (Int32.TryParse(lottoNumber7.Text, out input))
                LottoNumbers.Add(input);
        }

        // LottoNumbersAreValid: Determines whether the creates list of Lottonumbers are valid by ensuring that it contains 7 unique numbers.
        // Pre: -
        // Post: If the list doesn't contain the specified number of unique entires, a warning has been shown.
        private bool LottoNumbersAreValid()
        {
            if (LottoNumbers.Select(x => x).Distinct().Count() != numberOfLottoNumbers)
            {
                MessageBox.Show("Du måste ange sju unika lottotal innan du kan starta lottot.");
                return false;
            }
            return true;
        }

        // NumberOfDrawsIsValid: Determines whether a number has been specified in the TextBox for number of draws.
        // Pre: -
        // Post: If the TextBox for number of draws doesn't contain a number, a warning has been shown.
        private bool NumberOfDrawsIsValid()
        {
            if (!Int32.TryParse(numberOfDraws.Text, out int n))
            {
                MessageBox.Show("Du måste ange antal dragningar innan du kan starta lottot.");
                return false;
            }
            return true;
        }

        // RunLotto: Creates a number of random lotto numbers equal to the number of runs specified by the user and compares
        // each result to the numbers given by the user. The results are displayed in the matching TextBoxes.
        // Pre: The property list LottoNumbers contains 7 unique numbers within the given bounds and the TextBox numberOfDraws
        // contains a number within its given bounds.
        // Post: The lotto has been run as many times as given in the TextBox numberOfDraws. Each time a new list is created and
        // compared to the numbers specified by the user. Runs with 5, 6 or 7 matches are tracked and the final number of matches
        // are shown in the respective TextBoxes.
        private void RunLotto()
        {
            int numberOfDrawsWithFiveMatches = 0;
            int numberOfDrawsWithSixMatches = 0;
            int numberOfDrawsWithSevenMatches = 0;
            for (int i = 0; i < Convert.ToInt32(numberOfDraws.Text); i++)
            {
                GenerateRandomLottoNumbers();
                int numberOfMatches = CompareRandomNumbersToUserNumbers();
                if (numberOfMatches == 7)
                    numberOfDrawsWithSevenMatches++;
                else if (numberOfMatches == 6)
                    numberOfDrawsWithSixMatches++;
                else if (numberOfMatches == 5)
                    numberOfDrawsWithFiveMatches++;
            }
            fiveMatches.Text = numberOfDrawsWithFiveMatches.ToString();
            sixMatches.Text = numberOfDrawsWithSixMatches.ToString();
            sevenMatches.Text = numberOfDrawsWithSevenMatches.ToString();
        }

        // GenerateRandomLottoNumbers: Empties and repopulates the list RandomNumbers with 7 unique numbers within the bounds
        // given by the constants.
        // Pre: -
        // Post: The property list RandomNumbers contains 7 unique numbers between lowerBound and lottoNumberUpperBound.
        public List<int> RandomNumbers { get; set; } = new List<int>();
        public Random Randomizer { get; set; } = new Random();
        private void GenerateRandomLottoNumbers()
        {
            RandomNumbers.Clear();
            while (RandomNumbers.Count < numberOfLottoNumbers)
            {
                int nextNumber = Randomizer.Next(lowerBound, lottoNumberUpperBound + 1);
                while (RandomNumbers.Contains(nextNumber))
                    nextNumber = Randomizer.Next(lowerBound, lottoNumberUpperBound + 1);
                RandomNumbers.Add(nextNumber);
            }
        }

        // CompareRandomNumbersToUserNumbers: Compares the current RandomNumbers to the list numbers given by the users input and hence
        // saved in LottoNumbers.
        // Pre: Both RandomNumbers and LottoNumbers contains 7 unique numbers.
        // Post: The number of matches between the two lists have been returned.
        private int CompareRandomNumbersToUserNumbers()
        {
            int numberOfMatches = 0;
            for (int i = 0; i < numberOfLottoNumbers; i++)
            {
                if (RandomNumbers.Contains(LottoNumbers[i]))
                    numberOfMatches++;
            }
            return numberOfMatches;
        }
    }
}
