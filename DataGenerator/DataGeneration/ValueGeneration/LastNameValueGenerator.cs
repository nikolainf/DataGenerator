using DataGenerator.DataStore;

namespace DataGenerator.DataGeneration.ValueGeneration;
public class LastNameValueGenerator
{
    public async Task<string[]> Generate(int count)
    {
        DataItemJsonFileContext context = new(DataItemName.MaleLastNames);
        Random random = new();
        var data = await context.GetData();
        string[] result = new string[count];

        for (int i = 0; i < result.Length; i++)
        {
            result[i] = data[random.Next(data.Length)];
        }

        return result;
    }
}
