using System;
using System.Collections.Generic;
using System.Text;

namespace CharacterSheetHandler.Models.CollectionExtensions
{
    /// <summary>
    /// Extension methods for <see cref="IList{T}"/>.
    /// </summary>
    public static class ListExtension
    {
        /// <summary>
        /// Adds the elements of the specified collection to the end of the <paramref name="source"/>.
        /// If the <paramref name="source"/> is an <see cref="List{T}"/> the <see cref="List{T}.AddRange(IEnumerable{T})"/> is used.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="collection">The collection whose elements should be added to the end of the <paramref name="source"/>.
        ///                          The collection itself cannot be null, but it can contain elements that are null, if type T is a reference type.</param>
        /// <exception cref="ArgumentNullException"/>
        public static void AddRange<T>(this IList<T> source, IEnumerable<T> collection)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            if (collection is null)
                throw new ArgumentNullException(nameof(collection));

            if (source is List<T> concreteList)
            {
                concreteList.AddRange(collection);
                return;
            }

            foreach (var element in collection)
                source.Add(element);
        }
    }
}
