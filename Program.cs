// See https://aka.ms/new-console-template for more information

class MyProgram
{
static int Main(string[] args)
{
    if (args.Length == 0)
    {
        Console.WriteLine("No argument found. Number+letter [1-25][a-b] required as the first argument");
        return 1;
    }
    String dayToRun = args[0];
    try
    {
        // run the calendar day code
        switch (dayToRun)
        {
            case "1a":
                Console.WriteLine(Day01.Part1("./inputs/day01input.txt"));
                break;
            case "1b":
                Console.WriteLine(Day01.Part2("./inputs/day01input.txt"));
                break;
            case "2a":
                Console.WriteLine(Day02.Part1("./inputs/day02input.txt"));
                break;
            default:
                Console.WriteLine("Invalid argument. Number+letter [1-25][a-b] required as the first argument");
                return 1;
        }
    }
    catch (System.Exception e)
    {
        Console.WriteLine(e.Message);
        return 1;
    }

    return 0;
}
}