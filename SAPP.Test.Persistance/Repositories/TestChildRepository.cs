using Microsoft.EntityFrameworkCore;
using SAPP.Test.Domain.Entities.Test;
using SAPP.Test.Domain.Repositories.Test;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SAPP.Test.Persistance.Repositories
{
    internal sealed class TestChildRepository : ITestChildRepository
    {
        private readonly RepositoryDbContext _repositoryDbContext;

        public TestChildRepository(RepositoryDbContext repositoryDbContext)
        {
            _repositoryDbContext = repositoryDbContext;
        }
        public async Task<IEnumerable<TestChild>> GetAllByTestIdAsync(int testId, CancellationToken cancellationToken = default)
            => await _repositoryDbContext.TestChildren.Where(a => a.TestId == testId).ToListAsync(cancellationToken);

        public async Task<TestChild> GetByIdAsync(int id, CancellationToken cancellationToken = default)
            => await _repositoryDbContext.TestChildren.SingleOrDefaultAsync(t => t.Id == id, cancellationToken);


        public async Task Insert(TestChild testChild)
            =>await _repositoryDbContext.TestChildren.AddAsync(testChild);

        public void Remove(TestChild testChild)
            => _repositoryDbContext.TestChildren.Remove(testChild);
    }
}
