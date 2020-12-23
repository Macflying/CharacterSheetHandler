using FunctionalCSharp.Result;

using System;
using System.Collections.Generic;

namespace CharacterSheetHandler.Models.Vampire
{
    public class Physical : ValueObject<Physical>
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

        public static Result<Physical, PhysicalError> New(Level strength, Level dexterity, Level stamina)
        {
            if (strength == null)
                return Error<Physical, PhysicalError>.Value(PhysicalError.NoStrength);
            if (dexterity == null)
                return Error<Physical, PhysicalError>.Value(PhysicalError.NoDexterity);
            if (stamina == null)
                return Error<Physical, PhysicalError>.Value(PhysicalError.NoStamina);

            return Ok<Physical, PhysicalError>.Value(new Physical(strength, dexterity, stamina));
        }

        public override string ToString()
            => $"Strength: {Strength}, Dexterity: {Dexterity}, Stamina: {Stamina}";

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Strength;
            yield return Dexterity;
            yield return Stamina;
        }
    }

    public abstract class PhysicalError
    {
        public static NoStrengthError NoStrength =>
            new NoStrengthError();

        public static NoDexterityError NoDexterity =>
            new NoDexterityError();

        public static NoStaminaError NoStamina =>
            new NoStaminaError();
    }

    public class NoStrengthError : PhysicalError
    { }

    public class NoDexterityError : PhysicalError
    { }

    public class NoStaminaError : PhysicalError
    { }
}