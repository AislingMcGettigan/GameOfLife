using System;

namespace GameOfLife.Classes
{
    public class Board
    {
        private readonly int Heigth;
        private readonly int Width;
        private readonly bool[,] Cell;

        /// <summary>
        /// Initializes a new Game of Life.
        /// </summary>
        /// <param name="Heigth">Heigth of the cell field.</param>
        /// <param name="Width">Width of the cell field.</param>

        public Board(int heigth, int width)
        {
            Heigth = heigth;
            Width = width;
            Cell = new bool[Heigth, Width];
            GenerateValues();
        }



        /// <summary>
        /// Advances the game by one generation according to GoL's ruleset.
        /// </summary>

        public void Run()
        {
            for (int i = 0; i < Heigth; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    int numOfAliveNeighbors = GetNeighbors(i, j);

                    if (Cell[i, j])
                    {
                        if (numOfAliveNeighbors < 2)
                        {
                            Cell[i, j] = false;
                        }

                        if (numOfAliveNeighbors > 3)
                        {
                            Cell[i, j] = false;
                        }
                    }
                    else
                    {
                        if (numOfAliveNeighbors == 3)
                        {
                            Cell[i, j] = true;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Checks how many alive neighbors are in the vicinity of a cell.
        /// </summary>
        /// <param name="Width">X-coordinate of the cell.</param>
        /// <param name="Height">Y-coordinate of the cell.</param>
        /// <returns>The number of alive neighbors.</returns>

        private int GetNeighbors(int width, int height)
        {
            int NumOfAliveNeighbors = 0;

            for (int i = width - 1; i < width + 2; i++)
            {
                for (int j = height - 1; j < height + 2; j++)
                {
                    if (!(i < 0 || j < 0 || i >= Heigth || j >= Width))
                    {
                        if (Cell[i, j])
                        {
                            NumOfAliveNeighbors++;
                        }
                    }
                }
            }
            return NumOfAliveNeighbors;
        }

        /// <summary>
        /// Draws the game to the console.
        /// </summary>

        public void Draw()
        {
            for (int i = 0; i < Heigth; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Console.Write(Cell[i, j] ? "x" : " ");
                    if (j == Width - 1)
                    {
                        Console.WriteLine("\n");
                    }
                }
            }
            Console.SetCursorPosition(0, Console.WindowTop);
        }

        /// <summary>
        /// Initializes the field with random boolean values.
        /// </summary>

        private void GenerateValues()
        {
            var generator = new Random();
            for (int i = 0; i < Heigth; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    var number = generator.Next(2);
                    Cell[i, j] = (number == 0) ? false : true;
                }
            }
        }
    }
}
