using KnightTour.Extensions;
using KnightTour.Models;

namespace KnightTour;

public class KnightTourFinder : IKnightTourFinder
{
    private const int BoardSize = 8;

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

        foreach (var next in current.GetKnightMoves())
        {
            if (!IsValid(next, visited))
                continue;

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
}

