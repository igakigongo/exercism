namespace LogAnalysis;
using Xunit;

public class LogAnalysisTests
{
    [Fact]
    public void SubstringAfter_WithDelimiterOfLength1()
    {
        Assert.Equal(" am the 1st test", "I am the 1st test".SubstringAfter("I"));
    }

    [Fact]
    public void SubstringAfter_WithDelimiterOfLengthLongerThan1()
    {
        Assert.Equal(" test", "I am the 2nd test".SubstringAfter("2nd"));
    }

    [Fact]
    public void SubstringBetween()
    {
        Assert.Equal("INFO", "[INFO]: File Deleted.".SubstringBetween("[", "]"));
    }

    [Fact]
    public void SubstringBetweenLongerDelimiters()
    {
        Assert.Equal("SOMETHING", "FIND >>> SOMETHING <===< HERE".SubstringBetween(">>> ", " <===<"));
    }

    [Fact]
    public void Message()
    {
        const string log = "[WARNING]: Library is deprecated.";
        Assert.Equal("Library is deprecated.", log.Message());
    }

    [Fact]
    public void LogLevel()
    {
        const string log = "[WARNING]: Library is deprecated.";
        Assert.Equal("WARNING", log.LogLevel());
    }
}
