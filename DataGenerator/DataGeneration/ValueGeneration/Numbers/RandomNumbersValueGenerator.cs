namespace DataGenerator.DataGeneration.ValueGeneration.Numbers;
public class RandomNumbersValueGenerator
{
    const string chars = "0123456789";

    public string Generate(int length)
    {
        Random random = new();

        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}
