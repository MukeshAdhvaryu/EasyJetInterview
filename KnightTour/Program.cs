using System.Diagnostics;

using KnightTour;
using KnightTour.Models;

const int boardSize = 8;

/*
 * algorithm is pretty slow. needs to see how long it takes.
 */ 
Stopwatch stopwatch = new Stopwatch();

var finder = new KnightTourFinder(step =>
{
    if (step % 100_000 == 0)
    {
        Console.WriteLine($"Steps: {step:N0} | Time: {stopwatch.ElapsedMilliseconds} ms");
    }
});;
var start = new Square(0, 0);
stopwatch.Start();

var result = finder.FindTour(start);

if (!result.Success)
{
    Console.WriteLine("No tour found.");
    return;
}

var board = new int[boardSize, boardSize];

int i = -1;

foreach (var square in result.Path)
{
    ++i;
    board[square.Row, square.Column] = i + 1;
}

Console.WriteLine("Knight's Tour (move order):\n");

for (int row = 0; row < boardSize; row++)
{
    for (int col = 0; col < boardSize; col++)
    {
        Console.Write($"{board[row, col],3} ");
    }
    Console.WriteLine();
}
