string inputStream = File.ReadAllText(
            "/Users/aaronrobinson/repos/Advent-of-Code-2022/Advent of Code" +
            " 2022 (.NET)/Day06/inputs.txt");
Queue<char> lastFour = new Queue<char>(4);
Queue<char> lastFourteen = new Queue<char>(14);
int marker = 0;
int marker2 = 0;

//------------
//PART ONE
//------------
while (lastFour.Distinct().Count() != 4)
{
        if (lastFour.Count() == 4)
        {
            lastFour.Dequeue();
        }

    lastFour.Enqueue(char.Parse(inputStream.Substring(marker, 1)));
    marker++;   
}

//------------
//PART TWO
//------------
while (lastFour.Distinct().Count() != 14)
{
    if (lastFour.Count() == 14)
    {
        lastFour.Dequeue();
    }

    lastFour.Enqueue(char.Parse(inputStream.Substring(marker2, 1)));
    marker2++;
}

    Console.WriteLine(marker);
    Console.WriteLine(marker2);
