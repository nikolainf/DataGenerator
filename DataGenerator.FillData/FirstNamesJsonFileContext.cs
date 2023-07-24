using Newtonsoft.Json;
using System.Linq;

namespace DataGenerator.FillData;
public class FirstNamesJsonFileContext
{
    private readonly string _fileName;

    public FirstNamesJsonFileContext(DataItemName dataItem) =>
        _fileName = Path.Combine(Utils.GetSolutionDirectory(), @$"DataGenerator\DataStore\PersonData\{dataItem}.json");

    public async Task<bool> AddNew(string[] data)
    {
        if(data == null)
        {
            throw new ArgumentNullException(nameof(data));
        }

        var existingData = await GetExistingData();
       
        if(existingData != null)
        {
            var unionData = data.Union(existingData);

            await SaveData(unionData);
        }
        else
        {
            await SaveData(data);
        }

        async Task<string[]?> GetExistingData()
        {
            bool isFileExist = File.Exists(_fileName);
            if (isFileExist)
            {
                var dataJson = await File.ReadAllTextAsync(_fileName);
                var dataFromFile = JsonConvert.DeserializeObject<string[]>(dataJson);

                return dataFromFile;
            }
            else
            {
                return null;
            }
        }

        async Task SaveData(IEnumerable<string> dataToSave)
        {
            if (!File.Exists(_fileName))
            {
                using (File.Create(_fileName))
                { }
            }

            var dataToSaveJson = JsonConvert.SerializeObject(dataToSave);

            await File.WriteAllTextAsync(_fileName, dataToSaveJson);

        }
        return true;
    }
}
