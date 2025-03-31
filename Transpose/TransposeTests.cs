using Xunit;

namespace Transpose;

public class TransposeTests
{
    [Fact]
    public void Empty_string()
    {
        const string lines = "";
        const string expected = "";
        Assert.Equal(expected, Transpose.String(lines));
    }

    [Fact]
    public void Two_characters_in_a_row()
    {
        const string lines = "A1";
        const string expected = "A\n" + "1";
        Assert.Equal(expected, Transpose.String(lines));
    }

    [Fact]
    public void Two_characters_in_a_column()
    {
        const string lines = "A\n" +
                             "1";
        const string expected = "A1";
        Assert.Equal(expected, Transpose.String(lines));
    }

    [Fact]
    public void Simple()
    {
        const string lines = "ABC\n" +
                             "123";
        const string expected = "A1\n" +
                                "B2\n" +
                                "C3";
        Assert.Equal(expected, Transpose.String(lines));
    }

    [Fact]
    public void Single_line()
    {
        const string lines = "Single line.";
        const string expected = "S\n" +
                                "i\n" +
                                "n\n" +
                                "g\n" +
                                "l\n" +
                                "e\n" +
                                " \n" +
                                "l\n" +
                                "i\n" +
                                "n\n" +
                                "e\n" +
                                ".";
        Assert.Equal(expected, Transpose.String(lines));
    }

    [Fact]
    public void First_line_longer_than_second_line()
    {
        const string lines = "The fourth line.\n" +
                             "The fifth line.";
        const string expected = "TT\n" +
                                "hh\n" +
                                "ee\n" +
                                "  \n" +
                                "ff\n" +
                                "oi\n" +
                                "uf\n" +
                                "rt\n" +
                                "th\n" +
                                "h \n" +
                                " l\n" +
                                "li\n" +
                                "in\n" +
                                "ne\n" +
                                "e.\n" +
                                ".";
        Assert.Equal(expected, Transpose.String(lines));
    }

    [Fact]
    public void Second_line_longer_than_first_line()
    {
        const string lines = "The first line.\n" +
                             "The second line.";
        const string expected = "TT\n" +
                                "hh\n" +
                                "ee\n" +
                                "  \n" +
                                "fs\n" +
                                "ie\n" +
                                "rc\n" +
                                "so\n" +
                                "tn\n" +
                                " d\n" +
                                "l \n" +
                                "il\n" +
                                "ni\n" +
                                "en\n" +
                                ".e\n" +
                                " .";
        Assert.Equal(expected, Transpose.String(lines));
    }

    [Fact]
    public void Mixed_line_length()
    {
        const string lines = "The longest line.\n" +
                             "A long line.\n" +
                             "A longer line.\n" +
                             "A line.";
        const string expected = "TAAA\n" +
                                "h   \n" +
                                "elll\n" +
                                " ooi\n" +
                                "lnnn\n" +
                                "ogge\n" +
                                "n e.\n" +
                                "glr\n" +
                                "ei \n" +
                                "snl\n" +
                                "tei\n" +
                                " .n\n" +
                                "l e\n" +
                                "i .\n" +
                                "n\n" +
                                "e\n" +
                                ".";
        Assert.Equal(expected, Transpose.String(lines));
    }

    [Fact]
    public void Square()
    {
        const string lines = "HEART\n" +
                             "EMBER\n" +
                             "ABUSE\n" +
                             "RESIN\n" +
                             "TREND";
        const string expected = "HEART\n" +
                                "EMBER\n" +
                                "ABUSE\n" +
                                "RESIN\n" +
                                "TREND";
        Assert.Equal(expected, Transpose.String(lines));
    }

    [Fact]
    public void Rectangle()
    {
        const string lines = "FRACTURE\n" +
                             "OUTLINED\n" +
                             "BLOOMING\n" +
                             "SEPTETTE";
        const string expected = "FOBS\n" +
                                "RULE\n" +
                                "ATOP\n" +
                                "CLOT\n" +
                                "TIME\n" +
                                "UNIT\n" +
                                "RENT\n" +
                                "EDGE";
        Assert.Equal(expected, Transpose.String(lines));
    }

    [Fact]
    public void Triangle()
    {
        const string lines = "T\n" +
                             "EE\n" +
                             "AAA\n" +
                             "SSSS\n" +
                             "EEEEE\n" +
                             "RRRRRR";
        const string expected = "TEASER\n" +
                                " EASER\n" +
                                "  ASER\n" +
                                "   SER\n" +
                                "    ER\n" +
                                "     R";
        Assert.Equal(expected, Transpose.String(lines));
    }

    [Fact]
    public void Jagged_triangle()
    {
        const string lines = "11\n" +
                             "2\n" +
                             "3333\n" +
                             "444\n" +
                             "555555\n" +
                             "66666";
        const string expected = "123456\n" +
                                "1 3456\n" +
                                "  3456\n" +
                                "  3 56\n" +
                                "    56\n" +
                                "    5";
        Assert.Equal(expected, Transpose.String(lines));
    }
}