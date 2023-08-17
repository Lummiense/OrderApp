using Azure.Identity;
using Microsoft.EntityFrameworkCore;
using OrderApp.Domain.Data;
using OrderApp.Domain.Entities;
using OrderApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.Services.Implementation
{
    /// <summary>
    /// Generic-репорзиторий.
    /// </summary>
    /// <typeparam name="T">BaseEntity</typeparam>
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DataContext _dataContext;
        private readonly DbSet<T> _dbSet;
        public Repository(DataContext dataContext)
        {
            _dataContext = dataContext;
            _dbSet = _dataContext.Set<T>();
        }
        /// <summary>
        /// Добавление сущности в базу данных.
        /// </summary>
        /// <param name="entity">Базовая сущность.</param>          
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await SaveChangesAsync();            
        }
        /// <summary>
        /// Добавить коллекцию сущностей в базу данных.
        /// </summary>
        /// <param name="entities">Коллекция сущностей.</param>
        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            await SaveChangesAsync();
        }
        /// <summary>
        /// Получить список всех сущностей типа из базы данных.
        /// </summary>
        /// <returns>Коллекция сущностей.</returns>
        public async Task<IEnumerable<T>> GetAllAsync()
        {
           var entities =await _dbSet.AsNoTracking().ToListAsync();
            if(entities==null)
            {
                throw new ArgumentNullException("Сущности с такими параметрами не существуют");
            }
           return entities;
        }
        /// <summary>
        /// Получить сущность из базы данных с приминением фильтра.
        /// </summary>
        /// <param name="filter">Условие поиска в базе данных.</param>
        /// <param name="includeProperties">Опция загрузки данных из связанных таблиц.</param>
        /// <returns>Сущность данного типа.</returns>
        public async Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includeProperties)            
        {
            IQueryable<T> query = _dbSet.Where(filter);
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }
            var entity = await query.AsNoTracking().FirstOrDefaultAsync(filter);
            if (entity == null)
            {
                throw new ArgumentNullException("Сущности с такими параметрами не существует");
    }
            return entity;
        }
        /// <summary>
        /// Удалить экземпляр сущности из базы данных.
        /// </summary>
        /// <param name="filter">Условие поиска в базе данных.</param>
        /// <returns></returns>
        public async Task RemoveAsync(Expression<Func<T, bool>> filter)
        {
            var entity = await _dbSet.Where(filter).FirstOrDefaultAsync();
            if (entity == null) 
            {
              throw new ArgumentNullException("Сущности с такими параметрами не существует");
            }
            _dbSet.Remove(entity);
            await SaveChangesAsync();
        }
        /// <summary>
        /// Сохранить изменения в базе данных.
        /// </summary>        
        public async Task SaveChangesAsync()
        {
            await _dataContext.SaveChangesAsync();
        }
        /// <summary>
        /// Изменить данные сущности в базе данных.
        /// </summary>
        /// <param name="entity">Базовая сущность.</param>        
        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            #region Обработка конфликта параллелизма
            var saved = false;
            while (!saved)
            {
                try
                {
                    _dataContext.SaveChanges();
                    saved = true;
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    foreach (var entry in ex.Entries)
                    {
                        if (entry.Entity is T)
                        {
                            var proposedValues = entry.CurrentValues;
                            var databaseValues = entry.GetDatabaseValues();

                            foreach (var property in proposedValues.Properties)
                            {
                                var proposedValue = proposedValues[property];
                                var databaseValue = databaseValues[property];                                
                            }

                            entry.OriginalValues.SetValues(databaseValues);
                        }
                        else
                        {
                            throw new NotSupportedException(entry.Metadata.Name);
                        }
                    }
                }
            }
            #endregion
        }
    }
}
