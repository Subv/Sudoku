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
            Console.WriteLine();
            Print(game);
            game.Solve();
            Print(game);
            

            Console.ReadLine();
        }

        public static void Print(SudokuGame game)
        {
            for (int gx = 0; gx < game.Size; ++gx)
            {
                for (int gy = 0; gy < game.Size; ++gy)
                {
                    Console.Write(game[gx, gy] + " ");
                    if ((gy + 1) % 3 == 0 && gy != game.Size - 1)
                        Console.Write("| ");
                }

                Console.WriteLine();

                if ((gx + 1) % 3 == 0 && gx != game.Size - 1)
                    Console.WriteLine("------+-------+------");
            }
        }
    }
}
