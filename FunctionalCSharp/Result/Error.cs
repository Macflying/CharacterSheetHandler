
namespace FunctionalCSharp.Result
{
    /// <summary>
    /// Wrap an Error.
    /// </summary>
    /// <typeparam name="TSuccess">The success' type.</typeparam>
    /// <typeparam name="TError">The error's type.</typeparam>
    public class Error<TSuccess, TError> : Result<TSuccess, TError>
    {
        private TError _content;

        private Error(TError value) => _content = value;

        /// <summary>
        /// Create an Error represented by <paramref name="error"/> value.
        /// </summary>
        /// <param name="error">The error's representation.</param>
        public static Result<TSuccess, TError> Value(TError error)
            => new Error<TSuccess, TError>(error);

        public static implicit operator TError(Error<TSuccess, TError> error)
            => error._content;
    }
}
