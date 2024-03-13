using Xunit;

namespace TracksOnTracksOnTracks;

public class TracksOnTracksOnTracksTests
{
    [Fact]
    public void NewList()
    {
        Assert.Empty(Languages.NewList());
    }

    [Fact]
    public void ExistingList()
    {
        var expected = new List<string>();
        expected.Add("C#");
        expected.Add("Clojure");
        expected.Add("Elm");
        Assert.Equal(expected, Languages.GetExistingLanguages());
    }

    [Fact]
    public void AddLanguage()
    {
        var expected = new List<string>();
        expected.Add("C#");
        expected.Add("Clojure");
        expected.Add("Elm");
        expected.Add("Bash");
        var languages = new List<string>();
        languages.Add("C#");
        languages.Add("Clojure");
        languages.Add("Elm");
        Assert.Equal(expected, Languages.AddLanguage(languages, "Bash"));
    }

    [Fact]
    public void CountLanguages()
    {
        var expected = new List<string>();
        expected.Add("C#");
        expected.Add("Clojure");
        expected.Add("Elm");
        Assert.Equal(3, Languages.CountLanguages(expected));
    }

    [Fact]
    public void HasLanguage_yes()
    {
        var expected = new List<string>();
        expected.Add("C#");
        expected.Add("Clojure");
        expected.Add("Elm");
        Assert.True(Languages.HasLanguage(expected, "Elm"));
    }

    [Fact]
    public void HasLanguage_no()
    {
        var expected = new List<string>();
        expected.Add("C#");
        expected.Add("Clojure");
        expected.Add("Elm");
        Assert.False(Languages.HasLanguage(expected, "D"));
    }

    [Fact]
    public void ReverseList()
    {
        var expected = new List<string>();
        expected.Add("Elm");
        expected.Add("Clojure");
        expected.Add("C#");
        var languages = new List<string>();
        languages.Add("C#");
        languages.Add("Clojure");
        languages.Add("Elm");
        Assert.Equal(expected, Languages.ReverseList(languages));
    }

    [Fact]
    public void IsExciting_yes()
    {
        var expected = new List<string>();
        expected.Add("C#");
        expected.Add("Clojure");
        expected.Add("Elm");
        Assert.True(Languages.IsExciting(expected));
    }

    [Fact]
    public void IsExciting_too_many()
    {
        var languages = new List<string>();
        languages.Add("VBA");
        languages.Add("C#");
        languages.Add("Clojure");
        languages.Add("Elm");
        Assert.False(Languages.IsExciting(languages));
    }

    [Fact]
    public void IsExciting_empty()
    {
        var languages = new List<string>();
        Assert.False(Languages.IsExciting(languages));
    }

    [Fact]
    public void IsExciting_single_star()
    {
        var languages = new List<string>();
        languages.Add("C#");
        Assert.True(Languages.IsExciting(languages));
    }

    [Fact]
    public void IsExciting_star_on_second_place_size2()
    {
        var languages = new List<string>();
        languages.Add("F#");
        languages.Add("C#");
        Assert.True(Languages.IsExciting(languages));
    }

    [Fact]
    public void IsExciting_star_on_second_place_size3()
    {
        var languages = new List<string>();
        languages.Add("F#");
        languages.Add("C#");
        languages.Add("Clojure");
        Assert.True(Languages.IsExciting(languages));
    }

    [Fact]
    public void RemoveLanguage_yes()
    {
        var expected = new List<string>();
        expected.Add("C#");
        expected.Add("Elm");
        var languages = new List<string>();
        languages.Add("C#");
        languages.Add("Clojure");
        languages.Add("Elm");
        Assert.Equal(expected, Languages.RemoveLanguage(languages, "Clojure"));
    }

    [Fact]
    public void RemoveLanguage_no()
    {
        var expected = new List<string>();
        expected.Add("C#");
        expected.Add("Clojure");
        expected.Add("Elm");
        var languages = new List<string>();
        languages.Add("C#");
        languages.Add("Clojure");
        languages.Add("Elm");
        Assert.Equal(expected, Languages.RemoveLanguage(languages, "English"));
    }

    [Fact]
    public void IsUnique_yes()
    {
        var languages = new List<string>();
        languages.Add("C#");
        languages.Add("Clojure");
        languages.Add("Elm");
        Assert.True(Languages.IsUnique(languages));
    }

    [Fact]
    public void IsUnique_no()
    {
        var languages = new List<string>();
        languages.Add("C#");
        languages.Add("Clojure");
        languages.Add("Elm");
        languages.Add("C#");
        Assert.False(Languages.IsUnique(languages));
    }
}
