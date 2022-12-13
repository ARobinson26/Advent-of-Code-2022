string[] inputLines = File.ReadAllLines(
        "/Users/aaronrobinson/repos/Advent-of-Code-2022/Advent of Code" +
        " 2022 (.NET)/Day09/inputs.txt");

int[] headPosition = new int[2] { 0, 0 };
int[] tailPosition = new int[2] { 0, 0 };
List<string> uniqueTailPositions = new List<string>();
int ropeLength = 2;


foreach (string input in inputLines)
{
    string[] commands = input.Split(" ");
    string direction = commands[0];
    int movementAmount = Int32.Parse(commands[1]);

    for (int x = 0; x < movementAmount; x++)
    {
        switch (direction)
        {
            case "U":
                headPosition[1] += 1;
                break;

            case "D":
                headPosition[1] -= 1;
                break;

            case "L":
                headPosition[0] -= 1;
                break;

            case "R":
                headPosition[0] += 1;
                break;

            default:
                break;
        }

        //Head & tail are on the same line x-coordinate
        if (headPosition[0] == tailPosition[0])
        {
            //Head is 2 positions above tail
            if (headPosition[1] == tailPosition[1] + ropeLength)
            {
                tailPosition[1]++;
            }
            else
            {
                //Head is 2 positions below tail
                if (headPosition[1] == tailPosition[1] - ropeLength)
                {
                    tailPosition[1]--;
                }
            }
        }
        else
        {
            //Head & tail are on the same y-coordinate
            if (headPosition[1] == tailPosition[1])
            {
                //Head is 2 positions right of tail
                if (headPosition[0] == tailPosition[0] + ropeLength)
                {
                    tailPosition[0]++;
                }
                else
                {
                    //Head is 2 positions left of tail
                    if (headPosition[0] == tailPosition[0] - ropeLength)
                    {
                        tailPosition[0]--;
                    }
                }
            } else
            {

                //Head is more than two away on y axis
                if (Math.Abs(headPosition[1] - tailPosition[1]) == ropeLength)
                {
                    if (headPosition[1] > tailPosition[1])
                    {
                        tailPosition[1]++;
                    } else
                    {
                        tailPosition[1]--;
                    }
                    //tailPosition[1] += (headPosition[1] - tailPosition[1]) / 2;

                    if (headPosition[0] > tailPosition[0])
                    {
                        tailPosition[0]++;
                    } else
                    {
                        tailPosition[0]--;
                    }

                } else
                {
                    //Head is more than two away on x axis
                    if (Math.Abs(headPosition[0] - tailPosition[0]) == ropeLength)
                    {
                        if (headPosition[0] > tailPosition[0])
                        {
                            tailPosition[0]++;
                        }
                        else
                        {
                            tailPosition[0]--;
                        }

                        //tailPosition[0] += (headPosition[0] - tailPosition[0]) / 2;

                        if (headPosition[1] > tailPosition[1])
                        {
                            tailPosition[1]++;
                        }
                        else
                        {
                            tailPosition[1]--;
                        }
                    }

                }
            }
        }

        string tailPositionString = tailPosition[0] + "," + tailPosition[1];
        

        if (!uniqueTailPositions.Contains(tailPositionString))
        {
            uniqueTailPositions.Add(tailPositionString);
        }

    }

    
}
Console.WriteLine(uniqueTailPositions.Count());