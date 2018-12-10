using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        // the playfield
        static char[,] numberList = new char[3, 3] { 
            { '1', '2', '3' }, //Row 0
            { '4', '5', '6' }, //Row 1
            { '7', '8', '9' } //Row 2
        };

        static int turns = 0;
        static void Main(string[] args)
        {
            //Player 1
            int player = 2;
            //User input
            int input = 0;
            //Checks input
            bool inputCheck = true;
                        
            // Runs code as long as program runs
            do
            {
                
                if (player == 2)
                {
                    player = 1;
                    CreateXorO('O', input);
                }
                    
                else if (player == 1)
                {
                    player = 2;
                    CreateXorO('X', input);
                }
                SetField();

                #region
                char[] playerChars = { 'X', 'O' };
                foreach (char playerChar in playerChars)
                {
                    if (((numberList[0, 0] == playerChar) && (numberList[0, 1] == playerChar) && (numberList[0, 2] == playerChar))
                        || ((numberList[1, 0] == playerChar) && (numberList[1, 1] == playerChar) && (numberList[1, 2] == playerChar))
                        || ((numberList[2, 0] == playerChar) && (numberList[2, 1] == playerChar) && (numberList[2, 2] == playerChar))
                        || ((numberList[0, 0] == playerChar) && (numberList[1, 1] == playerChar) && (numberList[2, 2] == playerChar))
                        || ((numberList[2, 0] == playerChar) && (numberList[1, 1] == playerChar) && (numberList[0, 2] == playerChar))
                        || ((numberList[0, 1] == playerChar) && (numberList[1, 1] == playerChar) && (numberList[2, 1] == playerChar))
                        || ((numberList[0, 0] == playerChar) && (numberList[1, 0] == playerChar) && (numberList[2, 0] == playerChar))
                        )
                    {
                        if (playerChar == 'X')
                        {
                            Console.WriteLine("\nPlayer 2 has won!");
                        }
                        else if (playerChar == 'O')
                        {
                            Console.WriteLine("\nPlayer 1 has won");
                        }
                        Console.WriteLine("\nPress any key to reset the game :)");
                        Console.ReadKey();
                        ResetField();
                        break;

                    }
                    else if (turns == 10)
                    {
                        Console.WriteLine("\nIt's a draw\nPress any key to reset");
                        Console.ReadKey();
                        ResetField();
                        break;
                    }
                }
                #endregion
                //Checking the winner

                #region 
                //Testing field is already taken
                do
                {
                    Console.WriteLine("\nPlayer {0}, please choose a number", player);
                    try
                    {
                        input = Convert.ToInt32(Console.ReadLine());

                    } catch
                    {
                        Console.WriteLine("\nPlease enter a number");
                    }

                    if ((input == 1) && (numberList[0, 0] == '1'))
                    {
                        inputCheck = true;
                    }
                    else if ((input == 2) && (numberList[0, 1] == '2'))
                    {
                        inputCheck = true;
                    }
                    else if ((input == 3) && (numberList[0, 2] == '3'))
                    {
                        inputCheck = true;
                    }
                    else if ((input == 4) && (numberList[1, 0] == '4'))
                    {
                        inputCheck = true;
                    }
                    else if ((input == 5) && (numberList[1, 1] == '5'))
                    {
                        inputCheck = true;
                    }
                    else if ((input == 6) && (numberList[1, 2] == '6'))
                    {
                        inputCheck = true;
                    }
                    else if ((input == 7) && (numberList[2, 0] == '7'))
                    {
                        inputCheck = true;
                    }
                    else if ((input == 8) && (numberList[2, 1] == '8'))
                    {
                        inputCheck = true;
                    }
                    else if ((input == 9) && (numberList[2, 2] == '9'))
                    {
                        inputCheck = true;
                    } else
                    {
                        Console.WriteLine("Incorrect input, try again");
                        inputCheck = false;
                    }
                    #endregion

                } while (!inputCheck);
                                
                
            } while (inputCheck);

            //char userImput = GetKeyPress("Player 1 goes first. Please type a number:",
              //                                   new Char[] { '1', '2', '3' });
            //Console.WriteLine("Player 1 goes first. Please type a number:");
            //int userInput = Convert.ToInt32(Console.ReadLine());
                   
                 
            Console.Read();
        }

        public static void ResetField()
        {
            char[,] numberListInitial = new char[3, 3] 
            {
            { '1', '2', '3' }, //Row 0
            { '4', '5', '6' }, //Row 1
            { '7', '8', '9' } //Row 2
             };
            numberList = numberListInitial;
            SetField();
            turns = 0;
        }
        public static void SetField()
        {
            Console.Clear();
            Console.WriteLine("   |   |   \n {0} | {1} | {2} \n___|___|___\n   |   |   \n {3} | {4} | {5} \n___|___|___\n   |   |   \n {6} | {7} | {8} \n", numberList[0, 0], numberList[0, 1], numberList[0, 2], numberList[1, 0], numberList[1, 1], numberList[1, 2], numberList[2, 0], numberList[2, 1], numberList[2, 2]);
            turns++;
        }

        public static void CreateXorO(char playerSign, int input)
        {
                 switch (input)
            {
                case 1: numberList[0, 0] = playerSign; break;
                case 2: numberList[0, 1] = playerSign; break;
                case 3: numberList[0, 2] = playerSign; break;
                case 4: numberList[1, 0] = playerSign; break;
                case 5: numberList[1, 1] = playerSign; break;
                case 6: numberList[1, 2] = playerSign; break;
                case 7: numberList[2, 0] = playerSign; break;
                case 8: numberList[2, 1] = playerSign; break;
                case 9: numberList[2, 2] = playerSign; break;
            }

        }

    }
}
