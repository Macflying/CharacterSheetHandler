using CharacterSheetHandler.Models.Tests.Vampire.Arbitraries;
using CharacterSheetHandler.Models.Vampire;

using FsCheck;
using FsCheck.Xunit;
using FunctionalCSharp.Result;

using Xunit;

namespace CharacterSheetHandler.Models.Tests.Vampire
{
    public class PhysicalTests
    {
        [Property(Arbitrary = new[] { typeof(LevelArbitrary)})]
        public Property CanCreate_Physical_From_Levels(Level strength, Level dexterity, Level stamina)
        {
            var physicalResult = Physical.New(strength, dexterity, stamina);

            Assert.IsAssignableFrom<Ok<Physical, PhysicalError>>(physicalResult);
            Physical physical = (Ok<Physical, PhysicalError>)physicalResult;

            return (physical.Strength == strength && physical.Dexterity == dexterity && physical.Stamina == stamina)
                .ToProperty();
        }

        [Property(Arbitrary = new[] { typeof(LevelArbitrary) })]
        public Property IfStrengthIsNull_Get_NoStrengthError(Level dexterity, Level stamina)
        {
            var physicalResult = Physical.New(null, dexterity, stamina);

            Assert.IsAssignableFrom<Error<Physical, PhysicalError>>(physicalResult);

            return (physicalResult is Error<Physical, PhysicalError> error
                && (PhysicalError)error is PhysicalError.NoStrengthError)
                .ToProperty();
        }

        [Property(Arbitrary = new[] { typeof(LevelArbitrary) })]
        public Property IfDexterityIsNull_Get_NoDexterityError(Level strength, Level stamina)
        {
            var physicalResult = Physical.New(strength, null, stamina);

            Assert.IsAssignableFrom<Error<Physical, PhysicalError>>(physicalResult);

            return (physicalResult is Error<Physical, PhysicalError> error
                && (PhysicalError)error is PhysicalError.NoDexterityError)
                .ToProperty();
        }

        [Property(Arbitrary = new[] { typeof(LevelArbitrary) })]
        public Property IfStaminaIsNull_Get_NoStaminaError(Level strength, Level dexterity)
        {
            var physicalResult = Physical.New(strength, dexterity, null);

            Assert.IsAssignableFrom<Error<Physical, PhysicalError>>(physicalResult);

            return (physicalResult is Error<Physical, PhysicalError> error
                && (PhysicalError)error is PhysicalError.NoStaminaError)
                .ToProperty();
        }
    }
}
