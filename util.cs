

static class Util
{
    // expects file to only contain UTF-16 characters
    // returns null when something went wrong.
    static string? ReadFileToString(string path)
    {
        try
        {
            return File.ReadAllText(path);
        }
        catch (System.Exception e)
        {
            Console.Write(e.Message);
            return null;
            throw;
        }
    }
}