using Day_11;
using System.Numerics;

var lines = File.ReadAllLines("input.txt").Where(l => !string.IsNullOrWhiteSpace(l));

var chunkedLinesMonkeys = lines.Chunk(6);

var monkeys = new List<Monkey>();

var isPartOne = true;

foreach (var lineMonkey in chunkedLinesMonkeys)
{
    var monkey = new Monkey
    {
        Id = int.Parse(lineMonkey[0].Split("Monkey").Last().Trim().Replace(":", string.Empty)),
        Items = lineMonkey[1].Split("Starting items:").Last().Trim().Split(",").Select(x => int.Parse(x.Trim())).ToList(),
        TextOperation = lineMonkey[2].Split("Operation: new = ").Last(),
        Divider = int.Parse(lineMonkey[3].Split("Test: divisible by ").Last()),
        InspectedItems = 0
    };    
    var throwToMonkeyWhenTrue = int.Parse(lineMonkey[4].Trim().Split("If true: throw to monkey ").Last());
    var throwToMonkeyWhenFalse = int.Parse(lineMonkey[5].Trim().Split("If false: throw to monkey ").Last());

    monkey.ThrowToMonkey.AddRange( new  List<int> { throwToMonkeyWhenTrue, throwToMonkeyWhenFalse });
    monkeys.Add(monkey);
}

var rounds = isPartOne ? 20 : 1000;
for (var i = 0; i < rounds; i++)
{
    foreach (var monkey in monkeys)
    {
        foreach (var monkeyItem in monkey.Items)
        {
            var afterOperationValue = isPartOne ? GetResultFromOperation(monkey.TextOperation, monkeyItem) / 3 : GetResultFromOperation(monkey.TextOperation, monkeyItem);            

            GiveItemToMonkey(afterOperationValue, monkey);

            monkey.InspectedItems++;
        }

        monkey.Items.Clear();
    }
}

int GetResultFromOperation(string textOperation, int item)
{
    var splittedTextOperation = textOperation.Split(" ");
    var operation = splittedTextOperation[1];
    var firstArgument = splittedTextOperation.First() == "old" ? item : int.Parse(splittedTextOperation.First());
    var secondArgument = splittedTextOperation.Last() == "old" ? item : int.Parse(splittedTextOperation.Last());

    switch (operation)
    {
        case "*":
            return firstArgument * secondArgument;

        case "+":
            return firstArgument + secondArgument;
    }

    return 0;
}

void GiveItemToMonkey(int afterOperationValue, Monkey monkey)
{
    var monkeyIdWhichReceiveItem = afterOperationValue % monkey.Divider == 0 ? monkey.ThrowToMonkey[0] : monkey.ThrowToMonkey[1];
    var receivingMonkey = monkeys!.First(x => x.Id == monkeyIdWhichReceiveItem);
    receivingMonkey.Items.Add(afterOperationValue);
}

var twoMonkeysWithHighestInspectedItemsNumber = monkeys.OrderByDescending(x => x.InspectedItems).Take(2).Select(x => x.InspectedItems);
var monkeyBusiness = twoMonkeysWithHighestInspectedItemsNumber.First() * twoMonkeysWithHighestInspectedItemsNumber.Last();

Console.ReadKey();