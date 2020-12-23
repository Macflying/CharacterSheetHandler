using System.Text;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace CharacterSheetHandler.Services
{
    internal class JSonFileAccessLayer<TEntity>
    {
        private readonly string _folder;

        public JSonFileAccessLayer(string folder)
        {
            if (string.IsNullOrWhiteSpace(folder))
                throw new System.ArgumentException($"'{nameof(folder)}' cannot be null or whitespace", nameof(folder));

            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            _folder = folder;
        }

        private static JsonSerializerOptions SerializerOptions => new JsonSerializerOptions()
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };

        public void Create(TEntity entity, string fileName)
        {
            var entityAsText = Serialize(entity);
            File.WriteAllText(_folder + fileName, entityAsText, Encoding.UTF8);
        }

        public TEntity Read(string fileName)
        {
            var entityAsText = File.ReadAllText(_folder + fileName, Encoding.UTF8);
            return Deserialize(entityAsText);
        }

        public void Delete(string fileName)
        {
            File.Delete(_folder + fileName);
        }

        public IReadOnlyList<TEntity> ReadAll()
        {
            return Directory
                .GetFiles(_folder)
                .Select(file => File.ReadAllText(file))
                .Select(Deserialize)
                .ToList();
        }

        private static string Serialize(TEntity entity)
            => JsonSerializer.Serialize(entity, SerializerOptions);

        private static TEntity Deserialize(string entityAsText)
            => JsonSerializer.Deserialize<TEntity>(entityAsText, SerializerOptions);
    }
}