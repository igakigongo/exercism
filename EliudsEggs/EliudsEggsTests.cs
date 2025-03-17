using Xunit;

namespace EliudsEggs;

public class EliudsEggsTests
{
    [Fact]
    public void Zero_eggs()
    {
        Assert.Equal(0, EliudsEggs.EggCount(0));
    }

    [Fact]
    public void One_egg()
    {
        Assert.Equal(1, EliudsEggs.EggCount(16));
    }

    [Fact]
    public void Four_eggs()
    {
        Assert.Equal(4, EliudsEggs.EggCount(89));
    }

    [Fact]
    public void Thirteen_eggs()
    {
        Assert.Equal(13, EliudsEggs.EggCount(2000000000));
    }
}