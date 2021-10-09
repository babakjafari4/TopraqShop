using FluentAssertions;
using TopraqShop.Framework.Base.Application;
using Xunit;

namespace TopraqShop.Framework.Base.Tests.Unit.Application
{
    public class GenerateSlugTests
    {
        [Theory]
        [InlineData("new test one", "new-test-one")]
        [InlineData("new test one and (paranthesis)", "new-test-one-and-paranthesis")]
        public void ToSlug_ShouldReturnCorrectedVersion_WhenCalled(string input, string expected)
        {
            input.ToSlug().Should().Be(expected);
        }
    }
}