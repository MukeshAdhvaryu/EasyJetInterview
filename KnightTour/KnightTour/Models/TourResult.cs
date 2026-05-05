namespace KnightTour.Models;

public record TourResult (bool Success, IReadOnlyCollection<Square> Path);
