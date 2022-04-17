using Microsoft.EntityFrameworkCore;
using SAPP.Test.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SAPP.Test.Persistance.Repositories
{
    internal class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbSet<T> _context;

        public GenericRepository(RepositoryDbContext repositoryDbContext)
        {
            _context = repositoryDbContext.Set<T>();
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public async Task<IList<T>> GetAll(CancellationToken cancellationToken)=>
           await _context.AsNoTracking().ToListAsync(cancellationToken);

        public async Task<IList<T>> GetByCondition(Expression<Func<T, bool>> condition, CancellationToken cancellationToken) =>
            await _context.Where(condition).ToListAsync(cancellationToken);


        public async Task Post(T entity, CancellationToken cancellationToken) =>
            await _context.AddAsync(entity,cancellationToken);

        public void Update(T entity) =>
             _context.Update(entity);

    }
}
