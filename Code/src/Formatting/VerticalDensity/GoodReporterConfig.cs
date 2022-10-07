namespace VerticalDensity;

public class GoodReporterConfig
{
    private string m_className;
    private readonly List<Property> m_properties = new();

    public void addProperty(Property property)
    {
        m_properties.Add(property);
    }
}