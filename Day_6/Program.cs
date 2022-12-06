var input = File.ReadAllText("input.txt");

int GetMarkerIndex(string input, int numberofUniqueCharacters)
{
    var markerIndex = 0;

    for (var i = 0; i < input.Length - numberofUniqueCharacters; i++)
    {
        var substring = input.Substring(i, numberofUniqueCharacters);
        var uniqueCharacters = substring.Distinct().Count();
        if (uniqueCharacters == numberofUniqueCharacters)
        {
            markerIndex = i + numberofUniqueCharacters;
            break;
        }
    }

    return markerIndex;
}

//var part1 = GetMarkerIndex(input, 4);
var part2 = GetMarkerIndex(input, 14);

Console.WriteLine(part2);

Console.ReadKey();