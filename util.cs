

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
}