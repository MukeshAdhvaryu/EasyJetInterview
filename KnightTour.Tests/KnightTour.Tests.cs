using KnightTour.Constants;
using KnightTour.Models;
using Shouldly;

namespace KnightTour.Tests;

public class Tests
{
    private const int BoardSize = Consts.BorderSize;
    private Square Origin = Square.Empty;

    [Test]
    public void Finder_Should_FindsTour()
    {
        IKnightTourFinder finder = new KnightTourFinder();

        TourResult result = finder.FindTour(Origin);

        result.Success.ShouldBeTrue();
        result.Path.Count.ShouldBe(BoardSize * BoardSize);
    }

    [Test]
    public void Tour_Should_Not_Revisit_Squares()
    {
        IKnightTourFinder finder = new KnightTourFinder();

        TourResult result = finder.FindTour(Origin);

        result.Success.ShouldBeTrue();

        var distinctCount = result.Path.Distinct().Count();

        distinctCount.ShouldBe(result.Path.Count);
    }

    [Test]
    public void Tour_Should_Stay_Within_Board()
    {
        IKnightTourFinder finder = new KnightTourFinder();

        TourResult result = finder.FindTour(Origin);

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

        TourResult result = finder.FindTour(Origin);

        result.Success.ShouldBeTrue();

        Square? previousSquare = default;

        foreach (var currentSquare in result.Path)
        {
            if (previousSquare == null)
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

            previousSquare = currentSquare;
        }
    }

    [Test]
    public void Tour_Should_Start_At_The_Given_Square()
    {
        IKnightTourFinder finder = new KnightTourFinder();
        var start = Square.Point(4);

        TourResult result = finder.FindTour(start);

        result.Success.ShouldBeTrue();
        result.Path.First().ShouldBe(start);
    }

    [Test]
    public void Finder_Should_Work_From_All_64_Starting_Positions()
    {
        IKnightTourFinder finder = new KnightTourFinder();

        for (int row = 0; row < BoardSize; row++)
        {
            for (int col = 0; col < BoardSize; col++)
            {
                var start = new Square(row, col);
                var result = finder.FindTour(start);

                result.Success.ShouldBeTrue(
                    $"Expected a complete tour from ({row},{col}) but none was found.");
                result.Path.Count.ShouldBe(
                    BoardSize * BoardSize,
                    $"Tour from ({row},{col}) has {result.Path.Count} moves, expected {BoardSize * BoardSize}.");
                result.Path.First().ShouldBe(
                    start,
                    $"Tour from ({row},{col}) does not start at the given square.");
            }
        }
    }
}
