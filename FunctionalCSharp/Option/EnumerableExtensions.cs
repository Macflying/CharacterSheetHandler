using System;
using System.Collections.Generic;
using System.Linq;

namespace FunctionalCSharp.Option
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Returns the <paramref name="sequence"/> whith the element transformed and filtered by <paramref name="map"/> function.
        /// Only element of type Some will be reduced into the output sequence.
        /// </summary>
        /// <typeparam name="T">Input sequence contained type.</typeparam>
        /// <typeparam name="TResult">Output sequence contained type.</typeparam>
        /// <param name="sequence">The sequence to transform and filter.</param>
        /// <param name="map">A fonction thant will transform and filter the elements of input sequence.</param>
        /// <exception cref="ArgumentNullException"/>
        public static IEnumerable<TResult> SelectOptional<T, TResult>(
            this IEnumerable<T> sequence, Func<T, Option<TResult>> map)
        {
            if (sequence is null)
                throw new ArgumentNullException(nameof(sequence));

            if (map is null)
                throw new ArgumentNullException(nameof(map));

            return sequence
                .Select(map)
                .OfType<Some<TResult>>()
                .Select(some => some.Reduce(() => throw new InvalidOperationException($"{nameof(SelectOptional)}: Some should never have to reduce a None value.")));
        }
    }
}
