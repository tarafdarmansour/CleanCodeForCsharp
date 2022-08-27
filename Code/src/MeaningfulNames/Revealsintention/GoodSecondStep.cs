namespace CleanCodeNotes.MeaningfulNames.RevealsIntention.GoodSecondStep;

public class Cell
{
    public bool isFlagged()
    {
        throw new NotImplementedException();
    }
}

public class boardGame
{
    public List<Cell> getFlaggedCells(List<Cell> gameBoard)
    {
        var flaggedCells = new List<Cell>();
        foreach (var cell in gameBoard)
            if (cell.isFlagged())
                flaggedCells.Add(cell);
        return flaggedCells;
    }
}