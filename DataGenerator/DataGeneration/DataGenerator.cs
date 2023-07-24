using DataGenerator.DataGeneration.ValueGeneration;
using DataGenerator.RequestParsing;

namespace DataGenerator.DataGeneration;
public class DataGenerator
{
    public async Task<DataResult> Generate(ParsingResult parsingResult)
    {
        Dictionary<RequestProperty,string[]> propertyDataList = new(parsingResult.Properties.Count);
        foreach (var prop in parsingResult.Properties)
        {
            propertyDataList.Add(prop, await GetValues(prop, parsingResult.ItemsCount));
        }

        return new DataResult
        {
            Data = propertyDataList
        };
    }

    private async Task<string[]> GetValues(RequestProperty property, int itemsCount)
    {
        if (property.Type == RequestPropertyType.String)
        {
            RandomLettersValueGenerator generator = new();
            string[] values = new string[itemsCount];
            for (int i = 0; i < itemsCount; i++)
            {
                values[i] = generator.Generate(15);
            }

            return values;
        }
        else if (property.Type == RequestPropertyType.Number)
        {
            RandomNumbersValueGenerator generator = new();
            string[] values = new string[itemsCount];
            for (int i = 0; i < itemsCount; i++)
            {
                values[i] = generator.Generate(15);
            }

            return values;
        }
        else if(property.Type == RequestPropertyType.FirstName) 
        {
            FirstNameValueGenerator generator = new();
            return await generator.Generate(itemsCount);
        }
        else if(property.Type == RequestPropertyType.LastName) 
        {
            LastNameValueGenerator generator = new();
            return await generator.Generate(itemsCount);
        }

        throw new NotImplementedException();
    }
}
