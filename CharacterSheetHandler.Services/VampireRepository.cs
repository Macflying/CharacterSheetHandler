using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CharacterSheetHandler.Models.Vampire;

using FunctionalCSharp.Result;

namespace CharacterSheetHandler.Services
{
    public class VampireRepository
    {
        private readonly JSonFileAccessLayer<DTOs.Vampire.VampireSheet> _dataAccessLayer = new JSonFileAccessLayer<DTOs.Vampire.VampireSheet>(_folder);
        private static readonly string _folder = Environment.CurrentDirectory + "/Vampires/";

        public void Create(VampireSheet entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            var dto = entity.ToDTO();
            var fileName = GetFileName(dto.Header.Player, dto.Header.Name);
            _dataAccessLayer.Create(dto, fileName);
        }

        public void Update(VampireSheet entity) => Create(entity);

        public void Delete(Name player, Name character)
        {
            var fileName = GetFileName(player.Value, character.Value);
            _dataAccessLayer.Delete(fileName);
        }

        public Result<VampireSheet, VampireSheetError> Get(Name player, Name character)
        {
            var fileName = GetFileName(player.Value, character.Value);
            var dto = _dataAccessLayer.Read(fileName);

            return dto.ToModel();
        }

        public IReadOnlyList<VampireSheet> GetAll()
        {
            return _dataAccessLayer
                .ReadAll()
                .Select(dto => dto.ToModel())
                .OfType<Ok<VampireSheet, VampireSheetError>>()
                .Select(model => (VampireSheet)model)
                .ToList();
        }

        private string GetFileName(string player, string character)
        {
            return new StringBuilder()
                .Append(player.Replace(' ', '-'))
                .Append('_')
                .Append(character.Replace(' ', '-'))
                .ToString();
        }
    }

    internal static class VampireSheetModelConversionExtension
    {
        public static Result<VampireSheet, VampireSheetError> ToModel(this DTOs.Vampire.VampireSheet vampireSheet)
        {
            var id = vampireSheet.Id;
            var header = new Header()
            {
                Name = (Ok<Name, NameError>)Name.New(vampireSheet.Header.Name),
                Player = (Ok<Name, NameError>)Name.New(vampireSheet.Header.Player)
            };
            return VampireSheet.New(id, header, null, null, null, null);
        }

        public static DTOs.Vampire.VampireSheet ToDTO(this VampireSheet vampireSheet)
        {
            if (vampireSheet is null)
                throw new ArgumentNullException(nameof(vampireSheet));

            return new DTOs.Vampire.VampireSheet()
            {
                Header = vampireSheet.Header.ToDTO(),
            };
        }

        private static DTOs.Vampire.Header ToDTO(this Header header)
        {
            if (header is null)
                throw new ArgumentNullException(nameof(header));

            return new DTOs.Vampire.Header()
            {
                Name = header.Name.Value,
                Player = header.Player.Value,
            };
        }
    }
}