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

        public uint NumGroups
        {
            get;
            private set;
        }

        public uint Size
        {
            get;
            private set;
        }

        public uint this[int row, int col]
        {
            get
            {
                return Groups[(int)(row / NumGroups), (int)(col / NumGroups)][(int)(row % NumGroups), (int)(col % NumGroups)];
            }
        }

        public SudokuGame(uint size)
        {
            Size = size;
            NumGroups = (uint)Math.Sqrt(Size);
            Generate();
        }

        public void Generate()
        {
            Groups = new CellGroup[(int)Math.Sqrt(Size), (int)Math.Sqrt(Size)];
            int i = 0;
            for (int x = 0; x < Math.Sqrt(Size); ++x)
                for (int y = 0; y < Math.Sqrt(Size); ++y)
                    Groups[x, y] = new CellGroup((uint)Math.Sqrt(Size), this, i++);
        }

        public void Solve()
        {
            
        }
    }
}
