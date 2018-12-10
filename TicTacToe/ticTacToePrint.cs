using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class ticTacToePrint
    {
        public int[,] numberList = new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
        public int num1 = 1;
        public void PrintGame()
        {
            //string Line1 = "   |   |   \n {0} |  |  \n___|___|___", numberList[0, 0];
            Console.WriteLine("   |   |   \n {0} | {1} | {2} \n___|___|___", numberList[0, 0], numberList[0, 1], numberList[0, 2]);
            Console.WriteLine("   |   |   \n {0} | {1} | {2} \n___|___|___", numberList[1, 0], numberList[1, 1], numberList[1, 2]);
            Console.WriteLine("   |   |   \n {0} | {1} | {2} \n", numberList[2, 0], numberList[2, 1], numberList[2, 2]);
            
        }
    }
}
