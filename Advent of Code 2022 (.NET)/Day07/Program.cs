using Day07;

class Program
{
    public static void Main(string[] args)
    {

        ElfDirectory topDirectory = new ElfDirectory("/");
        ElfDirectory? currentDirectory = topDirectory;


        string[] inputStream = File.ReadAllLines(
        "/Users/aaronrobinson/repos/Advent-of-Code-2022/Advent of Code" +
        " 2022 (.NET)/Day07/inputs.txt");

        int currentLine = 0;

        while (currentLine < inputStream.Length-1)
        {

            string[] line = inputStream[currentLine].Split(" ");


            if (line[0] == "$" && currentDirectory != null)
            {
                switch (line[1])
                {
                    case "cd":
                        currentDirectory = ChangeDirectory(topDirectory, currentDirectory, line[2]);
                        currentLine++;
                        break;

                    case "ls":
                        currentLine++;

                        while (currentLine < inputStream.Length  && !inputStream[currentLine].StartsWith("$"))
                        {
                            string[] lineParts = inputStream[currentLine].Split(" ");

                            if (lineParts[0] == "dir")
                            {
                                AddDirectory(currentDirectory, lineParts[1]);
                            } else
                            {
                                AddFile(currentDirectory, Int32.Parse(lineParts[0]), lineParts[1]);
                            }

                            currentLine++;
                        }
                        break;

                    default:
                        break;
                }
            }
            else
            {
                currentLine++;
            }

        }



        int part1Answer = GetSizeUnder100000(topDirectory);

        List<int> orderedSizeList = GetSizeList(topDirectory);

        orderedSizeList.Sort();

        int spaceRemaining = 70000000 - topDirectory.GetSize();

        int spaceRequired = 30000000 - spaceRemaining;

        int part2Answer = orderedSizeList.Find(x => x >= spaceRequired);

     }

    public static ElfDirectory? ChangeDirectory(ElfDirectory topDirectory, ElfDirectory currentDirectory, string targetDirectory)
    {

        switch (targetDirectory)
        {
            case "/":
                return topDirectory;


            case "..":
                return currentDirectory.GetParentDirectory();

            default:
                return currentDirectory.GetDirectories()
                    .Find(x => x.GetName() == targetDirectory);
        }

    }

    public static void AddDirectory(ElfDirectory currentDirectory, string directoryName)
    {
        currentDirectory.AddChildDirectory(new ElfDirectory(directoryName, currentDirectory));
    }

    public static void AddFile(ElfDirectory currentDirectory, int fileSize, string fileName)
    {
        currentDirectory.AddFile(new ElfFile(fileName, fileSize));
    }

    public static int GetSizeUnder100000(ElfDirectory directory)
    {

        int total = 0;

        int directorySize = directory.GetSize();

        Console.WriteLine(directory.GetName() + " " + directorySize);

        if (directorySize < 100000)
        {
            total += directorySize;
        }
        

        foreach(ElfDirectory childDirectory in directory.GetDirectories())
        {
            total += GetSizeUnder100000(childDirectory);
        }

        return total;
    }

    public static List<int> GetSizeList(ElfDirectory directory)
    {

        List<int> sizes = new List<int>();

        int directorySize = directory.GetSize();

        Console.WriteLine(directory.GetName() + " " + directorySize);
        
        sizes.Add(directorySize);
        
        foreach (ElfDirectory childDirectory in directory.GetDirectories())
        {
            foreach(int size in GetSizeList(childDirectory))
            {
                sizes.Add(size);
            }
        }

        return sizes;
    }
}





