namespace MandatedComments;

public class Bad
{
    private List<CD> CDs;

    /// <summary>
    ///     Adding a new cd to cd list
    /// </summary>
    /// <param name="title">The title of the CD</param>
    /// <param name="author">The author of the CD</param>
    /// <param name="tracks">The number of tracks on the CD</param>
    /// <param name="durationInMinutes">The duration of the CD in minutes</param>
    public void addCD(string title, string author, int tracks, int durationInMinutes)
    {
        var cd = new CD();
        cd.Title = title;
        cd.Author = author;
        cd.Tracks = tracks;
        cd.Duration = durationInMinutes;
        CDs.Add(cd);
    }
}

public class CD
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Tracks { get; set; }
    public int Duration { get; set; }
}