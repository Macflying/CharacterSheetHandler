using CharacterSheetHandler.Models.Vampire;
using FunctionalCSharp.Option;
using FunctionalCSharp.Result;

namespace CharacterSheetHandler.Models.Validations
{
    public class IntToLevelValidation : IValidationRule<int, LevelError>
    {
        private readonly int _maxLevel;

        public IntToLevelValidation(int maxLevel) => _maxLevel = maxLevel;

        public Option<LevelError> Validate(int value)
            => Level
            .New(_maxLevel, value)
            .MapError(e => Some<LevelError>.Value(e))
            .ReduceError(None.Value);
    }
}
