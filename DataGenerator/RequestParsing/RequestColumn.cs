namespace DataGenerator.RequestParsing;
public enum RequestPropertyType
{
    String,
    Number
};

public record struct RequestProperty(string Name, RequestPropertyType Type);
