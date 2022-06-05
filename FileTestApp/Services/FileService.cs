using System.Text;
using System.Text.RegularExpressions;

namespace FileTestApp.Services;

public class FileService
{
    public int GetOccurrencesOfFileNameInFileContent(string filePath)
    {
        var fileInfo = new FileInfo(filePath);

        if (!fileInfo.Exists)
        {
            throw new FileNotFoundException($"The specified file does not exist: {filePath}");
        }

        //Assuming path should not be included in the string we are looking for (as opposed to test code behavior).
        //From specs: "its filename (minus the file extension)"
        var nameWithoutExtension = fileInfo.Name.Replace(fileInfo.Extension, string.Empty);

        //Assuming UTF8 encoded files.
        var fileContent = File.ReadAllText(filePath, Encoding.UTF8);
        
        return Regex.Matches(fileContent, nameWithoutExtension).Count();
    }
}