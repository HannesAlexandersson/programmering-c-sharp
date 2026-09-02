var names = new []
{
    "Egon Spengler",
    "Peter Venkman",
    "Ray Stantz",
    "Winston Zeddemore",
};

var output = GetLongestString(names);

Console.WriteLine(output);  // Winston Zeddemore

string GetLongestString(string[] values)
{
    var longestString = string.Empty;

    foreach (var value in values)
    {
        if (value.Length <= longestString.Length)
        {
            continue;
        }

        longestString = value;
    }

    return longestString;
}
