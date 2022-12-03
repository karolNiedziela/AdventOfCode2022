// See https://aka.ms/new-console-template for more information
using Day_2;

//-------------------- PART 1 --------------------

var pointsForWin = 6;
var pointsForDraw = 3;
var rock = "Rock";
var paper = "Paper";
var scissors = "Scissors";

var opponentPossibilities = new Dictionary<string, string>()
{
    { "A", rock },
    { "B", paper },
    { "C", scissors },
};

var myPossibilities = new Dictionary<string, Choice>
{
    { "X", new Choice(rock, 1) },
    { "Y", new Choice(paper, 2) },
    { "Z", new Choice(scissors, 3) },
};

var winningCombinations = new Dictionary<string, string>
{
    { "A", "Y" },
    { "B", "Z" },
    { "C", "X" }
};


var input = File.ReadAllText("input.txt");

var totalPoints = 0;

var rounds = input.Split(new string[] { "\r\n" }, StringSplitOptions.None);

foreach (var round in rounds)
{
    var choices = round.Split(" ");
    var opponentChoice = choices.First();
    var myChoice = choices.Last();
    var pointsForChoice = myPossibilities.FirstOrDefault(x => x.Key == myChoice).Value.Points;

    if (myPossibilities.FirstOrDefault(x => x.Key == myChoice).Value.Name == opponentPossibilities.FirstOrDefault(x => x.Key == opponentChoice).Value)
    {
        totalPoints += pointsForDraw;
        totalPoints += pointsForChoice;
        continue;
    }

    var winning = winningCombinations.FirstOrDefault(x => x.Key == opponentChoice);

    if (winning.Value == myChoice)
    {
        totalPoints += pointsForWin;
        totalPoints += pointsForChoice;
        continue;
    }

    totalPoints += pointsForChoice;
}

//-------------------- PART 2 --------------------

var resultsToOpponentChoice = new Dictionary<string, List<Part2Choice>>()
{
    { 
        "A",  
        new List<Part2Choice>
        {
            { new Part2Choice("X", "Z") },
            { new Part2Choice("Y", "X") },
            { new Part2Choice("Z", "Y") },
        }
    },
    {
        "B",
        new List<Part2Choice>
        {
            { new Part2Choice("X", "X") },
            { new Part2Choice("Y", "Y") },
            { new Part2Choice("Z", "Z") },
        }
    },
    {
        "C",
        new List<Part2Choice>
        {
            { new Part2Choice("X", "Y") },
            { new Part2Choice("Y", "Z") },
            { new Part2Choice("Z", "X") },
        }
    },
};

var partTwoTotalPoints = 0;

foreach (var round in rounds)
{
    var choices = round.Split(" ");
    var opponentChoice = choices.First();
    var resultToAchieve = choices.Last();

    var myAnswer = resultsToOpponentChoice
        .FirstOrDefault(x => x.Key == opponentChoice)
        .Value
        .FirstOrDefault(x => x.MyChoice == resultToAchieve)
        !.Answer;

    var pointsForChoice = myPossibilities.FirstOrDefault(x => x.Key == myAnswer).Value.Points;

    switch (resultToAchieve)
    {
        case "Y":
            partTwoTotalPoints += 3;
            break;

        case "Z":
            partTwoTotalPoints += 6;
            break;
    }

    partTwoTotalPoints += pointsForChoice;
}

Console.WriteLine(partTwoTotalPoints);

Console.ReadKey();