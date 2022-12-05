using System.Text;

var lines = File.ReadAllLines("input.txt");

var emptyLine = lines.First(x => string.IsNullOrEmpty(x));

var indexOfEmptyLine = Array.IndexOf(lines, emptyLine);
var numberOfColumns = int.Parse(lines[indexOfEmptyLine - 1].Trim().Split(" ").Last());

var supplies = lines.Take(indexOfEmptyLine - 1).ToArray();

var moveOperations = lines.Skip(indexOfEmptyLine + 1)
    .Select(x => x.Replace("move", string.Empty)
    .Replace("from", string.Empty)
    .Replace("to", string.Empty)
    .Replace("  ", " ")
    .Trim()
    .Split(" "))
    .Select(x => Array.ConvertAll(x, int.Parse))
    .ToList();

void Part1(List<int[]> moveOperations)
{
    var stacks = GetStacks(supplies, lines);

    for (var i = 0; i < moveOperations.Count; i++)
    {
        var numberOfElementsToMove = moveOperations[i][0];
        var stackFrom = moveOperations[i][1] - 1;
        var stackTo = moveOperations[i][2] - 1;

        for (var j = 0; j < numberOfElementsToMove; j++)
        {
            var itemToMove = stacks[stackFrom].Pop();
            stacks[stackTo].Push(itemToMove);
        }
    }

    var finalText = new StringBuilder();

    foreach (var stack in stacks)
    {
        finalText.Append(stack.Pop());
    }

    Console.WriteLine(finalText.ToString());
}


void Part2(List<int[]> moveOperations)
{
    var stacks = GetStacks(supplies, lines);

    for (var i = 0; i < moveOperations.Count; i++)
    {
        var numberOfElementsToMove = moveOperations[i][0];
        var stackFrom = moveOperations[i][1] - 1;
        var stackTo = moveOperations[i][2] - 1;
        if (numberOfElementsToMove != 1)
        {
            var poppedItems = new char[numberOfElementsToMove];

            for (var k = 0; k < numberOfElementsToMove; k++)
            {
                poppedItems[k] = stacks[stackFrom].Pop();
            }

            for (var k = numberOfElementsToMove - 1; k >= 0; k--)
            {
                stacks[stackTo].Push(poppedItems[k]);
            }
        }

        if (numberOfElementsToMove == 1)
        {
            for (var j = 0; j < numberOfElementsToMove; j++)
            {
                var itemToMove = stacks[stackFrom].Pop();
                stacks[stackTo].Push(itemToMove);
            }
        }
    }

    var finalText = new StringBuilder();

    foreach (var stack in stacks)
    {
        finalText.Append(stack.Pop());
    }

    Console.WriteLine(finalText.ToString());
}

List<Stack<char>> GetStacks(string[] supplies, string[] lines)
{
    var stacks = new List<Stack<char>>();

    for (var i = 0; i < numberOfColumns; i++)
    {
        stacks.Add(new Stack<char>());

        for (var j = supplies.Length - 1; j >= 0; j--)
        {
            var valueToTake = i * 4 + 1;
            var crate = lines[j].ToCharArray()[valueToTake];
            if (crate == '[')
            {
                crate = lines[j].ToCharArray()[valueToTake + 1];
            }

            if (crate != ' ')
                stacks[i].Push(crate);
        }
    }

    return stacks;
}

Part1(moveOperations);

Part2(moveOperations);

Console.ReadKey();
