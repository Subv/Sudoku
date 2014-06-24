using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class SudokuGame
    {
        public CellGroup[,] Groups
        {
            get;
            private set;
        }

        public uint Size
        {
            get;
            private set;
        }

        public SudokuGame(uint size)
        {
            Size = size;
            Generate();
        }

        public void Generate()
        {
            Groups = new CellGroup[(int)Math.Sqrt(Size), (int)Math.Sqrt(Size)];
            for (int x = 0; x < Math.Sqrt(Size); ++x)
                for (int y = 0; y < Math.Sqrt(Size); ++y)
                    Groups[x, y] = new CellGroup((uint)Math.Sqrt(Size));
        }

        public void Solve()
        {
            
        }
    }
}
