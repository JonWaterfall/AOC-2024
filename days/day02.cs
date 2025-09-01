/*
 * The task is to read each row in the input file and check that all numbers are in ascending or descending order
 * Additionally, any two adjacent numbers may not be the same or deffer by more than three
 * Count each row that is valid then report the total
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
                // +1 lets me avoid writing a check for zero
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