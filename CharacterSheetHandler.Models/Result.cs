using System;
using System.Collections.Generic;
using System.Text;

namespace CharacterSheetHandler.Models
{
    public abstract class Result<TSuccess, TError>
    {
        private Result()
        { }

        public class Ok : Result<TSuccess, TError>
        {
            private TSuccess _content;

            public Ok(TSuccess value) => _content = value;

            public static implicit operator TSuccess(Ok ok) => ok._content;
        }

        public class Error : Result<TSuccess, TError>
        {
            private TError _content;

            public Error(TError value) => _content = value;

            public static implicit operator TError(Error error) => error._content;
        }
    }

    public static class Ok
    {
        public static Result<TSuccess, TError> Value<TSuccess, TError>(TSuccess value)
            => new Result<TSuccess, TError>.Ok(value);
    }

    public static class Error
    {
        public static Result<TSuccess, TError> Value<TSuccess, TError>(TError error)
            => new Result<TSuccess, TError>.Error(error);
    }
}
