namespace LogLevels;

using Xunit;

public class LogLevelsTests
{
    [Fact]
    public void Error_message()
    {
        Assert.Equal("Stack overflow", LogLine.Message("[ERROR]: Stack overflow"));
    }

    [Fact]
    public void Warning_message()
    {
        Assert.Equal("Disk almost full", LogLine.Message("[WARNING]: Disk almost full"));
    }

    [Fact]
    public void Info_message()
    {
        Assert.Equal("File moved", LogLine.Message("[INFO]: File moved"));
    }

    [Fact]
    public void Message_with_leading_and_trailing_white_space()
    {
        Assert.Equal("Timezone not set", LogLine.Message("[WARNING]:   \tTimezone not set  \r\n"));
    }

    [Fact]
    public void Error_log_level()
    {
        Assert.Equal("error", LogLine.LogLevel("[ERROR]: Disk full"));
    }

    [Fact]
    public void Warning_log_level()
    {
        Assert.Equal("warning", LogLine.LogLevel("[WARNING]: Unsafe password"));
    }

    [Fact]
    public void Info_log_level()
    {
        Assert.Equal("info", LogLine.LogLevel("[INFO]: Timezone changed"));
    }

    [Fact]
    public void Error_reformat()
    {
        Assert.Equal("Segmentation fault (error)", LogLine.Reformat("[ERROR]: Segmentation fault"));
    }

    [Fact]
    public void Warning_reformat()
    {
        Assert.Equal("Decreased performance (warning)", LogLine.Reformat("[WARNING]: Decreased performance"));
    }

    [Fact]
    public void Info_reformat()
    {
        Assert.Equal("Disk defragmented (info)", LogLine.Reformat("[INFO]: Disk defragmented"));
    }

    [Fact]
    public void Reformat_with_leading_and_trailing_white_space()
    {
        Assert.Equal("Corrupt disk (error)", LogLine.Reformat("[ERROR]: \t Corrupt disk\t \t \r\n"));
    }
}
