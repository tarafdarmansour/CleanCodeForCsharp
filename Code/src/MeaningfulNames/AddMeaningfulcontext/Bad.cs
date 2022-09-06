namespace AddMeaningfulcontext;

public class Bad
{
    public double ExampleMethod()
    {
        var state = "Tehran";
        //Some code here
        var firstName = "Ali";
        //Some code here
        var lastName = "Ahmadi";
        //Some code here
        var street = "Avenue";
        return 0;
    }

    private void printGuessStatistics(char candidate, int count)
    {
        string number;
        string verb;
        string pluralModifier;
        if (count == 0)
        {
            number = "no";
            verb = "are";
            pluralModifier = "s";
        }
        else if (count == 1)
        {
            number = "1";
            verb = "is";
            pluralModifier = "";
        }
        else
        {
            number = Convert.ToString(count);
            verb = "are";
            pluralModifier = "s";
        }

        var guessMessage = string.Format(
            "There {0} {1} {2}{3}", verb, number, candidate, pluralModifier
        );
        Console.WriteLine(guessMessage);
    }
}