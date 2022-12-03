class Program
{
    public static void Main(string[] args)
    {
        string[] rucksacks = File.ReadAllLines(
            "/Users/aaronrobinson/repos/Advent-of-Code-2022/Advent of Code" +
            " 2022 (.NET)/Day03/inputs.txt");

        List<char> compartment1 = new List<char>();
        List<char> compartment2 = new List<char>();
        
        List<char> duplicateItems = new List<char>();
        List<char> duplicateBadges = new List<char>();

        int linePointer = 1;

        int priorityTotal = 0;
        int badgeTotal = 0;

        foreach (string rucksack in rucksacks)
        {
            //On every third line, look for common items in three rucksacks.
            if (linePointer % 3 == 0)
            {
                foreach(char item in rucksack.ToCharArray())
                {
                    if (rucksacks[linePointer - 3].ToCharArray().Contains(item)
                        &&
                        rucksacks[linePointer - 2].ToCharArray().Contains(item)
                        &&
                        !duplicateBadges.Contains(item)
                        )
                    {
                        duplicateBadges.Add(item);

                        badgeTotal += GetPriorityValue(item);   
                    }
                }

                duplicateBadges.Clear();
            }

            compartment1.Clear();
            compartment2.Clear();
            duplicateItems.Clear();

            int backpackSize = rucksack.Length / 2;

            //Adds each item from the rucksack into correct compartment array.
            for (int x=0; x<backpackSize; x++)
            {
                compartment1.Add(rucksack.ToCharArray()[x]);
                compartment2.Add(rucksack.ToCharArray()[x+backpackSize]);
            }

            //Look for common items in both compartments of backpack.
            foreach (char item in compartment1)
            {
                if (compartment2.Contains(item) && !duplicateItems.Contains(item))
                {
                    duplicateItems.Add(item);

                    priorityTotal += GetPriorityValue(item);
                } 
            }

            linePointer++;
        }

        Console.WriteLine(priorityTotal);
        Console.WriteLine(badgeTotal);
    }

    //Returns the 'priority' value by converting ASCII value.
    public static int GetPriorityValue(char item)
    {
        if (item <= 90)
        {
            return (item - 38);
        }
        else
        {
            return (item - 96);
        }
    }
};

