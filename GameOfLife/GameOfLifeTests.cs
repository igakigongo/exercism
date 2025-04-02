using Xunit;

namespace GameOfLife;

public class GameOfLifeTests
{
    [Fact]
    public void Empty_matrix()
    {
        int[,] matrix =
        {
        };
        Assert.Empty(GameOfLife.Tick(matrix));
    }

    [Fact]
    public void Live_cells_with_zero_live_neighbors_die()
    {
        int[,] matrix =
        {
            { 0, 0, 0 },
            { 0, 1, 0 },
            { 0, 0, 0 }
        };
        int[,] expected =
        {
            { 0, 0, 0 },
            { 0, 0, 0 },
            { 0, 0, 0 }
        };
        Assert.Equal(expected, GameOfLife.Tick(matrix));
    }

    [Fact]
    public void Live_cells_with_only_one_live_neighbor_die()
    {
        int[,] matrix =
        {
            { 0, 0, 0 },
            { 0, 1, 0 },
            { 0, 1, 0 }
        };
        int[,] expected =
        {
            { 0, 0, 0 },
            { 0, 0, 0 },
            { 0, 0, 0 }
        };
        Assert.Equal(expected, GameOfLife.Tick(matrix));
    }

    [Fact]
    public void Live_cells_with_two_live_neighbors_stay_alive()
    {
        int[,] matrix =
        {
            { 1, 0, 1 },
            { 1, 0, 1 },
            { 1, 0, 1 }
        };
        int[,] expected =
        {
            { 0, 0, 0 },
            { 1, 0, 1 },
            { 0, 0, 0 }
        };
        Assert.Equal(expected, GameOfLife.Tick(matrix));
    }

    [Fact]
    public void Live_cells_with_three_live_neighbors_stay_alive()
    {
        int[,] matrix =
        {
            { 0, 1, 0 },
            { 1, 0, 0 },
            { 1, 1, 0 }
        };
        int[,] expected =
        {
            { 0, 0, 0 },
            { 1, 0, 0 },
            { 1, 1, 0 }
        };
        Assert.Equal(expected, GameOfLife.Tick(matrix));
    }

    [Fact]
    public void Dead_cells_with_three_live_neighbors_become_alive()
    {
        int[,] matrix =
        {
            { 1, 1, 0 },
            { 0, 0, 0 },
            { 1, 0, 0 }
        };
        int[,] expected =
        {
            { 0, 0, 0 },
            { 1, 1, 0 },
            { 0, 0, 0 }
        };
        Assert.Equal(expected, GameOfLife.Tick(matrix));
    }

    [Fact]
    public void Live_cells_with_four_or_more_neighbors_die()
    {
        int[,] matrix =
        {
            { 1, 1, 1 },
            { 1, 1, 1 },
            { 1, 1, 1 }
        };
        int[,] expected =
        {
            { 1, 0, 1 },
            { 0, 0, 0 },
            { 1, 0, 1 }
        };
        Assert.Equal(expected, GameOfLife.Tick(matrix));
    }

    [Fact]
    public void Bigger_matrix()
    {
        int[,] matrix =
        {
            { 1, 1, 0, 1, 1, 0, 0, 0 },
            { 1, 0, 1, 1, 0, 0, 0, 0 },
            { 1, 1, 1, 0, 0, 1, 1, 1 },
            { 0, 0, 0, 0, 0, 1, 1, 0 },
            { 1, 0, 0, 0, 1, 1, 0, 0 },
            { 1, 1, 0, 0, 0, 1, 1, 1 },
            { 0, 0, 1, 0, 1, 0, 0, 1 },
            { 1, 0, 0, 0, 0, 0, 1, 1 }
        };
        int[,] expected =
        {
            { 1, 1, 0, 1, 1, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 1, 1, 0 },
            { 1, 0, 1, 1, 1, 1, 0, 1 },
            { 1, 0, 0, 0, 0, 0, 0, 1 },
            { 1, 1, 0, 0, 1, 0, 0, 1 },
            { 1, 1, 0, 1, 0, 0, 0, 1 },
            { 1, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 1, 1 }
        };
        Assert.Equal(expected, GameOfLife.Tick(matrix));
    }
}