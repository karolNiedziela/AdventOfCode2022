var lines = File.ReadAllLines("input.txt");

var xHeadPosition = 0;
var yHeadPosition = 0;
var xTailPosition = 0;
var yTailPosition = 0;

var tailPositions = new HashSet<string>
{
    "00"
};

foreach (var line in lines)
{
    var splittedLine = line.Split(" ");
    var direction = splittedLine[0];
    var numberOfShifts = int.Parse(splittedLine[1]);

    for (var i = 0; i < numberOfShifts; i++)
    {
        int prevXHeadPosition = xHeadPosition;
        int prevYHeadPosition = yHeadPosition;

        switch (direction)
        {
            case "U":            
                yHeadPosition++;           
                break;
            case "D":
                yHeadPosition--;             
                break;
            case "R":          
                xHeadPosition++;
                break;
            case "L":            
                xHeadPosition--;
                break;
        }
        Console.WriteLine($"Head: [{xHeadPosition}] [{yHeadPosition}]");

        var oneApartFromEachOther = xHeadPosition == xTailPosition && (yHeadPosition == yTailPosition || Math.Abs(yHeadPosition - yTailPosition) == 1) || 
            (yHeadPosition == yTailPosition && (yHeadPosition == yTailPosition || Math.Abs(xHeadPosition - xTailPosition) == 1));
        if (oneApartFromEachOther)
        {
            continue;
        }

        var covers = Math.Abs(yHeadPosition - yTailPosition) == 1 && Math.Abs(xHeadPosition - xTailPosition) == 1;
        if (covers)
        {
            continue;
        }

        xTailPosition = prevXHeadPosition;
        yTailPosition = prevYHeadPosition;

        tailPositions.Add($"{xTailPosition.ToString()}{yTailPosition.ToString()}");

        Console.WriteLine($"Tail: [{xTailPosition}] [{yTailPosition}]");
    }
}



var positionVisited = tailPositions.Count();

Console.ReadKey();