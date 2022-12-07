var lines = File.ReadAllLines("input.txt");

var pathChanges = new List<string>();
var directorySizes = new Dictionary<string, int>();
var fileNameToSize = new Dictionary<string, string>();

long totalFileSize = 0;

foreach (var line in lines)
{
    var splittedLine = line.Split(" ");
    if (splittedLine[0] == "dir")
    {
        continue;
    }

    if (splittedLine[0] == "$")
    {
        var command = line.Split(" ");

        if (command[1] == "ls")
        {
            continue;
        }

        if (command[1] == "cd" && command[2] == "..") 
        {
            pathChanges.RemoveAt(pathChanges.Count - 1);
            continue;
        }

        pathChanges.Add(command[2]);
        continue;
    }

    var directory = string.Join("/", pathChanges);
    directory = directory.Replace("//", "/");
    var file = line.Split(" ");
    totalFileSize += int.Parse(file[0]);
    if (!fileNameToSize.ContainsKey(file[1]))
    {
        fileNameToSize.Add(file[1], file[0]);
    }

    if (!directorySizes.ContainsKey(directory))
    {
        directorySizes[directory] = 0;
    }


    while (directory.Contains("/"))
    {
        if (directory == "/")
        {
            break;
        }

        if (!directorySizes.ContainsKey(directory))
        {
            directorySizes[directory] = 0;
        }
        directorySizes[directory] += int.Parse(file[0]);

        var parentDirectory = directory.Split("/").ToList();
        parentDirectory.RemoveAt(parentDirectory.Count - 1);
        directory = string.Join("/", parentDirectory);
    }
}

long totalFileSizesAtMost100000Size = directorySizes.Where(x => x.Value < 100000).Sum(x => x.Value);

var fileSystemSpace = 70000000;
var updateSpace = 30000000;
var requiredSpaceForUpdate = updateSpace - (fileSystemSpace - totalFileSize);
var directoryToRemoveSize = directorySizes
    .Where(x => x.Key != "/" 
        && x.Value > requiredSpaceForUpdate)
    .MinBy(x => x.Value)
    .Value;

Console.ReadKey();
