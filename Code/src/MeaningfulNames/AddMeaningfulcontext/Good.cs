namespace AddMeaningfulcontext;

public class Good
{
    public double ExampleMethod()
    {
        var companyState = "Tehran";
        //Some code here
        var userFirstName = "Ali";
        //Some code here
        var customerLastName = "Ahmadi";
        //Some code here
        var addressStreet = "Avenue";


        return 0;
    }
}

public class GuessStatisticsMessage
{
    private string number;
    private string pluralModifier;
    private string verb;

    public string make(char candidate, int count)
    {
        createPluralDependentMessageParts(count);
        return string.Format(
            "There {0} {1} {2}{3}",
            verb, number, candidate, pluralModifier);
    }

    private void createPluralDependentMessageParts(int count)
    {
        if (count == 0)
            thereAreNoLetters();
        else if (count == 1)
            thereIsOneLetter();
        else
            thereAreManyLetters(count);
    }

    private void thereAreManyLetters(int count)
    {
        number = Convert.ToString(count);
        verb = "are";
        pluralModifier = "s";
    }

    private void thereIsOneLetter()
    {
        number = "1";
        verb = "is";
        pluralModifier = "";
    }

    private void thereAreNoLetters()
    {
        number = "no";
        verb = "are";
        pluralModifier = "s";
    }
}