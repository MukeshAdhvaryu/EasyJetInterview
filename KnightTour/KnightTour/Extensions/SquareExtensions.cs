using KnightTour.Models;

namespace KnightTour.Extensions;

public static class SquareExtensions
{
    public static bool IsWithinBoard(this Square square, int size) =>
        square.Row >= 0 && square.Row < size &&
        square.Column >= 0 && square.Column < size;

    public static IEnumerable<Square> GetKnightMoves(this Square square)
    {
        foreach (var move in Square.AllMoves)
        {
            yield return square + move;
        }
    }
}
