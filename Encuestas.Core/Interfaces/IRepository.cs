using Encuestas.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encuestas.Core.Interfaces
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetAll(IEnumerable<string> propiedadesIncluir);
        Task<T> GetById(int id);
        Task<T> Add(T entity);
        Task<bool> AddRange(IEnumerable<T> entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task DeleteRange(IEnumerable<T> entity);
        Task<T> GetById(int id, IEnumerable<string> propiedadesIncluir, string propertyName);
        Task<IEnumerable<T>> GetById(int id, string propertyName, IEnumerable<string> propiedadesIncluir = null);
        Task<T> GetByStringParameter(string propertyName, string propertyNameToFind, IEnumerable<string> propiedadesIncluir = null);
    }
}
