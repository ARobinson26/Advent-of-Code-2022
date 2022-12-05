// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;
using System.IO;

string[] inputLines = File.ReadAllLines(
            "/Users/aaronrobinson/repos/Advent-of-Code-2022/Advent of Code" +
            " 2022 (.NET)/Day05/inputs.txt");

int linePointer = 0;
string currentLine = inputLines[linePointer];

int stackCount = (inputLines[linePointer].Length + 1) / 4;
List<char> [] stacks = new List<char>[stackCount];


//Get Stacks as-is
while (currentLine != "")
{
    int stackPointer = 0;
    for (int i = 0; i<currentLine.Length; i+=4)
    {
        if (currentLine.Substring(i + 1, 1) != " " && char.Parse(currentLine.Substring(i + 1, 1)) > 64 )
        {
            if (stacks[stackPointer] == null)
            {
                stacks[stackPointer] = new List<char>();
            };

            stacks[stackPointer].Add(char.Parse(currentLine.Substring(i + 1, 1)));
        }
        
        stackPointer++;
    }

    linePointer++;
    currentLine = inputLines[linePointer];
}

linePointer++;

foreach(List<char> stack in stacks)
{
    stack.Reverse();
}

while(linePointer < inputLines.Length){
    string[] inputLineSplit = inputLines[linePointer].Split(" ");

    int moveQuantity = Int32.Parse(inputLineSplit[1]);
    List<char> fromStack = stacks[Int32.Parse(inputLineSplit[3])-1];
    List<char> toStack = stacks[Int32.Parse(inputLineSplit[5])-1];

    //----------------
    //PART ONE:
    //----------------
    //for (int i = 0; i<moveQuantity; i++)
    //{
    //    toStack.Add(fromStack.Last());
    //    fromStack.RemoveAt(fromStack.Count-1);
    //};

    //----------------
    //PART TWO
    //----------------
    toStack.AddRange(
            fromStack.TakeLast(moveQuantity));

    fromStack.RemoveRange(fromStack.Count-moveQuantity, moveQuantity);

    linePointer++;
}

foreach(List<char> stack in stacks)
{
    Console.Write(stack.Last().ToString());
}