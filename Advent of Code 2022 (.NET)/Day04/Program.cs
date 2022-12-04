class Program
{
    public static void Main(string[] args)
    {
        string[] inputLines = File.ReadAllLines(
            "/Users/aaronrobinson/repos/Advent-of-Code-2022/Advent of Code" +
            " 2022 (.NET)/Day04/inputs.txt");

        int pairsWithContainedZones = 0;
        int pairsWithOverlappingZones = 0;

        foreach (string inputLine in inputLines)
        {
             string[] elfPair = inputLine.Split(",");

            int zone1Start = int.Parse(elfPair[0].Split("-").First());
            int zone1End = int.Parse(elfPair[0].Split("-").Last());

            int zone2Start = int.Parse(elfPair[1].Split("-").First());
            int zone2End = int.Parse(elfPair[1].Split("-").Last());

            if(
                zone1Start >= zone2Start && zone1End <= zone2End ||
                zone2Start>= zone1Start && zone2End <= zone1End
                )
            {
                pairsWithContainedZones++;
            }

            if (
                zone1Start <= zone2Start && zone1End >= zone2Start ||
                zone2Start <= zone1Start && zone2End >= zone1Start
                )
            {
                pairsWithOverlappingZones++;
            }                        
        }

        Console.WriteLine(pairsWithContainedZones);
        Console.WriteLine(pairsWithOverlappingZones);

    }
}