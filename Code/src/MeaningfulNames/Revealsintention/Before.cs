namespace CleanCodeNotes.MeaningfulNames.RevealsIntention.Before;

public class boardGame
{

    public List<int[]> getThem(List<int[]> theList)
    {
        List<int[]> list1 = new List<int[]>();
        foreach (var item in theList)
            if (item[0] == 4)
                list1.Add(item);
        return list1;
    }
}

