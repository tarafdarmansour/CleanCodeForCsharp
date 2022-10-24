namespace WriteYourTry_Catch_FinallyStatementFirst;

public class UnitTest1
{
    [Fact]
    public void retrieveSectionShouldThrowOnInvalidFileName()
    {
        Action act = () => retrieveSection("invalid - file");
        var exception = Assert.Throws<StorageException>(act);
        //The thrown exception can be used for even more detailed assertions.
        Assert.Equal("retrieval error", exception.Message);
    }

    public List<RecordedGrip> retrieveSection(string sectionName)
    {
        try
        {
            StreamReader stream = new(sectionName);
            stream.Close();
        }
        catch (FileNotFoundException e)
        {
            throw new StorageException("retrieval error");
        }

        return new List<RecordedGrip>();
    }
}

public class StorageException : Exception
{
    public StorageException(string s) : base(s)
    {
    }
}