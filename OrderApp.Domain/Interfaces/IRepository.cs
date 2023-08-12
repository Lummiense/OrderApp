using OrderApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.Services.Interfaces
{
    /// <summary>
    /// Интерефейс репозитория.
    /// </summary>
    /// <typeparam name="T">Базовая сущность.</typeparam>
    public interface IRepository<T> where T : BaseEntity
    {        
        /// <summary>
        /// Получить сущность из базы данных по фильтру.
        /// </summary>
        /// <param name="filter">Фильтр поиска по базе данных.</param>
        /// <param name="includeProperties">Опция загрузки данных из связанных таблиц.</param>
        /// <returns>Сущность данного типа.</returns>
        Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includeProperties);
        /// <summary>
        /// Добавить в базу данных новый экземпляр сущности.
        /// </summary>
        /// <param name="entity">Базовая сущность.</param>
        Task AddAsync(T entity);
        /// <summary>
        /// Добавить в базу данных коллекцию экземпляров сущностей.
        /// </summary>
        /// <param name="entities">Коллекция экземпляров сущностей.</param>
        Task AddRangeAsync(IEnumerable<T> entities);
        /// <summary>
        /// Изменить данные сущности в базе данных.
        /// </summary>
        /// <param name="entity">Базовая сущность.</param>
        Task UpdateAsync(T entity);
        /// <summary>
        /// Удалить сущность из базы данных.
        /// </summary>
        /// <param name="filter">Параметры поиска сущности в базе данных.</param>
        Task RemoveAsync(Expression<Func<T, bool>> filter);
        /// <summary>
        /// Сохранить изменения в базе данных.
        /// </summary>
        Task SaveChangesAsync();
    }
}
