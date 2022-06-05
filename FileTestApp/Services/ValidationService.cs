namespace FileTestApp.Services;

public class ValidationService
{
    public void ValidateArguments(string[] args)
    {
        if (args.Length != 1)
        {
            throw new ArgumentException("Exactly one parameter (the file path) is required.");
        }
    }
}