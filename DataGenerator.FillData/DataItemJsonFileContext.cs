
using Newtonsoft.Json;

namespace DataGenerator.DataStore;
public class DataItemJsonFileContext
{
    private readonly string _fileName;

    public DataItemJsonFileContext(DataItemName dataItem) =>
        _fileName = Utils.GetFileNameFromPersonData(dataItem);

    public async Task<bool> AddNew(string[] data)
    {
        if(data == null)
        {
            throw new ArgumentNullException(nameof(data));
        }

        var existingData = await GetData();
       
        if(existingData != null)
        {
            var unionData = data.Union(existingData);

            await SaveData(unionData);
        }
        else
        {
            await SaveData(data);
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

    public async Task<string[]?> GetData()
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
}
