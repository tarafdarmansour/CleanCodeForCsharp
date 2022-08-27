namespace CleanCodeNotes.MeaningfulNames.RevealsIntention.GoodFirstStep;

public class GoodFirstStep
{
    private const int STATUS_VALUE = 0;
    private const int FLAGGED = 4;

    public List<int[]> getFlaggedCells(List<int[]> gameBoard)
    {
        var flaggedCells = new List<int[]>();
        foreach (var cell in gameBoard)
            if (cell[STATUS_VALUE] == FLAGGED)
                flaggedCells.Add(cell);
        return flaggedCells;
    }
}