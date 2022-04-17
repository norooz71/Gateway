using SAPP.Test.Domain.Repositories;
using SAPP.Test.Persistance.Repositories;
using System.Threading;
using System.Threading.Tasks;

public class UnitOfWork : IUnitOfWork
{
    private readonly RepositoryDbContext _repositoryDbContext;

    public UnitOfWork(RepositoryDbContext repositoryDbContext)
    {
        this._repositoryDbContext = repositoryDbContext;
    }

    public IGenericRepository<T> GetRepository<T>() where T : class =>
        new GenericRepository<T>(_repositoryDbContext);
    

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)=>
        await _repositoryDbContext.SaveChangesAsync(cancellationToken);
    
}

