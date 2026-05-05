using KnightTour.Constants;
using KnightTour.Extensions;
using KnightTour.Models;

namespace KnightTour;

public class KnightTourFinder() : IKnightTourFinder
{
    private const int BoardSize = Consts.BorderSize;

    public TourResult FindTour(Square start)
    {
        var path = new List<Square> { start };
        var visited = new HashSet<Square> { start };

        return TryFindTour(start, path, visited)
            ? TourResult.NotifySuccess(path)
            : TourResult.NotifyFailure();
    }

    private bool TryFindTour(Square current, List<Square> path, HashSet<Square> visited)
    {
        if (IsComplete(path))
            return true;

        /// Warnsdorff's rule: prefer moves with fewest onward options (lowest degree).
        var moves = current.GetKnightMoves()
            .Where(n => IsValid(n, visited))
            .OrderBy(n => n.GetKnightMoves().Count(m => IsValid(m, visited)))
            .ThenBy(n => DistanceFromCentre(n)) // Suggested by Claude analzer
            ;
 
        foreach (var next in moves)
        {
            path.Add(next);
            visited.Add(next);
 
            if (TryFindTour(next, path, visited))
                return true;
 
            path.RemoveAt(path.Count - 1);
            visited.Remove(next);
        }
 
        return false;
    }

    private static bool IsValid(Square square, HashSet<Square> visited) =>
        square.IsWithinBoard(BoardSize) && !visited.Contains(square);

    private static bool IsComplete(IReadOnlyCollection<Square> path) =>
        path.Count == BoardSize * BoardSize;

    //Suggested by Claude analyzer
    // Returns the squared distance from the board's centre (3.5, 3.5).
    // Multiplied by 4 to keep integer arithmetic; relative ordering is preserved.
    private static int DistanceFromCentre(Square square) =>
        (2 * square.Row - (BoardSize - 1)) * (2 * square.Row - (BoardSize - 1)) +
        (2 * square.Column - (BoardSize - 1)) * (2 * square.Column - (BoardSize - 1));
}

