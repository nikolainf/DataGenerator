using DataGenerator.DataStore;

namespace DataGenerator.DataGeneration.ValueGeneration;
public class FirstNameValueGenerator
{
    public async Task<string[]> Generate(int count)
    {
        DataItemJsonFileContext context = new(DataItemName.MaleFirstNames);
        Random random = new();
        var maleFirstnames = await context.GetData();
        string[] result = new string[count];

        for(int i = 0; i < result.Length; i++) 
        {
            result[i] = maleFirstnames[random.Next(maleFirstnames.Length)];
        }

        return result;
    }
}
