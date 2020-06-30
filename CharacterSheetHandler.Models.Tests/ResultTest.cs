using FsCheck;
using FsCheck.Xunit;

using System;

using Xunit;

namespace CharacterSheetHandler.Models.Tests
{
    public class ResultTest
    {
        [Fact]
        public void Ok_Is_Result()
        {
            Assert.IsAssignableFrom<Result<int, string>>(Ok.Value<int, string>(5));
        }

        [Fact]
        public void Error_Is_Result()
        {
            Assert.IsAssignableFrom<Result<int, string>>(Error.Value<int, string>("Error"));
        }

        [Property]
        public Property IfOKHodlsValue_CanRetrieveIt(int value)
        {
            Result<decimal, Guid> rslt = Ok.Value<decimal, Guid>(value);
            return (rslt is Result<decimal, Guid>.Ok ok && ok == value).ToProperty();
        }

        [Property]
        public Property IfErrorHodlsValue_CanRetrieveIt(string value)
        {
            Result<DateTime, string> rslt = Error.Value<DateTime, string>(value);
            return (rslt is Result<DateTime, string>.Error error && error == value).ToProperty();
        }
    }
}
