namespace ClosingBraceComments;

public class Bad
{
    public static void main(string[] args)
    {
        using var textReader = new StreamReader("c:\\a.txt");
        string line;
        var lineCount = 0;
        var charCount = 0;
        var wordCount = 0;
        try
        {
            while ((line = textReader.ReadLine()) != null)
            {
                lineCount++;
                charCount += line.Length;
                var words = line.Split(" ");
                wordCount += words.Length;
            } //while

            Console.WriteLine("wordCount = " + wordCount);
            Console.WriteLine("lineCount = " + lineCount);
            Console.WriteLine("charCount = " + charCount);
        } // try
        catch (IOException e)
        {
            Console.WriteLine("Error:" + e.Message);
        } //catch
    } //main
}