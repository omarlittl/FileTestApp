using System;
using FileTestApp.Services;
using NUnit.Framework;

namespace FileTestApp.Tests.Services;

[TestFixture]
public class ValidationServiceTests
{
    private readonly ValidationService _sut = new();
    private const string ARGUMENT_ERROR_MESSAGE = "Exactly one parameter (the file path) is required.";
    
    [Test]
    public void ValidateArguments_throws_ArgumentException_when_args_length_is_not_1()
    {
        Assert.Throws( typeof(ArgumentException), () => _sut.ValidateArguments(Array.Empty<string>()), ARGUMENT_ERROR_MESSAGE);
        Assert.Throws( typeof(ArgumentException), () => _sut.ValidateArguments(new []{"test", "test"}), ARGUMENT_ERROR_MESSAGE);
        Assert.DoesNotThrow(() => _sut.ValidateArguments(new []{"test"}));
    }
}