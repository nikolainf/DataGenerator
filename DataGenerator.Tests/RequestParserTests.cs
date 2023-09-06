using DataGenerator.RequestParsing;
using FluentAssertions;

namespace DataGenerator.Tests;

public class RequestParserTests
{
    [Fact]
    public void Simple_Parse()
    {
        RequestParser parser = new("firstname lastname birthdate year postcode zipcode");

        var result = parser.Parse()!;

        result.Properties.Should().BeEquivalentTo(new[]
        {
            new RequestProperty("firstname", RequestPropertyType.FirstName),
            new RequestProperty("lastname", RequestPropertyType.LastName),
            new RequestProperty("birthdate", RequestPropertyType.String),
            new RequestProperty("year", RequestPropertyType.LastHundredYears),
            new RequestProperty("postcode", RequestPropertyType.PostCode),
            new RequestProperty("zipcode", RequestPropertyType.PostCode)
        });

    }

    [Fact]
    public void Simple_Parse_ItemsCountDefault()
    {
        RequestParser parser = new("firstname lastname birthdate");

        var result = parser.Parse()!;

        result.ItemsCount.Should().Be(100);
    }

    [Fact]
    public void Simple_Parse_ItemsCountEnd()
    {
        RequestParser parser = new("firstname lastname birthdate 250");

        var result = parser.Parse()!;

        result.ItemsCount.Should().Be(250);
    }

    [Fact]
    public void Simple_Parse_ItemsCountStart()
    {
        RequestParser parser = new("300 firstname lastname birthdate");

        var result = parser.Parse()!;

        result.ItemsCount.Should().Be(300);
    }
}