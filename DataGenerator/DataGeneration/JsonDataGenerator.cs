using Newtonsoft.Json.Linq;

namespace DataGenerator.DataGeneration;
public class JsonDataGenerator
{
    public string Generate(DataResult data)
    {
        JArray jArray =
            new(
                Enumerable.Range(0, data.Data.First().Value.Length).Select(number =>
                new JObject(
                    (from prop in data.Data
                    select new JProperty(prop.Key.Name, prop.Value[number])
                    ).ToArray()
                    )
                ));

        return jArray.ToString();

    }
}
