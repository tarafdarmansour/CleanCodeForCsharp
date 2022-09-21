namespace ExplanationofIntent;

public class Good
{
    private readonly List<string> names = new();

    public int compareTo(object o)
    {
        if (o.GetType() == typeof(WikiPagePath))
        {
            var p = (WikiPagePath)o;
            var compressedName = string.Join("", names);
            var compressedArgumentName = string.Join("", p.names);
            return compressedName.CompareTo(compressedArgumentName);
        }

        return 1; // we are greater because we are the right type.
    }
}