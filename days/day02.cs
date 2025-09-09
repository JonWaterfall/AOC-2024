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
                    break;
                }

                int num1 = Int32.Parse(splitLine[i]);
                int num2 = Int32.Parse(splitLine[i + 1]);
                if (num1 == num2 || Math.Abs(num1 - num2) > 3)
                {
                    // bypass validLines increment without using goto keyword
                    isAscending = false;
                    isDescending = false;
                    break;
                }
            }
            if (isAscending || isDescending)
            {
                // Console.WriteLine($"Valid line found {line}");
                validLines++;
            }
        }

        return validLines;
    }

    public static int Part2(string filePath)
    {
        int validLines = 0;
        int ascentCount;
        int descentCount; // potential issue with first entry error?
        int duplicateCount;
        using StreamReader r = new StreamReader(filePath);
        string? line;

        while ((line = r.ReadLine()) != null)
        {
            ascentCount = 0;
            descentCount = 0;
            duplicateCount = 0;
            string[] splitLineString = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            List<int> splitLineInt = new List<int>(splitLineString.Length);

            // parse once to make reading easier.
            for (int i = 0; i < splitLineString.Length; i++)
            {
                splitLineInt.Add(Int32.Parse(splitLineString[i]));
            }

            //first pass
            for (int i = 0; i < splitLineInt.Count - 1; i++)
            {
                if (splitLineInt[i] > splitLineInt[i + 1])
                    ascentCount++;
                else if (splitLineInt[i] < splitLineInt[i + 1])
                    descentCount++;
                else if (splitLineInt[i] == splitLineInt[i + 1])
                    duplicateCount++;
            }

            // discard line if too many errors
            if (duplicateCount > 1)
                continue;
            else if ((ascentCount < descentCount) && ((ascentCount + duplicateCount) > 1))
                continue;
            else if ((ascentCount > descentCount) && ((descentCount + duplicateCount) > 1))
                continue;

            //second pass
            if (IsValidLine(splitLineInt))
            {
                validLines++;
                continue;
            }
            for (int i = 0; i < splitLineInt.Count; i++)
            {
                List<int> miniList = splitLineInt.ExceptIndex(i);
                if (IsValidLine(miniList))
                {
                    validLines++;
                    break;
                }
            }
        } // while ((line = r.ReadLine()) != null)

        return validLines;
    }

    private static bool IsValidLine(List<int> intLine)
    {
        bool isAscending = true;
        bool isDescending = true;

        for (int i = 0; i < intLine.Count - 1; i++)
        {
            if (intLine[i] > intLine[i + 1])
            {
                isAscending = false;
            }
            else if (intLine[i] < intLine[i + 1])
            {
                isDescending = false;
            }
            if (!isAscending && !isDescending)
            {
                return false;
            }

            // check for same or too far off
            int num1 = intLine[i];
            int num2 = intLine[i + 1];
            if (num1 == num2 || Math.Abs(num1 - num2) > 3)
            {
                return false;
            }
        }
        return true;
    }
}