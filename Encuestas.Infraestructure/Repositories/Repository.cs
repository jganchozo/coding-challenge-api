using Encuestas.Core.Interfaces;
using Encuestas.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Encuestas.Infraestructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly EncuestasContext _context;

        public Repository(EncuestasContext context)
        {
            _context = context;
        }

        public async Task<T> Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> AddRange(IEnumerable<T> entity)
        {
            await _context.Set<T>().AddRangeAsync(entity);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetById(int id, string propertyName, IEnumerable<string> propiedadesIncluir = null)
        {
            var query = _context.Set<T>().AsQueryable();

            if (propiedadesIncluir is not null)
            {
                foreach (var propiedad in propiedadesIncluir)
                {
                    query = query.Include(propiedad);
                }
            }

            var parameter = Expression.Parameter(typeof(T), "x");
            var property = Expression.Property(parameter, propertyName);
            var constant = Expression.Constant(id);
            var equals = Expression.Equal(property, constant);
            var lambda = Expression.Lambda<Func<T, bool>>(equals, parameter);

            var resultados = await query.Where(lambda).ToListAsync();

            return resultados;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAll(IEnumerable<string> propiedadesIncluir)
        {
            var query = _context.Set<T>().AsQueryable();

            foreach (var propiedad in propiedadesIncluir)
            {
                query = query.Include(propiedad);
            }

            var resultados = await query.ToListAsync();

            return resultados;
        }

        public async Task Update(T entity)
        {
            _context.Set<T>().Update(entity);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteRange(IEnumerable<T> entity)
        {
            _context.Set<T>().RemoveRange(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T> GetById(int id, IEnumerable<string> propiedadesIncluir, string propertyName)
        {
            var query = _context.Set<T>().AsQueryable();

            foreach (var propiedad in propiedadesIncluir)
            {
                query = query.Include(propiedad);
            }

            var parameter = Expression.Parameter(typeof(T), "x");
            var property = Expression.Property(parameter, propertyName);
            var constant = Expression.Constant(id);
            var equals = Expression.Equal(property, constant);
            var lambda = Expression.Lambda<Func<T, bool>>(equals, parameter);

            var resultados = await query.Where(lambda).FirstOrDefaultAsync();

            return resultados;
        }

        public async Task<T> GetByStringParameter(string propertyName, string propertyNameToFind, IEnumerable<string> propiedadesIncluir = null)
        {
            var query = _context.Set<T>().AsQueryable();

            if (propiedadesIncluir is not null)
            {
                foreach (var propiedad in propiedadesIncluir)
                {
                    query = query.Include(propiedad);
                } 
            }

            var parameter = Expression.Parameter(typeof(T), "x");
            var property = Expression.Property(parameter, propertyName);
            var constant = Expression.Constant(propertyNameToFind);
            var equals = Expression.Equal(property, constant);
            var lambda = Expression.Lambda<Func<T, bool>>(equals, parameter);

            var resultados = await query.Where(lambda).FirstOrDefaultAsync();

            return resultados;
        }
    }
}
