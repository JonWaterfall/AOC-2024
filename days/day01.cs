/*
 * Simple parse and compare task.
 * Each line of the input file has two numbers that originate from two different lists.
 * Said lists were unsorted before being put together and need to be sorted.
 * Accending or decending doesn't matter as long as they both get sorted the same way.
 * After sorting we find the difference between each entry and sum the differences.
 *
 * Part 2 did not require the lists to be sorted.
 * instead of checking difference we now calculate an exponentially scaling similarity score.
 *
 * I could have extracted the while loop that parsed the input into a private function, 
 * but part2 was so fast to solve, and the code is so short that duplicating it wasn't seen as that bad.
 *
 * I thought about implementing a Quicksort in place function but the default Sort() function makes for easier to read code
 */

static class Day01
{
    public static int Part1(string filePath)
    {
        using StreamReader r = new StreamReader(filePath);

        LinkedList<int> firstList = new();
        LinkedList<int> secondList = new();
        string? line;
        int lineNum = 0;

        while ((line = r.ReadLine()) != null)
        {
            lineNum++;
            string[] splitLine = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (splitLine.Length == 0)
            {
                break;
            }
            else if (splitLine.Length != 2)
            {
                throw new System.Exception($"Input file error: Line {lineNum} did not have the expected non-blank entries.");
            }

            // I had a thought to have some form of sort in place function usage, but converting and using the default sort method does what I want.
            firstList.AddLast(Int32.Parse(splitLine[0]));
            secondList.AddLast(Int32.Parse(splitLine[1]));
        }

        List<int> firstSorted = firstList.ToList();
        firstSorted.Sort();
        List<int> secondSorted = secondList.ToList();
        secondSorted.Sort();
        int distance = 0;

        for (int i = 0; i < lineNum; i++)
        {
            //Console.WriteLine($"first:{firstSorted[i]}   second:{secondSorted[i]}");
            distance += Math.Abs(firstSorted[i] - secondSorted[i]);
        }


        return distance;
    }

    public static int Part2(string filePath)
    {
        using StreamReader reader = new StreamReader(filePath);

        LinkedList<int> firstList = new();
        LinkedList<int> secondList = new();
        string? line;
        int lineNum = 0;

        while ((line = reader.ReadLine()) != null)
        {
            lineNum++;
            string[] splitLine = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (splitLine.Length == 0)
            {
                break;
            }
            else if (splitLine.Length != 2)
            {
                throw new System.Exception($"Input file error: Line {lineNum} did not have the expected non-blank entries.");
            }

            // I had a thought to have some form of sort in place function usage, but converting and using the default sort method does what I want.
            firstList.AddLast(Int32.Parse(splitLine[0]));
            secondList.AddLast(Int32.Parse(splitLine[1]));
        }

        int similarityScore = 0;
        int simTemp;

        for (int r = 0; r < lineNum; r++)
        {
            simTemp = 0;
            for (int l = 0; l < lineNum; l++)
            {
                if (firstList.ElementAt(r) == secondList.ElementAt(l))
                {
                    simTemp++;
                }
            }
            similarityScore += firstList.ElementAt(r) * simTemp;
        }


        return similarityScore;
    }
}