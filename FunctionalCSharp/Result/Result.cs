
namespace FunctionalCSharp.Result
{
    /// <summary>
    /// Wrap either a success or an error.
    /// </summary>
    /// <typeparam name="TSuccess">The success' type.</typeparam>
    /// <typeparam name="TError">The error's type.</typeparam>
    public abstract class Result<TSuccess, TError>
    {
        internal Result()
        { }

        public static implicit operator Result<TSuccess, TError>(TSuccess ok) =>
            Ok<TSuccess, TError>.Value(ok);

        public static implicit operator Result<TSuccess, TError>(TError error) =>
            Error<TSuccess, TError>.Value(error);
    }
}
