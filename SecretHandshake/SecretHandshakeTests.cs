using Xunit;

namespace SecretHandshake;

public class SecretHandshakeTests
{
    [Fact]
    public void Wink_for_1()
    {
        string[] expected = ["wink"];
        Assert.Equal(expected, SecretHandshake.Commands(1));
    }

    [Fact]
    public void Double_blink_for_10()
    {
        string[] expected = ["double blink"];
        Assert.Equal(expected, SecretHandshake.Commands(2));
    }

    [Fact]
    public void Close_your_eyes_for_100()
    {
        string[] expected = ["close your eyes"];
        Assert.Equal(expected, SecretHandshake.Commands(4));
    }

    [Fact]
    public void Jump_for_1000()
    {
        string[] expected = ["jump"];
        Assert.Equal(expected, SecretHandshake.Commands(8));
    }

    [Fact]
    public void Combine_two_actions()
    {
        string[] expected = ["wink", "double blink"];
        Assert.Equal(expected, SecretHandshake.Commands(3));
    }

    [Fact]
    public void Reverse_two_actions()
    {
        string[] expected = ["double blink", "wink"];
        Assert.Equal(expected, SecretHandshake.Commands(19));
    }

    [Fact]
    public void Reversing_one_action_gives_the_same_action()
    {
        string[] expected = ["jump"];
        Assert.Equal(expected, SecretHandshake.Commands(24));
    }

    [Fact]
    public void Reversing_no_actions_still_gives_no_actions()
    {
        string[] expected = [];
        Assert.Equal(expected, SecretHandshake.Commands(16));
    }

    [Fact]
    public void All_possible_actions()
    {
        string[] expected = ["wink", "double blink", "close your eyes", "jump"];
        Assert.Equal(expected, SecretHandshake.Commands(15));
    }

    [Fact]
    public void Reverse_all_possible_actions()
    {
        string[] expected = ["jump", "close your eyes", "double blink", "wink"];
        Assert.Equal(expected, SecretHandshake.Commands(31));
    }

    [Fact]
    public void Do_nothing_for_zero()
    {
        string[] expected = [];
        Assert.Equal(expected, SecretHandshake.Commands(0));
    }
}