/*
 * The task is to read each row in the input file and check that all numbers are in ascending or descending order
 * Additionally, any two adjacent numbers may not be the same or differ by more than three
 * Count each row that is valid then report the total
 *
 * Part 2 lets us remove a single number from a line in the input and re-evaluate it. 
 * I have to assume that if the second number is removed that whether a line is ascending or descending might change.
 * ex: 7 9 6 5 4 can be valid by removing the 9, and the line changes from ascending to descending.
 *
 * I think the "simplest" would be to just brute force check every removal. Not optimal but makes for easier to read code.
 * 
 */

static class Day02
{
    public static int Part1(string filePath)
    {
        int validLines = 0;
        bool isAscending;
        bool isDescending;
        using StreamReader r = new StreamReader(filePath);
        string? line;

        while ((line = r.ReadLine()) != null)
        {
            string[] splitLine = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            isAscending = true;
            isDescending = true;

            for (int i = 0; i < splitLine.Length - 1; i++)
            {
                if (Int32.Parse(splitLine[i]) > Int32.Parse(splitLine[i + 1]))
                {
                    isAscending = false;
                }
                else if (Int32.Parse(splitLine[i]) < Int32.Parse(splitLine[i + 1]))
                {
                    isDescending = false;
                }
                if (!isAscending && !isDescending)
                {
                    // At school I was taught to "never" use goto in c/c++. 
                    // But because I can't break to an outer loop like in Rust, goto seems polite enough for that usecase.
                    goto skipLine;
                }
                
                int num1 = Int32.Parse(splitLine[i]);
                int num2 = Int32.Parse(splitLine[i + 1]);
                if (num1 == num2 || Math.Abs(num1 - num2) > 3)
                {
                    goto skipLine;
                }
            }
            if (isAscending || isDescending)
            {
                // Console.WriteLine($"Valid line found {line}");
                validLines++;
            }
        skipLine:;
        }

        return validLines;
    }
 }