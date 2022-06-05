using FileTestApp.Services;

var fileService = new FileService();
var validationService = new ValidationService();

try
{
    validationService.ValidateArguments(args);
    Console.WriteLine($"The filename occurs {fileService.GetOccurrencesOfFileNameInFileContent(args[0])} times in the file content.");
}
catch (Exception e)
{
    Console.WriteLine($"Error: {e.Message}");
}