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
        private SudokuGame game;
        private Random Random;

        public int Index
        {
            get;
            private set;
        }

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

        public CellGroup(uint size, SudokuGame _game, int index)
        {
            game = _game;
            Size = size;
            Index = index;
            Cells = new uint[size, size];
            Random = new Random(12340 + index);
            Generate();
        }

        public void Generate()
        {
            var numbers = Enumerable.Range(1, (int)(Size * Size)).ToList();
            for (int x = 0; x < Size; ++x)
            {
                for (int y = 0; y < Size; ++y)
                {
                    int index = Random.Next(numbers.Count());
                    Cells[x, y] = (uint)numbers[index];
                    numbers.RemoveAt(index);
                }
            }
        }
    }
}
