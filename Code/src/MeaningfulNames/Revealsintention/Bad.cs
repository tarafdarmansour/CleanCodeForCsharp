namespace CleanCodeNotes.MeaningfulNames.RevealsIntention.Bad;

public class boardGame
{
    public List<int[]> getThem(List<int[]> theList)
    {
        var list1 = new List<int[]>();
        foreach (var item in theList)
            if (item[0] == 4)
                list1.Add(item);
        return list1;
    }
}