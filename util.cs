

static class Util
{
    public struct FileData(string s, int i)
    {
        public string inputtext = s;
        public int lineCount = i;
    }

    // expects file to only contain UTF-16 characters
    // entire file will be read once to count the number of lines
    public static FileData ReadFileToString(string path)
    {
        try
        {
            using StreamReader r = new StreamReader(path);

            string totalText = "";
            int lineCount = 0;
            string? line = r.ReadLine();
            while (line != null)
            {
                lineCount++;
                totalText += line;

                line = r.ReadLine();
            }
            return new FileData(totalText, lineCount);
        }
        catch (System.Exception e)
        {
            Console.Write(e.Message);
            throw;
        }
    }

    // Returns a copy of the List but with the element at the given index removed.
    // Throws an exception if index is out of bounds.
    //
    // Decided during day02 part2 to make this extenstion function for List<T>
    // as I didn't find exactly what I was looking for in the list of default member functions.
    // I wanted something similar to Enumerable.Except() but instead of excluding a value which can appear multiple times, I wanted to exclude a spesific element by index.
    public static List<T> ExceptIndex<T>(this List<T> originList, int index)
    {
        if (index < 0 || index >= originList.Count)
        {
            throw new System.Exception("Index must be within range of List<T>.Count");
        }

        List<T> newList = new List<T>(originList.Count - 1);
        int itterator = 0;
        while (itterator < index)
        {
            newList.Add(originList[itterator]);
            itterator++;
        }
        //skip the exception
        itterator++;
        while (itterator < originList.Count)
        {
            newList.Add(originList[itterator]);
            itterator++;
        }

        if (newList.Count != originList.Count - 1)
        {
            throw new System.Exception($"I fucked up the implementation of the ExceptIndex method. expected count of {originList.Count - 1}, got {newList.Count}");
        }

        return newList;
    }
}