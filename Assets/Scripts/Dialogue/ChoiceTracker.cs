using System.Collections.Generic;

public static class ChoiceTracker
{
    public static List<string> chosenOptions = new List<string>();

    public static void RecordChoice(string choice)
    {
        if (!chosenOptions.Contains(choice))
            chosenOptions.Add(choice);
    }

    public static bool HasMadeChoice(string choice)
    {
        return chosenOptions.Contains(choice);
    }
}
