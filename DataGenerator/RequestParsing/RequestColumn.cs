namespace DataGenerator.RequestParsing;
public enum RequestPropertyType
{
    String,
    Number,
    FirstName,
    MaleFirstName,
    FemaleFirstName,
    LastName,
    MaleLastName,
    FemaleLastName
};

public record struct RequestProperty(string Name, RequestPropertyType Type);
