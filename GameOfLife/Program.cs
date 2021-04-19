using GameOfLife.Classes;

namespace GameOfLife
{
    class Program
    {
        private const int Heigth = 10;
        private const int Width = 30;
        private const uint MaxRuns = 100;

        static void Main(string[] args)
        {
            int runs = 0;
            var board = new Board(Heigth, Width);

            while (runs++ < MaxRuns)
            {
                board.Draw();
                board.Run();
            }
        }
    }
}
