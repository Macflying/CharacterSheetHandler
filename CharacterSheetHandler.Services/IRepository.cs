using System;
using System.Collections.Generic;

using CharacterSheetHandler.Models;

namespace CharacterSheetHandler.Services
{
    public interface IRepository<T> where T : Entity
    {
        T Get(Guid id);
        IEnumerable<T> GetAll();
        void Create(T entity);
        void Update(T entity);
        void Delete(Guid id);
    }
}
