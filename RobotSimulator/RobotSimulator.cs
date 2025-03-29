namespace RobotSimulator;

public enum Direction
{
    North = 0,
    East = 1,
    South = 2,
    West = 3
}

public class RobotSimulator(Direction direction, int x, int y)
{
    public Direction Direction { get; private set; } = direction;
    public int X { get; private set; } = x;
    public int Y { get; private set; } = y;

    public void Move(string instructions)
    {
        foreach (var ch in instructions)
            switch (ch)
            {
                case 'A':
                    var (dy, dx) = _deltas[Direction];
                    X += dx;
                    Y += dy;
                    break;

                case 'R':
                    Direction = (Direction)(((int)Direction + 1) % 4);
                    break;
                case 'L':
                    Direction = (Direction)(((int)Direction + 3) % 4);
                    break;
            }
    }

    private readonly Dictionary<Direction, (int dy, int dx)> _deltas = new()
    {
        { Direction.North, (1, 0) },
        { Direction.East, (0, 1) },
        { Direction.South, (-1, 0) },
        { Direction.West, (0, -1) },
    };
}