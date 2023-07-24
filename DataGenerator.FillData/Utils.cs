namespace DataGenerator.FillData;
internal static class Utils
{
   

    internal static string GetSolutionDirectory()
    {
        DirectoryInfo currentDirectory = new(Directory.GetCurrentDirectory());
        while (!currentDirectory.GetFiles("*.sln").Any())
        {
            currentDirectory = currentDirectory.Parent!;
        }

        return currentDirectory.FullName;
    }
}
