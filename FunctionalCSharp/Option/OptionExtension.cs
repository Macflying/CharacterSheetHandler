using System;

namespace FunctionalCSharp.Option
{
    public static class OptionExtension
    {
        /// <summary>
        /// Filter the <paramref name="value"/> with a <paramref name="predicate"/>.
        /// Will return <see cref="Some{T}"/> if the value passes the predicate, <see cref="None{T}"/> otherwise.
        /// </summary>
        /// <typeparam name="T">Value's wrapped type.</typeparam>
        /// <param name="value">The value to filter.</param>
        /// <param name="predicate">The operation to filter the value. If it returns true then <see cref="Some{T}"/> is returned, <see cref="None{T}"/> otherwise.</param>
        public static Option<T> When<T>(this T value, Func<T, bool> predicate)
        {
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));

            return predicate(value) ? (Option<T>)value : None.Value;
        }
    }
}
