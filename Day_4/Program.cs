var input = File.ReadAllText("input.txt");

var pairs = input.Split("\r\n");


var rangeFullyContainTheOtherCounter = 0;
var rangesOverlapCounter = 0;

foreach (var pair in pairs)
{
    var firstElf = pair.Split(',').First();
    var secondElf = pair.Split(',').Last();

    var firstElfStart = int.Parse(firstElf.Split('-').First());
    var firstElfEnd = int.Parse(firstElf.Split('-').Last());
    var firstElfDifference = firstElfEnd - firstElfStart + 1;
    var firstElfSection = Enumerable.Range(firstElfStart, firstElfDifference);

    var secondElfStart = int.Parse(secondElf.Split('-').First());
    var secondElfEnd = int.Parse(secondElf.Split('-').Last());
    var secondElfDifference = secondElfEnd - secondElfStart + 1;
    var secondElfSection = Enumerable.Range(secondElfStart, secondElfDifference);

    var firstSectionInBoth = firstElfSection.Intersect(secondElfSection);
    var secondSectionInBoth = secondElfSection.Intersect(firstElfSection);
    if (firstSectionInBoth.Count() == firstElfSection.Count() ||
        secondSectionInBoth.Count() == secondElfSection.Count())
    {
        rangeFullyContainTheOtherCounter++;
    }
    
    if (firstSectionInBoth.Any())
    {
        rangesOverlapCounter++;
    }
}

Console.WriteLine(rangeFullyContainTheOtherCounter);
Console.WriteLine(rangesOverlapCounter);

Console.ReadKey();