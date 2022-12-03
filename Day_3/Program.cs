var input = File.ReadAllText("input.txt");

//-------------------- PART 1 --------------------

var rucksacks = input.Split("\r\n");

var duplicates = new List<char>();

foreach (var rucksack in rucksacks)
{
    var rucksackLength = rucksack.Length;

    var firstCompartment = rucksack.Take(rucksackLength / 2).ToArray();
    var secondCompartment = rucksack.Skip(rucksackLength / 2).ToArray();

    var duplicatesInRucksack = firstCompartment.Where(x => secondCompartment.Contains(x)).Distinct().ToArray();

    duplicates.AddRange(duplicatesInRucksack);
}

// sumOfPriorities = ASCII Value - value in exercise
var sumOfPrioritiesForUpperCase = duplicates.Where(x => char.IsUpper(x)).Select(x => (int)x - 38).Sum();
var sumOfPrioritiesForLowerCase = duplicates.Where(x => char.IsLower(x)).Select(x => (int)x - 96).Sum();

var sumOfPriorities = sumOfPrioritiesForUpperCase + sumOfPrioritiesForLowerCase;

Console.WriteLine(sumOfPriorities);

//-------------------- PART 2 --------------------

var elvesGroups = rucksacks.Chunk(3);

var groupDuplicates = new List<char>();

foreach (var elvesGroup in elvesGroups)
{
    var duplicateInFirstAndSecondElf = elvesGroup[0].Where(x => elvesGroup[1].Contains(x)).Distinct().ToArray();
    var duplicateInSecondAndThirdElf = elvesGroup[1].Where(x => elvesGroup[2].Contains(x)).Distinct().ToArray();

    var duplicateInElfGroup = duplicateInFirstAndSecondElf.Where(x => duplicateInSecondAndThirdElf.Contains(x)).Distinct().ToArray();

    groupDuplicates.AddRange(duplicateInElfGroup);
}

var sumOfGroupPrioritiesForUpperCase = groupDuplicates.Where(x => char.IsUpper(x)).Select(x => (int)x - 38).Sum();
var sumOfGroupPrioritiesForLowerCase = groupDuplicates.Where(x => char.IsLower(x)).Select(x => (int)x - 96).Sum();

var sumOfGroupPriorities = sumOfGroupPrioritiesForUpperCase + sumOfGroupPrioritiesForLowerCase;

Console.WriteLine(sumOfGroupPriorities);

Console.ReadKey();