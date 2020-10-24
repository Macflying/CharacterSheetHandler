using FunctionalCSharp.Result;
using System;
using System.Collections.Generic;

namespace CharacterSheetHandler.Models.Vampire
{
    public class Physical : IEquatable<Physical>
    {
        public Level Strength { get; }
        public Level Dexterity { get; }
        public Level Stamina { get; }

        public Physical(Level strength, Level dexterity, Level stamina)
        {
            Strength = strength;
            Dexterity = dexterity;
            Stamina = stamina;
        }

        public static Result<Physical, PhysicalError>New(Level strength, Level dexterity, Level stamina)
        {
            if (strength == null)
                return Error<Physical, PhysicalError>.Value(PhysicalError.NoStrength);
            if (dexterity == null)
                return Error<Physical, PhysicalError>.Value(PhysicalError.NoDexterity);
            if (stamina == null)
                return Error<Physical, PhysicalError>.Value(PhysicalError.NoStamina);

            return Ok<Physical, PhysicalError>.Value(new Physical(strength, dexterity, stamina));
        }

        public override bool Equals(object obj) =>
            Equals(obj as Physical);

        public bool Equals(Physical other)
        {
            return other != null &&
                   EqualityComparer<Level>.Default.Equals(Strength, other.Strength) &&
                   EqualityComparer<Level>.Default.Equals(Dexterity, other.Dexterity) &&
                   EqualityComparer<Level>.Default.Equals(Stamina, other.Stamina);
        }

        public override int GetHashCode() =>
            HashCode.Combine(Strength, Dexterity, Stamina);

        public override string ToString()
            => $"Strength: {Strength}, Dexterity: {Dexterity}, Stamina: {Stamina}";

        public static bool operator ==(Physical left, Physical right) =>
            EqualityComparer<Physical>.Default.Equals(left, right);

        public static bool operator !=(Physical left, Physical right) =>
            !(left == right);
    }

    public abstract class PhysicalError
    {
        private PhysicalError()
        { }

        public static NoStrengthError NoStrength =>
            new NoStrengthError();
        public class NoStrengthError : PhysicalError
        { }

        public static NoDexterityError NoDexterity =>
            new NoDexterityError();
        public class NoDexterityError : PhysicalError
        { }

        public static NoStaminaError NoStamina =>
            new NoStaminaError();
        public class NoStaminaError : PhysicalError
        { }
    }
}