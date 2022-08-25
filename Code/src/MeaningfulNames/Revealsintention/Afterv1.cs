using System;
using System.Collections;

namespace CleanCodeNotes.MeaningfulNames.RevealsIntention.Afterv1;
public class boardGame
{
    const int STATUS_VALUE = 0;
    const int FLAGGED = 4;
    public List<int[]> getFlaggedCells(List<int[]> gameBoard)
    {
        List<int[]> flaggedCells = new List<int[]>();
        foreach (int[] cell in gameBoard)
            if (cell[STATUS_VALUE] == FLAGGED)
                flaggedCells.Add(cell);
        return flaggedCells;
    }
}



