using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class Sudoku
    {
        public static void Main(String[] args)
        {
            SudokuGame game = new SudokuGame(9);
            Console.WriteLine("Starting State");
            
            for (int gx = 0; gx < game.Size; ++gx)
            {
                for (int gy = 0; gy < game.Size; ++gy)
                    Console.Write(game[gx, gy] + " ");

                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
