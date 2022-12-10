string[] inputLines = File.ReadAllLines(
        "/Users/aaronrobinson/repos/Advent-of-Code-2022/Advent of Code" +
        " 2022 (.NET)/Day08/inputs.txt");

List<List<int>> rows = new List<List<int>>();

foreach (string line in inputLines)
{
    List<int> row = new List<int>();

    foreach (char tree in line.ToCharArray())
    {
        row.Add(Int32.Parse(tree.ToString()));
    }

    rows.Add(row);

}


int visibleTrees = 0;//(rows.Count() * 2);
int rowPointer = 0;
int visibleHighScore = 0;

//For each row
for (int y=0; y<rows.Count(); y++)
{

    List<int> row = rows[y];
    //For each tree in row that isn't on the ends
    for (int i=0; i<row.Count(); i++)
    {
        bool visibleFromLeft = true;
        bool visibleFromRight = true;
        bool visibleFromTop = true;
        bool visibleFromBottom = true;

        int visibleTreesToLeft = 0;
        int visibleTreesToRight = 0;
        int visibleTreesToTop = 0;
        int visibleTreesToBottom = 0;

        int visibilityScore = 0;

        //bool blockedLeft = false;
        //bool blockedRight;
        //bool blockedTop;
        //bool blockedBottom;


        if (i != 0)
        {
            //Check each tree to the left
            for (int x = i - 1; x >= 0; x--)
            {
                if (visibleFromLeft == true)
                {
                    visibleTreesToLeft++;
                }

                if (row[x] >= row[i])
                {
                    visibleFromLeft = false;
                }
            }
        }

        if (i != row.Count()-1)
        {
            //Check each tree to the right
            for (int x = i + 1; x <= row.Count() - 1; x++)
            {
                if (visibleFromRight == true)
                {
                    visibleTreesToRight++;
                }

                if (row[x] >= row[i])
                {
                    visibleFromRight = false;
                }
            }
        }

        if (rowPointer != 0)
        {
            //Check each tree to the top
            for (int x = rowPointer-1; x >= 0; x--)
            {
                if (visibleFromTop == true)
                {
                    visibleTreesToTop++;
                }

                if (rows[x][i] >= row[i])
                {
                    visibleFromTop = false;
                }
            }
        }

        if (rowPointer != rows.Count()-1)
        {
            //Check each tree to the bottom
            for (int x = rowPointer+1; x <= rows.Count() - 1; x++)
            {
                if (visibleFromBottom == true)
                {
                    visibleTreesToBottom++;
                }

                if (rows[x][i] >= row[i])
                {
                    visibleFromBottom = false;
                }
            }
        }

        if (visibleFromLeft == true || visibleFromRight == true ||
                visibleFromTop == true || visibleFromBottom == true)
        {
            visibleTrees++;
        }

        visibilityScore =
            visibleTreesToTop *
            visibleTreesToLeft *
            visibleTreesToRight *
            visibleTreesToBottom;

        if (visibilityScore > visibleHighScore)
        {
            visibleHighScore = visibilityScore;
        }
    }
    rowPointer++;
}

Console.WriteLine(visibleTrees);
Console.WriteLine(visibleHighScore);