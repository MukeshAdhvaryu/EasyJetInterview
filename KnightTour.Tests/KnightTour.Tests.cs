using KnightTour.Models;
using Shouldly;

namespace KnightTour.Tests;

public class Tests
{
    private const int BoardSize = 8;

    [Test]
    public void Finder_FindsTour()
    {
        IKnightTourFinder finder = new KnightTourFinder();

        TourResult result = finder.FindTour(new Square(0, 0));

        result.Success.ShouldBeTrue();
        result.Path.Count.ShouldBe(BoardSize * BoardSize);
    }

    [Test]
    public void Tour_Should_Not_Revisit_Squares()
    {
        IKnightTourFinder finder = new KnightTourFinder();

        TourResult result = finder.FindTour(new Square(0, 0));

        result.Success.ShouldBeTrue();

        var distinctCount = result.Path.Distinct().Count();

        distinctCount.ShouldBe(result.Path.Count);
    }

    [Test]
    public void Tour_Should_Stay_Within_Board()
    {
        IKnightTourFinder finder = new KnightTourFinder();

        TourResult result = finder.FindTour(new Square(0, 0));

        result.Success.ShouldBeTrue();

        foreach (var square in result.Path)
        {
            square.Row.ShouldBeInRange(0, BoardSize - 1);
            square.Column.ShouldBeInRange(0, BoardSize - 1);
        }
    }

    [Test]
    public void Tour_Should_Contain_Only_Valid_Knight_Moves()
    {
        IKnightTourFinder finder = new KnightTourFinder();

        TourResult result = finder.FindTour(new Square(0, 0));

        result.Success.ShouldBeTrue();
        
        Square? previousSquare = default;

        foreach (var currentSquare in result.Path)
        {
            if(previousSquare == null)
            {
                previousSquare = currentSquare;
                continue;
            }
            var rowDiff = Math.Abs(previousSquare.Row - currentSquare.Row);
            var colDiff = Math.Abs(previousSquare.Column - currentSquare.Column);

            bool isValidMove =
                (rowDiff == 2 && colDiff == 1) ||
                (rowDiff == 1 && colDiff == 2);

            isValidMove.ShouldBeTrue();
        }
    }

    [Test]
    public void Finder_Should_Work_From_Different_Starting_Positions()
    {
        IKnightTourFinder finder = new KnightTourFinder();

        var startingPoints = new[]
        {
            new Square(0, 0),
            new Square(3, 3),
            new Square(7, 7)
        };

        foreach (var start in startingPoints)
        {
            var result = finder.FindTour(start);

            result.Success.ShouldBeTrue();
            result.Path.Count.ShouldBe(BoardSize * BoardSize);
        }
    }
}
