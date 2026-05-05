namespace KnightTour.Models;

public record TourResult (bool Success, IReadOnlyCollection<Square> Path)
{
    public static TourResult NotifySuccess(IReadOnlyCollection<Square> path) => new(true, path);
    public static TourResult NotifyFailure() => new(false, Array.Empty<Square>());
}
