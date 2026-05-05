using KnightTour.Models;

using Shouldly;

namespace KnightTour.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Finder_FindsTour()
    {
        IKnightTourFinder finder = new KnightTourFinder();
        TourResult result = finder.FindTour(new Square(0, 0));

        result.Success.ShouldBe(true);
        result.Path.Count.ShouldBe(64);
    }
}
