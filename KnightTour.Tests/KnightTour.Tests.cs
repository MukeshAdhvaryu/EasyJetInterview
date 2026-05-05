using NUnit.Framework;
using Shouldly;

using KnightTour;

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
        KnightTour.IKnightTourFinder finder = new KnightTour.KnightTourFinder();
        var result = finder.FindTour(new Square(0, 0));

        result.Success.ShouldBe(true);
        result.Path.Count.ShouldBe(64);
    }
}
