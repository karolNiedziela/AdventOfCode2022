var input = File.ReadAllText("input");

var totalCaloriesCarriedByEachElf = input.Split(new string[] { "\r\n\r\n"}, StringSplitOptions.None)
    .Select(x => x.Split("\r\n", StringSplitOptions.None))
    .Select(x => Array.ConvertAll(x, int.Parse))
    .Select(x => x.Sum());

var highestCaloriesValue = totalCaloriesCarriedByEachElf.Max();

var elfIndexWithHighestCaloriesValue = totalCaloriesCarriedByEachElf.ToList().IndexOf(highestCaloriesValue) + 1;

var totalCaloriesOfTop3Efles = totalCaloriesCarriedByEachElf.OrderByDescending(x => x).Take(3).Sum();

Console.ReadKey();