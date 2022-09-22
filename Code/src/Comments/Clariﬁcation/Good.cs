namespace Clariﬁcation;

public class Good
{
    public void testCompareTo()
    {
        var a = PathParser.Parse("PageA");
        var ab = PathParser.Parse("PageA.PageB");
        var b = PathParser.Parse("PageB");
        var aa = PathParser.Parse("PageA.PageA");
        var bb = PathParser.Parse("PageB.PageB");
        var ba = PathParser.Parse("PageB.PageA");
        assertTrue(a.compareTo(a) == 0); // a == a
        assertTrue(a.compareTo(b) != 0); // a != b
        assertTrue(ab.compareTo(ab) == 0); // ab == ab
        assertTrue(a.compareTo(b) == -1); // a < b
        assertTrue(aa.compareTo(ab) == -1); // aa < ab
        assertTrue(ba.compareTo(bb) == -1); // ba < bb
        assertTrue(b.compareTo(a) == 1); // b > a
        assertTrue(ab.compareTo(aa) == 1); // ab > aa
        assertTrue(bb.compareTo(ba) == 1); // bb > ba
    }

    private void assertTrue(bool condition)
    {
        throw new NotImplementedException();
    }
}