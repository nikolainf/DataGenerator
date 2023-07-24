namespace DataGenerator.DataStore;
public static class Utils
{
    public static string GetSolutionDirectory()
    {
        DirectoryInfo currentDirectory = new(Directory.GetCurrentDirectory());
        while (!currentDirectory.GetFiles("*.sln").Any())
        {
            currentDirectory = currentDirectory.Parent!;
        }

        return currentDirectory.FullName;
    }

    public static string GetFileNameFromPersonData(DataItemName dataItemName)
    {
        return Path.Combine(GetSolutionDirectory(), @$"DataGenerator\DataStore\PersonData\{dataItemName}.json");
    }
}
