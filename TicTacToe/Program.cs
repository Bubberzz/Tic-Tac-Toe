using System;

namespace TicTacToe
{
    internal class Program
    {
        // Creates a three dimensional array - which will be used for the playing field
        private static char[,] _numberList = new char[3, 3] {
            { '1', '2', '3' }, // Row 0
            { '4', '5', '6' }, // Row 1
            { '7', '8', '9' }  // Row 2
        };

        // Stores turns players taken / number if iterations
        private static int _turns;
        // Stores user input, int 1-9
        private static int _input;

        private static void Main()
        {
            // Player variable, used to switch turns
            var player = 2;
            // Set to true when input is an int / breaks do while loop
            bool inputCheck;

            do
            {
                // Player alternation switch
                switch (player)
                {
                    case 1:
                        player = 2;
                        AddUserInputToArray('X', _input);
                        break;
                    case 2:
                        player = 1;
                        AddUserInputToArray('O', _input);
                        break;
                }

                SetField();

                #region CheckingForWinner
                // Checks if there's a winner based on 3 matching combinations of X's or O's
                char[] playerChars = { 'X', 'O' };
                foreach (var playerChar in playerChars)
                {
                    if (((_numberList[0, 0] == playerChar) && (_numberList[0, 1] == playerChar) && (_numberList[0, 2] == playerChar))
                        || ((_numberList[1, 0] == playerChar) && (_numberList[1, 1] == playerChar) && (_numberList[1, 2] == playerChar))
                        || ((_numberList[2, 0] == playerChar) && (_numberList[2, 1] == playerChar) && (_numberList[2, 2] == playerChar))
                        || ((_numberList[0, 0] == playerChar) && (_numberList[1, 1] == playerChar) && (_numberList[2, 2] == playerChar))
                        || ((_numberList[2, 0] == playerChar) && (_numberList[1, 1] == playerChar) && (_numberList[0, 2] == playerChar))
                        || ((_numberList[0, 1] == playerChar) && (_numberList[1, 1] == playerChar) && (_numberList[2, 1] == playerChar))
                        || ((_numberList[0, 0] == playerChar) && (_numberList[1, 0] == playerChar) && (_numberList[2, 0] == playerChar))
                        || ((_numberList[0, 2] == playerChar) && (_numberList[1, 2] == playerChar) && (_numberList[2, 2] == playerChar))
                       )
                    {
                        switch (playerChar)
                        {
                            case 'X':
                                Console.WriteLine("\nPlayer 1 has won!");
                                break;
                            case 'O':
                                Console.WriteLine("\nPlayer 2 has won!");
                                break;
                        }
                        Console.WriteLine("\nPress any key to reset the game :)");
                        Console.ReadKey();
                        ResetField();
                        break;
                    }
                }
                // Checks if all possible turns have been used up, in which case it's a draw 
                if (_turns == 10)
                {
                    Console.WriteLine("\nIt's a draw\n" + "\nPress any key to reset");
                    Console.ReadKey();
                    ResetField();
                }
                #endregion

                #region PlayerInput
                // Game loop, requires player to enter a 1-9 integer, performs validation
                do
                {
                    Console.WriteLine("\nPlayer {0}, please choose a number", player);
                    try
                    {
                        _input = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("\nPlease enter a number");
                    }
                    // Uses the inputted integer to validate it's array position, the input variable will be passed to AddUserInputToArray method
                    if ((_input == 1 && _numberList[0, 0] == '1') || (_input == 2 && _numberList[0, 1] == '2') ||
                        (_input == 3 && _numberList[0, 2] == '3') || (_input == 4 && _numberList[1, 0] == '4') ||
                        (_input == 5 && _numberList[1, 1] == '5') || (_input == 6 && _numberList[1, 2] == '6') ||
                        (_input == 7 && _numberList[2, 0] == '7') || (_input == 8 && _numberList[2, 1] == '8') ||
                        (_input == 9 && _numberList[2, 2] == '9'))
                    {
                        inputCheck = true;
                    }
                    else
                    {
                        Console.Clear();
                        SetField();
                        Console.WriteLine("\nIncorrect input, try again");
                        inputCheck = false;
                    }
                } while (!inputCheck);
            } while (inputCheck);
            Console.Read();
        }
        #endregion

        // Resets the playing field to beginning
        public static void ResetField()
        {
            var numberListInitial = new char[3, 3]
            {
            { '1', '2', '3' }, // Row 0
            { '4', '5', '6' }, // Row 1
            { '7', '8', '9' }  // Row 2
             };
            _numberList = numberListInitial;
            SetField();
            _turns = 1;
            _input = 0;
        }

        // Draws the playing field - using a multidimensional array to display values
        public static void SetField()
        {
            Console.Clear();
            Console.WriteLine("   |   |   \n {0} | {1} | {2} \n___|___|___\n   |   |   \n {3} | {4} | {5} \n___|___|___\n   |   |   \n {6} | {7} | {8} \n", _numberList[0, 0], _numberList[0, 1], _numberList[0, 2], _numberList[1, 0], _numberList[1, 1], _numberList[1, 2], _numberList[2, 0], _numberList[2, 1], _numberList[2, 2]);
        }

        // Uses the int the player typed in to replace with an 'X' or 'O' in the array / playing field
        public static void AddUserInputToArray(char addChar, int playerInput)
        {
            switch (playerInput)
            {
                case 1: _numberList[0, 0] = addChar; break;
                case 2: _numberList[0, 1] = addChar; break;
                case 3: _numberList[0, 2] = addChar; break;
                case 4: _numberList[1, 0] = addChar; break;
                case 5: _numberList[1, 1] = addChar; break;
                case 6: _numberList[1, 2] = addChar; break;
                case 7: _numberList[2, 0] = addChar; break;
                case 8: _numberList[2, 1] = addChar; break;
                case 9: _numberList[2, 2] = addChar; break;
            }
            _turns++;
        }
    }
}
