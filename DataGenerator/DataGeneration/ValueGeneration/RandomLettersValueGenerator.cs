namespace DataGenerator.DataGeneration.ValueGeneration;
public class RandomLettersValueGenerator
{
    const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZqwertyuiopasdfghjklzxcvbnm";

    public string Generate(int length)
    {
        Random random = new();
        
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}
