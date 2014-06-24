using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class CellGroup
    {
        public uint[,] Cells
        {
            get;
            private set;
        }

        public uint this[int row, int col]
        {
            get
            {
                return Cells[row, col];
            }
        }

        public uint Size
        {
            get;
            private set;
        }

        public CellGroup(uint size)
        {
            Size = size;
            Cells = new uint[size, size];
            Generate();
        }

        public void Generate()
        {
            for (int x = 0; x < Size; ++x)
                for (int y = 0; y < Size; ++y)
                    Cells[x, y] = 3;
        }
    }
}
