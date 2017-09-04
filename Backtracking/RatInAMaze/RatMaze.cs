using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatInAMaze
{
    public class RatMaze
    {
        class Position
        {
            public int X { get; set; }
            public int Y { get; set; }
        }
        private readonly int[,] _maze;
        private readonly Position[] _steps = 
        {
            new Position
            {
                X = 0,
                Y = 1
            },
            new Position
            {
                X = 1,
                Y = 0
            }
        };

        public RatMaze(int[,] maze)
        {
            _maze = (int[,]) maze.Clone();
            for (var i = 0; i < maze.GetLength(0); i++)
            {
                for (var j = 0; j < maze.GetLength(1); j++)
                {
                    Console.Write(maze[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            _maze[0, 0] = 2;
            BuildResult(new Position {X = 0, Y = 0});
        }

        private bool BuildResult(Position currentPosition)
        {
            if (currentPosition.X == _maze.GetLength(0) - 1 && currentPosition.Y == _maze.GetLength(1) - 1)
            {
                return true;
            }
            foreach (var step in _steps)
            {
                var nextPositionX = currentPosition.X + step.X;
                var nextPositionY = currentPosition.Y + step.Y;
                if (nextPositionX < 0 || nextPositionY < 0 || nextPositionX > _maze.GetLength(0) - 1 ||
                    nextPositionY > _maze.GetLength(1) - 1 || _maze[nextPositionX, nextPositionY] == 0) continue;
                _maze[nextPositionX, nextPositionY] = 2;
                if (BuildResult(new Position { X = nextPositionX, Y = nextPositionY }))
                {
                    return true;
                }
                _maze[nextPositionX, nextPositionY] = 1;
            }
            return false;
        }

        public void PrintResult()
        {
            for (var i = 0; i < _maze.GetLength(0); i++)
            {
                for (var j = 0; j < _maze.GetLength(1); j++)
                {
                    Console.Write(_maze[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
