using System.IO;
using FileTestApp.Services;
using NUnit.Framework;

namespace FileTestApp.Tests.Services;

[TestFixture]
public class FileServiceTests
{
    private readonly FileService _sut = new();
    private readonly string _testDataDirectoryPath = $"{System.Environment.CurrentDirectory}/Services/TestData/";

    [Test]
    public void When_GetOccurrencesOfFileNameInFileContent_and_file_does_not_exist_then_exception_is_thrown()
    {
        Assert.Throws( typeof(FileNotFoundException) , 
            () => _sut.GetOccurrencesOfFileNameInFileContent("fileName.txt"), 
            "The specified file does not exist: fileName.txt");
    }

    [Test]
    [TestCase("TestData.txt", 6)]
    [TestCase("TeД дstDataåäö.txt", 1)] 
    [TestCase("TestData.json", 1)]
    public void When_GetOccurrencesOfFileNameInFileContent_and_file_exits_then_the_correct_number_is_returned(string testFileName, int expectedNrOfOccurrences)
    {
        var result = _sut.GetOccurrencesOfFileNameInFileContent($"{_testDataDirectoryPath}{testFileName}");
        Assert.AreEqual(expectedNrOfOccurrences, result);
    }
}