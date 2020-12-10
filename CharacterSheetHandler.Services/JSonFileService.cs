using System;
using System.Text;
using System.Text.Json;
using System.IO;

namespace CharacterSheetHandler.Services
{
    public class JSonFileService<TEntity>
    {
        private static JsonSerializerOptions SerializerOptions => new JsonSerializerOptions()
        {
            WriteIndented = true,
        };

        public void Create(TEntity entity, string fileName)
        {
            var entityAsText = JsonSerializer.Serialize(entity, SerializerOptions);
            File.WriteAllText(fileName, entityAsText, Encoding.UTF8);
        }

        public TEntity Read(string fileName)
        {
            var entityAsText = File.ReadAllText(fileName, Encoding.UTF8);
            return JsonSerializer.Deserialize<TEntity>(entityAsText, SerializerOptions);
        }
    }
}
