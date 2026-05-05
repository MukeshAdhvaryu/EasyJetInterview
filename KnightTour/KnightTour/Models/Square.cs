namespace KnightTour.Models;

public record Square (int Row, int Column)
{
    public static Square operator +(Square a, Square b) => 
        new Square(a.Row + b.Row, a.Column + b.Column);

    public static Square Empty = new Square (0, 0);
    public static Square Point(int point) => new Square(point, point);
    
    private static readonly Square MoveOneByTwo = new(1, 2);
    private static readonly Square MoveTwoByOne = new(2, 1);


    private Square NegateRow() => new Square(-Row, Column);
    private Square NegateColumn() => new Square(Row, -Column);
    private Square Negate() => new Square(-Row, -Column);

    private static readonly Square[] BaseMoves =
    [
        MoveOneByTwo,
        MoveTwoByOne
    ];

    public static readonly Square[] AllMoves =
    [
        ..BaseMoves,
        ..BaseMoves.Select(m => m.NegateRow()),
        ..BaseMoves.Select(m => m.NegateColumn()),
        ..BaseMoves.Select(m => m.Negate())
    ];
}
