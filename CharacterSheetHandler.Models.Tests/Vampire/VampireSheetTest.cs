using CharacterSheetHandler.Models.Vampire;


namespace CharacterSheetHandler.Models.Tests.Vampire
{
    public class VampireSheetTest
    {
        public void VampireSheetModel_Can_BeConstructed()
        {
            var vampireSheet = new VampireSheet();
        }

        public void VampireSheetModel_Can_BeConvertedToDTOs()
        {
            var vampireSheet = new VampireSheet();

            var dto = vampireSheet.ToDTO();
        }

        public void VampireSheetModel_Can_BeConstructedFromDTOs()
        {
            var dto = new DTOs.Vampire.VampireSheet();

            var vampireSheet = VampireSheet.FromDTO(dto);
        }
    }
}
