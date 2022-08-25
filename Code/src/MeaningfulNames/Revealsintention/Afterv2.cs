using System;
using System.Collections;

namespace CleanCodeNotes.MeaningfulNames.RevealsIntention.Afterv2;
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
        List<Cell> flaggedCells = new List<Cell>();
        foreach (Cell cell in gameBoard)
            if (cell.isFlagged())
                flaggedCells.Add(cell);
        return flaggedCells;
    }
}


