using System;
using System.Collections.Generic;
using System.Linq;

namespace CharacterSheetHandler.Models
{
    public abstract class ValueObject<T> : IEquatable<ValueObject<T>> where T : ValueObject<T>
    {
        protected abstract IEnumerable<object> GetEqualityComponents();

        public override bool Equals(object obj)
        {
            return Equals(obj as ValueObject<T>);
        }

        public override int GetHashCode()
        {
            return GetEqualityComponents()
                .Aggregate(1, (current, obj) =>
                {
                    // unchecked is ok here because we only need to guarrantee HashCode contract.
                    unchecked
                    {
                        return current * 23 + (obj?.GetHashCode() ?? 0);
                    }
                });
        }

        public bool Equals(ValueObject<T> other)
        {
            if (ReferenceEquals(other, null))
                return false;

            if (GetType() != other.GetType())
                return false;

            return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        }

        public static bool operator ==(ValueObject<T> a, ValueObject<T> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(ValueObject<T> a, ValueObject<T> b)
        {
            return !(a == b);
        }
    }
}