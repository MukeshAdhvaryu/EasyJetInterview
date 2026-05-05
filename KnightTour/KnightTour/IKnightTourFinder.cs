using KnightTour.Models;

namespace KnightTour;

public interface IKnightTourFinder
{
    TourResult FindTour(Square square);
}
