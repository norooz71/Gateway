using Microsoft.EntityFrameworkCore;
using SAPP.Test.Domain.Entities.Test;
using SAPP.Test.Domain.Repositories.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SAPP.Test.Persistance.Repositories;

    internal sealed class TestParentRepository : ITestParentRepository
    {
        private readonly RepositoryDbContext _repositoryDbContext;

        public TestParentRepository(RepositoryDbContext repositoryDbContext)
        {
            _repositoryDbContext = repositoryDbContext;
        }

        public async Task<IEnumerable<TestParent>> GetAllAsync(CancellationToken cancelationToken = default) =>
            await _repositoryDbContext.TestParents.ToListAsync(cancelationToken);


        public async Task<TestParent> GetById(int id, CancellationToken cancelationToken = default) =>
            await _repositoryDbContext.TestParents.SingleOrDefaultAsync(parent => parent.Id == id, cancelationToken);


        public async Task InsertAsync(TestParent test, CancellationToken cancelationToken)=>
            await _repositoryDbContext.TestParents.AddAsync(test, cancelationToken);


        public void Remove(TestParent testParent) =>
            _repositoryDbContext.Remove(testParent);
    }

