class Program
{
    public static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines("/Users/aaronrobinson/repos/Advent-of-Code-2022/Advent of Code 2022 (.NET)/Day03/inputs.txt");
        List<char> backpack1 = new List<char>();
        List<char> backpack2 = new List<char>();
        int priorityTotal = 0;
        int lineCounter = 1;
        List<char> duplicates = new List<char>();
        List<char> duplicateBadges = new List<char>();
        int badgeTotal = 0;
        

        foreach (string line in lines)
        {

            //On every third line
            if (lineCounter % 3 == 0)
            {
                foreach(char item in line.ToCharArray())
                {
                    if (lines[lineCounter - 3].ToCharArray().Contains(item)
                        && lines[lineCounter - 2].ToCharArray().Contains(item)
                        && !duplicateBadges.Contains(item)
                        )
                    {
                        duplicateBadges.Add(item);
                        if (item <= 90)
                        {
                            badgeTotal += (item - 38);
                        }
                        else
                        {
                            badgeTotal += (item - 96);
                        }
                    }
                }
                duplicateBadges.Clear();
            }


            backpack1.Clear();
            backpack2.Clear();
            duplicates.Clear();

            int backpackSize = line.Length / 2;

            for (int x=0; x<(backpackSize); x++)
            {
                backpack1.Add(line.ToCharArray()[x]);
                backpack2.Add(line.ToCharArray()[x+backpackSize]);
            }

            foreach (char item in backpack1)
            {
                

                if (backpack2.Contains(item) && !duplicates.Contains(item))
                {
                    duplicates.Add(item);

                    if (item <= 90)
                    {
                        priorityTotal += (item - 38);
                    } else
                    {
                        priorityTotal += (item - 96);
                    }
                }

                
            }
            lineCounter++;
        }


        Console.WriteLine(priorityTotal);
        Console.WriteLine(badgeTotal);
    }
};

