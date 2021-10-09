using FluentAssertions;
using TopraqShop.Framework.Base.Application;
using Xunit;

namespace TopraqShop.Framework.Base.Tests.Unit.Application
{
    public class OperationResultTests
    {
        [Fact]
        public void Succeeded_ShouldReturnTrue_WhenItCalled()
        {
            var operationResult = new OperationResult();
            var succeeded = operationResult.Succeeded();

            succeeded.IsSucceeded.Should().BeTrue();
            succeeded.Message.Should().Be("Operation has done successfully");
        }

        [Fact]
        public void Failed_ShouldReturnFalse_WhenItCalled()
        {
            var operationResult = new OperationResult();
            var succeeded = operationResult.Failed("test message");

            succeeded.IsSucceeded.Should().BeFalse();
            succeeded.Message.Should().Be("test message");
        }
    }
}