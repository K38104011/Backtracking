using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheKnightTour
{
    class Program
    {
        static void Main(string[] args)
        {
            var kt = new KnightTour(8);
            kt.PrintResult();
            Console.ReadKey();
        }
    }

    class KnightTour
    {
        class Position
        {
            public int X { get; set; }
            public int Y { get; set; }
        }

        private readonly int _size;
        private readonly int[,] _board;
        private readonly IList<Position> _moveSteps = new List<Position>
        {
            new Position { X = 2, Y = 1 },
            new Position { X = 1, Y = 2 },
            new Position { X = -1, Y = 2 },
            new Position { X = -2, Y = 1 },
            new Position { X = -2, Y = -1 },
            new Position { X = -1, Y = -2 },
            new Position { X = 1, Y = -2 },
            new Position { X = 2, Y = -1 },
            
        };

        public KnightTour(int size)
        {
            _size = size;
            _board = new int[_size, _size];
            for (var i = 0; i < _size; i++)
            {
                for (var j = 0; j < _size; j++)
                {
                    _board[i, j] = -1;
                }
            }
            _board[0, 0] = 0;
            BuildResult(1, 0, 0);
        }

        public void PrintResult()
        {
            for (var i = 0; i < _size; i++)
            {
                for (var j = 0; j < _size; j++)
                {
                    Console.Write(_board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        private bool BuildResult(int stepCount, int positionX, int positionY)
        {
            if (stepCount == _size * _size)
            {
                return true;
            }
            foreach (var step in _moveSteps)
            {
                var nextPositionX = positionX + step.X;
                var nextPositionY = positionY + step.Y;
                if (nextPositionX < 0 || nextPositionY < 0 || nextPositionX >= _size || nextPositionY >= _size ||
                    _board[nextPositionX, nextPositionY] != -1) continue;
                _board[nextPositionX, nextPositionY] = stepCount;
                if (BuildResult(stepCount + 1, nextPositionX, nextPositionY))
                {
                    return true;
                }
                _board[nextPositionX, nextPositionY] = -1;
            }
            return false;
        }
    }
}
