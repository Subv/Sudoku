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
        private Random Random = new Random(12340);

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

        public int this[int row, int col]
        {
            get
            {
                return Groups[(int)(row / NumGroups), (int)(col / NumGroups)][(int)(row % NumGroups), (int)(col % NumGroups)];
            }
            private set
            {
                Groups[(int)(row / NumGroups), (int)(col / NumGroups)][(int)(row % NumGroups), (int)(col % NumGroups)] = value;
            }
        }

        public SudokuGame(uint size)
        {
            Size = size;
            NumGroups = (uint)Math.Sqrt(Size);
            Generate();
        }

        public bool CanBePlaced(int x, int y, int val)
        {
            for (int _y = 0; _y < Size; ++_y)
                if (this[x, _y] == val)
                    return false;

            for (int _x = 0; _x < Size; ++_x)
                if (this[_x, y] == val)
                    return false;

            return true;
        }

        public void Generate()
        {
            Groups = new CellGroup[(int)Math.Sqrt(Size), (int)Math.Sqrt(Size)];
            int i = 0;
            for (int x = 0; x < Math.Sqrt(Size); ++x)
                for (int y = 0; y < Math.Sqrt(Size); ++y)
                    Groups[x, y] = new CellGroup((uint)Math.Sqrt(Size), this, i++, x, y);

            // Fill 9 random squares with random numbers
            var numbers = Enumerable.Range(1, (int)(Size)).ToList();

            while (numbers.Count != 0)
            {
                int index = Random.Next(numbers.Count);
                this[(int)Random.Next((int)Size), (int)Random.Next((int)Size)] = numbers[index];
                numbers.RemoveAt(index);
            }

            for (int x = 0; x < Math.Sqrt(Size); ++x)
                for (int y = 0; y < Math.Sqrt(Size); ++y)
                    Groups[x, y].NotifyCandidates();
/*

            Solve();
            Blank(); // Add some blanks*/
        }

        public void Solve()
        {
            if (IsSolved())
                return;

            if (!IsValid())
            {
                // Go back a few steps
                throw new NotImplementedException("Not valid solution");
                return;
            }

            // First get a random group
            int x = Random.Next((int)NumGroups);
            int y = Random.Next((int)NumGroups);
            CellGroup group = Groups[x, y];

            // Now place a random number in it
            group.PlaceRandomValue();

            // Try again now
            Solve();
        }

        private CellGroup GetGroupForCoords(int x, int y)
        {
            return Groups[(int)(x / NumGroups), (int)(y / NumGroups)];
        }

        private bool IsValid()
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();

            for (int x = 0; x < Size; ++x)
            {
                for (int y = 0; y < Size; ++y)
                {
                    if (!dict.ContainsKey(this[x, y]))
                        dict.Add(this[x, y], 0);
                    dict[this[x, y]]++;
                }

                foreach (var kvp in dict)
                    if (kvp.Key != 0 && kvp.Value > 1)
                        return false;
                dict = new Dictionary<int, int>();
            }

            return true;
        }

        public bool IsSolved()
        {
            for (int x = 0; x < NumGroups; ++x)
                for (int y = 0; y < NumGroups; ++y)
                    if (!Groups[x, y].IsSolved())
                        return false;
            return true;
        }

        public void Blank()
        {

        }
    }
}
