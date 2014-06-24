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

        private List<int> _candidates;
        public List<int> Candidates
        {
            private set { _candidates = value; }
            get { return _candidates; }
        }

        public int Index
        {
            get;
            private set;
        }

        public int[,] Cells
        {
            get;
            private set;
        }

        public int this[int row, int col]
        {
            get
            {
                return Cells[row, col];
            }
            set
            {
                Cells[row, col] = value;
            }
        }

        public uint Size
        {
            get;
            private set;
        }

        public int X
        {
            get;
            private set;
        }

        public int Y
        {
            get;
            private set;
        }

        public CellGroup(uint size, SudokuGame _game, int index, int x, int y)
        {
            X = x;
            Y = y;
            game = _game;
            Size = size;
            Index = index;
            Cells = new int[size, size];
            Random = new Random(12340 + index);
            Generate();
        }

        public void Generate()
        {

        }

        public void NotifyCandidates()
        {
            _candidates = Enumerable.Range(1, (int)(Size * Size)).ToList();

            for (int x = 0; x < Size; ++x)
                for (int y = 0; y < Size; ++y)
                    _candidates.Remove(Cells[x, y]);
        }

        public bool IsSolved()
        {
            return _candidates.Count == 0;
        }

        public void PlaceRandomValue()
        {
            if (_candidates.Count == 0)
                return;
            
            // Get a possible value first
            int index = Random.Next(_candidates.Count);
            bool set = false;
            while (!set)
            {
                int x = Random.Next((int)Size);
                int y = Random.Next((int)Size);
                if (Cells[x, y] != 0)
                    continue;

                if (!game.CanBePlaced((int)(x + X * Size), (int)(y + Y * Size), _candidates[index]))
                    continue;

                Cells[x, y] = _candidates[index];
                _candidates.RemoveAt(index);
                set = true;
            }
        }
    }
}
