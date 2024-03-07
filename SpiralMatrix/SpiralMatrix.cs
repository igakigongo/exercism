namespace SpiralMatrix;

public enum Direction
{
    Right,
    Down,
    Left,
    Up
}

public static class SpiralMatrix
{
    public static int[,] GetMatrix(int size)
    {
        if (size == 0) return new int[0, 0];
        if (size == 1) return new[,] { { 1 } };

        var arr = new int[size, size];
        int curr = 1, i = 0, j = 0;
        var queueOfMoves = GetMoves(size);

        while (queueOfMoves.Count != 0)
        {
            var (dir, moves) = queueOfMoves.Dequeue();
            ApplyMove(dir, moves, arr, ref i, ref j, ref curr);
        }


        return arr;
    }

    private static Queue<(Direction direction, int moves)> GetMoves(int size)
    {
        var queue = new Queue<(Direction dir, int moves)>();
        var direction = Direction.Right;
        queue.Enqueue((direction, size));

        var moves = size - 1;
        while (moves > 0)
        {
            direction = direction.Turn();
            queue.Enqueue((direction, moves));
            direction = direction.Turn();
            queue.Enqueue((direction, moves));
            moves--;
        }

        return queue;
    }

    private static Direction Turn(this Direction direction) =>
        direction switch
        {
            Direction.Right => Direction.Down,
            Direction.Down => Direction.Left,
            Direction.Left => Direction.Up,
            Direction.Up => Direction.Right,
            _ => throw new NotSupportedException()
        };

    private static void ApplyMove(Direction dir, int moves, int[,] arr, ref int i, ref int j, ref int curr)
    {
        int limit;
        switch (dir)
        {
            case Direction.Right:
                limit = j + moves - 1;
                for (; j <= limit; j++)
                    arr[i, j] = curr++;
                i++; // advance to row (down)
                j--; // fix j
                break;

            case Direction.Down:
                limit = i + moves - 1;
                for (; i <= limit; i++)
                    arr[i, j] = curr++;
                j--; // advance to col (left)
                i--; // fix i
                break;

            case Direction.Left:
                limit = j - moves + 1;
                for (; j >= limit; j--)
                    arr[i, j] = curr++;
                i--; // advance to row (up)
                j++; // fix j
                break;

            case Direction.Up:
                limit = i - moves + 1;
                for (; i >= limit; i--)
                    arr[i, j] = curr++;
                j++; // advance to the col (right)
                i++; // fix i
                break;

            default:
                throw new NotSupportedException("Invalid Direction Value");
        }
    }
}
