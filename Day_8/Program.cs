var lines = File.ReadAllLines("input.txt");


var rows = lines.Count();
var columns = lines[0].Length;

var treeMap = new int[rows, columns];

for (var i = 0; i < rows; i++)
{
    for (var j = 0; j < columns; j++)
    {
        treeMap[i, j] = int.Parse(lines[i][j].ToString());
    }
}

var visibleTrees = (rows * 2) + (columns * 2) - 4;
var heighestScenicScore = 0;

for (var i = 1; i < rows - 1; i++)
{
    for (var j = 1; j < columns - 1; j++)
    {
        var currentElement = treeMap[i, j];
        var currentColumn = Enumerable.Range(0, treeMap.GetLength(0))
               .Select(x => treeMap[x, j])
               .ToArray();
        var elementsInColumnBeforeCurrentElement = currentColumn[0..i];
        var elementsInColumnAfterCurrentElement = currentColumn[(i + 1)..columns];

        var currentRow = Enumerable.Range(0, treeMap.GetLength(1))
                .Select(x => treeMap[i, x])
                .ToArray();
        var elementsInRowBeforeElement = currentRow[0..j];
        var elementsInRowAfterCurrentElement = currentRow[(j + 1)..rows];

        var isVisibleFromLeft = elementsInRowBeforeElement.All(x => x < currentElement);
        var isVisibleFromRight = elementsInRowAfterCurrentElement.All(x => x < currentElement);
        var isVisibleFromTop = elementsInColumnBeforeCurrentElement.All(x => x < currentElement);
        var isVisibleFromBottom = elementsInColumnAfterCurrentElement.All(x => x < currentElement);

        if (isVisibleFromRight || isVisibleFromLeft || isVisibleFromBottom || isVisibleFromTop)
        {
            visibleTrees++;
        }

        var left = 0; 
        for (var l = j - 1; l >= 0; l--)
        {
            if (treeMap[i, l] >= currentElement)
            {
                left++;
                break;
            }

            left++;
        }

        var right = 0;
        for (var r = j + 1; r < columns; r++)
        {
            if (treeMap[i, r] >= currentElement)
            {
                right++;
                break;
            }

            right++;
        }

        var top = 0;
        for (var t = i - 1; t >= 0; t--)
        {
            if (treeMap[t, j] >= currentElement)
            {
                top++;
                break;
            }

            top++;
        }

        var bottom = 0;
        for (var b = i + 1; b < rows; b++)
        {
            if (treeMap[b, j] >= currentElement)
            {
                bottom++;
                break;
            }

            bottom++;
        }

        var scenicScore = left * right * top * bottom;
        heighestScenicScore = Math.Max(heighestScenicScore, scenicScore);      
    }
}

Console.ReadKey();