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

        //var left = Array.FindIndex(currentRow, 0, j, x => x == elementsInRowBeforeElement.FirstOrDefault(x => x >= currentElement));
        //left = left > -1 ? currentRow[left..j].Length : elementsInRowBeforeElement.Length;

        //var right = Array.FindIndex(currentRow, j, x => x == elementsInRowAfterCurrentElement.FirstOrDefault(x => x >= currentElement));
        //right = right > -1 ? currentRow[j..right].Length : elementsInRowAfterCurrentElement.Length;

        //var top = Array.FindIndex(currentColumn, 0, i, x => x == elementsInColumnBeforeCurrentElement.FirstOrDefault(x => x >= currentElement));
        //top = top > -1 ? currentColumn[top..i].Length : elementsInColumnBeforeCurrentElement.Length;
        //var bottom = Array.FindIndex(currentColumn, i, x => x == elementsInColumnAfterCurrentElement.FirstOrDefault(x => x >= currentElement));
        //bottom = bottom > -1 ? currentColumn[i..bottom].Length : elementsInColumnAfterCurrentElement.Length;

        //var scenicScore = left * right * top * bottom;
        //if (scenicScore > heighestScenicScore)
        //{
        //    heighestScenicScore = scenicScore;
        //}

        if (isVisibleFromRight || isVisibleFromLeft || isVisibleFromBottom || isVisibleFromTop)
        {
            visibleTrees++;
        }
    }
}

//left = 14 right = 10 up = 52 down = 46

Console.ReadKey();