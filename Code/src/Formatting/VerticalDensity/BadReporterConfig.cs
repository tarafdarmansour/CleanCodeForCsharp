namespace VerticalDensity;

public class BadReporterConfig
{
    /**
     * The properties of the reporter listener
     */
    private readonly List<Property> m_properties = new();

    /**
     * The class name of the reporter listener
     */
    private string m_className;

    public void addProperty(Property property)
    {
        m_properties.Add(property);
    }
}