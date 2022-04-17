using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace SAPP.Test.Domain.Repositories;

public interface IGenericRepository<T> where T : class
{
    Task<IList<T>> GetAll(CancellationToken cancellationToken);

    Task<IList<T>> GetByCondition(Expression<Func<T, bool>> condition, CancellationToken cancellationToken);

    Task Post(T entity, CancellationToken cancellationToken);

    void Delete(T entity);

    void Update(T entity);
}

