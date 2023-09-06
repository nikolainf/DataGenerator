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
    FemaleLastName,
    /// <summary>
    /// Год за последние 100 лет
    /// </summary>
    LastHundredYears,
    /// <summary>
    /// Почтовый индекс
    /// </summary>
    PostCode
};

public record struct RequestProperty(string Name, RequestPropertyType Type);
