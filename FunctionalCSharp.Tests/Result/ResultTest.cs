using FsCheck;
using FsCheck.Xunit;
using FunctionalCSharp.Result;
using System;

using Xunit;

namespace FunctionalCSharp.Tests.Result
{
    public class ResultTest
    {
        [Fact]
        public void Ok_Is_Result()
        {
            Assert.IsAssignableFrom<Result<int, string>>(Ok<int, string>.Value(5));
        }

        [Fact]
        public void Error_Is_Result()
        {
            Assert.IsAssignableFrom<Result<int, string>>(Error<int, string>.Value("Error"));
        }

        [Property]
        public Property IfOKHoldsValue_CanRetrieveIt(int value)
        {
            Result<decimal, Guid> rslt = Ok<decimal, Guid>.Value(value);
            return (rslt is Ok<decimal, Guid> ok && ok == value).ToProperty();
        }

        [Property]
        public Property IfErrorHoldsValue_CanRetrieveIt(NonNull<string> value)
        {
            Result<DateTime, string> rslt = Error<DateTime, string>.Value(value.Get);
            return (rslt is Error<DateTime, string> error && error == value.Get).ToProperty();
        }
    }
}
