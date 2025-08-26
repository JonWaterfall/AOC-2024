// See https://aka.ms/new-console-template for more information

class MyProgram
{
static int Main(string[] args)
{
    String? argstring = args.ToString();
    if (argstring == null)
    {
        Console.WriteLine("whole number 1-25 required as an argument");
        return 1;
    }
    try
    {
        int daytorun = Int32.Parse(argstring);

        // run the calendar day code
    }
    catch (System.Exception e)
    {
        Console.WriteLine("whole number 1-25 required as an argument");
        Console.WriteLine(e.Message);
        return 1;
        throw;
    }

    return 0;
}
}