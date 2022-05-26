namespace TelegramService.Tests.Helpers;

public sealed class PathBuilderTests
{
    public PathBuilderTests()
    {
        DotEnv.Load();
    }

    [Theory]
    [InlineData("qwerty")]
    [InlineData(null)]
    [InlineData("")]
    public void Append_Single_Test(string data)
    {
        var expected = ConfigKeys.BASE_URL + "/" + data;

        var pd = new PathBuilder();
        var actual = pd.Append(data);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("1", "2", "3")]
    [InlineData(null, "", "4")]
    public void Append_Miltiple_Test(params string[] strings)
    {
        var expected = ConfigKeys.BASE_URL;
        foreach (var str in strings)
        {
            expected += "/" + str;
        }

        var pd = new PathBuilder();
        string? actual = default;
        foreach (var str in strings)
        {
            actual = pd.Append(str);
        }

        Assert.Equal(expected, actual);
        Assert.Equal(expected, pd.ToString());

    }

}